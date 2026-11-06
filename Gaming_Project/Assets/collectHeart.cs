using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectHeart : MonoBehaviour
{
   public AudioClip heartSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerenter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            PlayerStas.lives++;
            PlayerStas.hasHeart=true;
            AudioManager.Instance.PlayMusicSFX(heartSound);
            Destroy(gameObject);
        }
    }
}
