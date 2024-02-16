using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] BoxCollider saver;
    AudioSource popSource;
    private SphereCollider col;
    bool hiddenBall;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(16, 2, 0);
    }
    private void Awake()
    {
        col = GetComponent<SphereCollider>();
        popSource = GetComponent<AudioSource>();
    }
    IEnumerator DestroyBall()
    {
        col.enabled = false;
        popSource.Play();
        particles.Play();
        yield return new WaitForSeconds(1f);
        
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (hiddenBall)
        {

        }
        else
        {
            StartCoroutine(DestroyBall());
        }
    }
}
