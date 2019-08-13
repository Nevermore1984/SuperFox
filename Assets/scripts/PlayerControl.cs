using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {




    private float horizontal;  //水平偏移量

    private float moveSpeed=5; //水平移动速度绝对值

    private float jumpSpeed=7;//

    private float activeFallSpeed=10;//

    private float passiveFallSpeed = 5;

    private Vector3 prePos;//

    private bool isJumping=false;

    private int isFalling = 0;

    void Start()
    {


    }

    void Update()
    {

        
    }

        private void FixedUpdate()
    {
        Move();
        Jump();
    }


    private void Jump()
    {
        if (isJumping)
        {
            if (isFalling == 0)
            {
                transform.Translate(Vector3.up * 1f * jumpSpeed * Time.fixedDeltaTime, Space.World);
                if (transform.position.y - prePos.y > 2f)
                {
                    isFalling = 1;
                }
                if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.DownArrow))
                {
                    isFalling = 2;
                }
            }
            else if (isFalling == 1)
                passiveFall();
            else
                activeFall();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                prePos = transform.position;
                isJumping = true;
            }
        }
    }


    private void passiveFall()
    {
        transform.Translate(Vector3.up * -1f * passiveFallSpeed * Time.fixedDeltaTime, Space.World);
        if(transform.position.y != prePos.y)
            prePos = transform.position;
        else
        {
            isJumping = false;
            isFalling = 0;
        }
    }

    private void activeFall()
    {
        transform.Translate(Vector3.up * -1f * activeFallSpeed * Time.fixedDeltaTime, Space.World);
        if (transform.position.y != prePos.y)
            prePos = transform.position;
        else
        {
            isJumping = false;
            isFalling = 0;
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        //float v = Input.GetAxisRaw("Vertical");
        //transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
      

        
    }
}
