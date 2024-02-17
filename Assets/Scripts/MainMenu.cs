using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] Animator menuAnimator;
    [SerializeField] AudioSource spinSFX;
    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime);
        //transform.Rotate(new Vector3(0, 0, 0) * rotationSpeed * Time.deltaTime);
        //transform.Rotate(new Vector3(0, 0, 0) * rotationSpeed * Time.deltaTime);
    }

    public void StartGame()
    {
        menuAnimator.SetBool("hasStart", true);
        spinSFX.Play();
        Invoke("StartGameSequance",2f);
    }

    private void StartGameSequance()
    {
        SceneManager.LoadScene(0);
    }

    public void Options()
    {
        menuAnimator.SetBool("hasOptions", true);
        spinSFX.Play();
    }
    public void Credit()
    {
        menuAnimator.SetBool("hasCredit", true);
        spinSFX.Play();
    }
    public void QuitGame()
    {
        menuAnimator.SetBool("QuitGame", true);
        spinSFX.Play();
    }
    public void Spin()
    {
        menuAnimator.SetBool("hasSpin", true);
        spinSFX.Play();
    }
    public void ResetAllProgress()
    {
        menuAnimator.SetBool("hasReset", true);
        spinSFX.Play();
    }
}
