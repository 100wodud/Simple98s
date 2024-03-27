using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Audio;
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
    public virtual void Destroy()
    {
        PopDestroy();
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
        if (gameObject != null)
        {
          Destroy(gameObject);
        }
    }
}
