using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;
    public TMP_Text scoreText;
    public TMP_Text bestscoreText;
    int score, best;

    void Awake()
    {
        instance = this;
        scoreText.text = "0";
        bestscoreText.text = PlayerPrefs.GetInt("BestScore").ToString();

    }

    void Update()
    {
        
        if (Ball.GetZ() == 0)
            scoreText.gameObject.SetActive(false);
        else
            scoreText.gameObject.SetActive(true);


        if ((int)Ball.GetZ() >= 0)
            scoreText.text = Ball.GetScore().ToString();
        else
            scoreText.text = "0";

        if(PlayerPrefs.GetInt("BestScore") < Ball.GetScore())
        {
            best = Ball.GetScore();
            PlayerPrefs.SetInt("BestScore", best);
            bestscoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
    }
    public void setScore(int scorre)
    {
        score = scorre;
    }
}
