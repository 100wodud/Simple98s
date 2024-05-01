using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountStar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _starTxt;

    public void Start()
    {
        UpdateAllStars();
    }
    public void UpdateAllStars()
    {
        StarManager.Instance.GetAllStars();
        RefreshStars(StarManager.Instance.starCount);
    }

    private void RefreshStars(int star)
    {
        _starTxt.text = star.ToString();
    }
}
