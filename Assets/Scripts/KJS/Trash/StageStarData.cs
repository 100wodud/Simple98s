using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageStarData", menuName = "ScriptableObjects/StageStarData", order = 1)]
public class StageStarData : ScriptableObject
{
    public int maxStars = 3; // 최대 별 개수
    public int starsEarned; // 얻은 별 개수
}

