using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] int maxRoomNumber;
    [SerializeField] List<int> usedNumbers = new List<int>();
    public int randomRoom;

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
            GetUniqueRandomRoom();
            SaveUsedNumbers();
            LoadRandomScene();
        }
    }
    void LoadRandomScene()
    {

        SceneManager.LoadScene(randomRoom);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
