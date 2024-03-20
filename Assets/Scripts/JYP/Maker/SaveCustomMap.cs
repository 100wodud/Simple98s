using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCustomMap : MonoBehaviour
{
    public void SaveCustomButton()
    {
        DataManager.Instance.CustomMapData.SaveCustomStage();
    }
}
