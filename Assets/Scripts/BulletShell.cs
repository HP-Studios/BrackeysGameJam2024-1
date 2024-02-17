using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitFor2Seconds());

    }

    
    IEnumerator WaitFor2Seconds()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
