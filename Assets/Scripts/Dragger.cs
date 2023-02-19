using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            Debug.Log("Arrastrando Muerto");
            
            DeadBehaviour deadComponent = collision.gameObject.GetComponent<DeadBehaviour>();
            if (deadComponent != null)
                deadComponent.SetTarget(transform.parent.position);
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBody"))
        {
            Debug.Log("Arrastrando Muerto");

            DeadBehaviour deadComponent = collision.gameObject.GetComponent<DeadBehaviour>();
            if (deadComponent != null)
                deadComponent.canBeDrag = false;
        }
    }
}
