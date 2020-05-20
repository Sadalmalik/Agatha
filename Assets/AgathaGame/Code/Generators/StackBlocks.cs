using UnityEngine;

[ExecuteInEditMode]
public class StackBlocks : MonoBehaviour
{
#if UNITY_EDITOR
    public bool rebuild;
    public bool cleanup;

    [Space(10)]
    public int count;

    [Space(10)]
    public Vector3 offset;
    public Vector3 step;
    public Vector3 rotation;
    public Vector3 rotationStep;
    public Vector3 randomizeStepPower;
    public Vector3 randomizeRotationPower;

    [Space(10)]
    public GameObject[] prefabs;

    public PrefabsOrder order;
    public int index = 0;

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

    private void Rebuild()
    {
        UniGenTools.Clear(transform);

        for (int i = 0; i < count; i++)
        {
            var element = UniGenTools.InstantiateElement(order, prefabs, ref index);
            element.transform.SetParent(transform);

            element.transform.localPosition = offset + step * i + CreateRandomVector(randomizeStepPower);
            element.transform.localRotation =
                Quaternion.Euler(rotation + rotationStep * i) *
                Quaternion.Euler(CreateRandomVector(randomizeRotationPower));
        }
    }

    private Vector3 CreateRandomVector(Vector3 powers)
    {
        return new Vector3(
            Random.Range(-1f, 1f) * powers.x,
            Random.Range(-1f, 1f) * powers.y,
            Random.Range(-1f, 1f) * powers.z
            );
    }

#endif
}
