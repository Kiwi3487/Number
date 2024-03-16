using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public FloatSO playerScore;
    //Used to load scenes based on the scene that is used
    public void LoadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }
    
    //Closes program
    public void CloseProgram()
    {
        
        #if UNITY_EDITOR
            playerScore.value = 0;
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            playerScore.value = 0;
            Application.Quit();
        
        #endif
    }
    public void LoadSceneButResetScore(SceneAsset scene)
    {
        playerScore.value = 0;
        SceneManager.LoadScene(scene.name);
    }
    
}