using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text label;

    private int _fps = 0;
    private int _count = 0;
    private float _nextTime = 0;

    private void Start()
    {
        if (label == null)
            enabled = false;
    }

    private void Update()
    {
        _count++;
        if (_nextTime < Time.time)
        {
            _nextTime += 1;
            _fps = _count;
            _count = 0;
        }
        label.text = $"FPS: {1/Time.deltaTime:F1} (summ: {_fps})";
    }
}
