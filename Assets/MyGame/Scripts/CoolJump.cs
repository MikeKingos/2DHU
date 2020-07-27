using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolJump : MonoBehaviour
{
    public float speed = 8f;
    public float jump = 9f;
    private Rigidbody2D rb;
    private float moveInput;


    private bool isGrounded;
    public Transform feetpos;
    public float checkradius;
    public LayerMask whatisGround;

    private float jtc;
    public float jt;
    private bool isj;



    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


    }
    private void Update()
    {

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkradius, whatisGround);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            anim.SetTrigger("takeOf");
            isj = true;
            jtc = jt;
            rb.velocity = Vector2.up * jump;




        }
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }






        else { anim.SetBool("isJumping", true); }
        if (Input.GetKey(KeyCode.UpArrow) && isj == true)
        {
            if (jtc > 0)
            {
                rb.velocity = Vector2.up * jump;
                jtc -= Time.deltaTime;
            }
            else
            {

                isj = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isj = false;
        }
    }
}