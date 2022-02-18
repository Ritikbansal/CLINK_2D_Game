using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Rigidbody2D rigidbody;
    void Start()
    {
        animator=GetComponent<Animator>();
        rigidbody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.velocity.x==0)
        {
            animator.enabled=false;
        }
    }
}
