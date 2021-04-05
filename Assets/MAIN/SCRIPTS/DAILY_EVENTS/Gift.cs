using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private const string MONEY = "MONEY";

    private const int ONE_HOUR = 90; // it's supposed to be 60, and it's not a hour, it's a MINUTE

    private static Random random = new Random();

    private static List<int> moneySums;

    //public PetComponent pet;
    public int money;
    public string type;
    //public Upgrade upgrade;

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

    public static Gift getRandomGift()
    {
        Gift gift = new Gift();
        //        gift = getPhoenixGift(gameStage);
        int i = Random.Range(0, 100);
        if (i >= 0 && i <= PlayerController.player.level.rewardChanceGroups["RAVEN"])
        {
            //gift = getPetGift();
            gift = getMoneyGift(50);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["RAVEN"] &&
              i <= PlayerController.player.level.rewardChanceGroups["CAT"])
        {
            //gift = getPet2Gift();
            gift = getMoneyGift(50);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["CAT"] &&
              i <= PlayerController.player.level.rewardChanceGroups["DRAGON"])
        {
            //gift = getPet3Gift();
            gift = getMoneyGift(50);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["DRAGON"] &&
              i <= PlayerController.player.level.rewardChanceGroups["PHOENIX"])
        {
            //gift = getPhoenixGift();
            gift = getMoneyGift(50);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["PHOENIX"] &&
              i <= PlayerController.player.level.rewardChanceGroups["BJ_DOUBLE"])
        {
            //gift = getDoubleJuiceGift();
            gift = getMoneyGift(50);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["BJ_DOUBLE"] &&
              i <= PlayerController.player.level.rewardChanceGroups["MONEY_50"])
        {
            gift = getMoneyGift(50);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["MONEY_50"] &&
              i <= PlayerController.player.level.rewardChanceGroups["MONEY_100"])
        {
            gift = getMoneyGift(100);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["MONEY_100"] &&
              i <= PlayerController.player.level.rewardChanceGroups["MONEY_150"])
        {
            gift = getMoneyGift(150);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["MONEY_150"] &&
              i <= PlayerController.player.level.rewardChanceGroups["MONEY_200"])
        {
            gift = getMoneyGift(200);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["MONEY_200"] &&
              i <= PlayerController.player.level.rewardChanceGroups["MONEY_250"])
        {
            gift = getMoneyGift(250);
        }
        else if (i > PlayerController.player.level.rewardChanceGroups["MONEY_250"])
        {
            gift = getMoneyGift(300);
        }
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

    //public static Gift getPhoenixGift(GameStage gameStage)
    //{
    //    System.out.println("TRYING TO GET PET GIFT!");
    //    if (!Upgrade.getPhoenix().enabled && !Upgrade.getPhoenix().bought)
    //    {
    //        Gift gift = new Gift();
    //        gift.upgrade = Upgrade.getPhoenix();
    //        gift.upgrade.tryPeriod = true;
    //        gift.upgrade.tryPeriodDuration = ONE_HOUR;
    //        gift.type = PHOENIX;
    //        return gift;
    //    }
    //    else
    //    {
    //        return getRandomMoneyGift();
    //    }
    //}

    //public static Gift getDoubleJuiceGift(GameStage gameStage)
    //{
    //    System.out.println("TRYING TO GET PET GIFT!");
    //    if (!Upgrade.getBJDouble().enabled && !Upgrade.getBJDouble().bought)
    //    {
    //        Gift gift = new Gift();
    //        gift.upgrade = Upgrade.getBJDouble();
    //        gift.upgrade.tryPeriod = true;
    //        gift.upgrade.tryPeriodDuration = ONE_HOUR;
    //        gift.type = BJ_DOUBLE;
    //        return gift;
    //    }
    //    else
    //    {
    //        return getRandomMoneyGift();
    //    }
    //}

    public void takeGift()
    {
        //PromoWindow.offerPromo = false;
        switch (type)
        {
            case (MONEY):
                {
                    PlayerController.player.BJamountTotal += money;
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
            //case (PHOENIX):
            //    {
            //        upgrade.tryPeriod = true;
            //        //                upgrade.tryPeriodDuration = 1 * 60;
            //        upgrade.tryPeriodStart = System.currentTimeMillis();
            //        upgrade.bought = true;
            //        upgrade.enabled = true;
            //        fpc.upgrades.put(Upgrade.UpgradeType.PHOENIX, upgrade);
            //        TrialTimer.trialTimerLogoName = upgrade.shopIcon;
            //        break;
            //    }
            //case (BJ_DOUBLE):
            //    {
            //        upgrade.tryPeriod = true;
            //        //                upgrade.tryPeriodDuration = 1 * 60;
            //        upgrade.tryPeriodStart = System.currentTimeMillis();
            //        upgrade.bought = true;
            //        upgrade.enabled = true;
            //        fpc.upgrades.put(Upgrade.UpgradeType.BJ_DOUBLE, upgrade);
            //        TrialTimer.trialTimerLogoName = upgrade.shopIcon;
            //        break;
            //    }
        }
        PlayerController.player.level.setNextLevel();
    }
}
