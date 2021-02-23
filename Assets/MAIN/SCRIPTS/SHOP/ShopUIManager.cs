using SpriterDotNetUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public static ShopUIManager shopUIManager;

    public SpriterData old;
    public FlowerHatCusomizable flowerHatCustomizable;
    public GameObject ShopPreviewObject;

    public GameObject ShopItemPrefab;
    public GameObject LevelListContent;

    public Sprite questionMark;
    public List<Sprite> shopIconImages;
    List<ItemShopData> shopItems;

    void Start()
    {
        shopUIManager = this;

        shopItems = DataController.LoadShopItems();
        FillShopItemList();
    }

    public void FillShopItemList()
    {
        foreach (ItemShopData i in shopItems)
        {
            GameObject g = Instantiate(ShopItemPrefab);
            g.transform.GetChild(1).GetComponent<Text>().text = i.name;
            g.transform.parent = LevelListContent.transform;

            g.name = i.name;

            // icon
            g.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = questionMark;
            foreach (Sprite s in shopIconImages)
            {
                if (s.name == i.imageIcon)
                {
                    g.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = s;
                    break;
                }
            }

            g.GetComponent<ShopItemController>().sio = i;
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

    public void OpenShopPreview(ItemShopData itemShopData)
    {
        ShopPreviewObject.SetActive(true);

        ShopPreview sp = ShopPreviewObject.GetComponent<ShopPreview>();

        sp.icon.sprite = questionMark;
        foreach (Sprite s in shopIconImages)
        {
            if (s.name == itemShopData.imageIcon)
            {
                sp.icon.sprite = s;
                break;
            }
        }

        sp.name.text = itemShopData.name;
        sp.price.text = ""+itemShopData.priceBJ;
        sp.priceShadow.text = "" + itemShopData.priceBJ;
    }
}
