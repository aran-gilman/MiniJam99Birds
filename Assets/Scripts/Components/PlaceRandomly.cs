using UnityEngine;

public class PlaceRandomly : MonoBehaviour
{
    public GameObject coin;
    public GameObject skull;

    public int coinCount = 100;
    public int skullCount = 25;

    public Vector2 min = new Vector2(0, -5);
    public Vector2 max = new Vector2(100, 5);

    private void OnEnable()
    {
        for (int i = 0; i < coinCount; i++)
        {
            float dx = min.x + (max.x - min.x) * Random.value;
            float dy = min.y + (max.y - min.y) * Random.value;
            GameObject go = Instantiate(coin, transform);
            go.transform.Translate(new Vector3(dx, dy, 0));
        }

        for (int i = 0; i < skullCount; i++)
        {
            float dx = min.x + (max.x - min.x) * Random.value;
            float dy = min.y + (max.y - min.y) * Random.value;
            GameObject go = Instantiate(skull, transform);
            go.transform.Translate(new Vector3(dx, dy, 0));
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
