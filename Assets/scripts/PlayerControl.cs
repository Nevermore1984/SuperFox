using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {




    public Animator anim;

    private int State=1;//角色状态
    private int oldState ;//前一次角色的状态

    float h;//获得左右按键输入

    private float horizontal;  //水平偏移量

    private float moveSpeed=5; //水平移动速度绝对值
    private float passivemovespeed = 2.5f;//被动下降时水平移动速度

    private float jumpSpeed=7;//跳跃速度    

    private float activeFallSpeed=8;//主动下降垂直速度

    private float passiveFallSpeed = 2.5f;//被动下降垂直速度

    private Vector3 prePos;//先前位置

    private bool isJumping=false;//是否在跳跃

    private bool isUp = false;//是否在跳跃的上升阶段

    private int isFalling = 0;//0 不在下降 1 被动下降 2主动下降

    private bool isRunning=false;

    void Start()
    {


    }

    void Update()
    {
        Move();
        Jump();
        refreshAnimation();
        
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

    private void refreshAnimation()
    {
        anim.SetBool("isjump", isJumping);
        anim.SetInteger("isFall", isFalling);
        anim.SetBool("isRun", isRunning);
        anim.SetBool("isUp", isUp);
    }

    private void FixedUpdate()
    {
        //如果将按键读取放在这里，会卡卡的，是因为刷新率不同的原因
    }


   


    private void Jump()
    {
        if (isJumping)
        {
            if (isFalling == 0)
            {
                transform.Translate(Vector3.up * 1f * jumpSpeed * Time.deltaTime, Space.World);
                if (transform.position.y - prePos.y > 3f)
                {
                    isFalling = 1;
                    isUp = false;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    isFalling = 2;
                    isUp = false;
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
                isUp = true;
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
        h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        //transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h > 0)
        {
            SetState(1);
            isRunning = true;
        }
        else if (h < 0)
        {
            SetState(3);
            isRunning = true;
        }
        else
            isRunning = false;
    }

    private void SetState(int currState)//转向
    {
        int rotateValue = (currState - State) * 90;
        float speed = moveSpeed;
        if (isFalling == 1)
            speed = passivemovespeed;
        switch (currState)
        {
            case 1:
                transform.Translate(Vector3.right * 1 * speed * Time.deltaTime, Space.World);
                break;
            case 3:
                transform.Translate(Vector3.right * -1 * speed * Time.deltaTime, Space.World);
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
    }


}
