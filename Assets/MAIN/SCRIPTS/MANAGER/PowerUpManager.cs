using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static bool isPowerUpOnScene;
    public GameObject coccoonGo;

    float timer = 0f;
    int counter = 0;
    int spawnIntervalIndex;
    int[] spawnIntervals = {30, 15, 30, 15, 30, 15}; // seconds

    string powerup = "ChosenPowerUp";
    int bias = 50;

    // Update is called once per frame
    void Update()
    {
        if(isPowerUpOnScene == false && GameManager.IsPaused == false)
        {
            SpawnPowerUpsWithInterval();
        }
    }

    public void SpawnPowerUpsWithInterval()
    {
        // the longer Player plays the more more power ups appear
        if (counter < spawnIntervals[spawnIntervalIndex])
        {
            timer += Time.deltaTime;
            counter = (int)timer % 60;
        }
        else
        {
            counter = 0;
            timer = 0;

            SpawnPowerUp();

            spawnIntervalIndex++;
            if(spawnIntervalIndex >= spawnIntervals.Length)
            {
                spawnIntervalIndex = 0;
            }
        }
    }

    public void SpawnPowerUp()
    {
        if(isPowerUpOnScene == false)
        {
            isPowerUpOnScene = true;

            int roll = Random.Range(0, 100);
            int result = roll + bias;

            Debug.Log("result: " + result);

            if (result > 75)
            {
                powerup = "x2";
                bias -= 150;

                X2Controller.x2Controller.Spawn();
            }
            else
            {
                powerup = "cocoon";
                bias += 25;

                coccoonGo.SetActive(true);
            }
        }

    }
}
