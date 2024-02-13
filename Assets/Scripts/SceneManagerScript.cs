using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    int currentSceneIndex;
    private void Awake()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("New Scene Is Loading");
            LoadNextScene();
        }
    }
    void LoadNextScene()
    {

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
