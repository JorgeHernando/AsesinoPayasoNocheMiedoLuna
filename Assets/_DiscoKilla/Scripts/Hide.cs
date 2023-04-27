using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public bool canHide;
    public bool isHiding;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.gameObject.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canHide)
        {
            Debug.Log("Lo puedes Draggear con Click Izquierdo");
            isHiding = true;
            HideMe();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Trying To Undrag");
            isHiding = false;
            ShowMe();
        }
    }
    public void startHiding()
    {
        if (isHiding == false)
            isHiding = true;
        else
            isHiding = false;
    }
    public void HideMe()
    {
        renderer.enabled = false;
    }

    public void ShowMe()
    {
        renderer.enabled = true;
    }
}
