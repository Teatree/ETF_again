using System.Collections;
using System.Collections.Generic;
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

    public LevelInfo level; 
    void Start()
    {
        gameManager = this;
    }

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

            // show popup


            // open pause popup
            RevivePopup.SetActive(true);

            // pause game
            PauseGame();
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

}
