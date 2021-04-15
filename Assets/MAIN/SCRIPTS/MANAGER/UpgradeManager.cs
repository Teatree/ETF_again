using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public const string CURR_HARD = "HARD";
    public const string BJ_DOUBLE = "BJ_DOUBLE";
    public const string EXTRA_LIFE = "EXTRA_LIFE";

    public static UpgradeManager upgradeManager;
    public Dictionary<string, Upgrade> allUpgrades;

    public void Awake()
    {
        upgradeManager = this;
        instantiateAllUpgrades();
    }

    public void updateUpgradeState(Upgrade upgr)
    {
        allUpgrades[upgr.upgradeType] = upgr;
    }

    private void Update()
    {

        foreach (Upgrade u in allUpgrades.Values)
        {
            u.checkTrial();
        }
    }
    public void instantiateAllUpgrades()
    {
        allUpgrades = new Dictionary<string, Upgrade>();

        Upgrade extraLife = new Upgrade();
        extraLife.upgradeType = EXTRA_LIFE;

        extraLife.name = "EXTRA LIFE";
        extraLife.isBought = false;
        extraLife.description = "Get 1 extra life every new game";
        extraLife.isEquipped = false;
        extraLife.currencyType = CURR_HARD;

        extraLife.idSKU = "phoenix";
        extraLife.idSKUDisc = "phoenixDisc";
        extraLife.imageIcon = "extra_life";

        extraLife.priceSKU = "" + 100;
        extraLife.priceSKUDisc = "" + 50;
        allUpgrades[EXTRA_LIFE] = extraLife;

        Upgrade bjd = new Upgrade();
        bjd.upgradeType = BJ_DOUBLE;

        bjd.name = "DOUBLE COINS";
        bjd.isBought = false;
        bjd.description = "Twice the coins~from eating bugs";
        bjd.isEquipped = false;
        bjd.currencyType = CURR_HARD;

        bjd.idSKU = "bj_upgrade";
        bjd.idSKUDisc = "bj_upgrade_discount";
        bjd.imageIcon = "x2_upgrade";

        bjd.priceSKU = "" + 100;
        bjd.priceSKUDisc = "" + 50;

        allUpgrades[BJ_DOUBLE] = bjd;
    }

    public Upgrade getExtraLife()
    {

        return allUpgrades[EXTRA_LIFE];
    }

    public Upgrade getBJDouble()
    { 

        return allUpgrades[BJ_DOUBLE];
    }
}

[System.Serializable]
public class Upgrade : ShopItemObject
{
    public string upgradeType;
    public int counter;

    public Upgrade() { }

    public void equip()
    {
        this.isEquipped = true;
        if (UpgradeManager.BJ_DOUBLE.Equals(upgradeType))
        {
            PlayerController.player.bjDoubleUpgr = this;
        }
        else if (UpgradeManager.EXTRA_LIFE.Equals(upgradeType))
        {
            PlayerController.player.extraLifeUpgr = this;
        }
    }

    public void startTrial()
    {
        equip();
        isTrial = true;
        trialPeriodStart = System.DateTime.UtcNow;
        trialPeriodDuration = Gift.ONE_HOUR;
    }

    public void checkTrial ()
    {
        if (isTrial )
        {
            System.TimeSpan trialTimeCurrent = System.DateTime.UtcNow - trialPeriodStart;
            Debug.Log(">>> trial check > " + trialTimeCurrent.TotalMilliseconds);
            if (trialTimeCurrent.TotalMilliseconds > trialPeriodDuration)
            {
                PlayerController.player.removeTrialUpgrade(this);
                unEquip();
                Debug.Log(">>> trial ends > ");
            }
        }
    }
    public void unEquip()
    {
        isEquipped = false;
        isTrial = false;
    }
}