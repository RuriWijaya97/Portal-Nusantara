using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementdupli : MonoBehaviour
{
    // bisa gerak apa nggak
    private bool canMove = true;

    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public float moveSpeed = 5f;

    [SerializeField] private InputActionReference moveAction;
    private CharacterController characterController;
    public CharacterController controller => characterController;
    private Vector3 moveDirection;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        if (moveAction != null) moveAction.action.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null) moveAction.action.Disable();
    }

    private void Update()
    {
        // kalau nggak bisa gerak maka skip
        if (!canMove) return;

        if (characterController == null) return;
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        moveDirection = new Vector3(input.x, 0, input.y);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
