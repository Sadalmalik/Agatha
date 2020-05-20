using System;
using UnityEngine;

public class UnityEvent : MonoBehaviour
{
    private static UnityEvent instance_;

    private static event Action OnUpdate_;

    private static event Action OnFixedUpdate_;

    private static event Action OnLateUpdate_;

    private static event Action OnNextUpdate_;

    private static event Action<bool> OnApplicationFocusChanged_;

    public static event Action OnUpdate
    {
        add { CheckInstance(); OnUpdate_ += value; }
        remove { CheckInstance(); OnUpdate_ -= value; }
    }

    public static event Action OnFixedUpdate
    {
        add { CheckInstance(); OnFixedUpdate_ += value; }
        remove { CheckInstance(); OnFixedUpdate_ -= value; }
    }

    public static event Action OnLateUpdate
    {
        add { CheckInstance(); OnLateUpdate_ += value; }
        remove { CheckInstance(); OnLateUpdate_ -= value; }
    }

    public static event Action OnNextUpdate
    {
        add { CheckInstance(); OnNextUpdate_ += value; }
        remove { CheckInstance(); OnNextUpdate_ -= value; }
    }

    public static event Action<bool> OnApplicationFocusChanged
    {
        add { CheckInstance(); OnApplicationFocusChanged_ += value; }
        remove { CheckInstance(); OnApplicationFocusChanged_ -= value; }
    }

    private static void CheckInstance()
    {
        if (instance_ == null)
        {
            GameObject o = new GameObject("DefaultUnityEvent");
            instance_ = o.AddComponent<UnityEvent>();
            GameObject.DontDestroyOnLoad(o);
        }
    }

    private void Start()
    {
        if (instance_ == null)
        {
            instance_ = this;
        }
        else
        {
            if (instance_ != this)
                this.enabled = false;
        }
    }

    private void Update()
    {
        OnUpdate_?.Invoke();
        OnNextUpdate_?.Invoke();
        OnNextUpdate_ = null;
    }

    private void FixedUpdate()
    {
        OnFixedUpdate_?.Invoke();
    }

    private void LateUpdate()
    {
        OnLateUpdate_?.Invoke();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        OnApplicationFocusChanged_?.Invoke(hasFocus);
    }
}
