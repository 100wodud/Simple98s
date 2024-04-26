using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_PauseBtn : UIPopup
{
    private Popup_Pause _pause;

    private GameObject _sfxObject;
    private AudioSource _btnSound;
    private Button _pauseBtn;
    public void Initialize() //초기화 메서드
    {
        Refresh();
    }
    private void Refresh()
    {
        _sfxObject = GameObject.Find("SfxAudio");
        _btnSound = _sfxObject.GetComponent<AudioSource>();
        GameObject pop = GameObject.Find("PauseBtn");
        _pauseBtn = pop.transform.GetChild(0).GetComponent<Button>();
        PopBtnSet();
    }
    private void PopBtnSet()
    {
        _pauseBtn.onClick.AddListener(_btnSound.Play);
    }
    public void OnClickPause() //일시정지메뉴
    {
        if (_pause != null)
        {
            _pause.Show();
            Time.timeScale = 0f;
            return;
        }
        else
        {
            Time.timeScale = 0f;
            _pause = UIManager.Instance.ShowPopup<Popup_Pause>();
            _pause.Initialize();
        }
    }
}
