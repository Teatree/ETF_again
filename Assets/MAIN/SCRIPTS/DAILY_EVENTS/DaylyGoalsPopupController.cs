using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaylyGoalsPopupController : MonoBehaviour
{
    public GameObject[] goalTiles;
    public Text levelText;
    public Text header;
    public Text headerSh;

    void OnEnable()
    {
        if(GameManager.IsGameStarted == true)
        {
            header.text = "Pause";
            headerSh.text = "Pause";
        }
        else
        {
            header.text = "Challenges";
            headerSh.text = "Challenges";
        }

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

}
