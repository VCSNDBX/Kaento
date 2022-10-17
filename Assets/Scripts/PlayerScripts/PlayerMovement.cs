using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D Rigidbody2D;
    private Vector3 change;
    private Animator animator;
    public FixedJoystick joystick;
    public VectorValue startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
        
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = joystick.Horizontal;
        change.y = joystick.Vertical;
        UpdateAnimationAndMove();
    }

    private void FixedUpdate()
    {
        UpdateAnimationAndMove();
    }

    void MoveCharacter()
    {
        Rigidbody2D.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);

        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
