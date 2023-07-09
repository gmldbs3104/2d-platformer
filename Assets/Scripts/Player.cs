using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //��������
    Rigidbody2D Rigid;
    public float MaxSpeed;
    public float JumpPower;
    SpriteRenderer SR;
    Animator Anim;

    void Awake()
    {
        //������ �Ҵ�
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
        //�̵� �ӵ�
        float h = Input.GetAxisRaw("Horizontal");

        Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //�ִ� �ӵ� �����ִ� ����
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
        if (Input.GetButtonDown("Horizontal")) //��ư�� ������ �̵�
        {
            SR.flipX = Input.GetAxisRaw("Horizontal") == -1; //�������� ���� ���� �ٲٴ� ����

        }

        if (Input.GetButtonDown("Jump") && !Anim.GetBool("isJump")) //��ư�� ������ ����
        {
            Rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            Anim.SetBool("isJump", true);
        }

        //�ӵ��� 0.3���� Ŀ���� Run�̶�� animation�� true������ �ٲ�� ��
        if (Mathf.Abs(Rigid.velocity.x) < 0.3)
        {
            Anim.SetBool("isRun", false);
        }
        else
        {
            Anim.SetBool("isRun", true);
        }
        
        //�ӵ��� 0.3���� Ŀ���� Jump��� animation�� true������ �ٲ�� ��
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
