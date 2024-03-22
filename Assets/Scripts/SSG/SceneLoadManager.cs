using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : Singleton<SceneLoadManager>
{

    private const string path = "Resources/Scenes/";
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(path + SceneName);
    }
}
