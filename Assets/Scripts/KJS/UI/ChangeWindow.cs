using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWindow : MonoBehaviour
{
    [SerializeField] private int _setWidth = 1920; //����
    [SerializeField] private int _setHeight = 1080; //����
    [SerializeField] private bool _isWindow = true; //��üȭ�� ����
     
    private void Start()
    {
        SetResolution(); //ó���ػ�
    }

    public void SetResolution()
    {
        Debug.Log("����: " + _setWidth);
        Debug.Log("����"+_setHeight);
        Debug.Log("��üȭ��" + _isWindow);
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

    //�ػ� ����
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
