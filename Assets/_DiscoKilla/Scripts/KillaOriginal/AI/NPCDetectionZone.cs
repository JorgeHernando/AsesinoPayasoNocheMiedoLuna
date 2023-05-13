using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCDetectionZone : MonoBehaviour
{
    public float delay;
    [SerializeField] private Vector3 lookDirection;

    [SerializeField] private DeadBehaviour dead;
    [SerializeField] private Transform pfFieldOfView;
    [SerializeField] private float fov = 90f;
    [SerializeField] private float viewDistance = 50f;


    private FieldOfView fieldOfView;
    private Vector3 lastMoveDir;

    // Start is called before the first frame update
    void Start()
    {
        lastMoveDir = lookDirection;

        fieldOfView = Instantiate(pfFieldOfView, null).GetComponent<FieldOfView>();
        fieldOfView.SetFoV(fov);
        fieldOfView.SetViewDistance(viewDistance);

    }

    // Update is called once per frame
    void Update()
    {
        FindTargetDead();
        if (fieldOfView != null)
        {
            fieldOfView.SetOrigin(transform.position);
            fieldOfView.SetAimDirection(GetLookDir());
        }

        //Debug.DrawLine(transform.position, transform.position + GetAimDir() * 10f);
    }

    private void FindTargetDead()
    {
        if (Vector3.Distance(GetPosition(), dead.GetPosition()) < viewDistance)
        {
            // Player inside viewDistance
            Vector3 dirToPlayer = (dead.GetPosition() - GetPosition()).normalized;
            if (Vector3.Angle(GetLookDir(), dirToPlayer) < fov / 2f)
            {
                // Player inside Field of View
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance);
                if (raycastHit2D.collider != null)
                {
                    // Hit something
                    if (raycastHit2D.collider.gameObject.GetComponent<DeadBehaviour>() != null)
                    {
                        // Hit Player

                        LoadNextScene("LoseScene");
                    }
                    else
                    {
                        // Hit something else
                    }
                }
            }
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetLookDir()
    {
        return lastMoveDir;
    }

    private IEnumerator LoadNextScene(string levelName)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Cambia nivel");
        SceneManager.LoadScene(levelName);
    }
}
