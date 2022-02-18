using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCollider : MonoBehaviour
{
    // Start is called before the first frame update
    PolygonCollider2D polygonCollider2D;
    void Start()
    {
        polygonCollider2D=GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    public void ToggleColliderF()
    {
        polygonCollider2D.enabled=!polygonCollider2D.enabled;
    }
}
