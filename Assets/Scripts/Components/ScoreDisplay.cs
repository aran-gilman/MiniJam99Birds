using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public int maxCoinsDisplayed = 10;
    public int iconSpacing = 12;

    public GameObject iconPrefab;

    public void SetScore(int score)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i < score);
        }
    }

    private void Awake()
    {
        int x = 0;
        for (int i = 0; i < maxCoinsDisplayed; i++)
        {
            GameObject go = Instantiate(iconPrefab, transform);
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, x, rt.sizeDelta.x);
            x += iconSpacing;
            go.SetActive(false);
        }
    }
}
