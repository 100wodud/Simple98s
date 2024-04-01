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
        // Scroll Rect의 content를 새로운 content로 변경합니다.
        scrollRect.content = newContent.GetComponent<RectTransform>();
    }
}
