using System.Collections;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] TextMeshPro doorText;
    [SerializeField] float openSpeed = 2.0f;
    [SerializeField] float openAngle = 90f;
    [SerializeField] float playerDistance = 2.0f;
    [SerializeField] RandomWheelDecider buttonScript = null;
    [SerializeField] bool isLocked = true;
    [SerializeField] AudioClip doorCloseSFX;
    [SerializeField] AudioClip doorOpenSFX;
    [SerializeField] AudioSource doorSource;

    private Quaternion openRotation;
    private Quaternion closedRotation;
    private bool isPlayerInDistance;
    private bool isOpen;

    private void Start()
    {
        doorText.enabled = false;
        openRotation = transform.rotation * Quaternion.Euler(0, openAngle, 0);
        closedRotation = Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        isPlayerInDistance = Vector3.Distance(transform.position, Camera.main.transform.position) < playerDistance;

        if ((isOpen || !isLocked) && isPlayerInDistance)
        {
            OpenSlowly();
        }
        else if (isOpen || !isLocked)
        {
            CloseSlowly();
        }

        if (buttonScript == null)
        {
            ToggleDoorState();
        }
    }
    #region Mouse Input's
    private void OnMouseOver()
    {
        doorText.enabled = !isOpen && isPlayerInDistance;
    }

    private void OnMouseExit()
    {
        doorText.enabled = !isOpen;
    }

    private void OnMouseDown()
    {
        if (buttonScript && isPlayerInDistance && buttonScript.SpinningFinished && !isOpen)
        {
            ToggleDoorState();
        }
    }
    #endregion
    #region Open & Close Sequance's
    private void OpenSlowly()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
    }

    private void CloseSlowly()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);

        if (Quaternion.Angle(transform.rotation, closedRotation) < 1.0f && isOpen)
        {
            isOpen = false;
            PlayDoorSound(doorCloseSFX);
        }
    }
    #endregion
    private void ToggleDoorState()
    {
        isOpen = true;
        doorText.enabled = false;

        if (isOpen)
        {
            PlayDoorSound(doorOpenSFX);
        }
        else
        {
            PlayDoorSound(doorCloseSFX);
        }
    }

    private void PlayDoorSound(AudioClip soundClip)
    {
        doorSource.clip = soundClip;
        doorSource.Play();
    }
}
