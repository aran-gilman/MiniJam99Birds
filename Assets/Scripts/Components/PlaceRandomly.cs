using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaceRandomly : MonoBehaviour
{
    [Serializable]
    public class PrefabDefinition
    {
        public GameObject prefab;
        public int count;
    }
    public List<PrefabDefinition> prefabs = new List<PrefabDefinition>();

    public Vector2 min = new Vector2(0, -5);
    public Vector2 max = new Vector2(100, 5);

    private void OnEnable()
    {
        foreach (PrefabDefinition def in prefabs)
        {
            for (int i = 0; i < def.count; i++)
            {
                float dx = min.x + (max.x - min.x) * Random.value;
                float dy = min.y + (max.y - min.y) * Random.value;
                GameObject go = Instantiate(def.prefab, transform);
                go.transform.Translate(new Vector3(dx, dy, 0));

            }
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
