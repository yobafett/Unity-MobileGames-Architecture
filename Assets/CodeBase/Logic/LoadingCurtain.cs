using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCurtain : MonoBehaviour
{
    public CanvasGroup Curtain;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Curtain.alpha = 1f;
    }

    public void Hide() => 
        StartCoroutine(FadeIn());

    private IEnumerator FadeIn()
    {
        while (Curtain.alpha > 0)
        {
            Curtain.alpha -= 0.03f;
            yield return new WaitForSeconds(0.03f);
        }
        
        gameObject.SetActive(false);
    }
}
