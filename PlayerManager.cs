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
    int jumpCount = 0;

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


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // 점프 힘을 Rigidbody에 적용 
            isJumping = true; // 점프 중임을 나타내는 플래그 설정
            jumpCount++;
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            isJumping = false;
        }
        anim.SetBool("IsJumping", isJumping); // "IsJumping" 매개변수를 true로 설정하여 점프 애니메이션 재생
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            jumpCount = 0;
        }
    }
}
//---------------------------------------------------------------
// 아래 부터는 모바일 버전
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerManager : MonoBehaviour
//{
//    public float playerSpeed = 2; // 플레이어 속도
//    public float jumpPower = 3;
//    Rigidbody2D rigid;    // 리지드바디 선언
//    Animator anim;
//    bool isJumping = false;
//    int jumpCount = 0;

//    private bool isMovingRight = false;
//    private bool isMovingLeft = false;

//    void Start()
//    {
//        rigid = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        anim.SetBool("IsJumping", false);
//    }

//    void Update()
//    {
//        PlayerMove();
//    }

//    void PlayerMove()
//    {
//        bool isWalking = false;

//        if (isMovingRight)
//        {
//            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
//            transform.localScale = new Vector3(-1, 1, 1);
//            isWalking = true;
//        }

//        if (isMovingLeft)
//        {
//            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));
//            transform.localScale = new Vector3(1, 1, 1);
//            isWalking = true;
//        }

//        anim.SetBool("IsWalking", isWalking);

//        if (isJumping)
//        {
//            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
//            isJumping = false;
//            jumpCount++;
//            anim.SetBool("IsJumping", true);
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Border"))
//        {
//            jumpCount = 0;
//        }
//    }

//    public void SetMoveRight(bool value)
//    {
//        isMovingRight = value;
//    }

//    public void SetMoveLeft(bool value)
//    {
//        isMovingLeft = value;
//    }

//    public void Jump()
//    {
//        isJumping = true;
//    }
//}
//---------------------------------------------------------------------------

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerManager : MonoBehaviour
//{
//    public float playerSpeed = 2; // 플레이어 속도
//    public float jumpPower = 3;
//    Rigidbody2D rigid;
//    Animator anim;
//    bool isJumping = false;
//    int jumpCount = 0;
//    int maxJumpCount = 2;

//    private bool isMovingRight = false;
//    private bool isMovingLeft = false;

//    void Start()
//    {
//        rigid = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        anim.SetBool("IsJumping", false);
//        anim.SetBool("IsWalking", false); // 초기에도 애니메이션을 정지 상태로 설정
//    }

//    void Update()
//    {
//        PlayerMove();
//    }

//    void PlayerMove()
//    {
//        bool isWalking = false;

//        if (isMovingRight)
//        {
//            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
//            transform.localScale = new Vector3(1, 1, 1);
//            isWalking = true;
//        }

//        if (isMovingLeft)
//        {
//            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));
//            transform.localScale = new Vector3(-1, 1, 1);
//            isWalking = true;
//        }

//        Debug.Log("isWalking: " + isWalking);

//        anim.SetBool("IsWalking", isWalking);

//        if (isJumping && jumpCount < maxJumpCount)
//        {
//            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
//            isJumping = false;
//            jumpCount++;
//            anim.SetBool("IsJumping", true);
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Border"))
//        {
//            jumpCount = 0;
//        }
//    }

//    public void SetMoveRight(bool value)
//    {
//        isMovingRight = value;
//        anim.SetBool("IsWalking", isMovingRight); // 오른쪽 이동 버튼을 누를 때만 애니메이션 재생
//        anim.SetBool("IsJumping", false); // 점프 애니메이션 정지
//    }

//    public void SetMoveLeft(bool value)
//    {
//        isMovingLeft = value;
//        anim.SetBool("IsWalking", isMovingLeft); // 왼쪽 이동 버튼을 누를 때만 애니메이션 재생
//        anim.SetBool("IsJumping", false); // 점프 애니메이션 정지
//    }

//    public void StopMoving()
//    {
//        isMovingRight = false;
//        isMovingLeft = false;
//        anim.SetBool("IsWalking", false); // 모든 이동 애니메이션 정지
//    }

//    public void Jump()
//    {
//        if (jumpCount < maxJumpCount)
//        {
//            isJumping = true;
//            anim.SetBool("IsJumping", true); // 점프 버튼을 누를 때만 점프 애니메이션 재생
//            anim.SetBool("IsWalking", false); // 이동 애니메이션 정지
//        }
//    }
//}



