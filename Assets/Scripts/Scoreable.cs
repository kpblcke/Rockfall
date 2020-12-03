using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreable : MonoBehaviour
{
    public int value = 10;

    private void OnDestroy()
    {
        ScoreSystem.instance.addScore(value);
    }
}
