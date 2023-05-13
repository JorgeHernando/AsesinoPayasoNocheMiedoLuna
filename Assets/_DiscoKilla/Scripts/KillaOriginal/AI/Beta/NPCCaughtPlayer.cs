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
    [SerializeField] GameObject fakeVision;

    public void StateSuspicious()
    {
        feeling.gameObject.SetActive(true);
        fakeVision.SetActive(true);
        //Debug.Log("Ha visto cuerpo");
        //SceneManager.LoadScene(_nextScene);
        //LoadNextScene(_nextScene);
    }

    public void StateCalm()
    {
        feeling.gameObject.SetActive(false);
        fakeVision.SetActive(false);
        //Debug.Log("De Chill");
        //SceneManager.LoadScene(_nextScene);
        //LoadNextScene(_nextScene);
    }

    public void GameOver()
    {
        Debug.Log("Pilladisimo CRACK CRACK");
        animFade.SetTrigger("QuickFadeIn");
        Invoke("LoadGameOverLevel", delay);
    }

    public void LoadGameOverLevel()
    {
        SceneManager.LoadScene(_nextScene);
    }
}
