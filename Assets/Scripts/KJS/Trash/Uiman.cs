using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Uiman : MonoBehaviour
{
    public static Uiman instance;
    public GameObject game; //컴포넌트에 넣기(나중에 리소스에 넣어서 바꿀예정)
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
        
        _createPoint = Camera.main.WorldToScreenPoint(new Vector2(0f, 0f)); //캔버스위치
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

    public void OptionExit() //옵션팝업 찾아서 종료 실행
    {
        GameObject obj = GameObject.Find("OptionPop");
        PopExit(obj);
    }
    
    public void GameExit() //게임종료
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    private void PopExit(GameObject obj) //팝업 종료시 팝업오브젝트 삭제
    {
        Destroy(obj);
    }

    private void PopShow(GameObject obj)
    {
        Instantiate(obj, _createPoint, Quaternion.identity,GameObject.Find("Canvas").transform);
    }

    private void PopLoad() //UI프리팹 버튼정보 불러오기
    {
        GameObject icon = GameObject.Find("Icon");
        _masterBtn = icon.transform.GetChild(0).GetComponent<Button>();
        masterImage = icon.transform.GetChild(0).GetComponent<Image>();
        if(masterImage != null)
        {
            Debug.Log("이미지 찾음");
        }
        PopBtnSet();
    }

    private void PopBtnSet() //버튼 onClick 추가
    {
        //_masterBtn.onClick.AddListener(toggle.MasterMute);
    }

}
