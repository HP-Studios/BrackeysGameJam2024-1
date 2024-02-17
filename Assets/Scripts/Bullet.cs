using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
      
        gameObject.GetComponent<SphereCollider>().enabled = false;
        StartCoroutine(WaitFor2Seconds());
        
    }
    IEnumerator WaitFor2Seconds()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
