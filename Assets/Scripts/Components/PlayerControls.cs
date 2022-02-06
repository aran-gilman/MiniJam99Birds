using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float maxUpSpeed = 1.0f;
    public float maxDownSpeed = 2.0f;

    public int minY;
    public int maxY;

    public InputAction movement;

    public ScoreDisplay scoreDisplay;

    private Rigidbody2D rb;
    private Collider2D selfCollider;
    private Animator animator;

    private AudioSource audioPlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selfCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        audioPlayer = GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>();

        movement.performed += OnMovement;
        movement.canceled += OnMovement;
    }

    private void OnMovement(InputAction.CallbackContext ctx)
    {
        float dy = movement.ReadValue<float>();
        if (dy > 0)
        {
            //animator.SetTrigger("Flap");
            animator.SetInteger("Direction", 1);
            rb.velocity = dy * maxUpSpeed * Vector3.up;
        }
        else if (dy < -0.001f)
        {
            animator.SetInteger("Direction", -1);
            rb.velocity = dy * maxDownSpeed * Vector3.up;
        }
        else
        {
            animator.SetInteger("Direction", 0);
            rb.velocity = Vector3.zero;
        }
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
                if (col == null && !col.CompareTag("Coin"))
                {
                    continue;
                }
                scoreDisplay.IncrementScore();
                audioPlayer.PlayOneShot(col.GetComponent<SfxList>().SelectClip());
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
