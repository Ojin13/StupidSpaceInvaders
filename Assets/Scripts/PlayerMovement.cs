using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public bool isMoving;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public float shootingSpeed;
    private bool isShooting;

    public GameObject fireSpawnerLeft;
    public GameObject fireSpawnerRight;
    public GameObject fire;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager.status != "playing"){
            isShooting = false;
            isMoving = false;
            return;
        }

        isMoving = false;

        // Go left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0);
            isMoving = true;
        }

        // Go right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
            isMoving = true;
        }

        // Shoot
        if (Input.GetKey(KeyCode.Space))
        {
            if(isShooting == false){
                InvokeRepeating("Shoot", 0f, shootingSpeed);
            }

            isShooting = true;
        }else{
            isShooting = false;
            CancelInvoke();
        }


        // Shoot Laser
        if (Input.GetKeyDown(KeyCode.F) && GameManager.gameManager.freeLaser > 0)
        {
            GameManager.gameManager.freeLaser--;
            isShooting = false;
            CancelInvoke();
            Instantiate(laser, bulletSpawnPoint.transform.position+new Vector3(0,1,0), Quaternion.identity);
            AudioManager.audioManager.PlayLaserShotSound();

        }

        if(isMoving){
            GameObject fire_1 = Instantiate(fire, fireSpawnerLeft.transform.position+new Vector3(0,Random.Range(0,0.2f),0), Quaternion.identity);
            GameObject fire_2 = Instantiate(fire, fireSpawnerRight.transform.position+new Vector3(0,Random.Range(0,0.2f),0), Quaternion.identity);
        }
    }

    public void Shoot(){
        if(isShooting){
            Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
            AudioManager.audioManager.PlayBulletShotSound();
        }
    }
}
