using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }
    public GameObject StateGlobal;
    public Caughtbar caught;

    //public InteractionUI ins;

    [SerializeField] private int maxCaught;
    [SerializeField] private int currentCaught;

    public List<GameObject> bloodType = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentCaught = maxCaught;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        caught.SetMaxCatch(maxCaught);
    }

    public Color GetOriginalColor
    {
        get { return new Color(1, 1, 1, 1); }
    }
}
