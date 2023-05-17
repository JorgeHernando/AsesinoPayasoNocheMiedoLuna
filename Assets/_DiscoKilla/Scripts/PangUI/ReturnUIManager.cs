using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnUIManager : MonoBehaviour
{
    private int nextSceneToLoad;

    public int insertedCoins;

    private bool canPlay;

    [SerializeField]
    private GameObject _insertCoinPanel;

    [SerializeField]
    private GameObject _startGamePanel;

    [SerializeField]
    TextMeshProUGUI _insertCoinText;

    [SerializeField]
    private float FlickeringTimer;

    void Start()
    {
        insertedCoins = 0;
        nextSceneToLoad = 0;
        StartCoroutine(FlickeringInsertCoinPanel());
    }

    // Update is called once per frame
    void Update()
    {
        SwitchScenes();
    }

    private void SwitchScenes()
    {
        InsertCoinSequence();
        if (Input.GetKeyDown(KeyCode.Space) && canPlay)
            LoadMainMenuScene();
    }

    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

    void InsertCoinSequence()
    {
        if (Input.GetKeyDown(KeyCode.I) && insertedCoins <= 99)
        {
            insertedCoins++;
            _insertCoinText.GetComponent<TextMeshProUGUI>().text = insertedCoins + " Coin(s)";
        }

        if (insertedCoins > 0)
        {
            _startGamePanel.gameObject.SetActive(true);
            canPlay = true;
        }
    }

    IEnumerator FlickeringInsertCoinPanel()
    {
        while (true)
        {
            Debug.Log(FlickeringTimer);
            if (_insertCoinPanel.activeInHierarchy)
                _insertCoinPanel.gameObject.SetActive(false);
            else
                _insertCoinPanel.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(FlickeringTimer);
        }
    }
}