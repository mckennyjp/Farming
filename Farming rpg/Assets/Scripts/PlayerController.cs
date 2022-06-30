using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    private CharacterController controller;
    private Animator animator;

    private float moveSpeed = 4f;

    [Header("Movement System")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //get inputs as number
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //normalize direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * direction;

        //sprint
        if(Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
        } 
        else
        {
            moveSpeed = walkSpeed;
        }

        //check if there is movement
        if(direction.magnitude >= 0.1f)
        {
            //look towards that direction
            transform.rotation = Quaternion.LookRotation(direction);

            //move
            controller.Move(velocity);

        }



    }

}
