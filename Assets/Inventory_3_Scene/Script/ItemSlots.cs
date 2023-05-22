using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ItemSlots : MonoBehaviour, IPointerClickHandler
{
    [Header("Item Data")]
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    [SerializeField] public int maxNumberOfItem;

    [Header("Item Slots")]
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    public Color itemColor = Color.white;
    [SerializeField] private Sprite emptySprite;

    [Header("Selected Slot")]
    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("GameCanvas").GetComponent<InventoryManager>();
    }

    private void Update() 
    {
        if(thisItemSelected && Input.GetKeyDown(KeyCode.Space))
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(false);
            thisItemSelected = false;  
        }
    }
    public int AddItem(string _itemName, int _quantity, Sprite _itemSprite)
    {
        if(isFull)
        {
            return quantity;
        }
        
        this.itemName = _itemName;
        this.itemSprite = _itemSprite;
        itemImage.sprite = _itemSprite;


        itemColor.a = 1.0f;
        itemImage.GetComponent<Image>().color = itemColor;
        
        this.quantity += _quantity;
        if(this.quantity >= maxNumberOfItem)
        {
            quantityText.text = maxNumberOfItem.ToString("n0");
            isFull = true;

            int extraItems = this.quantity - maxNumberOfItem;
            this.quantity = maxNumberOfItem;
            return extraItems;
        }

        quantityText.text = this.quantity.ToString("n0");

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Select the Slot
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Deselect the Slot
            OnRightClick();
        }
    }

    private void OnLeftClick()
    {
        if(thisItemSelected && this.quantity > 0)
        {
            inventoryManager.UseItem(itemName);
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();

            if(this.quantity <= 0)
            {
                EmptySlot();
            }
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
    }

    private void EmptySlot()
    {
        itemName = null;
        quantity = 0;
        itemSprite = null;
        quantityText.text = "";
        itemColor.a = 0f;
        itemImage.GetComponent<Image>().color = itemColor;
        itemImage.sprite = emptySprite;
    }

    public void OnRightClick()
    {
        GameObject itemToDrop = new GameObject (itemName);
        Item_Inventory3 newItem = itemToDrop.AddComponent<Item_Inventory3>();
        newItem.quantity = 1;
        newItem.itemName = itemName;
        newItem.itemSprite = itemSprite;

        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5;

        itemToDrop.AddComponent<BoxCollider>();
        itemToDrop.GetComponent<BoxCollider>().isTrigger = true;

        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(3.0f, 2.0f, 0);

        this.quantity -= 1;
        quantityText.text = this.quantity.ToString();

        if (this.quantity <= 0)
        {
            EmptySlot();
        }

    }
}
