using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScoreSlimeManager scoreText;
    [SerializeField] TextMeshProUGUI m_Object;

    int scoreCount;

    private void OnEnable()
    {
        Slime.OnSlimeDeath += HandleSlimeAddScore;
        //To Hierarchy Up
        HabilidadBala1.OnPowerPickup += HandlePickUpScore;
        HabilidadBala2.OnPowerPickup += HandlePickUpScore;
        HabilidadBala3.OnPowerPickup += HandlePickUpScore;
        HabilidadBala4.OnPowerPickup += HandlePickUpScore;

}

    private void OnDisable()
    {
        Slime.OnSlimeDeath -= HandleSlimeAddScore;
        //To Hierarchy Up
        HabilidadBala1.OnPowerPickup -= HandlePickUpScore;
        HabilidadBala2.OnPowerPickup -= HandlePickUpScore;
        HabilidadBala3.OnPowerPickup -= HandlePickUpScore;
        HabilidadBala4.OnPowerPickup -= HandlePickUpScore;
    }

    private void Start()
    {
        UpdateHighScoreText();
    }

    void HandlePickUpScore() 
    {
        scoreCount = scoreCount + 200;
        scoreText.AddPowerUpScore(scoreCount);
        CheckHighScore();
    }

    void HandleSlimeAddScore()
    {
        scoreCount = scoreCount + 100;
        scoreText.AddSlimeScore(scoreCount);
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (scoreCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreCount);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        m_Object.text = $"HighScore: {PlayerPrefs.GetInt("HighScore"),0}";
    }
}
