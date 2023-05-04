using UnityEngine;

public class NPCLineOfSight : MonoBehaviour
{
    public float viewDistance;
    public LayerMask viewMask;
    Vector2 direction = Vector2.right;

    public bool hasWitnessed;
    public bool hasSeenBody;

    private NPCCaughtPlayer caughtPlayer;

    private void Start()
    {
        caughtPlayer = GetComponent<NPCCaughtPlayer>();
    }

    private void Update()
    {
        CheckForPlayer();
        CheckForDeadBodies();
    }

    private void CheckForPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, TopDownMovement.Instance.transform.position - transform.position,
            viewDistance, viewMask);

        if (hit.collider != null && hit.collider.CompareTag("Player") && IsPlayerCloseToDeadBody())
        {
            // Player is seen near a dead body, you lose.
            hasWitnessed = true;
            Debug.Log("Player caught!");
            caughtPlayer.GameOver();
            // Implement game over logic here.
        }
    }

    private void CheckForDeadBodies()
    {
        Collider2D[] deadBodyColliders = Physics2D.OverlapCircleAll(transform.position, viewDistance,
            LayerMask.GetMask("Dead"));
        Vector3 endPosition = (Vector3)direction + Vector3.forward * 0.01f;

        foreach (Collider2D collider in deadBodyColliders)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, collider.transform.position - transform.position,
                viewDistance, viewMask);

            if (hit.collider != null && hit.collider.CompareTag("DeadBody"))
            {
                // A dead body is seen, implement NPC reaction logic here.
                hasSeenBody = true;
                Debug.Log("NPC found a dead body!");
                caughtPlayer.StateSuspicious();
            }
            else
                caughtPlayer.StateCalm();
            Debug.DrawLine(transform.position, collider.transform.position - transform.position, Color.red);
        }
    }

    private bool IsPlayerCloseToDeadBody()
    {
        // Check if the player is close to a dead body.
        Collider2D[] deadBodyColliders = Physics2D.OverlapCircleAll(TopDownMovement.Instance.transform.position, 1f,
            LayerMask.GetMask("Dead"));

        return deadBodyColliders.Length > 0;
    }
}