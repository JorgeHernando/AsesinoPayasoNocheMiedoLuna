using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private GameObject[] activeNPC;

    public void Update()
    {
        activeNPC = GameObject.FindGameObjectsWithTag("NPCAlive");

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