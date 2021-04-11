using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public static bool IsPaused;
    public static bool IsGameStarted;

    // Manages start / end of the game condition
    // Keeps track of score
    // Pause State

    public GameObject loseAnimationsGreen;
    public GameObject RevivePopup;

    public GameObject[] coins;
    private IEnumerator coinFeedbackC;
    private Vector3 scorePosition = new Vector3(0.82f, -4.46f, 0);

    public LevelInfo level;

    public bool usedExtraLifeUpg;
    void Start()
    {
        gameManager = this;

    }

    int temp;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "butterfly_000")
        {
            Debug.Log("colliding loss! - " + collision.transform);
            loseAnimationsGreen.GetComponent<Animator>().SetTrigger("Activate");

            loseAnimationsGreen.transform.position = collision.contacts[0].point;

            if (PlayerController.player.extraLifeUpgr != null
                && PlayerController.player.extraLifeUpgr.upgradeType != null
                && PlayerController.player.extraLifeUpgr.isEquipped
                && !usedExtraLifeUpg)
            {
                Revive();
                usedExtraLifeUpg = true;

                Debug.LogError("You've used the extra life upgrade");
            }
            else
            {
                RevivePopup.SetActive(true);
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        // Relincuish Control from Flower
        // Sad Flower
        // Stop Bugs
        IsPaused = true;
    }

    public void Revive()
    {
        // 'splode the bugs
        // uncheck pause

        loseAnimationsGreen.transform.position = new Vector3(loseAnimationsGreen.transform.position.x + 30, loseAnimationsGreen.transform.position.y, loseAnimationsGreen.transform.position.z);
        BugsPool.bugsPool.DeactivateAllBugs();
        IsPaused = false;
    }

    public void CoinsFeedback(Vector3 pos, int amount)
    {
        GameObject chosenCoin = coins[0];

        foreach (GameObject c in coins)
        {
            if (c.activeSelf == false)
            {
                chosenCoin = c;
                chosenCoin.SetActive(true);
                break;
            }
        }

        coinFeedbackC = CoinFly(chosenCoin, pos, amount, 0.5f);
        StartCoroutine(coinFeedbackC);
    }

    public IEnumerator CoinFly(GameObject coin, Vector3 pos, int amount, float duration)
    {
        float elapsed_time = 0; //Elapsed time

        while (elapsed_time <= duration) //Inside the loop until the time expires
        {
            coin.transform.position = Vector3.Lerp(pos, scorePosition, (elapsed_time / duration));
            elapsed_time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        PlayerController.player.AddBJ(amount);
        coin.SetActive(false);
    }

}
