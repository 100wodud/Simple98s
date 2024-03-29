using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

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
            Debug.Log("있는 이름입니다.");
        }
        
    }

    public void InputCustomStageName()
    {

        bool canSave = true;
        int playerTile = BuildingCreator.Instance.makeStage.FindAll(item => item.tile == 48).Count;

        if (playerTile == 0)
        {
            Debug.Log("플레이어 타일을 하나 이상 넣으시오");
            canSave = false;
        }
        else if (playerTile > 1)
        {
            Debug.Log("플레이어 타일을 하나만 넣으시오");
            canSave = false;
        }

        if (canSave)
        {
            SaveButton.SetActive(true);
        }
    }

    public void LoadCustomButton()
    {
        BuildingCreator.Instance.ResetItem();
        List<StageData> stages = OpenFileStage();
        if (stages != null && stages.Count > 0)
        {
            foreach (var stage in stages)
            {
                BuildingCreator.Instance.LoadDrawItem(stage);
            }
        }
    }


    private List<StageData> OpenFileStage()
    {
        string filePath = Application.persistentDataPath;
        string extension = ".json";
        var path = UnityEditor.EditorUtility.OpenFilePanel("Open Stage JSON", filePath, extension.Replace(".", ""));
        List<StageData> stages = new List<StageData>();
        try
        {
            stages = JsonConvert.DeserializeObject<List<StageData>>(File.ReadAllText(path));
            Debug.Log(stages.Count);
        } catch
        {
            Debug.Log("맞지않는 JSON");
        }
        return stages;
    }
}
