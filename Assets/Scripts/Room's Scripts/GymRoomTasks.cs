using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GymRoomTasks : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI jumpAmountText;
    [SerializeField] private int targetJumpAmount;
    private CharacterController characterController;
    int jumpAmount;

    public int getJumpAmount()
    {
        return targetJumpAmount;
    }

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
            jumpAmountText.text = "Jumping Jacks:  " + jumpAmount + "/" +  targetJumpAmount;
        }
        else if(Input.GetKeyUp(KeyCode.Space) && characterController.isGrounded && jumpAmount != targetJumpAmount)
        {
            jumpAmount++;
            jumpAmountText.text = "Squat:  " + jumpAmount + "/" + targetJumpAmount;
        }
    }
}
