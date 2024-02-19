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
    [SerializeField] GameObject squatBarbell;
    private Vector3 squatBarbellPosition;

    [SerializeField] TextMeshProUGUI deadliftText;
    int deadliftAmount;
    [SerializeField] int targetDeadliftAmount;
    bool inDeadliftArea;
    [SerializeField] GameObject deadliftBarbell;
    private Vector3 deadliftBarbellPosition;

    [SerializeField] TextMeshProUGUI jumpAmountText;
    [SerializeField] private int targetJumpAmount;
    private CharacterController characterController;
    int jumpAmount;


    [SerializeField] private GameObject gymPrize;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gymPrize.SetActive(false);
        inSquatArea = false;
        inDeadliftArea = false;
        squatBarbellPosition = squatBarbell.gameObject.transform.position;
        deadliftBarbellPosition = deadliftBarbell.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (crouchAmount == targetCrouchAmount && deadliftAmount == targetDeadliftAmount && jumpAmount == targetJumpAmount) //Wins here
        {
            gymPrize.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.C) && crouchAmount != targetCrouchAmount && inSquatArea)
        {
            crouchAmount++;
            crouchAmountText.text = "Squat:  " + crouchAmount + "/" + targetCrouchAmount;
        }
        else if (!inSquatArea)
        {
            squatBarbell.gameObject.transform.position = squatBarbellPosition;
        }

        if (Input.GetKeyUp(KeyCode.C) && deadliftAmount != targetDeadliftAmount && inDeadliftArea)
        {
            deadliftAmount++;
            deadliftText.text = "Deadlift:  " + deadliftAmount + "/" + targetDeadliftAmount;
        }
        else if (!inDeadliftArea)
        {
            deadliftBarbell.gameObject.transform.position = deadliftBarbellPosition;
        }

        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded && jumpAmount != targetJumpAmount)
        {
            jumpAmount++;
            jumpAmountText.text = "Jumping Jacks:  " + jumpAmount + "/" + targetJumpAmount;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && characterController.isGrounded && jumpAmount != targetJumpAmount)
        {
            jumpAmount++;
            jumpAmountText.text = "Squat:  " + jumpAmount + "/" + targetJumpAmount;
        }
    }

    #region Triggers for Deadlift and Squat

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Squat"))
        {
            inSquatArea = false;
            squatBarbell.gameObject.transform.position = squatBarbellPosition;

        }
        else if (other.gameObject.CompareTag("Deadlift"))
        {
            inDeadliftArea = false;
            deadliftBarbell.gameObject.transform.position = deadliftBarbellPosition;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Squat"))
        {
            inSquatArea = true;
            Vector3 playerPosition = transform.position;
            Vector3 offset = new Vector3(0, 1, 0);
            squatBarbell.transform.position = playerPosition + offset;
        }
        else if (other.gameObject.CompareTag("Deadlift"))
        {
            inDeadliftArea = true;
            Vector3 playerPosition = transform.position;
            Vector3 offset = new Vector3(0.2f, 0, 0);
            deadliftBarbell.transform.position = playerPosition + offset;
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
        else if (other.gameObject.CompareTag("Deadlift"))
        {
            inDeadliftArea = true;
            Vector3 playerPosition = transform.position;
            Vector3 offset = new Vector3(0.2f, 0, 0);
            deadliftBarbell.transform.position = playerPosition + offset;
        }
    }
    #endregion
}
