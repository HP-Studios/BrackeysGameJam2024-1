using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    private SphereCollider col;

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
    }
    IEnumerator DestroyBall()
    {
        col.enabled = false;
        particles.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }

    private void OnMouseDown()
    {

        StartCoroutine(DestroyBall());
    }
}
