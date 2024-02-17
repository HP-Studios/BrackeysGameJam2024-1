using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private TextMeshPro healthName;
    private int health = 3;
    private int maxHealth = 3;
    private void Awake()
    {

        healthName = gameObject.GetComponentInChildren<TextMeshPro>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            healthName.text = "Health: " + health + "/" + maxHealth;
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        Transform player = Camera.main.transform;
        healthName.transform.LookAt(2 * healthName.transform.position - player.position);
    }

}
