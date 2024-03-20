using Simple98;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomMapManager : Singleton<CustomMapManager>
{
    public void MakeCustomStage(int mapStage)
    {
        //�÷��̾� ���� �Լ�
        //�θ������Ʈ��
        foreach (var item in DataManager.Instance.CustomMapData.GetCustomStage(mapStage))
        {
            InstantiateTile(item.tile, item.x, item.y);
        }
        //Vector3 playerPos = DataManager.Instance.MapData.GetStageData(mapStage).PlayerPos;
        //Instantiate(Resources.Load("Prefabs/Player/Player"), playerPos, Quaternion.identity);
    }

    private void InstantiateTile(int index, int x, int y)
    {
        //�θ������Ʈ�� ���α�
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
            Button button = obj.GetComponent<Button>(); // ��ư ������Ʈ ��������
            button.onClick.AddListener(() =>
            {
                Debug.Log(stageKey);
                MakeCustomStage(stageKey);
            }
            );
            y -= 50;
        }
    }
}
