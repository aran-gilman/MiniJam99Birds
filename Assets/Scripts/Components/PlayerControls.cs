using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float maxVerticalSpeed = 1.0f;

    public InputAction movement;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement.performed += OnMovement;
        movement.canceled += OnMovement;
    }

    private void OnMovement(InputAction.CallbackContext ctx)
    {
        float dy = movement.ReadValue<float>();
        rb.velocity = dy * maxVerticalSpeed * Vector3.up;
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
