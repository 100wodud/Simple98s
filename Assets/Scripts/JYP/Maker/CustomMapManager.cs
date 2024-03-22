using Simple98;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomMapManager : Singleton<CustomMapManager>
{
    private int CustomStageNum;
    Vector3 playerPos;
    public void MakeCustomStage(int mapStage)
    {
        //플레이어 생성 함수
        //부모오브젝트맵
        const string path = "Prefabs/Player/Player";
        foreach (var item in DataManager.Instance.CustomMapData.GetCustomStage(mapStage))
        {
            if(item.tile == 48)
            {
                playerPos = new Vector3(item.x, item.y, 0);
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
        Dictionary<int, List<StageData>> stageData = new();
        stageData = DataManager.Instance.CustomMapData.GetCustomStageList();
        float y = 450;
        Canvas canvas = FindObjectOfType<Canvas>();
        const string buttonPath = "Prefabs/Test/Button";
        GameObject buttonPrefab = Resources.Load(buttonPath) as GameObject;
        foreach (KeyValuePair<int, List<StageData>> stage in stageData)
        {
            GameObject obj = Instantiate(buttonPrefab, canvas.transform);
            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, y);
            int stageKey = stage.Key;
            Button button = obj.GetComponent<Button>(); // 버튼 컴포넌트 가져오기
            button.onClick.AddListener(() =>
            {
                CustomStageNum = stage.Key;
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene("CustomStageScene");
            }
            );
            y -= 100;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        int stageKey = CustomStageNum;
        DataManager.Instance.Initialize();
        MakeCustomStage(stageKey);
    }
}
