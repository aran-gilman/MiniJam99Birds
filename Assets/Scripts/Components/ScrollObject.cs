using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScrollObject : MonoBehaviour
{
    public float scrollSpeed = 1.0f;

    public bool autoReset = false;
    public float resetAtX = -100.0f;
    public float resetToX = 30.0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        transform.position = Vector3.zero;
        rb.velocity = scrollSpeed * Vector3.left;
    }

    private void Update()
    {
        if (transform.position.x < resetAtX)
        {
            transform.position = Vector3.right * resetToX;
        }
    }
}
