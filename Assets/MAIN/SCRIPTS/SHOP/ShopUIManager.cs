using SpriterDotNetUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public static ShopUIManager shopUIManager;

    public GameObject ShopPreviewObject;

    public GameObject ShopItemPrefab;
    public GameObject LevelListContent;

    public Sprite questionMark;
    public List<Sprite> shopIconImages;
    List<ShopItemObject> shopItems;

    public Text bjAmountText;
    public Text bjAmountTextShadow;

    void Start()
    {
        shopUIManager = this;

        shopItems = DataController.LoadShopItems();
        updateShopItemsStates();

        FillShopItemList();
        setBJAmiountText();
    }

    public void setBJAmiountText()
    {
        bjAmountText.text = ""+PlayerController.player.BJamount;
        bjAmountTextShadow.text = ""+PlayerController.player.BJamount;
    }

    public void updateShopItemsStates ()
    {
      
        foreach (ShopItemObject o in shopItems)
        {
            if (PlayerController.player.ownShopItemsMap.ContainsKey(o.name))
            {
                o.isBought = PlayerController.player.ownShopItemsMap[o.name].isBought;
                o.isUsed = PlayerController.player.ownShopItemsMap[o.name].isUsed;
            }
        }
    }


    public void FillShopItemList()
    {
        foreach (ShopItemObject i in shopItems)
        {
            GameObject g = Instantiate(ShopItemPrefab);
            g.transform.GetChild(1).GetComponent<Text>().text = i.name;
            g.transform.parent = LevelListContent.transform;

            g.name = i.name;

            // icon
            g.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = questionMark;
            foreach (Sprite s in shopIconImages)
            {
                if (s.name == i.imageIcon && i.isBought)
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

    public void OpenShopPreview(ShopItemObject itemi)
    {
        
        ShopPreviewObject.SetActive(true);

        ShopPreview sp = ShopPreviewObject.GetComponent<ShopPreview>();
        sp.sio = itemi;

        sp.icon.sprite = questionMark;
        foreach (Sprite s in shopIconImages)
        {
            if (s.name == itemi.imageIcon && itemi.isBought)
            {
                sp.icon.sprite = s;
                break;
            }
        }

        sp.name.text = itemi.name;
        sp.price.text = ""+itemi.priceBJ;
        sp.priceShadow.text = "" + itemi.priceBJ;

       
    }
}
 