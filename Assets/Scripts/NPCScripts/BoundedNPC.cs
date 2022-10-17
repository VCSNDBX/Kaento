using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactable
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
