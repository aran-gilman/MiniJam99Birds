using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class ScrollObject : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public float endX = -110;

    public UnityEvent endReached = new UnityEvent();

    private Rigidbody2D rb;

    public void SetPosition(float x)
    {
        transform.position = Vector3.right * x;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = scrollSpeed * Vector3.left;
    }

    private void Update()
    {
        if (transform.position.x < endX)
        {
            endReached.Invoke();
        }
    }
}
