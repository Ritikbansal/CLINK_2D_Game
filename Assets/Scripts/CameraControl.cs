using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]
    private Transform player;
     [SerializeField]
    private float offset;
    void Start()
    {
       ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(player.position.x,player.position.y-offset,transform.position.z);
    }
}
