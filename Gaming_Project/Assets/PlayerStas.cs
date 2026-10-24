using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PlayerStas : MonoBehaviour
{
    public int health=3;
    public int lives=3;
    private float flickertime=0f;
    public float flickerduration=0.1f;
    private SpriteRenderer sr;
    public bool isTmmune= false;
    private float immunityTime=0f;
    public float immunityDuration=1.5f;

    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTmmune==true)
        {
            SpriteFlicker();
            immunityTime=immunityTime+Time.deltaTime;
            if(immunityTime>=immunityDuration)
            {
                isTmmune=false;
                sr.enabled=true;
            }
        }
    }
    void SpriteFlicker()
    {
        if(flickertime < flickerduration)
        {
            flickertime=flickertime+ Time.deltaTime;
        }
        else if(flickertime>=flickerduration)
        {
            sr.enabled=!(sr.enabled);
            flickertime=0;
        }
    }
    public void TakeDamage(int damage)
    {
        if(isTmmune==false)
        {
            health = health - damage;
            if(health<0)
            {
                health=0;
            }
            if(lives>0 && health==0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health=3;
                lives--;
            }
            else if(lives==0 && health==0)
            {
                Debug.Log("GameOver");
                Destroy(this.gameObject);
            }
            
            Debug.Log("Player Health: "+health.ToString());
            Debug.Log("Player lives: "+lives.ToString());
        }
        isTmmune=true;
        immunityTime=0f;
    }
}
