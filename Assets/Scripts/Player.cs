using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //변수선언
    Rigidbody2D Rigid;
    public float MaxSpeed;
    public float JumpPower;
    SpriteRenderer SR;
    Animator Anim;

    void Awake()
    {
        //변수에 할당
        Rigid = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //이동 속도
        float h = Input.GetAxisRaw("Horizontal");

        Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //최대 속도 정해주는 역할
        if (Rigid.velocity.x > MaxSpeed)
        {
            Rigid.velocity = new Vector2(MaxSpeed, Rigid.velocity.y);
        }
        else if (Rigid.velocity.x < MaxSpeed * -1)
        {
            Rigid.velocity = new Vector2(MaxSpeed * -1, Rigid.velocity.y);
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Horizontal")) //버튼을 누르면 이동
        {
            SR.flipX = Input.GetAxisRaw("Horizontal") == -1; //왼쪽으로 갈때 방향 바꾸는 역할

        }

        if (Input.GetButtonDown("Jump") && !Anim.GetBool("isJump")) //버튼을 누르면 점프
        {
            Rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            Anim.SetBool("isJump", true);
        }

        //속도가 0.3보다 커지면 Run이라는 animation이 true값으로 바뀌는 것
        if (Mathf.Abs(Rigid.velocity.x) < 0.3)
        {
            Anim.SetBool("isRun", false);
        }
        else
        {
            Anim.SetBool("isRun", true);
        }
        
        //속도가 0.3보다 커지면 Jump라는 animation이 true값으로 바뀌는 것
        if(Mathf.Abs(Rigid.velocity.y)<0.3)
        {
            Anim.SetBool("isJump", false);
        }
        else
        {
            Anim.SetBool("isJump", true);
        }
    }
}
