using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneManager : MonoBehaviour
{
    
    public void GotoCustomScene()
    {
        SceneManager.LoadScene("CustomScene");
    }
    public void GotoMakerScene()
    {
        SceneManager.LoadScene("MakerScene");
    }
    public void GotoCustomMapListScene()
    {
        SceneManager.LoadScene("CustomStageListScene");
    }
}
