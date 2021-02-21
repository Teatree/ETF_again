using SpriterDotNetUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public SpriterData old;
    public FlowerHatCusomizable flowerHatCustomizable;
    public GameObject ShopPreviewObject;

    public GameObject ShopItemPrefab;
    public GameObject LevelListContent;

    List<ItemShopData> shopItems;

    void Start()
    {
        shopItems = DataController.LoadShopItems();
        FillShopItemList();
    }

    void Update()
    {
        
    }

    public void FillShopItemList()
    {
        foreach (ItemShopData i in shopItems)
        {
            GameObject g = Instantiate(ShopItemPrefab);
            g.transform.GetChild(1).GetComponent<Text>().text = i.name;
            g.transform.parent = LevelListContent.transform;
            
        }
    }

    public void ReturnToGame()
    {
        SceneController.sceneController.LoadGame();
    }

    public void TestSwapAssets()
    {
        old.FileEntries[1].Sprite = flowerHatCustomizable.sprite;

        //old.GetComponent<SpriteRenderer>().sprite = flowerHatCustomizable.sprite;
    }

    public void OpenShopPreview(Text text)
    {
        ShopPreviewObject.SetActive(true);
    }
}
