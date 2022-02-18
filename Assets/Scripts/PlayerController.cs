using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    IDictionary<string,int> GemD;
    Rigidbody2D rb;
    BoxCollider2D col;
    private bool OnGround; 
    [SerializeField]
    private LayerMask jumpableGround;
     [SerializeField]
    private float JumpForce;
     [SerializeField]
    private float Speed,s;
    private Animator anim;
    private Vector2 colOffset;
   
    private float colSizeY;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        col=GetComponent<BoxCollider2D>();
        sprite=GetComponent<SpriteRenderer>();
        GemD=GameManager.Instance.GemD;

        
    }
    void OnCollisionEnter2D(Collision2D c)
    {
          if(c.collider.gameObject.CompareTag("BigBall"))
        {
            
            GameManager.Instance.DecreaseLife(GameManager.Instance.GetCurrentLives());
            GameManager.Instance.ShowLife();
            
       }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Acid"))
        {
            GameManager.Instance.DecreaseLife(GameManager.Instance.GetCurrentLives());
            GameManager.Instance.ShowLife();
            
        }
        if(collision.gameObject.CompareTag("Axe"))
        {
            GameManager.Instance.DecreaseLife();
            GameManager.Instance.DecreaseLife();
            GameManager.Instance.ShowLife();
            
        }
        if(collision.gameObject.CompareTag("Snake"))
        {
            GameManager.Instance.DecreaseLife();
            GameManager.Instance.DecreaseLife();
            GameManager.Instance.DecreaseLife();
            GameManager.Instance.ShowLife();
            
        }
        if(collision.gameObject.CompareTag("Robot"))
        {
            GameManager.Instance.DecreaseLife(GameManager.Instance.GetCurrentLives());
            GameManager.Instance.ShowLife();
            
        }
         if(collision.gameObject.CompareTag("BigBall"))
        {
            GameManager.Instance.DecreaseLife(GameManager.Instance.GetCurrentLives());
            GameManager.Instance.DecreaseLife();
            GameManager.Instance.ShowLife();
            
        }
         if(collision.gameObject.CompareTag("Ametist"))
        {
            
   GemD["Ametist"]++;  Destroy(collision.gameObject);
   GameManager.Instance.IncreaseLife();
    GameManager.Instance.IncreaseLife();
        }
          if(collision.gameObject.CompareTag("Coin"))
        {
             
   GemD["Coin"]++;  Destroy(collision.gameObject);
    GameManager.Instance.IncreaseLife();
        }  if(collision.gameObject.CompareTag("Saphire"))

        {
           GameManager.Instance.IncreaseLife(); 
           GameManager.Instance.IncreaseLife();
           GameManager.Instance.IncreaseLife();
   GemD["Saphire"]++;  Destroy(collision.gameObject);
 // GameManager.Instance.ShowGems(); 
        }  if(collision.gameObject.CompareTag("Ruby"))
        {
           GameManager.Instance.IncreaseLife();
           GameManager.Instance.IncreaseLife();
   GemD["Ruby"]++; Destroy(collision.gameObject);
        }  if(collision.gameObject.CompareTag("Emerald"))
        {
            GameManager.Instance.IncreaseLife();
            
   GemD["Emerald"]++;  Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Trophy"))
        {
            if(SceneManager.GetActiveScene().buildIndex!=2)
             GameManager.Instance.LoadNextScene();
             else  GameManager.Instance.LoadThanksScene();
        }
         if(collision.gameObject.CompareTag("Lightning"))
        {
             GameManager.Instance.DecreaseLife();
            GameManager.Instance.ShowLife();
        }
        
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
       public void LoadGameOverScene()
    {
         SceneManager.LoadScene(5);
    }
    void Die()
    {
        anim.SetTrigger("Death");
        rb.bodyType=RigidbodyType2D.Static;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>0&&transform.position.x<65)
        {
            if(!GameManager.Instance.soundBall.isPlaying)
            GameManager.Instance.soundBall.Play();
        }else if(transform.position.x>65&&transform.position.x<123)
        {  GameManager.Instance.soundBall.Stop();
          if(!GameManager.Instance.soundAxe.isPlaying)
            GameManager.Instance.soundAxe.Play();
        } else if(transform.position.x>123&&transform.position.x<144)
        {
              if(!GameManager.Instance.soundAxe.isPlaying)
              GameManager.Instance.soundAxe.Stop();
               if(!GameManager.Instance.soundSnake.isPlaying)
            GameManager.Instance.soundSnake.Play();
        }
        else if(transform.position.x>144&&transform.position.x<170)
        {
              GameManager.Instance.soundSnake.Stop();
                 if(!GameManager.Instance.soundRobot.isPlaying)
            GameManager.Instance.soundRobot.Play();
        }
        if(!GameManager.Instance.IsAlive)
        {
          //  Destroy(gameObject);
            return;
        }
        if(rb.velocity.x==0)
        {
            anim.SetBool("Running",false);
        }
        if(rb.velocity.y==0)
        {
            OnGround=true;
            anim.SetBool("Jump",false);
            anim.SetBool("Falling",false);
        }
        if(rb.velocity.y<0)
        {
            OnGround=true;
            anim.SetBool("Falling",true);
            anim.SetBool("Jump",false);
        }
        if(Input.GetKeyDown(KeyCode.W)&&IsGrounded())
        {
           rb.velocity=new Vector2(rb.velocity.x,JumpForce);
           anim.SetBool("Jump",true);
           
        }
        if(Input.GetKey(KeyCode.D))
        {
           anim.SetBool("Running",true);
           sprite.flipX=false;
           s=Speed;
           rb.velocity=new Vector2(s,rb.velocity.y);
        }
        if(Input.GetKey(KeyCode.L))
        {
         GameManager.Instance.LoadCurrentScene();
        }
        if(Input.GetKey(KeyCode.A))
        {
           sprite.flipX=true; 
           anim.SetBool("Running",true);
           s=-Speed;
           rb.velocity=new Vector2(s,rb.velocity.y);
        }
        if(Input.GetKey(KeyCode.C))
        {
            anim.SetBool("Sliding",true);
            rb.velocity=new Vector2(s*1.5f,rb.velocity.y);
            colSizeY=col.size.y;
            //print(colSizeY);
            colOffset=col.offset;
            col.size = new Vector2(col.size.x, 0.5f);
            col.offset= new Vector2(col.offset.x,-0.98f);
            Invoke("SlideOff",0.8f);
        }
          if(Input.GetKeyDown(KeyCode.F))
        {
            float offset=1.0f;
            bool flip=true;
            if(s<0)
            {
                offset*=-1.0f; flip=false;
            }
        GameObject go=Instantiate(GameManager.Instance.Fireball, new Vector3(transform.position.x+offset, transform.position.y+0.35f, 0), Quaternion.identity);
        Rigidbody2D rigidbody2D=go.GetComponent<Rigidbody2D>();
        SpriteRenderer spriteRenderer=go.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX=flip;
        rigidbody2D.velocity=new Vector2(s*GameManager.Instance.fireBallSpeed,rigidbody2D.velocity.y);
        }
    }
    void SlideOff()
    {   //print(colSizeY);
        col.size=new Vector2(col.size.x,2.31f);  col.offset=new Vector2(col.offset.x,-0.01494968f);
        anim.SetBool("Sliding",false);
    }
    bool IsGrounded()
    {
       return Physics2D.BoxCast(col.bounds.center,col.bounds.size,0.0f,Vector2.down,0.01f,jumpableGround);
    }
}
