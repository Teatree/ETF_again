﻿using System.Collections;
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

    public Level level;

    public Upgrade bjDoubleUpgr;
    public Upgrade extraLifeUpgr;

    public void removeTrialUpgrade(Upgrade u)
    {
        if (u.upgradeType == UpgradeManager.BJ_DOUBLE)
        {
            bjDoubleUpgr = null;
        }

        if (u.upgradeType == UpgradeManager.EXTRA_LIFE)
        {
            extraLifeUpgr = null;
        }
    }

    public void BuyShopItem(ShopItemObject sio)
    {
        // if first time buying
        sio.isBought = true;
        EquipShopItem(sio);

        ShopUIManager.shopUIManager.updateShopItemsStates();
        BJamountTotal -= sio.priceBJ;
    }

    public void BuyShopItemRealMoney(ShopItemObject sio)
    {
        // REAL MONEY PURCHASES
        sio.isBought = true;
        Upgrade u = (Upgrade) sio;
        u.equip();
        
        BJamountTotal -= sio.priceBJ;
    }

    public void Awake()
    {
        player = this;
    }

    public void LoadSave()
    {
        PlayerData pd = DataController.LoadPlayer();
        BJamountTotal = pd.bjAmount;
        BJamountBest = pd.bjAmountBest;

        if (pd.extraLifeUpgr != null && pd.extraLifeUpgr.upgradeType != null)
        {
            extraLifeUpgr = pd.extraLifeUpgr;
            UpgradeManager.upgradeManager.updateUpgradeState(extraLifeUpgr);
        }

        if (pd.bjDoubleUpgr != null && pd.extraLifeUpgr.upgradeType != null)
        {
            bjDoubleUpgr = pd.bjDoubleUpgr;
            UpgradeManager.upgradeManager.updateUpgradeState(bjDoubleUpgr);
        }

        List<ShopItemObject> ownShopItems = pd.getItems();
        if (ownShopItems != null && ownShopItems.Count > 0)
        {
            foreach (ShopItemObject o in ownShopItems)
            {
                ownShopItemsMap[o.name] = o;
            }
        }

        avaliableShopItems = DataController.LoadShopItems();

        loadGoals(pd);
    }

    private void loadGoals(PlayerData pd)
    {
        if (level == null) level = new Level();

        foreach (DailyGoalStats dg in pd.goals)
        {
            Goal goal = new Goal();
            goal.achieved = dg.achieved;
            goal.counter = dg.counter;
            goal.justAchieved = dg.justAchieved;
            goal.type = GoalType.getByName(dg.type);
            goal.periodType = dg.periodType;
            goal.n = dg.n;
            goal.description = dg.description;
            level.goals[goal.type.name] = goal;
            level.difficultyLevel = dg.difficultyLevel;
            level.name = Level.allLevelsInfo[dg.difficultyLevel].name;
            level.resetNewInfo();

        }
        level.updateLevel();

        level.gift = Gift.getRandomGift(level); // Muahj
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

    public void SavePlayerData()
    {
        PlayerData pi = new PlayerData();
        pi.bjAmount = BJamountTotal;
        pi.bjAmountBest = BJamountBest;

        pi.extraLifeUpgr = extraLifeUpgr;
        pi.bjDoubleUpgr = bjDoubleUpgr;

        pi.setItems(ownShopItemsMap);
        pi.setGoals(level);
        DataController.SavePlayer(pi);
    }

    private void updateScoreGoal()
    {
        Goal scoreGoal = level.getGoalByType(GoalType.GET_N_POINTS);
        if (scoreGoal != null)
        {
            if (scoreGoal.periodType.Equals(GoalConstants.PERIOD_IN_LIFE))
            {
                scoreGoal.counter = BJamountSession;
            }
            scoreGoal.update();
        }
    }
    public void checkAndUpdateBest()
    {
        if (BJamountSession > BJamountBest)
        {
            BJamountBest = BJamountSession;
        }
    }

    public void AddBJToTotal()
    {
        BJamountTotal += BJamountSession;
        checkAndUpdateBest();
    }

    public void AddBJ(int bj)
    {
        if (PlayerController.player.bjDoubleUpgr != null
               && PlayerController.player.bjDoubleUpgr.upgradeType != null
               && PlayerController.player.bjDoubleUpgr.isEquipped)
        {
            BJamountSession += 2 * bj;
        }
        else
        {

            BJamountSession += bj;
        }
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


    public void takeGift()
    {
        //PromoWindow.offerPromo = false;
        switch (level.gift.type)
        {
            case (Gift.MONEY):
                {
                    BJamountTotal += level.gift.money;
                    //System.out.println("FECK fpc.totalScore" + fpc.totalScore);
                    break;
                }
            //case (PET):
            //    {
            //        applyPetGiftNastya(gameStage);
            //        break;
            //    }
            //case (PET_2):
            //    {
            //        applyPetGiftNastya(gameStage);
            //        break;
            //    }
            //case (PET_3):
            //    {
            //        applyPetGiftNastya(gameStage);
            //        break;
            //    }
            case (UpgradeManager.EXTRA_LIFE):
                {
                    level.gift.upgrade.startTrial();
                    
                    // ui element

                    break;
                }
            case (UpgradeManager.BJ_DOUBLE):
                {
                    level.gift.upgrade.startTrial();

                    // ui element

                    break;
                }
        }

        level.setNextLevel();
    }
}
