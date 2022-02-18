using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveSpeed=1.0f;
     [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private float offset;
    private Vector2 startPosition;
    private float newXposition;
    void Start()
    {
        startPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newXposition=Mathf.Repeat(Time.time*-moveSpeed,offset);
        transform.position=startPosition+Vector2.right*newXposition+new Vector2(playerPos.position.x,0.0f);
        
    }
}
