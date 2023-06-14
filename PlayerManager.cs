using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float playerSpeed = 2; // �÷��̾� �ӵ�
    public float jumpPower = 3;
    Rigidbody2D rigid;    // ������ٵ� ����
    Animator anim;
    bool isJumping = false; 

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsJumping", false); //
    }

    void Update()
    {
        PlayerMove();
        //OnJumpAnimationEnd();
    }
    void PlayerMove()
    {
        bool isWalking = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0)); // Vector(x,y,z) ���̶� �������� �̵��� X��ǥ�� - ������
            transform.localScale = new Vector3(-1, 1, 1); // �¿� ����
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));
            transform.localScale = new Vector3(1, 1, 1);
            isWalking = true;
        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            isWalking = false;
        }
        anim.SetBool("IsWalking", isWalking);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // ���� ���� Rigidbody�� ���� 
            isJumping = true; // ���� ������ ��Ÿ���� �÷��� ����
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            isJumping = false;
        }
        anim.SetBool("IsJumping", isJumping); // "IsJumping" �Ű������� true�� �����Ͽ� ���� �ִϸ��̼� ���
    }
}
