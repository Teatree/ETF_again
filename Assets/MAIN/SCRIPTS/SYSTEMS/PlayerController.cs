using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriterDotNetUnity;

public class PlayerController : MonoBehaviour
{

    public static PlayerController player;
    
    public Dictionary<string, ShopItemObject> ownShopItemsMap = new Dictionary<string, ShopItemObject>();
   // public List<ShopItemObject> ownShopItems;
    public int BJamountTotal;
    public int BJamountSession;
    public int BJamountBest;

    //FLOWER UI
    public SpriterData oldIdle;
    public SpriterData oldPot;

    public List<Sprite> sprites;


    public void BuyShopItem(ShopItemObject sio)
    {
        // if first time buying
        sio.isBought = true;
        EquipShopItem(sio);

        ShopUIManager.shopUIManager.updateShopItemsStates();
        BJamountTotal -= sio.priceBJ;
    }

    public void Awake()
    {
        Debug.Log(" Player awake");
        player = this;
        PlayerData pd = DataController.LoadPlayer();
        BJamountTotal = pd.bjAmount;
        List<ShopItemObject> ownShopItems = pd.getItems();
        if (ownShopItems != null && ownShopItems.Count > 0)
        {
            foreach (ShopItemObject o in ownShopItems)
            {
                ownShopItemsMap[o.name] = o;
            }
        }
    }

    public void SavePlayerData ()
    {
        PlayerData pi = new PlayerData();
        pi.bjAmount = BJamountTotal;
        pi.setItems( ownShopItemsMap);
        DataController.SavePlayer(pi);
    }

    public void AddBJToTotal ()
    {
        BJamountTotal += BJamountSession;
    }

    #region Equip/unequip items
    public void EquipShopItem(ShopItemObject sio)
    {
        // head bottom
        if (sio.image_Head_Bottom != "" && oldIdle.FileEntries[0].Sprite.name != sio.image_Head_Bottom)
        {
            oldIdle.FileEntries[0].Sprite = GetSpriteFromList(sio.image_Head_Bottom);
        }

        if (sio.image_Head_Top != "" && oldIdle.FileEntries[1].Sprite.name != sio.image_Head_Top)
        {
            oldIdle.FileEntries[1].Sprite = GetSpriteFromList(sio.image_Head_Top);
        }

        if (sio.image_Middle_Leafs != "" && oldIdle.FileEntries[2].Sprite.name != sio.image_Middle_Leafs)
        {
            oldIdle.FileEntries[2].Sprite = GetSpriteFromList(sio.image_Middle_Leafs);
        }

        if (sio.image_Leaf_Left != "" && oldPot.FileEntries[1].Sprite.name != sio.image_Leaf_Left)
        {
            oldPot.FileEntries[0].Sprite = GetSpriteFromList(sio.image_Leaf_Left);
        }

        if (sio.image_Leaf_Right != "" && oldPot.FileEntries[2].Sprite.name != sio.image_Leaf_Right)
        {
            oldPot.FileEntries[1].Sprite = GetSpriteFromList(sio.image_Leaf_Right);
        }

        if (sio.image_Pot != "" && oldPot.FileEntries[2].Sprite.name != sio.image_Pot)
        {
            oldPot.FileEntries[2].Sprite = GetSpriteFromList(sio.image_Pot);
        }

        sio.isEquipped = true;
        PlayerController.player.ownShopItemsMap[sio.name] = sio;
        //old.FileEntries[1].Sprite = flowerHatCustomizable.sprite;
    }

    public void UnEquipShopItem(ShopItemObject sio)
    {
        // head bottom
        if (sio.image_Head_Bottom != "")
        {
            oldIdle.FileEntries[0].Sprite = GetSpriteFromList("head_bottom");
        }

        if (sio.image_Head_Top != "")
        {
            oldIdle.FileEntries[1].Sprite = GetSpriteFromList("head_top");
        }

        if (sio.image_Middle_Leafs != "")
        {
            oldIdle.FileEntries[2].Sprite = GetSpriteFromList("middle_leafs");
        }

        if (sio.image_Leaf_Left != "")
        {
            oldPot.FileEntries[0].Sprite = GetSpriteFromList("leaf_left");
        }

        if (sio.image_Leaf_Right != "")
        {
            oldPot.FileEntries[1].Sprite = GetSpriteFromList("leaf_right");
        }

        if (sio.image_Pot != "")
        {
            oldPot.FileEntries[2].Sprite = GetSpriteFromList("pot_default");
        }

        sio.isEquipped = false;
        PlayerController.player.ownShopItemsMap[sio.name] = sio;
        //old.FileEntries[1].Sprite = flowerHatCustomizable.sprite;
    }

    public Sprite GetSpriteFromList(string name)
    {
        Sprite result = null;
        foreach (Sprite s in sprites)
        {
            if (s.name == name)
            {
                result = s;
                break;
            }
        }

        return result;
    }
    #endregion

}
