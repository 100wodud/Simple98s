using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectImg : MonoBehaviour
{
    [SerializeField] private Image[] _stageImg;
    [SerializeField] private GameObject[] _stageObject;
    [SerializeField] private Sprite defaultStage;
    [SerializeField] private Sprite clearStage;
    [SerializeField] private Sprite unlockStage;
    private void Start()
    {
        Refresh();
        setStageImg();
    }

    private void Refresh()
    {
        for(int i = 0; i < StarManager.Instance.stageStarDataArray.Length; i++)
        {
            GameObject stage = _stageObject[i];
            GameObject stageStar = stage.transform.GetChild(1).gameObject;
            Debug.Log($"Stage{i}");
            if (StarManager.Instance.stageStarDataArray[i].isClear)
            {
                stage.transform.GetChild(0).transform.Translate(new Vector2(0, 27));
                Debug.Log("½ÇÇà");
                stageStar.gameObject.SetActive(true);

            }
            else
            {
                stage.transform.GetChild(0).transform.Translate(new Vector2(0, 0));
                stageStar.gameObject.SetActive(false);
            }
            for(int j =0; j < 3; j++)
            {
                if(StarManager.Instance.stageStarDataArray[i].starsEarned-1 >= j)
                {
                    stageStar.transform.GetChild(j).gameObject.SetActive(true);
                }
                else
                {
                    stageStar.transform.GetChild(j).gameObject.SetActive(false);
                }
            }
            
            
        }
        
    }
    private void setStageImg()
    {
        for (int i = 0; i < StarManager.Instance.stageStarDataArray.Length; i++)
        {
            if (StarManager.Instance.stageStarDataArray[i].isClear)
            {
                _stageImg[i].sprite = clearStage;
            }
            else
            {
                _stageImg[i].sprite = defaultStage;
            }
        }
    }
}
