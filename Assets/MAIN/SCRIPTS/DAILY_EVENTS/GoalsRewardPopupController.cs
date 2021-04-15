using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalsRewardPopupController : MonoBehaviour
{
    public GameObject[] goalTiles;
    public Text levelText;
    public GameObject rewardGo;
    public GameObject boxParentGo;
    public GameObject boxGo;

    public GameObject rewardMoney;
    public GameObject rewardUpgrades;
    public Image upgradeIcon;

    public Text moneyText;
    public Text moneyTextSh;

    void OnEnable()
    {
        // money
        moneyText.text = "+"+ PlayerController.player.level.gift.type;
        moneyTextSh.text = "+"+PlayerController.player.level.gift.type;


        LoadNewGoals();
    }

    public void LoadNewGoals()
    {
        // load new goals
        StartCoroutine(WaitThenShow(3f));
        UIController.uIController.DisableGos();
        levelText.text = PlayerController.player.level.name;

        foreach (GameObject g in goalTiles)
        {
            g.SetActive(false);
        }
        int i = 0;

        foreach (Goal g in PlayerController.player.level.goals.Values)
        {
            goalTiles[i].SetActive(true);
            if (g.achieved)
            {
                goalTiles[i].transform.GetChild(0).gameObject.SetActive(true);
                goalTiles[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                goalTiles[i].transform.GetChild(1).gameObject.SetActive(true);
                goalTiles[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            goalTiles[i].transform.GetChild(2).transform.GetComponent<Text>().text = g.getDescriptionText();
            goalTiles[i].transform.GetChild(3).transform.GetComponent<Text>().text = g.getProgress();

            i++;
        }
    }

    public IEnumerator WaitThenShow(float duration)
    {
        float elapsed_time = 0; //Elapsed time

        while (elapsed_time <= duration) //Inside the loop until the time expires
        {
            yield return null; //Waits/skips one frame

            elapsed_time += Time.deltaTime; //Adds to the elapsed time the amount of time needed to skip/wait one frame
        }

        StartCoroutine(ShowRewardScreen(4f));
    }

    public IEnumerator ShowRewardScreen(float duration)
    {
        float elapsed_time = 0; //Elapsed time

        rewardGo.SetActive(true);

        while (elapsed_time <= duration) //Inside the loop until the time expires
        {
            Color color = rewardGo.GetComponent<Image>().color;
            color.a += 0.1f;
            rewardGo.GetComponent<Image>().color = color;

            Color colorZ = boxGo.GetComponent<Image>().color;
            colorZ.a += 0.1f;
            boxGo.GetComponent<Image>().color = colorZ;

            yield return null; //Waits/skips one frame

            boxParentGo.GetComponent<Button>().interactable = true;
            elapsed_time += Time.deltaTime; //Adds to the elapsed time the amount of time needed to skip/wait one frame
        }
    }

    public void takeGift()
    {
        PlayerController.player.takeGift();

        if (PlayerController.player.level.gift.type == Gift.MONEY)
        {
            rewardMoney.SetActive(true);
            rewardUpgrades.SetActive(false);
        }
        else if (PlayerController.player.level.gift.type == UpgradeManager.BJ_DOUBLE || PlayerController.player.level.gift.type == UpgradeManager.EXTRA_LIFE)
        {
            rewardMoney.SetActive(false);
            rewardUpgrades.SetActive(true);

            SetImage();
        }
    }

    public void SetImage()
    {
        string imageIcon = PlayerController.player.level.gift.upgrade.imageIcon;

        foreach (Sprite s in AllManager.allManager.iconImages)
        {
            if (s.name == imageIcon)
            {
                upgradeIcon.sprite = s;
                break;
            }
        }
    }
}
