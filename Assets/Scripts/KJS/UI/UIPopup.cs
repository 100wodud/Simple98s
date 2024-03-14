using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    public virtual void Refresh()
    {
    }

    public virtual void Hide()
    {
        PopDestroy();
    }

    public void PopHide()
    {
        gameObject.SetActive(false);
    }

    public void PopDestroy()
    {
        Destroy(gameObject);
    }
}
