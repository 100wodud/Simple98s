using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecter : MonoBehaviour
{
    [SerializeField] private int selectStageIndex = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        StageManager.Instance.stageindex =selectStageIndex;
        SceneController.Instance.LoadScene("MapScene");
        //스테이지 매니저에서 값을 가져가고
        //이걸 스테이지 큐브마다 다르게 할 수 있는 인덱스라...
        //원하는 것: 스테이지 번호값을 가지게 하고 스테이지 매니저가
        //그 다음 씬을 변경하게 하기
    }
}
