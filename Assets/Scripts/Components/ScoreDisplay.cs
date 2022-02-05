using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public int starsDisplayed = 3;
    public int iconSpacing = 18;

    public GameObject iconPrefab;
    public List<Sprite> starStages = new List<Sprite>();

    public void SetScore(int score)
    {
        int remainingScore = score;
        for (int i = 0; i < transform.childCount; i++)
        {
            Image childImage = transform.GetChild(i).GetComponent<Image>();
            if (remainingScore >= starStages.Count)
            {
                childImage.sprite = starStages[starStages.Count - 1];
                remainingScore -= starStages.Count;
            }
            else
            {
                childImage.sprite = starStages[remainingScore];
                remainingScore = 0;
            }
        }
    }

    private void Awake()
    {
        int x = 0;
        for (int i = 0; i < starsDisplayed; i++)
        {
            GameObject go = Instantiate(iconPrefab, transform);
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, x, rt.sizeDelta.x);
            x += iconSpacing;
        }
        SetScore(0);
    }
}
