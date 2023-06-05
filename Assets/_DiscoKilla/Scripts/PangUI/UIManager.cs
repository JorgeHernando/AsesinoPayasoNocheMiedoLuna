using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int nextSceneToLoad;
    private int sceneToLoad;

    public int insertedCoins;

    private bool canPlay;

    private bool toOptions;

    [SerializeField]
    private GameObject TitlePanel;

    [SerializeField]
    private GameObject LevelPanel;

    [SerializeField]
    private GameObject _insertCoinPanel;

    [SerializeField]
    private GameObject _optionsPressPanel;

    [SerializeField]
    private GameObject _startGamePanel;

    [SerializeField]
    TextMeshProUGUI _insertCoinText;

    [SerializeField]
    TextMeshProUGUI _optionsText;

    [SerializeField]
    private float FlickeringTimer;

    //[Header] LevelNames
    [SerializeField]
    private string LevelOptions;
    #region Level Names
    [SerializeField]
    private string LevelTutorial;
    [SerializeField]
    private string LevelOne;
    [SerializeField]
    private string LevelTwo;
    [SerializeField]
    private string LevelThree;
    #endregion

    void Start()
    {
        StartCoroutine(FlickeringInsertCoinPanel());
        insertedCoins = 0;
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        toOptions = false;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchScenes();
    }

    private void SwitchScenes()
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        switch (sceneToLoad)
        {
            case 0:
                InsertCoinSequence();
                if (Input.GetKeyDown(KeyCode.Space) && canPlay)
                {
                    TitlePanel.SetActive(false);
                    LevelPanel.SetActive(true);
                    Debug.Log("Titilando");
                    StartCoroutine(FlickeringOptionsPanel());
                    canPlay = false;
                    toOptions = true;
                    
                    
                }
                GoToOptions();
                break;
        }
    }
    public void LoadLevelTutorial()
    {
        SceneManager.LoadScene(LevelTutorial);
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(LevelOne);
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(LevelTwo);
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene(LevelThree);
    }

    public void LoadLevelOptions()
    {
        SceneManager.LoadScene(LevelOptions);
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

    void GoToOptions()
    {
        if (Input.GetKeyDown(KeyCode.K) && toOptions == true)
        {
            Debug.Log("To Main Menu");
            LoadLevelOptions();
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
    IEnumerator FlickeringOptionsPanel()
    {
        while (true)
        {
            Debug.Log(FlickeringTimer);
            if (_optionsPressPanel.activeInHierarchy)
                _optionsPressPanel.gameObject.SetActive(false);
            else
                _optionsPressPanel.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(FlickeringTimer);
        }
    }
}
