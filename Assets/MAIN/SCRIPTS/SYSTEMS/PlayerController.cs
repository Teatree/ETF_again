using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriterDotNetUnity;

public class PlayerController : MonoBehaviour
{
    public List<ShopItemObject> avaliableShopItems;
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

    public ShopItemObject targetsio;

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
        player = this;
        LoadSave();
    }

    private void LoadSave()
    {
        PlayerData pd = DataController.LoadPlayer();
        BJamountTotal = pd.bjAmount;
        BJamountBest = pd.bjAmountBest;
        List<ShopItemObject> ownShopItems = pd.getItems();
        if (ownShopItems != null && ownShopItems.Count > 0)
        {
            foreach (ShopItemObject o in ownShopItems)
            {
                ownShopItemsMap[o.name] = o;
            }
        }

        avaliableShopItems = DataController.LoadShopItems();
    }

    public ShopItemObject getNextTargetItem(bool resetTarget)
    {
        if (targetsio != null && resetTarget == false) return targetsio;

        foreach (ShopItemObject sio in avaliableShopItems)
        {
            if (!ownShopItemsMap.ContainsKey(sio.name) && sio.priceBJ > BJamountTotal)
            {
                return targetsio = sio; 
            }
        }
        return null;
    }

    public void SavePlayerData ()
    {
        PlayerData pi = new PlayerData();
        pi.bjAmount = BJamountTotal;
        pi.bjAmountBest = BJamountBest;

        pi.setItems( ownShopItemsMap);
        
        DataController.SavePlayer(pi);
    }

    public void checkAndUpdateBest()
    {
        if (BJamountSession > BJamountBest)
        {
            BJamountBest = BJamountSession;
        }
    }

    public void AddBJToTotal ()
    {
        BJamountTotal += BJamountSession;
        checkAndUpdateBest();
    }

    public void AddBJ(int bj)
    {
        PlayerController.player.BJamountSession += bj;
        UIController.uIController.animateBJ();
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
