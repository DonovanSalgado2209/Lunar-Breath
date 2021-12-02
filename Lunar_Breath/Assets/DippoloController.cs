using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DippoloController : MonoBehaviour
{
    public float velocidad = 2f;
    public float maxVelocidad = 5f;
    public bool grounded;

    public float jumpPower = 6.5f;
   
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         anim.SetBool("Grounded", grounded);
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                jump = true;
            }
        

        anim.SetFloat("Velocidad", Mathf.Abs(rb2d.velocity.x));
        

        Ataque();
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * velocidad * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxVelocidad, maxVelocidad);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
    
        if(h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
        
    }
    public void Ataque()
    {

        if (Input.GetKeyDown("space"))
        {
            anim.SetBool("Ataque", true);
        }
        else
        {
            anim.SetBool("Ataque", false);
        }
      
    
    }
   
    
 
}