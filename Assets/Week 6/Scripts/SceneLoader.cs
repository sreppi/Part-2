using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneLoader : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings; // Watch out for sceneCount, it's something different || % is a modular function 
        SceneManager.LoadScene(nextSceneIndex);
    }

}
