using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWindow : MonoBehaviour
{
    [SerializeField] private int _setWidth = 1920; //가로
    [SerializeField] private int _setHeight = 1080; //세로
    [SerializeField] private bool _isWindow = true; //전체화면 여부
     
    private void Start()
    {
        SetResolution(); //처음해상도
    }

    public void SetResolution()
    {
        Debug.Log("가로: " + _setWidth);
        Debug.Log("세로"+_setHeight);
        Debug.Log("전체화면" + _isWindow);
        Screen.SetResolution(_setWidth, _setHeight, _isWindow);
    }

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

    //해상도 변경
    public void ChangeWindowVal(int val)
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
}
