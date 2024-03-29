using Simple98;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomMapManager : Singleton<CustomMapManager>
{
    private string CustomStageName;
    Vector3 playerPos;
    string filePath;
    public void MakeCustomStage(string mapStage)
    {
        //플레이어 생성 함수
        //부모오브젝트맵
        const string path = "Prefabs/Player/Player";
        foreach (var item in DataManager.Instance.CustomMapData.GetCustomStage(mapStage))
        {
            if(item.tile == 48)
            {
                playerPos = new Vector3(item.x, -item.y, 0);
            }
            else
            {
                InstantiateTile(item.tile, item.x, item.y);
            }
        }
        Instantiate(Resources.Load(path), playerPos, Quaternion.identity);
    }

    private void InstantiateTile(int index, int x, int y)
    {
        //부모오브젝트로 감싸기
        const string path = "Prefabs/";
        Tiles tile = DataManager.Instance.TileData.GetTile(index);
        Instantiate(Resources.Load($"{path + tile.Type + "/" + tile.localeID}"), new Vector3(x, -y, 0), Quaternion.identity);
    }

    public void CustomStageList()
    {
        filePath = Application.persistentDataPath;

        Dictionary<string, CustomData> stageData = new();
        stageData = DataManager.Instance.CustomMapData.GetCustomStageList();
        const string buttonPath = "Prefabs/StageList/UI_ListStage";
        GameObject buttonPrefab = Resources.Load(buttonPath) as GameObject;

        GameObject contents = GameObject.Find("Contents");
        foreach (KeyValuePair<string, CustomData> stage in stageData)
        {
            GameObject instance = Instantiate(buttonPrefab);
            instance.transform.SetParent(contents.transform, false);

            string stageKey = stage.Key;
            Image image = instance.GetComponentInChildren<Image>();

            if (File.Exists($"{filePath}/{stageKey}/{stageKey}.png"))
            {
                byte[] byteTexture = System.IO.File.ReadAllBytes($"{filePath}/{stageKey}/{stageKey}.png");
                Texture2D texture = new Texture2D(0, 0);
                texture.LoadImage(byteTexture);
                Rect rect = new Rect(0, 0, texture.width, texture.height);
                image.sprite = Sprite.Create(texture, rect, new Vector2(0, 0));
            }

            Button button = instance.GetComponent<Button>(); // 버튼 컴포넌트 가져오기
            button.onClick.AddListener(() =>
            {
                CustomStageName = stage.Key;
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene("CustomStageScene");
            }
            );
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        string stageKey = CustomStageName;
        DataManager.Instance.Initialize();
        MakeCustomStage(stageKey);
    }
}
