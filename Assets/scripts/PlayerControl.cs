using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {




    private int State;//角色状态
    private int oldState = 0;//前一次角色的状态


    private float horizontal;  //水平偏移量

    private float moveSpeed=5; //水平移动速度绝对值

    private float jumpSpeed=7;//跳跃速度    

    private float activeFallSpeed=10;//主动下降速度

    private float passiveFallSpeed = 3;//被动下降速度

    private Vector3 prePos;//先前位置

    private bool isJumping=false;//是否在跳跃

    private int isFalling = 0;//0 不在下降 1 被动下降 2主动下降

    void Start()
    {


    }

    void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        //如果将按键读取放在这里，会卡卡的，是因为刷新率不同的原因
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Land":
                JumpIsOver();
                break;

        }
    }


    private void Jump()
    {
        if (isJumping)
        {
            if (isFalling == 0)
            {
                transform.Translate(Vector3.up * 1f * jumpSpeed * Time.deltaTime, Space.World);
                if (transform.position.y - prePos.y > 2.5f)
                {
                    isFalling = 1;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    isFalling = 2;
                }
            }
            else if (isFalling == 1)
            {
                passiveFall();
                if (Input.GetKeyDown(KeyCode.S))
                {
                    isFalling = 2;
                }
            }
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
        transform.Translate(Vector3.up * -1f * passiveFallSpeed * Time.deltaTime, Space.World);
    }

    private void activeFall()
    {
        transform.Translate(Vector3.up * -1f * activeFallSpeed * Time.deltaTime, Space.World);
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        //transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h > 0)
            SetState(1);
        else if (h < 0)
            SetState(3);
    }

    private void SetState(int currState)//转向
    {
        int rotateValue = (currState - State) * 90;
        gameObject.GetComponent<Animation>().Play("player-run");
        switch (currState)
        {
            case 1:
                transform.Translate(Vector3.right * 1 * moveSpeed * Time.deltaTime, Space.World);
                break;
            case 3:
                transform.Translate(Vector3.right * -1 * moveSpeed * Time.deltaTime, Space.World);
                break;
        }
        transform.Rotate(Vector3.up, rotateValue);//旋转角色
        oldState = State;//赋值，方便下一次计算
        State = currState;//赋值，方便下一次计算
    }

    private void JumpIsOver()
    {
        isJumping = false;
        isFalling = 0;
        print("jump is over");
    }
}
