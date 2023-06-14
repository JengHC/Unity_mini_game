using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float playerSpeed = 2; // 플레이어 속도
    public float jumpPower = 3;
    Rigidbody2D rigid;    // 리지드바디 선언
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
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0)); // Vector(x,y,z) 값이라서 왼쪽으로 이동시 X좌표에 - 곱해줌
            transform.localScale = new Vector3(-1, 1, 1); // 좌우 반전
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
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // 점프 힘을 Rigidbody에 적용 
            isJumping = true; // 점프 중임을 나타내는 플래그 설정
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            isJumping = false;
        }
        anim.SetBool("IsJumping", isJumping); // "IsJumping" 매개변수를 true로 설정하여 점프 애니메이션 재생
    }
}
