using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 direcciones;
    private Animator animator;

    int _isWalkingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = new Animator();
        direcciones = new Vector3(0, 0, 0);

        //Animation
        _isWalkingHash = Animator.StringToHash("isWalking");

    }

    void HandleAnimation()
    {
        //Get Parameter Values From Animator
        bool _isWalking = animator.GetBool("isWalking");

        //Start Walking Animation If MovementPressed Is True And Not Already Walking Else Viceversa
        if (!_isWalking)
        {
            animator.SetBool(_isWalkingHash, true);
        }
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            HandleAnimation();
        //_characterController.Move(direcciones);
    }
}
