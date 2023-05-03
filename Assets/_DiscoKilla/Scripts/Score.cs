using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    private GameObject[] activeNPC;
    [SerializeField] TextMeshProUGUI m_Object;
    public int totalNPC;

    private void Awake()
    {
        activeNPC = GameObject.FindGameObjectsWithTag("NPCAlive");
        totalNPC = activeNPC.Length;
    }

    public void Update()
    {
        m_Object.text = activeNPC.Length.ToString();

        if (activeNPC.Length == 0)
        {
            Victory();
        }
    }

    public void Victory()
    {
        if (activeNPC.Length == 0)
        {
            SceneManager.LoadScene("WonScene");
        }
    }
}