using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class AudioToggle : MonoBehaviour
{
    //������� �̹���
    public Image masterImage;
    public Image bgmImage;
    public Image sfxImage;
    //������ ��������Ʈ
    public Sprite onAudio;
    public Sprite offAudio;

    private bool _isMute = false; //���Ұ� üũ

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
        OnMuteToggle(masterImage, null); //������ҽ��� ����
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
                OnMuteToggle(bgmImage, bgmAudio);
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
                OnMuteToggle(sfxImage, sfxAudio);
            }
        }
    }
}
