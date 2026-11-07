using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip coin1;
    public AudioClip coin2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
        PlayerStas.score++;
        AudioManager.Instance.PlayRandomSFX(coin1,coin2);
        Debug.Log("Score: "+PlayerStas.score);
        Destroy(gameObject);
        Debug.Log(gameObject);
        }
    }
}
