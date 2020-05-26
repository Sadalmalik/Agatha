using UnityEngine;

[ExecuteInEditMode]
public class MegaStack : MonoBehaviour
{
    public bool rebuild;
    public bool rebuildOnStart;
    public bool cleanup;

    [Space(10)]
    public int xCount;
    public int zCount;

    [Space(10)]
    public Vector3 stepXOffset;
    public Vector3 stepZOffset;

    [Space(10)]
    public GameObject[] prefabs;

    private void Start()
    {
        if (rebuildOnStart)
            Rebuild();
    }

#if UNITY_EDITOR

    private void Update()
    {
        if (rebuild)
        {
            rebuild = false;
            Rebuild();
        }
        if (cleanup)
        {
            cleanup = false;
            UniGenTools.Clear(transform);
        }
    }

#endif

    private void Rebuild()
    {
        UniGenTools.Clear(transform);

        for (int z = 0; z < zCount; z++)
            for (int x = 0; x < xCount; x++)
            {
                var element = UniGenTools.InstantiateRandomElement(prefabs);
                element.transform.SetParent(transform);

                element.transform.localPosition =
                    stepXOffset * x +
                    stepZOffset * z;
            }
    }
}
