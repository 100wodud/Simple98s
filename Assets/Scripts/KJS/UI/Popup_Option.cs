using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Popup_Option : UIPopup
{
    public AudioMixer mixer;

    //������� �̹���
    [SerializeField] private Image _masterImg;
    [SerializeField] private Image _bgmImage;
    [SerializeField] private Image _sfxImage;
    [SerializeField] private int _setWidth = 1920; //����
    [SerializeField] private int _setHeight = 1080; //����
    [SerializeField] private bool _isWindow = true; //��üȭ�� ����
    //������ ��������Ʈ
    private Sprite _onAudio;
    private Sprite _offAudio;

    private string _onResource = "Sprites/AudioOn";
    private string _offResource = "Sprites/AudioOff";

    private bool _isAllMute = false; //���Ұ� üũ
    private bool _isBgmMute = false; //��ü���Ұ� üũ
    private bool _isSfxMute = false;

    public void Initialize() //�ʱ�ȭ �޼���
    {
        Refresh();
    }

    private void Refresh()
    {
        _onAudio = Resources.Load<Sprite>(_onResource);
        _offAudio = Resources.Load<Sprite>(_offResource);
    }

    //=====================����� ����=============================
    //=================================================================
    //���Ұ� ���
    private void OnMuteToggle(Image image, AudioSource audioSource,ref bool mute)
    {
        mute = mute ? false : true; //��Ʈ����
        Debug.Log("all" + _isAllMute);
        Debug.Log("bgm" + _isBgmMute);
        Debug.Log("sfx" + _isSfxMute);
        if (mute == true)
        {
            image.sprite = _offAudio; //�̹�������
            //��ü���� ���������� null ���̸� �����ϱ�
            if (audioSource != null)
            {
                audioSource.mute = true; //��Ʈ
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
        //��ü���� ������ ���� ������ ������ ����
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        OnMuteToggle(_masterImg, null,ref _isAllMute); //������ҽ��� ����

    }

    public void BgmMute() //Bgm ���Ұ� ��ư
    {
        //Bgm ������Ʈ ã��
        GameObject bgmObject = GameObject.Find("BgmAudio");
        if (bgmObject != null)
        {
            //����� �ҽ� ������Ʈ
            AudioSource bgmAudio = bgmObject.GetComponent<AudioSource>();
            if (bgmAudio != null)
            {
                OnMuteToggle(_bgmImage, bgmAudio,ref _isBgmMute);
            }
        }
    }

    public void SfxMute() //Sfx ���Ұ� ��ư
    {
        //Sfx ������Ʈ ã��
        GameObject sfxObject = GameObject.Find("SfxAudio");
        if (sfxObject != null)
        {
            //����� �ҽ� ������Ʈ
            AudioSource sfxAudio = sfxObject.GetComponent<AudioSource>();
            if (sfxAudio != null)
            {
                OnMuteToggle(_sfxImage, sfxAudio,ref _isSfxMute);
            }
        }
    }


    //�Ҹ� �ͼ� ����� ����
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

    //=====================���÷��� ����=============================
    //=================================================================

    //�ػ�����
    public void SetResolution()
    {
        Debug.Log("����: " + _setWidth);
        Debug.Log("����" + _setHeight);
        Debug.Log("��üȭ��" + _isWindow);
        Screen.SetResolution(_setWidth, _setHeight, _isWindow);
    }

    //â��� ��Ӵٿ�
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

    //�ػ� ��Ӵٿ�
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
    public override void Hide() //����
    {
        base.Hide();
    }

    public override void Show()
    {
        base.Show();
    }
}
