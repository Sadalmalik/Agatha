using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text label;

    private int count = 0;
    private float nextTime = 0;

    private void Start()
    {
        if (label == null)
            enabled = false;
    }

    private void Update()
    {
        count++;
        if (nextTime < Time.time)
        {
            nextTime += 1;
            label.text = "FPS: " + count;
            count = 0;
        }
    }
}
