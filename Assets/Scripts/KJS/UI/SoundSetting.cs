using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundSetting
{
    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;

    public SoundSetting(float master, float bgm, float sfx)
    {
        masterVolume = master;
        bgmVolume = bgm;
        sfxVolume = sfx;
    }
}
