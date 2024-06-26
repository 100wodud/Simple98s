using Simple98;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Awake()
    {
        DataManager.Instance.Initialize();
        StarManager.Instance.StarArrayLoad();
        StarManager.Instance.ResetStageStar();
    }
}
