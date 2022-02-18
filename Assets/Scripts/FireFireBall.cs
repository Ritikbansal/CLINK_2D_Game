using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFireBall : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Animator animator;
   // SpriteRenderer spriteRenderer;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
       //spriteRenderer=GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Die");
        rb.isKinematic = true;
        Invoke("Destroy",GameManager.Instance.FireBallDieTime);
    }
    void Destroy()
    {
        Object.Destroy(gameObject);
    }
    void DestroyAfterTime()
    {
        animator.SetTrigger("Die");
        rb.isKinematic = true;
        Invoke("Destroy",GameManager.Instance.FireBallDieTime);
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyAfterTime",GameManager.Instance.FireBallDestoryTime-GameManager.Instance.FireBallDieTime);
      // Object.Destroy(gameObject, GameManager.Instance.FireBallDestoryTime); 
    }
}
