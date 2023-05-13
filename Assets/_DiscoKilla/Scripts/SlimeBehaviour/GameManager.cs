using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScoreSlimeManager scoreText;
    [SerializeField] TextMeshProUGUI m_Object;

    int scoreCount = 0;

    private void OnEnable()
    {
        Slime.OnSlimeDeath += HandleSlimeAddScore;
    }

    private void OnDisable()
    {
        Slime.OnSlimeDeath -= HandleSlimeAddScore;
    }

    private void Start()
    {
        UpdateHighScoreText();
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
