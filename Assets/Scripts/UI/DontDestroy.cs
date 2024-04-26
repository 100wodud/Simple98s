using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //[SerializeField] private AudioSource bgm1;
    //[SerializeField] private AudioSource bgm2;
    //public void Start()
    //{
    //    bgm1.Play();
    //    //bgm2.Play();
    //}

    //public void Update()
    //{
    //    if(SceneManager.GetActiveScene().name == "StageScene" || SceneManager.GetActiveScene().name == "CustomStageScene")
    //    {
    //        bgm1.Stop();
    //        bgm1.gameObject.SetActive(false);
    //        if (bgm2.gameObject.activeSelf == false) 
    //        {
    //            bgm2.gameObject.SetActive(true);
    //            bgm2.Play();
    //        }
    //    }
    //    else
    //    {
    //        bgm2.Stop();
    //        bgm2.gameObject.SetActive(false);
    //        if (bgm1.gameObject.activeSelf == false)
    //        {
    //            bgm1.gameObject.SetActive(true);
    //            bgm1.Play();
    //        }
    //    }
    //}
}
