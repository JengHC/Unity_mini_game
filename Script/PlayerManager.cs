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


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // ���� ���� Rigidbody�� ���� 
            isJumping = true; // ���� ������ ��Ÿ���� �÷��� ����
            jumpCount++;
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            isJumping = false;
        }
        anim.SetBool("IsJumping", isJumping); // "IsJumping" �Ű������� true�� �����Ͽ� ���� �ִϸ��̼� ���
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
// �Ʒ� ���ʹ� ����� ����
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerManager : MonoBehaviour
//{
//    public float playerSpeed = 2; // �÷��̾� �ӵ�
//    public float jumpPower = 3;
//    Rigidbody2D rigid;    // ������ٵ� ����
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
//    public float playerSpeed = 2; // �÷��̾� �ӵ�
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
//        anim.SetBool("IsWalking", false); // �ʱ⿡�� �ִϸ��̼��� ���� ���·� ����
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
//        anim.SetBool("IsWalking", isMovingRight); // ������ �̵� ��ư�� ���� ���� �ִϸ��̼� ���
//        anim.SetBool("IsJumping", false); // ���� �ִϸ��̼� ����
//    }

//    public void SetMoveLeft(bool value)
//    {
//        isMovingLeft = value;
//        anim.SetBool("IsWalking", isMovingLeft); // ���� �̵� ��ư�� ���� ���� �ִϸ��̼� ���
//        anim.SetBool("IsJumping", false); // ���� �ִϸ��̼� ����
//    }

//    public void StopMoving()
//    {
//        isMovingRight = false;
//        isMovingLeft = false;
//        anim.SetBool("IsWalking", false); // ��� �̵� �ִϸ��̼� ����
//    }

//    public void Jump()
//    {
//        if (jumpCount < maxJumpCount)
//        {
//            isJumping = true;
//            anim.SetBool("IsJumping", true); // ���� ��ư�� ���� ���� ���� �ִϸ��̼� ���
//            anim.SetBool("IsWalking", false); // �̵� �ִϸ��̼� ����
//        }
//    }
//}



