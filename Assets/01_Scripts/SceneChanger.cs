using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string nextScene;

    public void GoToNextScene()
    {
        Invoke("WaitForAnimation", 0.3f);
    }
    public void WaitForAnimation()
    {

        SceneManager.LoadScene(nextScene);
    }
    public void WaitForQuitGame()
    {
        Application.Quit();
        
    }

}
