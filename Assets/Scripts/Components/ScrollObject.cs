using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float scrollSpeed = 1.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        rb.velocity = scrollSpeed * Vector3.left;
    }
}
