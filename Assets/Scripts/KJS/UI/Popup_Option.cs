using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Popup_Option : UIPopup
{
    public AudioMixer mixer;

    //각오디오 이미지
    [SerializeField] private Image _masterImg;
    [SerializeField] private Image _bgmImage;
    [SerializeField] private Image _sfxImage;
    [SerializeField] private int _setWidth = 1920; //가로
    [SerializeField] private int _setHeight = 1080; //세로
    [SerializeField] private bool _isWindow = true; //전체화면 여부
    //변경할 스프라이트
    private Sprite _onAudio;
    private Sprite _offAudio;

    private string _onResource = "Sprites/AudioOn";
    private string _offResource = "Sprites/AudioOff";

    private bool _isAllMute = false; //음소거 체크
    private bool _isBgmMute = false; //전체음소거 체크
    private bool _isSfxMute = false;

    public void Initialize() //초기화 메서드
    {
        Refresh();
    }

    private void Refresh()
    {
        _onAudio = Resources.Load<Sprite>(_onResource);
        _offAudio = Resources.Load<Sprite>(_offResource);
    }

    //=====================오디오 설정=============================
    //=================================================================
    //음소거 토글
    private void OnMuteToggle(Image image, AudioSource audioSource,ref bool mute)
    {
        mute = mute ? false : true; //뮤트반전
        Debug.Log("all" + _isAllMute);
        Debug.Log("bgm" + _isBgmMute);
        Debug.Log("sfx" + _isSfxMute);
        if (mute == true)
        {
            image.sprite = _offAudio; //이미지변경
            //전체볼륨 조절때문에 null 값이면 무시하기
            if (audioSource != null)
            {
                audioSource.mute = true; //뮤트
            }
        }
        else
        {
            image.sprite = _onAudio;
            if (audioSource != null)
            {
                audioSource.mute = false;
            }
        }
    }
    public void MasterMute()
    {
        //전체볼륨 조절을 위해 리스너 음량을 조절
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        OnMuteToggle(_masterImg, null,ref _isAllMute); //오디오소스는 비우기

    }

    public void BgmMute() //Bgm 음소거 버튼
    {
        //Bgm 오브젝트 찾기
        GameObject bgmObject = GameObject.Find("BgmAudio");
        if (bgmObject != null)
        {
            //오디오 소스 컴포넌트
            AudioSource bgmAudio = bgmObject.GetComponent<AudioSource>();
            if (bgmAudio != null)
            {
                OnMuteToggle(_bgmImage, bgmAudio,ref _isBgmMute);
            }
        }
    }

    public void SfxMute() //Sfx 음소거 버튼
    {
        //Sfx 오브젝트 찾기
        GameObject sfxObject = GameObject.Find("SfxAudio");
        if (sfxObject != null)
        {
            //오디오 소스 컴포넌트
            AudioSource sfxAudio = sfxObject.GetComponent<AudioSource>();
            if (sfxAudio != null)
            {
                OnMuteToggle(_sfxImage, sfxAudio,ref _isSfxMute);
            }
        }
    }


    //소리 믹서 밸류값 조절
    public void MasterControl(float sliderVal)
    {
        mixer.SetFloat("MASTER", Mathf.Log10(sliderVal) * 20);
    }
    public void BgmControl(float sliderVal)
    {
        mixer.SetFloat("BGM", Mathf.Log10(sliderVal) * 20);
    }
    public void SfxControl(float sliderVal)
    {
        mixer.SetFloat("SFX", Mathf.Log10(sliderVal) * 20);
    }

    //=====================디스플레이 설정=============================
    //=================================================================

    //해상도지정
    public void SetResolution()
    {
        Debug.Log("가로: " + _setWidth);
        Debug.Log("세로" + _setHeight);
        Debug.Log("전체화면" + _isWindow);
        Screen.SetResolution(_setWidth, _setHeight, _isWindow);
    }

    //창모드 드롭다운
    public void setWindowMod(int val)
    {
        switch (val)
        {
            case 0:
                _isWindow = true;
                break;
            case 1:
                _isWindow = false;
                break;
        }
        SetResolution();
    }

    //해상도 드롭다운
    public void setResolutionVal(int val)
    {
        switch (val)
        {
            case 0:
                _setWidth = 1920;
                _setHeight = 1080;
                break;
            case 1:
                _setWidth = 1600;
                _setHeight = 900;
                break;
            case 2:
                _setWidth = 1360;
                _setHeight = 768;
                break;
            case 3:
                _setWidth = 1280;
                _setHeight = 720;
                break;
        }
        SetResolution();
    }
    public override void Hide() //종료
    {
        base.Hide();
    }

    public override void Show()
    {
        base.Show();
    }
}
