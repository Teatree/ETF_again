﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController uIController;

    public Text bjAmount;

    void Start()
    {
        uIController = this;
    }

    void Update()
    {
    }

    public void animateBJ ()
    {
        bjAmount.text = "" + PlayerController.player.BJamountSession;
        StartCoroutine(AnimateBJAmount(0.5f, (bjAmount.transform.localScale.x * 2)));
    }

    IEnumerator AnimateBJAmount(float duration, float endValue)
    {
            float time = 0;
        float scaleModifier = 1;
            float startValue = scaleModifier;
            Vector3 startScale = bjAmount.transform.localScale;

        while (time < duration)
            {
            if (time < duration / 2)
            {
                scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
                bjAmount.transform.localScale = startScale * scaleModifier;
            } else
            {
                scaleModifier = Mathf.Lerp(endValue, startValue , time / duration);
                bjAmount.transform.localScale = startScale * scaleModifier;
            }
                time += Time.deltaTime;
                yield return null;
            }
        //bjAmount.transform.localScale = startScale * targetScale;
        bjAmount.transform.localScale = startScale;
        scaleModifier = endValue;
    }
    public void LoadShopMenu()
    {
        SceneController.sceneController.LoadShop();
    }
}
