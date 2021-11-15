using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    protected Animator animator;
    public float DirectionDampTime = .25f;
    public bool ApplyGravity = true;

    AnimatorStateInfo stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            animator.SetFloat("Direction", -1, DirectionDampTime, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Direction", 0, DirectionDampTime, Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            animator.SetFloat("Direction", 1, DirectionDampTime, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Direction", 0, DirectionDampTime, Time.deltaTime);
        }
        if (Keyboard.current.wKey.isPressed)
        {
            animator.SetFloat("Speed", 1, DirectionDampTime, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Speed", 0, DirectionDampTime, Time.deltaTime);
        }

    }

    public void OnJump()
    {
        //if we're in the state Idle or Run in the animator, then trigger Jump
        if (stateInfo.IsName("Base Layer.Idle")||stateInfo.IsName("Base Layer.Run"))
        {
            animator.SetTrigger("Jump");
        }
    }

    public void OnMove(InputValue input)
    {
        //read the input vector and save it as a vector2 (forward and back)
        Vector2 inputVec = input.Get<Vector2>();
        //pass these values to animator- speed is how fast we're moving, direction is the direction we're moving
        animator.SetFloat("Speed", inputVec.x * inputVec.x + inputVec.y * inputVec.y);
        animator.SetFloat("Direction", 2*inputVec.x, DirectionDampTime, Time.deltaTime);
    }


  
}
