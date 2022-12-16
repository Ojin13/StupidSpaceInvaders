using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int HP;
    public GameObject destroyParticles;
    public GameObject hitParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -3){
            GameManager.gameManager.status = "lost";
        }
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Bullet" || col.collider.tag == "Laser"){

            Instantiate(hitParticles, transform.position, Quaternion.identity);
            if(col.collider.tag == "Bullet"){
                HP--;
            }else{
                HP -= 2;
            }

            if(HP <= 0){
                Instantiate(destroyParticles, transform.position, Quaternion.identity);
                GameManager.gameManager.numberOfEnemies--;
                AudioManager.audioManager.PlayDeadSound();
                Destroy(gameObject);
            }else{
                AudioManager.audioManager.PlayDamageSound();
            }

            if(col.collider.tag == "Bullet"){
                Destroy(col.gameObject);
            }

        }else if(col.collider.tag == "Player"){
           GameManager.gameManager.status = "lost";
           Instantiate(destroyParticles, col.gameObject.transform.position, Quaternion.identity);
           AudioManager.audioManager.PlayYouLoseSound();
           Destroy(col.gameObject);
        }
    }

}
