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
                o.isEquipped = PlayerController.player.ownShopItemsMap[o.name].isEquipped;
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

                    if(i.isEquipped)
                    {
                        g.transform.GetChild(2).gameObject.SetActive(true);
                    }
                    else
                    {
                        g.transform.GetChild(2).gameObject.SetActive(false);
                    }

                    break;
                }
            }

            g.GetComponent<ShopItemController>().sio = i;
        }
    }

    public void UpdateItemList()
    {

    } 

    public bool IsSioDirectionCap(ShopItemObject sio, bool isLeft)
    {
        int sioIndex = shopItems.IndexOf(sio);

        if (isLeft)
        {
            if (sioIndex - 1 == -1) return true;
            return false;
        }
        else
        {
            if (sioIndex + 1 == shopItems.Count) return true;
            return false;
        }
    }

    public ShopItemObject FindSioInListAndSwitchToDirection(ShopItemObject sio, bool isLeft)
    {
        int sioIndex = shopItems.IndexOf(sio);

        if (isLeft)
        {
            if (sioIndex - 1 > -1)
            {
                return shopItems[sioIndex - 1];
            }
            else
            {
                return shopItems[sioIndex];
            }
        }
        else
        {
            if (sioIndex - 1 < shopItems.Count)
            {
                return shopItems[sioIndex + 1];
            }
            else
            {
                return shopItems[sioIndex];
            }
        }
    }

    public void ReturnToGame()
    {
        SceneController.sceneController.LoadGame();
    }

    public void OpenShopPreview(ShopItemObject itemi)
    {
        ShopPreview sp = ShopPreviewObject.GetComponent<ShopPreview>();
        sp.sio = itemi;

        ShopPreviewObject.SetActive(true);

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

    // STUPID STUPID STUPID DIMA
    public void UpdateShopPreview(ShopItemObject itemi)
    {
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
        sp.price.text = "" + itemi.priceBJ;
        sp.priceShadow.text = "" + itemi.priceBJ;
    }

    public Sprite GetSpriteByName(string iconName)
    {
        foreach (Sprite s in shopIconImages)
        {
            if (s.name == iconName)
            {
                return s;
            }
        }
        return null;
    }

    public void UpdateShopItemList(string iconName, string name, bool isEquipped)
    {
        Sprite iconSprite = GetSpriteByName(iconName);
        foreach (Transform child in LevelListContent.transform)
        {
            if (child.name == name) {
                child.GetChild(0).gameObject.GetComponent<Image>().sprite = iconSprite;

                if (isEquipped)
                {
                    child.GetChild(2).gameObject.SetActive(true);
                }
                else
                {
                    child.GetChild(2).gameObject.SetActive(false);
                }
            }
        }
    }

}
 