using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] int maxRoomNumber;
    [SerializeField] List<int> usedNumbers = new List<int>();
    [SerializeField] TextMeshPro wheelScore = null;
    [SerializeField] PlayerMovement playerMovement = null;
    public int randomRoom;
    private bool isGamePaused = false;
    [SerializeField] private Animator animator;
    Canvas canvas;
    public float totalTimer;

    private int roomIndex;
    void Start()
    {
       
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        PlayerPrefs.SetInt("In Room", currentSceneIndex);
        


        if (PlayerPrefs.HasKey("Timer"))
        {
            totalTimer = PlayerPrefs.GetFloat("Timer");
        }
        else
        {
            PlayerPrefs.SetFloat("Timer", 0);
        }
           

        if (wheelScore != null)
        {
            wheelScore.text = usedNumbers.Count.ToString() + "/" + maxRoomNumber;
        }
        StartCoroutine(PlayStartAnimationAndWait());
    }

    IEnumerator PlayStartAnimationAndWait()
    {
        animator.Play("Eye Opening"); 

        yield return new WaitForSeconds(2); 
    }
    IEnumerator PlayEndAnimationAndWait(int sceneIndex)
    {
        animator.Play("Eye Closing");

        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(sceneIndex);
    }


    int currentSceneIndex;
    private void Awake()
    {
        LoadUsedNumbers();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    #region Random Room Selection

    private void GetUniqueRandomRoom()
    {
        if (usedNumbers.Count < maxRoomNumber)
        {
            do
            {
                randomRoom = UnityEngine.Random.Range(1, maxRoomNumber + 1);
            } while (usedNumbers.Contains(randomRoom));
            usedNumbers.Add(randomRoom);
        }
        else { SaveUsedNumbers(); } //buraya final odasýný çalýþtýracak kod eklenecek ve bu odaya gittikten sonra bitireceðiz
    }

    void SaveUsedNumbers()
    {
        string usedNumbersString = string.Join(",", usedNumbers);
        PlayerPrefs.SetString("UsedNumbers", usedNumbersString);
    }

    void LoadUsedNumbers()
    {
        if (PlayerPrefs.HasKey("UsedNumbers"))
        {
            string usedNumbersString = PlayerPrefs.GetString("UsedNumbers");
            string[] usedNumbersArray = usedNumbersString.Split(',');

            usedNumbers.Clear();

            foreach (string numberString in usedNumbersArray)
            {
                if (int.TryParse(numberString, out int number))
                {
                    usedNumbers.Add(number);
                }
                else
                {
                    Debug.LogWarning("Invalid number format in PlayerPrefs: " + numberString);
                }
            }
        }
    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlayStartAnimationAndWait());
            GetUniqueRandomRoom();
            SaveUsedNumbers();
            LoadRandomScene();
        }
    }
    void LoadRandomScene()
    {
        StartCoroutine(PlayEndAnimationAndWait(randomRoom));
    }
    public void TogglePause()
    {
        
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        canvas.enabled = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        canvas.enabled = false;
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && SceneManager.GetActiveScene().name != "Final Room")
        {
            int temp = PlayerPrefs.GetInt("In Room");
            StartCoroutine(PlayEndAnimationAndWait(temp));
        }

        if (SceneManager.GetActiveScene().name != "Main Menu" && SceneManager.GetActiveScene().name != "Final Room")
        {
            totalTimer += Time.deltaTime;
            PlayerPrefs.SetFloat("Timer", totalTimer);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(11);
    }
    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
