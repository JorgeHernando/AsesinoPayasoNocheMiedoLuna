using System.Collections;
using UnityEngine;

public class NPCTopDownMovement : MonoBehaviour
{
    public float speed = 3f;
    public float waitTime = 2f;
    public Transform[] waypoints;

    private int currentWaypoint = 0;
    private Animator animator;
    private Vector3 lastPosition;

    private NPCLineOfSight state;
    //Future Clean Implementation - Hiding Spots With Wall Checking
    public Transform[] hidingSpots;
    Transform randomHidingSpot;
    public int hidingTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<NPCLineOfSight>();
        lastPosition = new Vector3(transform.position.x, transform.position.y, 0);
        randomHidingSpot = hidingSpots[Random.Range(0, hidingSpots.Length)];

        StartCoroutine(MoveToWaypoint());
    }

    private IEnumerator MoveToWaypoint()
    {

        while (true)
        {
            Vector2 targetPosition;
            Vector2 direction;

            if (state.hasSeenBody)
            {
                //Debug.Log("Ay mamita");
                // Move to the hiding spot
                targetPosition = randomHidingSpot.position;
                direction = targetPosition - (Vector2)transform.position;
                //animator.SetBool("Moving", true);
            }
            else
            {
                //Debug.Log("Tamo Piola");
                // Move to the next waypoint
                targetPosition = waypoints[currentWaypoint].position;
                direction = targetPosition - (Vector2)transform.position;
                //animator.SetBool("Moving", true);
            }

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                if (state.hasSeenBody == true)
                {
                    // Wait for a bit and then start patrolling again
                    yield return new WaitForSeconds(hidingTime);
                    state.hasSeenBody = false;
                    currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                }
                else
                {
                    // Reached a waypoint, wait and then move to the next one
                    //animator.SetBool("Moving", false);
                    yield return new WaitForSeconds(waitTime);
                    currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                }
            }

            /*if (transform.position != lastPosition)
            {
                animator.SetFloat("MoveX", direction.x);
                animator.SetFloat("MoveY", direction.y);
            }*/

            lastPosition = transform.position;
            yield return null;
        }
    }

}
