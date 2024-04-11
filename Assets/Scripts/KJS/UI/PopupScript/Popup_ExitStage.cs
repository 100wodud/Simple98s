using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Popup_ExitStage : UIPopup
{
    private GameObject _sfxObject;
    private AudioSource _btnSound;
    private Button _yesBtn;
    private Button _noBtn;
    public void Initialize() //초기화 메서드
    {
        Refresh();
    }
    private void Refresh()
    {
        _sfxObject = GameObject.Find("SfxAudio");
        _btnSound = _sfxObject.GetComponent<AudioSource>();
        GameObject pop = GameObject.Find("isExitWindow");
        _yesBtn = pop.transform.GetChild(1).GetComponent<Button>();
        _noBtn = pop.transform.GetChild(2).GetComponent<Button>();
        PopBtnSet();
    }
    private void PopBtnSet()
    {
        _yesBtn.onClick.AddListener(_btnSound.Play);
        _noBtn.onClick.AddListener(_btnSound.Play);
    }
    public void isExitYes()
    {
        Resume();
        if(SceneManager.GetActiveScene().name == "CustomStageScene")
        {
            SceneLoader.Instance.GotoCustomMapListScene();
        }
        else
        {
            SceneLoader.Instance.GotoStoryScene();
        }
       
    }
    public override void Destroy()
    {
        base.Destroy();
    }
    private void Resume()
    {
        Time.timeScale = 1f;
        Hide();
    }
}
