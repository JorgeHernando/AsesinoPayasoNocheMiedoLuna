using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreInformation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;

    private GameObject[] activeNPC;
    private int totalScore;
    public int scoring;

    private void Awake()
    {
        activeNPC = GameObject.FindGameObjectsWithTag("NPCAlive");
        totalScore = activeNPC.Length;
        scoring = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_Object.text = scoring.ToString();
    }
}
