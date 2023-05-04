using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCCaughtPlayer : MonoBehaviour
{
    public GameObject feeling;
    public float delay;
    [SerializeField] string _nextScene = "LoseScene";

    [SerializeField] Animator animFade;

    public void StateSuspicious()
    {
        feeling.gameObject.SetActive(true);
        Debug.Log("Ha visto cuerpo");
        //SceneManager.LoadScene(_nextScene);
        //LoadNextScene(_nextScene);
    }

    public void StateCalm()
    {
        feeling.gameObject.SetActive(false);
        Debug.Log("Ha visto cuerpo");
        //SceneManager.LoadScene(_nextScene);
        //LoadNextScene(_nextScene);
    }

    public void GameOver()
    {
        Debug.Log("Caught");
        animFade.SetTrigger("QuickFadeIn");
        Invoke("LoadGameOverLevel", delay);
    }

    public void LoadGameOverLevel()
    {
        SceneManager.LoadScene(_nextScene);
    }
}
