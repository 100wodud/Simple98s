using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageStarData", menuName = "ScriptableObjects/StageStarData", order = 1)]
public class StageStarData : ScriptableObject
{
    public int maxStars = 3; // �ִ� �� ����
    public int starsEarned; // ���� �� ����
    public int unlockStar; //�ر� ������
    public int bestStar;
    public bool isClear;
}

