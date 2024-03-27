using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;

    [SerializeField] private int playerMoney;

    private const string prefMoney = "prefMoney";

    private void Awake()
    {
        instance = this;

        playerMoney = PlayerPrefs.GetInt(prefMoney);
    }
    public bool TryRemoveMoney(int moneyToRemove)
    {
        if (playerMoney >= moneyToRemove)
        {
            playerMoney -= moneyToRemove;
            PlayerPrefs.SetInt(prefMoney, playerMoney);
            return true;
        }
        else
        {
            return false;
        }
    }
}
