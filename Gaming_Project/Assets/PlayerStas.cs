using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Reflection;



public class PlayerStas : MonoBehaviour
{
    public static int health=3;
    public static int lives=3;
    public static int score=0;
    public static bool hasHeart=false;
    private float flickertime=0f;
    public float flickerduration=0.1f;
    private SpriteRenderer sr;
    public bool isTmmune= false;
    private float immunityTime=0f;
    public float immunityDuration=1.5f;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;
    public Image healthBar;

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
        scoreUI.text=" "+ score;
        livesUI.text= " "+lives;
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
            healthBar.fillAmount = health/3f;
            if(health<0)
            {
                health=0;
            }
            if(lives>0 && health==0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                health=3;
                healthBar.fillAmount = health/3f;
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
