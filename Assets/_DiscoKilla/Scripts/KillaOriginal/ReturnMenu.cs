using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{

    

    // Update is called once per frame
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");        
    }
}
