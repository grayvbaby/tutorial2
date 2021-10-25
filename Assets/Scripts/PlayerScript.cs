using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    
    public Text score;
    public Text winText;
    public Text livesText;
    public Text loseText;
    
    private int scoreValue = 0;
    private int lives;
    private bool facingRight = true;
    Animator anim;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    // Start is called before the first frame update
    void Start()
        {
        musicSource.clip = musicClipTwo;
        musicSource.Play();
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        lives = 3;
        anim = GetComponent<Animator>();

  
        
        if (scoreValue == 8) 
            {   
                musicSource.clip = musicClipTwo;
                musicSource.Stop();
            }
        }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
            {
         scoreValue += 1;
         score.text = scoreValue.ToString();        
         Destroy(collision.collider.gameObject);
            }

        if(collision.collider.tag == "EnemyCoin")
            {
         lives -= 1;
         livesText.text = "Lives: " + lives;        
         Destroy(collision.collider.gameObject);
            }

        if (scoreValue == 4) 
            {
            transform.position = new Vector2(37f, 9.0f); 
            }
         
    if (scoreValue == 8)
        {
        winText.text = "You Win! -Gray";
        gameObject.SetActive (false);
        }    

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Floor")
            {
            if(Input.GetKey(KeyCode.W))
                {
                rd2d.AddForce(new Vector2(0, 3),ForceMode2D.Impulse);
                }
            }
        
    }

   void Update()
   {

       if (Input.GetKeyDown(KeyCode.W))
            {
           anim.SetInteger("State",3);
            }

       if (Input.GetKeyDown(KeyCode.D))
            {
           anim.SetInteger("State",1);
            }

       if (Input.GetKeyDown(KeyCode.A))
            {
           anim.SetInteger("State",1);
            }

       if (Input.GetKeyDown(KeyCode.LeftShift))
            {
              if (Input.GetKeyDown(KeyCode.D))
               {
               anim.SetInteger("State",2);
               }
            }   

       if (Input.GetKeyDown(KeyCode.LeftShift)) 
            {
              if (Input.GetKeyDown(KeyCode.A)) 
               {
               anim.SetInteger("State",2);
               }
            }   

        if (Input.GetKeyUp(KeyCode.D)) 
            {
                anim.SetInteger("State",0);
            }
        if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("State",0);
            }
        if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetInteger("State",0);
            }    
        if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("State",0);
            }     
        if (facingRight == false && Input.GetKeyDown(KeyCode.D))
            {
                Flip();
            }
            else if (facingRight == true && Input.GetKeyDown(KeyCode.A))
            {
                Flip();
            }
       if (lives == 0)
        {
            loseText.text = "You Lose :( -Gray";
            gameObject.SetActive (false);
        }

            score.text = "Count: " + scoreValue.ToString();
    

    

        
    if (Input.GetKey("escape"))
      {
          Application.Quit();
      }
    }

void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x*-1;
        transform.localScale = Scaler;
    }
   }

