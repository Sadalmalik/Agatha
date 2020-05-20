using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogTarget
{
    public abstract void LogTemp(string message);

    public abstract void LogInfo(string message);

    public abstract void LogWarning(string message);

    public abstract void LogError(string message);
}

public class DefaultLogTarget : LogTarget
{
    public override void LogTemp(string message)
    {
        Debug.Log(message);
    }

    public override void LogInfo(string message)
    {
        Debug.Log(message);
    }

    public override void LogWarning(string message)
    {
        Debug.LogWarning(message);
    }

    public override void LogError(string message)
    {
        Debug.LogError(message);
    }
}

public class ObservableLogTarget : LogTarget
{
    public event Action<string> logAll;

    public event Action<string> logTemp;

    public event Action<string> logInfo;

    public event Action<string> logWarning;

    public event Action<string> logError;

    public override void LogTemp(string message)
    {
        logAll?.Invoke(message);
        logTemp?.Invoke(message);
    }

    public override void LogInfo(string message)
    {
        logAll?.Invoke(message);
        logInfo?.Invoke(message);
    }

    public override void LogWarning(string message)
    {
        logAll?.Invoke(message);
        logWarning?.Invoke(message);
    }

    public override void LogError(string message)
    {
        logAll?.Invoke(message);
        logError?.Invoke(message);
    }
}

public static class Log
{
    private static bool emptyTargets_ = true;
    private static List<LogTarget> targets_;

    public static List<LogTarget> targets
    {
        get
        {
            if (targets_ == null)
                targets_ = new List<LogTarget>();
            return targets_;
        }
    }

    public static void AddDefaultTarget()
    {
        emptyTargets_ = false;
        targets.Add(new DefaultLogTarget());
    }

    public static void AddTarget<T>() where T : LogTarget, new()
    {
        emptyTargets_ = false;
        targets.Add(new T());
    }

    public static void AddTarget<T>(T target) where T : LogTarget
    {
        emptyTargets_ = false;
        targets.Add(target);
    }

    public static void Temp(string message, params object[] args)
    {
        if (emptyTargets_)
            Debug.LogError("Log targets not defined!");
        string messsage = "[TEMP] " + string.Format(message, args);
        foreach (var target in targets)
            target.LogTemp(messsage);
    }

    public static void Info(string message, params object[] args)
    {
        if (emptyTargets_)
            Debug.LogError("Log targets not defined!");
        string messsage = "[INFO] " + string.Format(message, args);
        foreach (var target in targets)
            target.LogInfo(messsage);
    }

    public static void Warning(string message, params object[] args)
    {
        if (emptyTargets_)
            Debug.LogError("Log targets not defined!");
        string messsage = "[WARNING] " + string.Format(message, args);
        foreach (var target in targets)
            target.LogWarning(messsage);
    }

    public static void Error(string message, params object[] args)
    {
        if (emptyTargets_)
            Debug.LogError("Log targets not defined!");
        string messsage = "[ERROR] " + string.Format(message, args);
        foreach (var target in targets)
            target.LogError(messsage);
    }
}
