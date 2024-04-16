using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Popup_Pause : UIPopup
{
    private Popup_Option _option;
    private Popup_Exit _exit;
    private Popup_ExitStage _exitStage;
    private GameObject _sfxObject;
    private AudioSource _btnSound;
    private Button _resumeBtn;
    private Button _optionBtn;
    private Button _stageBtn;
    private Button _exitBtn;

    public void Initialize() //초기화 메서드
    {
        Refresh();
    }
    private void Refresh()
    {
        _sfxObject = GameObject.Find("SfxAudio");
        _btnSound = _sfxObject.GetComponent<AudioSource>();
        GameObject pop = GameObject.Find("Group_Buttons");
        _resumeBtn = pop.transform.GetChild(0).GetComponent<Button>();
        _optionBtn = pop.transform.GetChild(1).GetComponent<Button>();
        _stageBtn = pop.transform.GetChild(2).GetComponent<Button>();
        _exitBtn = pop.transform.GetChild(3).GetComponent<Button>();
        PopBtnSet();
    }
    private void PopBtnSet()
    {
        _resumeBtn.onClick.AddListener(_btnSound.Play);
        _optionBtn.onClick.AddListener(_btnSound.Play);
        _exitBtn.onClick.AddListener(_btnSound.Play);
        _stageBtn.onClick.AddListener(_btnSound.Play);
    }
    public void OnClickOption()
    {
        if (_option != null)
        {
            _option.Show();
            return;
        }
        else
        {
            _option = UIManager.Instance.ShowPopup<Popup_Option>();
            _option.Initialize();
        }

    }
    public void OnClickExit()
    {
        if (_exit != null)
        {
            return;
        }
        else
        {
            _exit = UIManager.Instance.ShowPopup<Popup_Exit>();
            _exit.Initialize();
        }

    }

    public void OnClickStage()
    {
        if (_exitStage != null)
        {
            return;
        }
        else
        {
            _exitStage = UIManager.Instance.ShowPopup<Popup_ExitStage>();
            _exitStage.Initialize();
        }
    }

    

    public void Resume()
    {
        Time.timeScale = 1f;
        Hide();
    }
    public override void Hide() //종료
    {
        base.Hide();
    }
    public override void Show()
    {
        base.Show();
    }
    public override void Destroy()
    {
        base.Destroy();
    }
}
