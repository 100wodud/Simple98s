using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject newContent;
    // Start is called before the first frame update
    public void ChangeContent()
    {
        // Scroll Rect�� content�� ���ο� content�� �����մϴ�.
        scrollRect.content = newContent.GetComponent<RectTransform>();
    }
}
