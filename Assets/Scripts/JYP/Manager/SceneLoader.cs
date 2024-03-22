using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void GotoStartMenuScene()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
    public void GotoStageScene()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void GotoStoryScene()
    {
        SceneManager.LoadScene("StoryScene");
    }






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
