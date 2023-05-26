using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSlimeManager: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;

    public void AddSlimeScore(int slimeValue)
    {
        m_Object.text = $"Score: {slimeValue.ToString()} ";
    }

    public void AddPowerUpScore(int powerUpValue)
    {
        m_Object.text = $"Score: {powerUpValue.ToString()} ";
    }
}
