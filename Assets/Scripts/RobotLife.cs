using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLife : MonoBehaviour
{
    // Start is called before the first frame update
    //Rigidbody2D rb;
    Animator animator;
   // SpriteRenderer spriteRenderer;
    void Start()
    {
        //rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
       //spriteRenderer=GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FireBall"))
        {
        animator.SetTrigger("Die");
        //rb.isKinematic = true;
        Invoke("Destroy",GameManager.Instance.RobotDieTime);
        }
    }
    void Destroy()
    {
        Object.Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
