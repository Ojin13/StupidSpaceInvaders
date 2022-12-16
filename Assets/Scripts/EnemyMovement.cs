using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 0.1f;
    public string direction = "left";
    public float boundLeftX;
    public float buondRightX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == "left"){
            transform.position -= new Vector3(speed, 0, 0);

            if(transform.position.x <= boundLeftX){
                direction = "right";
            }
        }else{
            transform.position += new Vector3(speed, 0, 0);

            if(transform.position.x >= buondRightX){
                direction = "left";
            }
        }

        transform.position -= new Vector3(0, speed/20, 0);
    }
}
