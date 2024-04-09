using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;

    public void SetupTooltip(string description)
    {
        descriptionText.text = description;
    }
}
