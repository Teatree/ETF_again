using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public const string MONEY = "MONEY";

    public const long ONE_HOUR = 360000000000; // it's supposed to be 60, and it's not a hour, it's a MINUTE

    private static Random random = new Random();

    private static List<int> moneySums;

    //public PetComponent pet;
    public int money;
    public string type;
    public Upgrade upgrade;

    // Start is called before the first frame update
    void Start()
    {
        moneySums = new List<int>();
        moneySums.Add(50);
        moneySums.Add(100);
        moneySums.Add(150);
        moneySums.Add(200);
        moneySums.Add(250);
        moneySums.Add(300);
}

    public static Gift getRandomGift(Level level)
    {
        Gift gift = new Gift();
        //        gift = getPhoenixGift(gameStage);
        int i = Random.Range(0, 100);
        if (i >= 0 && i <= level.rewardChanceGroups["RAVEN"])
        {
            //gift = getPetGift();
            gift = getMoneyGift(50);
        }
        else if (i > level.rewardChanceGroups["RAVEN"] &&
              i <= level.rewardChanceGroups["CAT"])
        {
            //gift = getPet2Gift();
            gift = getMoneyGift(50);
        }
        else if (i > level.rewardChanceGroups["CAT"] &&
              i <= level.rewardChanceGroups["DRAGON"])
        {
            //gift = getPet3Gift();
            gift = getMoneyGift(50);
        }
        else if (i > level.rewardChanceGroups["DRAGON"] &&
              i <= level.rewardChanceGroups["PHOENIX"])
        {
            gift = getExtraLifeGift();
        }
        else if (i > level.rewardChanceGroups["PHOENIX"] &&
              i <= level.rewardChanceGroups["BJ_DOUBLE"])
        {
            gift = getDoubleJuiceGift();
        }
        else if (i > level.rewardChanceGroups["BJ_DOUBLE"] &&
              i <= level.rewardChanceGroups["MONEY_50"])
        {
            gift = getMoneyGift(50);
        }
        else if (i > level.rewardChanceGroups["MONEY_50"] &&
              i <= level.rewardChanceGroups["MONEY_100"])
        {
            gift = getMoneyGift(100);
        }
        else if (i > level.rewardChanceGroups["MONEY_100"] &&
              i <= level.rewardChanceGroups["MONEY_150"])
        {
            gift = getMoneyGift(150);
        }
        else if (i > level.rewardChanceGroups["MONEY_150"] &&
              i <= level.rewardChanceGroups["MONEY_200"])
        {
            gift = getMoneyGift(200);
        }
        else if (i > level.rewardChanceGroups["MONEY_200"] &&
              i <= level.rewardChanceGroups["MONEY_250"])
        {
            gift = getMoneyGift(250);
        }
        else if (i > level.rewardChanceGroups["MONEY_250"])
        {
            gift = getMoneyGift(300);
        }

        gift = getDoubleJuiceGift(); // Muahj

        return gift;
    }

    public static Gift getRandomMoneyGift()
    {
        Gift gift = new Gift();
        int moneyIndex = Random.Range(0, moneySums.Count);
        gift.money = moneySums[moneyIndex];
        gift.type = MONEY;
        return gift;
    }

    public static Gift getMoneyGift(int sum)
    {
        Gift gift = new Gift();
        gift.money = sum;
        gift.type = MONEY;
        return gift;
    }

    //public static Gift getPetGift()
    //{
    //    Gift gift = new Gift();
    //    PetComponent pet = null;
    //    for (PetComponent p : gameStage.gameScript.fpc.pets)
    //    {
    //        if (p.name.equalsIgnoreCase(PET))
    //        {
    //            pet = p;
    //            break;
    //        }
    //    }
    //    System.out.println("TRYING TO GET PET GIFT!");
    //    if (!pet.bought)
    //    {
    //        gift.pet = pet;
    //        gift.pet.tryPeriod = true;
    //        gift.pet.tryPeriodDuration = ONE_HOUR;
    //        gift.type = pet.name.toUpperCase();
    //        return gift;
    //    }
    //    else
    //    {
    //        return getRandomMoneyGift();
    //    }
    //}

    //public static Gift getPet2Gift(GameStage gameStage)
    //{
    //    Gift gift = new Gift();
    //    PetComponent pet = null;
    //    for (PetComponent p : gameStage.gameScript.fpc.pets)
    //    {
    //        if (p.name.equalsIgnoreCase(PET_2))
    //        {
    //            pet = p;
    //            break;
    //        }
    //    }
    //    System.out.println("TRYING TO GET PET GIFT!");
    //    if (!pet.bought)
    //    {
    //        gift.pet = pet;
    //        gift.pet.tryPeriod = true;
    //        gift.pet.tryPeriodDuration = ONE_HOUR;
    //        gift.type = pet.name.toUpperCase();
    //        return gift;
    //    }
    //    else
    //    {
    //        return getRandomMoneyGift();
    //    }
    //}

    //public static Gift getPet3Gift(GameStage gameStage)
    //{
    //    Gift gift = new Gift();
    //    PetComponent pet = null;
    //    for (PetComponent p : gameStage.gameScript.fpc.pets)
    //    {
    //        if (p.name.equalsIgnoreCase(PET_3))
    //        {
    //            pet = p;
    //            break;
    //        }
    //    }
    //    System.out.println("TRYING TO GET PET GIFT!");
    //    if (!pet.bought)
    //    {
    //        gift.pet = pet;
    //        gift.pet.tryPeriod = true;
    //        gift.pet.tryPeriodDuration = ONE_HOUR;
    //        gift.type = pet.name.toUpperCase();
    //        return gift;
    //    }
    //    else
    //    {
    //        return getRandomMoneyGift();
    //    }
    //}

    public static Gift getExtraLifeGift()
    {
        if (!UpgradeManager.upgradeManager.allUpgrades[UpgradeManager.EXTRA_LIFE].isEquipped 
            && !UpgradeManager.upgradeManager.allUpgrades[UpgradeManager.EXTRA_LIFE].isBought)
        {
            Gift gift = new Gift();
            gift.upgrade = UpgradeManager.upgradeManager.getExtraLife();
            gift.upgrade.isTrial = true;
            gift.upgrade.trialPeriodDuration = ONE_HOUR;
            gift.type = UpgradeManager.EXTRA_LIFE;
            return gift;
        }
        else
        {
            return getRandomMoneyGift();
        }
    }

    public static Gift getDoubleJuiceGift()
    {
        if (!UpgradeManager.upgradeManager.allUpgrades[UpgradeManager.BJ_DOUBLE].isEquipped
            && !UpgradeManager.upgradeManager.allUpgrades[UpgradeManager.BJ_DOUBLE].isBought)
        {
            Gift gft = new Gift();
            gft.upgrade = UpgradeManager.upgradeManager.getBJDouble();
            gft.upgrade.isTrial = true;
            gft.upgrade.trialPeriodDuration = ONE_HOUR;
            gft.type = UpgradeManager.BJ_DOUBLE;
            return gft;
        }
        else
        {
            return getRandomMoneyGift();
        }
    }


}
