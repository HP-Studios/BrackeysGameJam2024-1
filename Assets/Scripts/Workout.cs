using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Workout : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI crouchAmountText;
    int crouchAmount;
    [SerializeField] int targetCrouchAmount;
    bool inSquatArea;
    [SerializeField] BoxCollider box;
    [SerializeField] GameObject squatBarbell;
    private Rigidbody barbellRB;

    private Vector3 barbellPosition;
    // Start is called before the first frame update
    void Start()
    {
        inSquatArea = false;
        barbellRB = squatBarbell.GetComponent<Rigidbody>();
        barbellPosition = squatBarbell.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && crouchAmount != targetCrouchAmount && inSquatArea)
        {
            crouchAmount++;
            crouchAmountText.text = crouchAmount + "/" + targetCrouchAmount;
        }
        else if (!inSquatArea)
        {
            barbellRB.useGravity = true;
            squatBarbell.gameObject.transform.position = barbellPosition;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Squat"))
        {
            inSquatArea = false;
            barbellRB.useGravity = true;
            squatBarbell.gameObject.transform.position = barbellPosition;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Squat"))
        {
            barbellRB.useGravity = false;
            inSquatArea = true;
            Vector3 playerPosition = transform.position;
            Vector3 offset = new Vector3(0, 1, 0);
            squatBarbell.transform.position = playerPosition + offset;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Squat"))
        {
            Vector3 playerPosition = transform.position;
            Vector3 offset = new Vector3(0, 1, 0);
            squatBarbell.transform.position = playerPosition + offset;
        }
    }
}
