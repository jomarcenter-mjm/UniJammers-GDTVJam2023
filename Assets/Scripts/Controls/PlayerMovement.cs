using System.Collections;
using System.Collections.Generic;
using uj.input;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputReader inputReader;
    CharacterController charController;
    private bool isFirstPlay = false;

    Vector2 moveInput;

    [SerializeField] float moveSpeed = 5;

    private void Start()
    {
        inputReader = FindObjectOfType<InputReader>();
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        moveInput = inputReader.GetMoveInput();
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);

        charController.Move(moveSpeed * Time.deltaTime * movement);
    }
}
