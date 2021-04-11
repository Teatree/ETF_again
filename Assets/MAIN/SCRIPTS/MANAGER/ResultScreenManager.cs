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
    public Image revealIcon;

    public ShopItemObject targetShopItem;

    public void Awake()
    {
        targetShopItem = PlayerController.player.getNextTargetItem(false);

        bjBestText.text = "BEST: " + PlayerController.player.BJamountBest;
        bjEarnedText.text = "+" + PlayerController.player.BJamountSession;
        bjTotalText.text = "" + (PlayerController.player.BJamountTotal - PlayerController.player.BJamountSession);
        if (targetShopItem != null)
        {
            float needUntilNextItem = targetShopItem.priceBJ - PlayerController.player.BJamountTotal;

            if (needUntilNextItem > 0)
            {
                bjUntilNextText.text = System.String.Format("YOU NEED {0} TO UNLOCK NEXT ITEM", needUntilNextItem);
            }
            else
            {
                bjUntilNextText.text = System.String.Format("CONGRATS! YOU'VE GOT {0}", targetShopItem.name);
            }


            proressBar.maxValue = targetShopItem.priceBJ;
            //proressBar.value = PlayerController.player.BJamountTotal;

            StartCoroutine(UpdateNumbersToReveal(PlayerController.player.BJamountSession));
        } else
        {
            bjUntilNextText.text = "WOW! LOOKS LIKE YOU'VE GOT IT ALL!";
            proressBar.maxValue = PlayerController.player.BJamountTotal;
            proressBar.value = PlayerController.player.BJamountTotal;
            revealIcon.gameObject.SetActive(false);
        }
    }

    public IEnumerator UpdateNumbersToReveal(int numbers)
    {
        float elapsedNumbers = 0;
        float tempCumulative = 0;
        proressBar.value = PlayerController.player.BJamountTotal - PlayerController.player.BJamountSession;
        float totalResult = PlayerController.player.BJamountTotal - PlayerController.player.BJamountSession;

        while (elapsedNumbers < numbers)
        {
            elapsedNumbers += 0.25f;

            // progress bar
            proressBar.value += 0.25f;

            // numbers
            tempCumulative += 0.25f;
            if (tempCumulative >= 1)
            {
                totalResult += 1;
                tempCumulative = 0;
            }

            //result numbers
            bjTotalText.text = "" + (int)totalResult;

            yield return new WaitForEndOfFrame();
        }

        bjTotalText.text = "" + PlayerController.player.BJamountTotal;

        if (PlayerController.player.BJamountTotal >= targetShopItem.priceBJ)
        {
            RevealIcon();
            PlayerController.player.getNextTargetItem(true);
        }
    }

    public void RevealIcon()
    {
        revealIcon.sprite = AllManager.allManager.GetSpriteByName(targetShopItem.imageIcon);
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
