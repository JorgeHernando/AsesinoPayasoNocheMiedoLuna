using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUIState : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;

    TopDownMovement characterPlayer;

    private void Awake()
    {
        characterPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Object.text = characterPlayer.states.ToString();
    }
}
