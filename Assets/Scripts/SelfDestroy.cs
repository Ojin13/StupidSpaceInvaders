using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    public float timeToLive;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Suicide());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Suicide()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}
