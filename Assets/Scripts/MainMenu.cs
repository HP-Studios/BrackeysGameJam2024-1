using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] Animator menuAnimator;
    [SerializeField] AudioSource spinSFX;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject HTP_Menu;
    [SerializeField] GameObject creditMenu;
    [SerializeField] GameObject resetMenu;

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
        Invoke("StartGameSequance",2.8f);
    }

    private void StartGameSequance()
    {
        SceneManager.LoadScene(0);
    }
    public void SetFalseAllParameters()
    {
        menuAnimator.SetBool("hasOptions", false);
        menuAnimator.SetBool("hasCredit", false);
        menuAnimator.SetBool("hasSpin", false);
        menuAnimator.SetBool("hasReset", false);
    }
    public void Options()
    {
        menuAnimator.SetBool("hasOptions", true);
        spinSFX.Play();
        Invoke("DelayForOptionsMenu", 2.8f);
    }

    private void DelayForOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void Credit()
    {
        menuAnimator.SetBool("hasCredit", true);
        spinSFX.Play();
        Invoke("CreditMenuDelay", 2.8f);
    }

    private void CreditMenuDelay()
    {
        creditMenu.SetActive(true);
    }

    public void QuitGame()
    {
        menuAnimator.SetBool("hasQuit", true);
        spinSFX.Play();
        Invoke("QuitDelay", 2.8f);
    }

    private void QuitDelay()
    {
        Debug.Log("Quit The game.");
        Application.Quit();
    }

    public void HowToPlay()
    {
        menuAnimator.SetBool("hasSpin", true);
        spinSFX.Play();
        Invoke("DelayForHTPMenu", 2.8f);
    }
    private void DelayForHTPMenu()
    {
        HTP_Menu.SetActive(true);
    }
    public void ResetAllProgress()
    {
        menuAnimator.SetBool("hasReset", true);
        spinSFX.Play();
        Invoke("ResetMenuDelay", 2.8f);
    }

    private void ResetMenuDelay()
    {
        resetMenu.SetActive(true);
    }
    public void DeleteConfirm()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player Prefs Deleted");
    }
}
