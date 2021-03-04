using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreenManager : MonoBehaviour
{

    public Text bjBestText;
    public Text bjEarnedText;
    public Text bjTotalText;
    public Text bjUntilNextText;
    public Slider proressBar;

    public ShopItemObject targetShopItem;

    public void Awake()
    {
        bjBestText.text = "" + PlayerController.player.BJamountBest;
        bjEarnedText.text = "" + PlayerController.player.BJamountSession;
        bjTotalText.text = "" + PlayerController.player.BJamountTotal;

        targetShopItem = PlayerController.player.getNextTargetItem();
        float needUntilNextItem = targetShopItem.priceBJ - PlayerController.player.BJamountTotal;
        if (needUntilNextItem > 0)
        {
            bjUntilNextText.text = System.String.Format("YOU NEED {0} TO UNLOCK NEXT ITEM", needUntilNextItem);
        } else
        {
            bjUntilNextText.text = System.String.Format("Congrats! YOU'VE GOT {0}", targetShopItem.name);
        }
        if (targetShopItem != null)
        {
            proressBar.value = targetShopItem.priceBJ - PlayerController.player.BJamountTotal / targetShopItem.priceBJ;
        }
    }

    // Start reveal of the screen

    // resutl calculations + animations

    // Next item tracker


    // reveal animations

    public void GoToMainMenu()
    {
        // button Return to main menu
        SceneController.sceneController.LoadGame();
    }

    public void GoToShop()
    {
        // buttton Go to Shop
        SceneController.sceneController.LoadShop();
    }

    public void GoToContinue()
    {
        // button continue playing
        SceneController.sceneController.LoadGame();
    }
}
