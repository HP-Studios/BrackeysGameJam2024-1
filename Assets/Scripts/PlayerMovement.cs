using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //BU KODUN TAMAMEN D�ZENLENMES� GEREK�YOR A�IRI K�T� YAZILMI�
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;
    [SerializeField] float temporarilyRunSpeed = 9f; //BEN EKLED�M YOKSA S�REKL� RUN SPEED� 12YE SAB�TL�YORDU
    [SerializeField] float temporarilyWalkSpeed = 9f; //BEN EKLED�M YOKSA S�REKL� WALK SPEED� 6YA SAB�TL�YORDU

    [SerializeField] public AudioSource walkSFX;
    [SerializeField] public AudioSource jumpSFX;
    bool isWalkSFXPlaying;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isWalkSFXPlaying = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);


        if(curSpeedX != 0 ||  curSpeedY != 0)
        {
            if (!isWalkSFXPlaying && characterController.isGrounded)
            {
                walkSFX.Play();
                isWalkSFXPlaying = true;
            }
            else if(!characterController.isGrounded)
            {
                isWalkSFXPlaying = false;

                walkSFX.Stop();
            }
        }
        else
        {
            walkSFX.Stop();
            isWalkSFXPlaying = false;
        }

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            jumpSFX.Play();
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = temporarilyWalkSpeed;
            runSpeed = temporarilyRunSpeed;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}