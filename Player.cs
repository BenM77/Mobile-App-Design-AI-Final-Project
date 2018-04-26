using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed = 10f;
    public int maxHealth;
    int health;

    public Image healthBar;

    Animator playerAnimator;

    public GameManager theGameManager;

    public Text healthText; 

    [HideInInspector] public bool facingRight = true;

    FloatingJoystick theJoystick;

    Animator anim;

    bool grounded = false;

    public float jumpForce = 1500f;

    Rigidbody2D playerRB2D;

    bool doubleJump = false;

    public float fallMultiplier = 2.5f;
    public float riseMultiplier = .5f;

    void Start()
    {
        //anim = GetComponent<Animator>();
        playerRB2D = GetComponent<Rigidbody2D>();
        playerRB2D.velocity = new Vector2(0, 0);
        theJoystick = FindObjectOfType<FloatingJoystick>();
        playerAnimator = GetComponent<Animator>();
        health = maxHealth;
    }

    void FixedUpdate()
    {
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;


        //anim.SetFloat("vSpeed", playerRB2D.velocity.y);

        //float move = Input.GetAxis("Horizontal");
        //float move = theJoystick.getDirection();
        float move = theJoystick.Horizontal;

        //anim.SetFloat("Speed", Mathf.Abs(move));

        playerRB2D.velocity = new Vector2(move * maxSpeed, playerRB2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (move != 0)
            playerAnimator.SetBool("Running", true);
        else
            playerAnimator.SetBool("Running", false);
    }

    void Update()
    {
        healthBar.fillAmount = (float)health / maxHealth;

        //jump
        if (playerRB2D.velocity.y < 0)
        {
            playerRB2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRB2D.velocity.y > 0)// && !Input.GetButton("Jump Button"))
        {
            playerRB2D.velocity += Vector2.up * Physics2D.gravity.y * (riseMultiplier - 1) * Time.deltaTime;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public void jump()
    {
        if ((grounded || !doubleJump))
        {
            //anim.SetBool("Grounded", false);
            playerRB2D.AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !grounded)
                doubleJump = true;

            grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//reset the jump counts
        {
            grounded = true;
            doubleJump = false;
        }
        else if (collision.gameObject.tag == "Enemy")
            doubleJump = false;
    }

    public void takeDamage(int dmgToTake)
    {
        if (dmgToTake >= health)
        {
            health = 0;
            healthText.text = "Player Health:\n" + health;
            theGameManager.GameOver(this.gameObject);
            //this.enabled = false;
        }
        else
        {
            health = health - dmgToTake;
            healthText.text = "Player Health:\n" + health;
        }
    }
}
