using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    private UIManager _manager = UIManager.Get();
   public void OnClickOption()
    {
        _manager.ShowPopup<Popup_Option>();
    }

    public void GameExit() //게임종료
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
