using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMenuIA : MonoBehaviour
{
    public float speed = 3f;
    public float waitTime = 2f;
    public Transform[] waypoints;

    private int currentWaypoint = 0;
    private Animator animator;
    private Vector3 lastPosition;

    Transform randomHidingSpot;
    public int hidingTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = new Vector3(transform.position.x, transform.position.y, 0);

        StartCoroutine(MoveToWaypoint());
    }

    private IEnumerator MoveToWaypoint()
    {

        while (true)
        {
            Vector2 targetPosition;
            Vector2 direction;

            //Debug.Log("Tamo Piola");
            // Move to the next waypoint
            targetPosition = waypoints[currentWaypoint].position;
            direction = targetPosition - (Vector2)transform.position;
            //animator.SetBool("Moving", true);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Reached a waypoint, wait and then move to the next one
                //animator.SetBool("Moving", false);
                yield return new WaitForSeconds(waitTime);
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            }
            lastPosition = transform.position;
            yield return null;
        }
    }

}
