using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{

    public virtual void Hide()
    {
        PopHide();
    }
    public virtual void Show()
    {
        PopShow();
    }

    private void PopShow()
    {
        gameObject.SetActive(true);
    }
    private void PopHide()
    {
        gameObject.SetActive(false);
    }

    private void PopDestroy()
    {
        Destroy(gameObject);
    }
}
