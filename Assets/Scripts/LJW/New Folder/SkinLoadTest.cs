using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class SkinLoadTest : MonoBehaviour
{
    
    void Start()
    {
        UnityGoogleSheet.Load<Simple98.Shop>();

        foreach(var value in Simple98.Shop.ShopMap)
        {
            //Debug.Log(value. +"," + value.Desc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
