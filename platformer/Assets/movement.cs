using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float speed;
    public float Jump;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool wallright;
    private bool wallleft;
    public LayerMask whatIsWall;
    public float radius;
    public Transform groundCheck;
    public Transform wallCheck;
    public Transform wallCheckleft;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;
    private int Jumps;
    public int jumpsvalue;
    private bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Jumps = jumpsvalue;
       

    }

  void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody.name == "Enemy")
        {
            Debug.Log("got here");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
       

    // Update is called once per frame
    void Update()
    {
        wallright = Physics2D.OverlapCircle(wallCheck.position, radius, whatIsWall);
        wallleft = Physics2D.OverlapCircle(wallCheckleft.position, radius, whatIsWall);

        if (wallright == true)
        {
          if  (Input.GetKeyDown(KeyCode.W)){

                rb.velocity = Vector2.up * Jump;
            }
        }
        if (wallleft == true)
        {
           if (Input.GetKeyDown(KeyCode.W)){

                rb.velocity = Vector2.up * Jump;
            }
     
        }
        if (Input.GetKeyDown(KeyCode.W) && Jumps > 0)
        {
            rb.velocity = Vector2.up * Jump;
            Jumps--;
        }
        if(isGrounded == true)
        {
            Jumps = jumpsvalue;
        }
        else if (Input.GetKeyDown(KeyCode.W) && Jumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * Jump;
        }
    }
    void FixedUpdate()
    {
        if(facingRight == false && moveInput > 0) {
            Flip(); }
        else if(facingRight == false && moveInput < 0)
        {
            Flip();
        }
       
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
