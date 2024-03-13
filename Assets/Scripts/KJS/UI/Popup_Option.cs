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
    //������ ��������Ʈ
    public Sprite onAudio;
    public Sprite offAudio;

    private string onResource = "Sprites/AudioOn";
    private string offResource = "Sprites/AudioOff";

    private bool _isMute = false; //���Ұ� üũ

    //private void Start()
    //{
    //    onAudio = Resources.Load<Sprite>(onResource);
    //    offAudio = Resources.Load<Sprite>(offResource);
    //}

    public override void Refresh()
    {
        onAudio = Resources.Load<Sprite>(onResource);
        offAudio = Resources.Load<Sprite>(offResource);
    }
    //���Ұ� ���
    private void OnMuteToggle(Image image, AudioSource audioSource)
    {
        _isMute = !_isMute; //��ƮȮ��
        if (_isMute)
        {
            image.sprite = offAudio; //�̹�������
            //��ü���� ���������� null ���̸� �����ϱ�
            if (audioSource != null)
            {
                audioSource.mute = true; //��Ʈ
            }
        }
        else
        {
            image.sprite = onAudio;
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
        OnMuteToggle(_masterImg, null); //������ҽ��� ����

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
                OnMuteToggle(_bgmImage, bgmAudio);
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
                OnMuteToggle(_sfxImage, sfxAudio);
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

    public override void Hide()
    {
        base.Hide();
    }
}
