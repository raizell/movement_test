using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform foot;
    private float moveX = 0f;
    private bool isJump = false;


    // Start is called before the first frame update
    void Start()
    {
       myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate() 
        {
            HandleMovement();
        }


    private void HandleMovement()
        {
            myRigidBody.velocity = new Vector2( moveX * moveSpeed , myRigidBody.velocity.y );

            if (isJump)
            {
                if(CheckGround())
                {
                myRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJump = false;
                }
            }
        }


    private void HandleInput()
        {
            moveX = 0f;


            if (Input.GetKey(KeyCode.D))
            {

                moveX = 1f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveX = -1f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
        }
    
    private bool CheckGround()
    {
        Debug.DrawRay(foot.position, Vector2.down * 0.5f,Color.red,1f);
        return Physics2D.Raycast(foot.position , Vector2.down, 1f,groundLayer);
    }
}
