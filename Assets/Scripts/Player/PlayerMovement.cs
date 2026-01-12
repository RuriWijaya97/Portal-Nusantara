using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] private InputActionReference moveAction;
    private CharacterController characterController;
    private Vector3 moveDirection;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController == null) return;
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        moveDirection = new Vector3(input.x, 0, input.y);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
