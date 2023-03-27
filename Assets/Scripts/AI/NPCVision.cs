using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCVision : MonoBehaviour
{
    public GameObject feeling;
    public float delay;
    [SerializeField] string _nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            feeling.gameObject.SetActive(true);
            Debug.Log("Ha visto cuerpo");
            SceneManager.LoadScene("LoseScene");
            //LoadNextScene("LoseScene");
        }
    }

    private IEnumerator LoadNextScene(string levelName)
    {
        yield return new WaitForSeconds(delay);
            Debug.Log("Cambia nivel");
        SceneManager.LoadScene(levelName);
    }
}
