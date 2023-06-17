using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;

    float walkSpeed = 0.03f;
    private float gravity = -9.81f;
    private Vector3 moveDirection = Vector3.zero;
    float jumpSpeed = 1.0f;

    bool isjumping;

    // Start is called before the first frame update
    void start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space)==true)
        //{
        //    animator.SetBool("isJumping");
        //    rigid.AddForce(transform.up * jumpSpeed);
        //}

        //if(Input.GetButtonDown("Jump"))
        //{
        //    rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}

        //if (Input.GetKey(KeyCode.Space) && transform.position.y <= -3.63f)
        //{
        //    animator.SetTrigger("isJumping");
        //    rigid.AddForce(transform.up * jumpSpeed);
        //}

        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
        //ม฿ทย
        moveDirection.y += gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            rigid.AddForce(-transform.right * walkSpeed);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            rigid.AddForce(transform.right * walkSpeed);
            transform.localScale = new Vector3(1.0f, 1.0f, 1);
        }
    }
}
