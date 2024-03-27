using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveCustomMap : MonoBehaviour
{
    public TMP_InputField inputName;
    public GameObject SaveButton;
    public GameObject Canvas;

    private string StageName;

    public void InputName()
    {
        StageName = inputName.text;
    }

    public void SaveCustomButton()
    {
        string filePath = Application.persistentDataPath;
        InputName();
        if (!File.Exists($"{filePath}/{StageName}.png"))
        {
            Canvas.SetActive(false);
            DataManager.Instance.CustomMapData.SaveCustomStage(StageName);
        }
        else
        {
            Debug.Log("�ִ� �̸��Դϴ�.");
        }
        
    }

    public void InputCustomStageName()
    {

        bool canSave = true;
        int playerTile = BuildingCreator.Instance.makeStage.FindAll(item => item.tile == 48).Count;

        if (playerTile == 0)
        {
            Debug.Log("�÷��̾� Ÿ���� �ϳ� �̻� �����ÿ�");
            canSave = false;
        }
        else if (playerTile > 1)
        {
            Debug.Log("�÷��̾� Ÿ���� �ϳ��� �����ÿ�");
            canSave = false;
        }

        if (canSave)
        {
            SaveButton.SetActive(true);
        }
    }

}
