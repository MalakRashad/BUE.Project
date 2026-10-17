using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentChekpoint;
    void Start()
    {
        CurrentChekpoint=null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        FindObjectOfType<Player_Script>().transform.position= CurrentChekpoint.transform.position;
    }
}
