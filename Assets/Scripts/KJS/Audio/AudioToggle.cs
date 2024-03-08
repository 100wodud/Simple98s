using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class AudioToggle : MonoBehaviour
{
    //각오디오 이미지
    public Image masterImage;
    public Image bgmImage;
    public Image sfxImage;
    //변경할 스프라이트
    public Sprite onAudio;
    public Sprite offAudio;

    private bool _isMute = false; //음소거 체크

    //음소거 토글
    private void OnMuteToggle(Image image, AudioSource audioSource)
    {
        _isMute = !_isMute; //뮤트확인
        if (_isMute)
        {
            image.sprite = offAudio; //이미지변경
            //전체볼륨 조절때문에 null 값이면 무시하기
            if (audioSource != null)
            {
                audioSource.mute = true; //뮤트
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
        //전체볼륨 조절을 위해 리스너 음량을 조절
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        OnMuteToggle(masterImage, null); //오디오소스는 비우기
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
                OnMuteToggle(bgmImage, bgmAudio);
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
                OnMuteToggle(sfxImage, sfxAudio);
            }
        }
    }
}
