using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class SlimeEnmey : EnmeyController
{
    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
        sr.flipX=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(sr.flipX==true)
        {
            this.GetComponent<Rigidbody2D>().velocity=new Vector2(maxSpeed,this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity=new Vector2(-maxSpeed,this.GetComponent<Rigidbody2D>().velocity.y);
            
        }
    }
}
