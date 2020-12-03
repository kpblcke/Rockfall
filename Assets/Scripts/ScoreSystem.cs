using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : Singleton<ScoreSystem> 
{
    [SerializeField]
    private Text scoretext;

    private int score;

    public void Reset()
    {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void addScore(int addScore)
    {
        score += addScore;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = score.ToString();
    }
}
