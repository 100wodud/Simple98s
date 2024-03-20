using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    private Popup_Option _option;

    public void OnClickOption()
    {
        if(_option != null)
        {
            _option.Show();
            return;
        }
        else
        {
            _option = UIManager.Instance.ShowPopup<Popup_Option>();
            _option.Initialize();
        }
        
    }

    public void GameExit() //��������
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
