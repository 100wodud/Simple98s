using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public AudioMixer mixer;

    //¼Ò¸® ¹Í¼­ ¹ë·ù°ª Á¶Àý
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
    
}
