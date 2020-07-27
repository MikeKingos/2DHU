using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    
    public float speed;
    public float jumpForce;
    private float moveInput;
    

    private Rigidbody2D rb;

    private bool facingRight = true;
    public GameObject gameOverText, restartButton,SFX;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

   
    void Start(){
        extraJumps = extraJumpsValue; 
        rb = GetComponent<Rigidbody2D>();
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
       

    }

    void FixedUpdate() {
        


                isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0) {
            Flip(); 
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }

    }


    void Update(){
       
        if (isGrounded == true) {
            extraJumps = extraJumpsValue;
        }
       
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps --;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;

        }
    }


    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

       void OnCollisionEnter2D (Collision col)
        {
            if(col.gameObject.tag.Equals("enemy"))
            {
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                Instantiate(SFX, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
    }
}


