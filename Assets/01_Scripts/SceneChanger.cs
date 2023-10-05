using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string nextScene;

    public void GoToNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

}