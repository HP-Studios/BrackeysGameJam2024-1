using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GymRoomTasks : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI jumpAmountText;
    [SerializeField] TextMeshProUGUI crouchAmountText;
    [SerializeField] int targetJumpAmount;
    [SerializeField] int targetCrouchAmount;
    private CharacterController characterController;
    int jumpAmount;
    int crouchAmount;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded && jumpAmount != targetJumpAmount)
        {
            jumpAmount++;
            jumpAmountText.text = jumpAmount + "/" +  targetJumpAmount;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && crouchAmount != targetJumpAmount)
        {
            crouchAmount++;
            crouchAmountText.text = crouchAmount + "/" + targetJumpAmount;  
        }
    }
}
