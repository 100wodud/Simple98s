using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private string _bgm1Resource = "Audio/8bitArcade";
    [SerializeField] private string _bgm2Resource = "Audio/arcadeGame";

    [SerializeField]private GameObject _bgmObject;
    [SerializeField] private AudioSource _bgmSource;
    private AudioClip _bgmClip1;
    private AudioClip _bgmClip2;
    private void Start()
    {
        _bgmClip1 = Resources.Load<AudioClip>(_bgm1Resource);
        _bgmClip2 = Resources.Load<AudioClip>(_bgm2Resource);
        _bgmSource = _bgmObject.GetComponent<AudioSource>();
        _bgmSource.clip = _bgmClip1;
        _bgmSource.Play();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "StageScene" || SceneManager.GetActiveScene().name == "CustomStageScene")
        {
            if (_bgmSource.clip == _bgmClip2)
            {

            }
            else
            {
                _bgmSource.clip = _bgmClip2;
                _bgmSource.Play();
            }

        }
        else
        {
            if (_bgmSource.clip == _bgmClip1)
            {

            }
            else
            {
                _bgmSource.clip = _bgmClip1;
                _bgmSource.Play();
            }
        }
    }
}
