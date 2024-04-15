using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_Exit : UIPopup
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public override void Destroy()
    {
        base.Destroy();
    }
}
