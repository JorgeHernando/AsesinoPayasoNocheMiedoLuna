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

    [SerializeField]
    private GameObject TitlePanel;

    [SerializeField]
    private GameObject LevelPanel;

    [SerializeField]
    private GameObject _insertCoinPanel;

    [SerializeField]
    private GameObject _startGamePanel;

    [SerializeField]
    TextMeshProUGUI _insertCoinText;
    
    [SerializeField]
    private float FlickeringTimer;

    //[Header] LevelNames
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
                    canPlay = false;
                }
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
