using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaNPCVision : MonoBehaviour
{
    private enum State
    {
        Dancing,
        Moving,
        Scared,
        Hiding,
    }

    private const float speed = 25f;

    [SerializeField] private List<Vector3> waypointList;
    [SerializeField] private List<float> waitTimeList;
    private int waypointIndex;

    private FieldOfView fieldOfView;
    [SerializeField] private Transform pfFieldOfView;
    [SerializeField] private float fov = 90f;
    [SerializeField] private float viewDistance = 50f;

    private State state;
    private float waitTimer;
    private Vector3 lastMoveDir;

    protected void Start()
    {
        //Vision
        fieldOfView = Instantiate(pfFieldOfView, null).GetComponent<FieldOfView>();
        fieldOfView.SetFoV(fov);
        fieldOfView.SetViewDistance(viewDistance);
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Dancing:
            case State.Moving:
                HandleMovement();
                //FindTargetBody();
                break;
            case State.Scared:
                //RunawayPlayer();
                break;
            case State.Hiding:
                break;
        }

        if (fieldOfView != null)
        {
            fieldOfView.SetOrigin(transform.position);
            fieldOfView.SetAimDirection(GetAimDir());
        }

        Debug.DrawLine(transform.position, transform.position + GetAimDir() * 10f);
    }

    /*private void FindTargetBody()
    {
        if (Vector3.Distance(GetPosition(), player.GetPosition()) < viewDistance)
        {
            // Player inside viewDistance
            Vector3 dirToPlayer = (player.GetPosition() - GetPosition()).normalized;
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f)
            {
                // Player inside Field of View
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance);
                if (raycastHit2D.collider != null)
                {
                    // Hit something
                    if (raycastHit2D.collider.gameObject.GetComponent<Player>() != null)
                    {
                        // Hit Player
                        StartAttackingPlayer();
                    }
                    else
                    {
                        // Hit something else
                    }
                }
            }
        }
    }*/
    
    private void HandleMovement()
    {
        switch (state)
        {
            case State.Dancing:
                waitTimer -= Time.deltaTime;
                //Animation Dancing
                //animatedWalker.SetMoveVector(Vector3.zero);
                if (waitTimer <= 0f)
                {
                    state = State.Moving;
                }
                break;
            case State.Moving:
                Vector3 waypoint = waypointList[waypointIndex];

                Vector3 waypointDir = (waypoint - transform.position).normalized;
                lastMoveDir = waypointDir;

                float distanceBefore = Vector3.Distance(transform.position, waypoint);
                //animatedWalker.SetMoveVector(waypointDir);
                transform.position = transform.position + waypointDir * speed * Time.deltaTime;
                float distanceAfter = Vector3.Distance(transform.position, waypoint);

                float arriveDistance = .1f;
                if (distanceAfter < arriveDistance || distanceBefore <= distanceAfter)
                {
                    // Go to next waypoint
                    waitTimer = waitTimeList[waypointIndex];
                    waypointIndex = (waypointIndex + 1) % waypointList.Count;
                    state = State.Dancing;
                }
                break;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetAimDir()
    {
        return lastMoveDir;
    }
}
