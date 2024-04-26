using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class Popup_Option : UIPopup
{
    public AudioMixer mixer;
    private static Popup_Option _instance;
    public static Popup_Option Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new Popup_Option();
            }
            return _instance;
        }
    }

    //������� �̹���
    [SerializeField] private Image _masterImg;
    [SerializeField] private Image _bgmImage;
    [SerializeField] private Image _sfxImage;
    [SerializeField] private int _setWidth = 1920; //����
    [SerializeField] private int _setHeight = 1080; //����
    [SerializeField] private bool _isWindow = true; //��üȭ�� ����
    
    private SoundSetting _soundSetting;
    private string savePath;

    //�����̴�
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;
    //������ ��������Ʈ
    private Sprite _onAudio;
    private Sprite _offAudio;

    private GameObject _bgmObject;
    private GameObject _sfxObject;

    private Button _masterBtn;
    private Button _bgmBtn;
    private Button _sfxBtn;
    private Button _exitBtn;

    private AudioSource _bgmSource;
    private AudioSource _sfxSource;

    private string _onResource = "Sprites/AudioOn";
    private string _offResource = "Sprites/AudioOff";

    private bool _isAllMute = false; //���Ұ� üũ
    private bool _isBgmMute = false; //��ü���Ұ� üũ
    private bool _isSfxMute = false;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "soundSettings.json");
        LoadSettings();
    }
    public void Initialize() //�ʱ�ȭ �޼���
    {
        Refresh();
    }

    private void Refresh()
    {
        
        _onAudio = Resources.Load<Sprite>(_onResource);
        _offAudio = Resources.Load<Sprite>(_offResource);
        _bgmObject = GameObject.Find("BgmAudio");
        _sfxObject = GameObject.Find("SfxAudio");
        _bgmSource = _bgmObject.GetComponent<AudioSource>();
        _sfxSource = _sfxObject.GetComponent<AudioSource>();
        GameObject icon = GameObject.Find("SoundIcon");
        GameObject select = GameObject.Find("SelectOption");
        GameObject op = GameObject.Find("Option");
        _masterBtn = icon.transform.GetChild(0).GetComponent<Button>();
        _bgmBtn = icon.transform.GetChild(1).GetComponent<Button>();
        _sfxBtn = icon.transform.GetChild(2).GetComponent<Button>();
        _exitBtn = op.transform.GetChild(2).GetComponent<Button>();
        PopBtnSet();
    }
    private void PopBtnSet() //��ư onClick �߰�
    {
        _masterBtn.onClick.AddListener(_sfxSource.Play);
        _bgmBtn.onClick.AddListener(_sfxSource.Play);
        _sfxBtn.onClick.AddListener(_sfxSource.Play);
        _exitBtn.onClick.AddListener(_sfxSource.Play);
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
        OnMuteToggle(_bgmImage, _bgmSource, ref _isBgmMute);
    }

    public void SfxMute() //Sfx ���Ұ� ��ư
    {
        OnMuteToggle(_sfxImage, _sfxSource, ref _isSfxMute);
    }


    //�Ҹ� �ͼ� ����� ����
    public void MasterControl(float sliderVal)
    {
        mixer.SetFloat("MASTER", Mathf.Log10(sliderVal) * 20);
        _soundSetting.masterVolume = sliderVal; 
        SaveSettings();
    }
    public void BgmControl(float sliderVal)
    {
        mixer.SetFloat("BGM", Mathf.Log10(sliderVal) * 20);
        _soundSetting.bgmVolume = sliderVal;
        SaveSettings();
    }
    public void SfxControl(float sliderVal)
    {
        mixer.SetFloat("SFX", Mathf.Log10(sliderVal) * 20);
        _soundSetting.sfxVolume = sliderVal;
        SaveSettings();
    }
    private void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(_soundSetting);
        File.WriteAllText(savePath, jsonData);

        masterSlider.value = _soundSetting.masterVolume;
        bgmSlider.value = _soundSetting.bgmVolume;
        sfxSlider.value = _soundSetting.sfxVolume;
    }

    public void LoadSettings()
    {
        if(File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            _soundSetting = JsonUtility.FromJson<SoundSetting>(jsonData);

            mixer.SetFloat("MASTER", Mathf.Log10(_soundSetting.masterVolume) * 20);
            mixer.SetFloat("BGM", Mathf.Log10(_soundSetting.bgmVolume) * 20);
            mixer.SetFloat("SFX", Mathf.Log10(_soundSetting.sfxVolume) * 20);

            masterSlider.value = _soundSetting.masterVolume;
            bgmSlider.value = _soundSetting.bgmVolume;
            sfxSlider.value = _soundSetting.sfxVolume;
        }
        else
        {
            _soundSetting = new SoundSetting(1f, 1f, 1f); // �⺻�� ����
            SaveSettings();
        }
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

    public void DeleteData()
    {
        SaveStageJson.Instance.DeleteStageData();
    }
    public override void Hide() //����
    {
        base.Hide();
    }

    public override void Show()
    {
        base.Show();
    }
    public override void Destroy()
    {
        base.Destroy();
    }
}