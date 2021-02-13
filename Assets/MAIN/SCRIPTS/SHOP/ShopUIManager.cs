using SpriterDotNetUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopUIManager : MonoBehaviour
{
    public SpriterData old;
    public FlowerHatCusomizable flowerHatCustomizable;
    public GameObject ShopPreviewObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ReturnToScene()
    {
        SceneManager.LoadScene(1);
    }

    public void TestSwapAssets()
    {
        old.FileEntries[1].Sprite = flowerHatCustomizable.sprite;

        //old.GetComponent<SpriteRenderer>().sprite = flowerHatCustomizable.sprite;
    }

    public void OpenShopPreview()
    {
        ShopPreviewObject.SetActive(true);
    }
}
