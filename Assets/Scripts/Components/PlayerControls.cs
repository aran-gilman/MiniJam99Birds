using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float maxVerticalSpeed = 1.0f;
    public int score = 0;

    public int coinValue = 1;

    public int minY;
    public int maxY;

    public InputAction movement;

    public UnityEvent gameOver;

    public ScoreDisplay scoreDisplay;

    private Rigidbody2D rb;
    private Collider2D selfCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selfCollider = GetComponent<Collider2D>();

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
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, 0);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, 0);
        }
    }

    private void FixedUpdate()
    {
        List<Collider2D> results = new List<Collider2D>();
        if (selfCollider.OverlapCollider(new ContactFilter2D().NoFilter(), results) > 0)
        {
            foreach (Collider2D col in results)
            {
                if (col == null)
                {
                    continue;
                }    
                if (col.CompareTag("Coin"))
                {
                    score += coinValue;
                    scoreDisplay.SetScore(score);
                }
                else if (col.CompareTag("Skull"))
                {
                    gameOver.Invoke();
                }
                Destroy(col.gameObject);
            }
        }
    }

    private void OnEnable()
    {
        movement.Enable();
        transform.position = Vector3.right * transform.position.x;
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
