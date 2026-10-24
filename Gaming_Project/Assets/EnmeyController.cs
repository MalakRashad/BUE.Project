using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyController : MonoBehaviour
{
   public float maxSpeed=2;
   public int damage=1;
   public SpriteRenderer sr;
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void flip()
    {
        sr.flipX =!sr.flipX;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            FindObjectOfType<PlayerStas>().TakeDamage(damage);
            flip();
        }
        else if(other.tag=="Wall")
        {
            flip();
        }
    }
}
