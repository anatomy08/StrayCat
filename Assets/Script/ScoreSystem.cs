using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoremultiplier;

    bool shouldCount = true;

    float score;
    void Update()
    {
        if(!shouldCount) {return;}

        score += Time.deltaTime * scoremultiplier;

        
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int EndScoreTime()
    {
        shouldCount = false; 

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }
}
