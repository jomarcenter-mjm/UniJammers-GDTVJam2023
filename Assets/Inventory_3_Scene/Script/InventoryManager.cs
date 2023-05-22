using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemSlots[] itemSlot;
    public Items_SO[] items_SOs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseItem(string itemName)
    {
        for (int i = 0; i < items_SOs.Length; i++)
        {
            if(items_SOs[i].itemName == itemName)
            {
                items_SOs[i].UseItem();
            }
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite);

                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
