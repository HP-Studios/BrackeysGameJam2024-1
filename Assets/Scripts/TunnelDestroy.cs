using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelDestroy : MonoBehaviour
{
    [SerializeField] GameObject Tunnel;
    [SerializeField] GameObject colliderBehind;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colliderBehind.SetActive(true);
            Destroy(Tunnel);
        }
    }
}
