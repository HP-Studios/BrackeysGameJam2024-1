using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private TextMeshPro healthName;
    private int health = 3;
    private int maxHealth = 3;
    public float moveForce = 10f;
    public float maxSpeed = 5f;

    Material[] materials;
    [SerializeField] GunRoomWin winScript;

    private Renderer rend;
    private Color originalColor;

    private Rigidbody rb;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        originalColor = rend.material.color;
        rb = GetComponent<Rigidbody>();
        ApplyRandomForce();
        materials = rend.materials;

    }

    void ApplyRandomForce()
    {
        Vector3 randomDirection = Random.onUnitSphere; // Random point on the surface of a sphere
        rb.AddForce(randomDirection * moveForce, ForceMode.Impulse);
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
            StartCoroutine(ChangeColor());
            healthName.text = "Health: " + health + "/" + maxHealth;
            if(health == 0)
            {
                winScript.botLeftToKill--;
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        Transform player = Camera.main.transform;
        healthName.transform.LookAt(2 * healthName.transform.position - player.position);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        ApplyRandomForce();
    }

    IEnumerator ChangeColor()
    {
        if (rend != null)
        {
            rend.material.SetColor("_Color", Color.red);
            materials[2].SetColor("_Color", Color.red);
        }

        yield return new WaitForSeconds(0.3f);
        if (rend != null)
        {
            rend.material.SetColor("_Color", originalColor);
            materials[2].SetColor("_Color", originalColor);

        }
    }
}
