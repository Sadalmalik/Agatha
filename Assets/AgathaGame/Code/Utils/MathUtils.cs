using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtils
{
    public static float Damping(float value)
    {
        return 1 / (value + 1);
        //Mathf.Lerp(transform.position.y, origin.y, 1 / (value + 1));
    }
}
