using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private TextMeshPro healthName;
    private int health = 3;
    private int maxHealth = 3;
    public float moveDistance = 5f;

    void Start()
    {
        StartCoroutine(MoveRandomly());
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            MoveInRandomDirection();
            yield return new WaitForSeconds(1f); // Add a delay for a more realistic effect
        }
    }

    void MoveInRandomDirection()
    {
        string[] directions = { "up", "down", "left", "right" };
        string direction = directions[Random.Range(0, directions.Length)];
        Vector3 movement = Vector3.zero;

        switch (direction)
        {
            case "up":
                movement = Vector3.up;
                break;
            case "down":
                movement = Vector3.down;
                break;
            case "left":
                movement = Vector3.left;
                break;
            case "right":
                movement = Vector3.right;
                break;
        }

        transform.Translate(movement * moveDistance);
        Debug.Log($"Enemy moves {moveDistance} units {direction}.");
    }
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
