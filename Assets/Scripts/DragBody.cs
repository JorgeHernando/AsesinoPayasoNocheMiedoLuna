using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBody : MonoBehaviour
{
    private bool canDrag;
    private bool isDragging;

    //Drag Bodies
    [SerializeField]
    private Transform grabPointRight;
    [SerializeField]
    private Transform grabPointLeft;

    [SerializeField]
    private float rayDistance;

    private GameObject draggedBody;
    public LayerMask layerIndex;

    private void Start()
    {
        canDrag = false;
        isDragging = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canDrag)
        {
            Debug.Log("Lo puedes Draggear con Click Izquierdo");
            isDragging = true;
            RaycastingCheck();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Trying To Undrag");
            isDragging = false;
            RaycastingUncheck();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            Debug.Log("Activar Dragger");
            canDrag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            Debug.Log("Activar Dragger");
            canDrag = false;
        }
    }

    private void RaycastingCheck()
    {
        RaycastHit2D hitInfoHorizontalLeft = Physics2D.Raycast(transform.position, -Vector2.right, rayDistance, layerIndex);
        RaycastHit2D hitInfoHorizontalRight = Physics2D.Raycast(transform.position, transform.right, rayDistance, layerIndex);
        Debug.Log("Llamando al Raycaster");

        if (hitInfoHorizontalLeft.collider != null)
        {
            Debug.Log("Hitting: " + hitInfoHorizontalLeft.collider.tag);

            if (hitInfoHorizontalLeft.collider.tag == "DeadBody" && isDragging == true)
            {
                Debug.Log("Activando Arrastrador Left");
                draggedBody = hitInfoHorizontalLeft.collider.gameObject;
                draggedBody.GetComponent<Rigidbody2D>().isKinematic = true;
                draggedBody.transform.position = grabPointLeft.position;
                draggedBody.transform.SetParent(transform);
                Debug.DrawRay(transform.position, -transform.right, Color.red);
            }
        }
        else if (hitInfoHorizontalRight.collider != null)
        {
            Debug.Log("Hitting: " + hitInfoHorizontalRight.collider.tag);

            if (hitInfoHorizontalRight.collider.tag == "DeadBody" && isDragging == true)
            {
                Debug.Log("Activando Arrastrador Right");
                draggedBody = hitInfoHorizontalRight.collider.gameObject;
                draggedBody.GetComponent<Rigidbody2D>().isKinematic = true;
                draggedBody.transform.position = grabPointRight.position;
                draggedBody.transform.SetParent(transform);
                Debug.DrawRay(transform.position, transform.right, Color.red);
            }
        }
    }

    private void RaycastingUncheck()
    {
        RaycastHit2D hitInfoHorizontalLeft = Physics2D.Raycast(transform.position, -Vector2.right, rayDistance, layerIndex);
        RaycastHit2D hitInfoHorizontalRight = Physics2D.Raycast(transform.position, transform.right, rayDistance, layerIndex);
        Debug.Log("Llamando al Raycaster");
        draggedBody?.transform.SetParent(null);

        if (hitInfoHorizontalLeft.collider != null)
        {

            Debug.Log("Hitting: " + hitInfoHorizontalLeft.collider.tag);

            if (hitInfoHorizontalLeft.collider.tag == "DeadBody" && isDragging == false)
            {
                Debug.Log("Desactivando  Arrastrador Left");
                draggedBody.GetComponent<Rigidbody2D>().isKinematic = false;
                draggedBody.transform.SetParent(null);
                draggedBody = null;
                Debug.DrawRay(transform.position, -transform.right, Color.red);
            }
        }
        else if (hitInfoHorizontalRight.collider != null)
        {
            Debug.Log("Hitting: " + hitInfoHorizontalRight.collider.tag);

            if (hitInfoHorizontalRight.collider.tag == "DeadBody" && isDragging == false)
            {
                Debug.Log("Desactivando  Arrastrador Right");
                draggedBody.GetComponent<Rigidbody2D>().isKinematic = false;
                draggedBody.transform.SetParent(null);
                draggedBody = null;
                Debug.DrawRay(transform.position, transform.right, Color.red);
            }
        }
    }
}
