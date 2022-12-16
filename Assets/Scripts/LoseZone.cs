using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<BoxCollider2D>().tag == "Enemy"){
            if(GameManager.gameManager.status == "playing"){
                AudioManager.audioManager.PlayYouLoseSound();
            }
            
            GameManager.gameManager.status = "lost";
        }
    }
}
