using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager audioManager;
    public AudioSource audioSource;

    public AudioClip buttonClickSound;
    public AudioClip laserShotSound;
    public AudioClip bulletSound;
    public AudioClip deadSound;
    public AudioClip damageSound;
    public AudioClip winSound;
    public AudioClip loseSound;

    void Awake()
    {
        audioManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayButtonClickSound(){
        audioSource.PlayOneShot(buttonClickSound);
    }


    public void PlayLaserShotSound(){
        audioSource.PlayOneShot(laserShotSound);
    }

    public void PlayBulletShotSound(){
        audioSource.PlayOneShot(bulletSound);
    }

    public void PlayDeadSound(){
        audioSource.PlayOneShot(deadSound);
    }

    public void PlayDamageSound(){
        audioSource.PlayOneShot(damageSound);
    }

    public void PlayYouWinSound(){
        audioSource.PlayOneShot(winSound);
    }

    public void PlayYouLoseSound(){
        audioSource.PlayOneShot(loseSound);
    }
}
