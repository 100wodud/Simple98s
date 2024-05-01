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
    public GameObject errorPopup;
    public GameObject SaveButton;
    public GameObject Canvas;
    public GameObject existName;

    private string StageName;


    public void ErrorPopup()
    {
        Time.timeScale = 0;
        errorPopup.SetActive(true);
    }
    public void ErrorPopupClose()
    {
        Time.timeScale = 1;
        errorPopup.SetActive(false);
    }
    public void InputName()
    {
        StageName = inputName.text;
    }

    public void SaveCustomButton()
    {
        string filePath = Application.persistentDataPath;
        InputName();
        if (!File.Exists($"{filePath}/{StageName}/{StageName}.json"))
        {
            existName.SetActive(false);
            Canvas.SetActive(false);
            DataManager.Instance.CustomMapData.SaveCustomStage(StageName);
        }
        else
        {
            existName.SetActive(true);
        }
        
    }

    public void SaveDevButton()
    {
        DataManager.Instance.CustomMapData.SaveDevStage();
    }

    public void InputCustomStageName()
    {
        bool canSave = true;
        int playerTile = BuildingCreator.Instance.makeStage.FindAll(item => item.tile == 48).Count;
        int goalTile = BuildingCreator.Instance.makeStage.FindAll(item => item.tile == 49).Count;

        if (playerTile != 1)
        {
            ErrorPopup();
            canSave = false;
        }

        if (goalTile != 1)
        {
            ErrorPopup();
            canSave = false;
        }

        if (canSave)
        {
            Time.timeScale = 0;
            SaveButton.SetActive(true);
        }
    }

    public void CancelSave()
    {
        inputName.text = "";
        Time.timeScale = 1;
        SaveButton.SetActive(false);
    }

    public void LoadCustomButton()
    {
        List<StageData> stages = OpenFileStage();
        if (stages != null & stages.Count > 0)
        {
            BuildingCreator.Instance.ResetItem();
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
        var path = "";
        List<StageData> stages = new List<StageData>();
#if UNITY_EDITOR
        path = UnityEditor.EditorUtility.OpenFilePanel("Open Stage JSON", filePath, extension.Replace(".", ""));
#else
        path = Path.Combine(Application.streamingAssetsPath, "YourFileName.json");
#endif
        try
        {
            stages = JsonConvert.DeserializeObject<List<StageData>>(File.ReadAllText(path));
        } catch
        {
            Debug.Log("맞지않는 JSON");
        }
        return stages;
    }
}
