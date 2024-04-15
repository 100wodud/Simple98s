using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStar : MonoBehaviour
{
    public static PlayerStar instance;

    private StarManager starManager;

    private void Awake()
    {
        instance = this;

        starManager = StarManager.Instance;
    }
    //public bool TryRemoveStars(int starsToRemove)
    //{
    //    if (starManager.starCount >= starsToRemove)
    //    {
    //        starManager.starCount -= starsToRemove;
    //        starManager.SaveStars();
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}
