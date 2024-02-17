using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
      
        gameObject.GetComponent<SphereCollider>().enabled = false;
        StartCoroutine(WaitFor2Seconds(collision));
        
    }
    IEnumerator WaitFor2Seconds(Collision collision)
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
