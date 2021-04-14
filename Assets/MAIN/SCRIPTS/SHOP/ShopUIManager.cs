using SpriterDotNetUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public static ShopUIManager shopUIManager;

    public GameObject ShopPreviewObject;

    public GameObject ExtraLifeShopItem;
    public GameObject BJ_DoubleShopItem;

    public GameObject ShopItemPrefab;
    public GameObject LevelListContent;

    public Sprite questionMark;
   
    public Text bjAmountText;
    public Text bjAmountTextShadow;

    void Start()
    {
        shopUIManager = this;

        updateShopItemsStates();

        FillShopItemList();
        setBJAmiountText();

        InitializeUpgradeShopItems();
    }

    public void setBJAmiountText()
    {
        bjAmountText.text = ""+PlayerController.player.BJamountTotal;
        bjAmountTextShadow.text = ""+PlayerController.player.BJamountTotal;
    }

    public void updateShopItemsStates ()
    {
        foreach (ShopItemObject o in PlayerController.player.avaliableShopItems)
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
        foreach (ShopItemObject i in PlayerController.player.avaliableShopItems)
        {
            GameObject g = Instantiate(ShopItemPrefab);
            g.transform.GetChild(1).GetComponent<Text>().text = i.name;
            g.transform.parent = LevelListContent.transform;

            g.name = i.name;

            // icon
            g.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = questionMark;
            foreach (Sprite s in AllManager.allManager.iconImages)
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

    // initialize shop upgrade shit
    public void InitializeUpgradeShopItems()
    {
        // extra life
        ExtraLifeShopItem.GetComponent<ShopItemController>().sio = UpgradeManager.upgradeManager.allUpgrades[UpgradeManager.EXTRA_LIFE];

        // doubler
        BJ_DoubleShopItem.GetComponent<ShopItemController>().sio = UpgradeManager.upgradeManager.allUpgrades[UpgradeManager.BJ_DOUBLE];

        // pets...
    }

    public void UpdateItemList()
    {

    } 

    public bool IsSioDirectionCap(ShopItemObject sio, bool isLeft)
    {
        int sioIndex = PlayerController.player.avaliableShopItems.IndexOf(sio);

        if (isLeft)
        {
            if (sioIndex - 1 == -1) return true;
            return false;
        }
        else
        {
            if (sioIndex + 1 == PlayerController.player.avaliableShopItems.Count) return true;
            return false;
        }
    }

    public ShopItemObject FindSioInListAndSwitchToDirection(ShopItemObject sio, bool isLeft)
    {
        int sioIndex = PlayerController.player.avaliableShopItems.IndexOf(sio);

        if (isLeft)
        {
            if (sioIndex - 1 > -1)
            {
                return PlayerController.player.avaliableShopItems[sioIndex - 1];
            }
            else
            {
                return PlayerController.player.avaliableShopItems[sioIndex];
            }
        }
        else
        {
            if (sioIndex - 1 < PlayerController.player.avaliableShopItems.Count)
            {
                return PlayerController.player.avaliableShopItems[sioIndex + 1];
            }
            else
            {
                return PlayerController.player.avaliableShopItems[sioIndex];
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
        foreach (Sprite s in AllManager.allManager.iconImages)
        {
            if (s.name == itemi.imageIcon && (itemi.isBought || UpgradeManager.CURR_HARD.Equals(itemi.currencyType)))
            {
                sp.icon.sprite = s;
                break;
            }
        }

        sp.name.text = itemi.name;
        sp.price.text = ""+itemi.priceBJ;
        sp.priceShadow.text = "" + itemi.priceBJ;

        // change to a different button

    }

    // STUPID STUPID STUPID DIMA
    public void UpdateShopPreview(ShopItemObject itemi)
    {
        ShopPreview sp = ShopPreviewObject.GetComponent<ShopPreview>();
        sp.sio = itemi;

        sp.icon.sprite = questionMark;
        foreach (Sprite s in AllManager.allManager.iconImages)
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

    

    public void UpdateShopItemList(string iconName, string name, bool isEquipped)
    {
        Sprite iconSprite = AllManager.allManager.GetSpriteByName(iconName);
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
 