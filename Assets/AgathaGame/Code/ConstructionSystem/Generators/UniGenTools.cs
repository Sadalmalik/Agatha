using System.Collections.Generic;
using UnityEngine;

public enum PrefabsOrder
{
    Random, Ordered
}

public static class UniGenTools
{
    public static void Clear(Transform transform)
    {
        List<Transform> childs = new List<Transform>();
        foreach (Transform t in transform)
        {
            childs.Add(t);
        }
        foreach (Transform t in childs)
        {
            t.gameObject.SetActive(false);
            GameObject.DestroyImmediate(t.gameObject);
        }
        childs.Clear();
    }

    public static GameObject InstantiateRandomElement(GameObject[] prefabs)
    {
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        return prefab ? GameObject.Instantiate(prefab) : null;
    }

    public static GameObject InstantiateElement(PrefabsOrder order, GameObject[] prefabs, ref int index)
    {
        GameObject prefab = null;

        switch (order)
        {
            case PrefabsOrder.Random:
                prefab = prefabs[Random.Range(0, prefabs.Length)];
                break;

            case PrefabsOrder.Ordered:
                index++;
                prefab = prefabs[index % prefabs.Length];
                break;
        }

        return prefab ? GameObject.Instantiate(prefab) : null;
    }
}
