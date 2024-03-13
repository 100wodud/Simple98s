using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Uiman : MonoBehaviour
{
    public static Uiman instance;
    public GameObject game; //������Ʈ�� �ֱ�(���߿� ���ҽ��� �־ �ٲܿ���)
    //private AudioToggle toggle;
    private Button _masterBtn;
    private Vector2 _createPoint;

    public Image masterImage;
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //toggle = GetComponent<AudioToggle>();
        
        _createPoint = Camera.main.WorldToScreenPoint(new Vector2(0f, 0f)); //ĵ������ġ
    }
    public void OptionShow()
    {
        if (GameObject.Find("OptionPop"))
        {
            return;
        }
        GameObject obj = game;
        PopShow(obj);
        PopLoad();
    }

    public void OptionExit() //�ɼ��˾� ã�Ƽ� ���� ����
    {
        GameObject obj = GameObject.Find("OptionPop");
        PopExit(obj);
    }
    
    public void GameExit() //��������
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    private void PopExit(GameObject obj) //�˾� ����� �˾�������Ʈ ����
    {
        Destroy(obj);
    }

    private void PopShow(GameObject obj)
    {
        Instantiate(obj, _createPoint, Quaternion.identity,GameObject.Find("Canvas").transform);
    }

    private void PopLoad() //UI������ ��ư���� �ҷ�����
    {
        GameObject icon = GameObject.Find("Icon");
        _masterBtn = icon.transform.GetChild(0).GetComponent<Button>();
        masterImage = icon.transform.GetChild(0).GetComponent<Image>();
        if(masterImage != null)
        {
            Debug.Log("�̹��� ã��");
        }
        PopBtnSet();
    }

    private void PopBtnSet() //��ư onClick �߰�
    {
        //_masterBtn.onClick.AddListener(toggle.MasterMute);
    }

}
