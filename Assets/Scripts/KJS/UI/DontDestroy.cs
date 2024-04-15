using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static List<string> dontDestroyObjects = new List<string>();

    private void Awake()
    {
        if (dontDestroyObjects.Contains(gameObject.name))
        {
            Destroy(gameObject);
            return;
        }

        dontDestroyObjects.Add(gameObject.name);
        DontDestroyOnLoad(gameObject);
    }
}
