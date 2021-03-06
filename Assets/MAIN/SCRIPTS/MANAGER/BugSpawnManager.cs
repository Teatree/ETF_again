using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnManager : MonoBehaviour
{
    int i;
    public GameObject bugPrefab;
 //   public GameObject[] allBugPrefabs;

    public const string SIMPLE = "Simple";
    public const string DRUNK = "Drunk";
    public const string CHARGER = "Charger";
    public const string BEE = "Bee";
    public const string QUEENBEE = "QueenBee";

    public const int DRUNK_SPAWN_PROB = 25;
    public const int SIMPLE_SPAWN_PROB = 63;
    public const int CHARGER_SPAWN_PROB = 10;
    public const int QUEENBEE_SPAWN_PROB = 1;
    public const int BEE_SPAWN_PROB = 1;
    public const int ANGERED_BEE_PATTERN_1_y_1 = 32;
    public const int ANGERED_BEE_PATTERN_1_y_2 = 500;
    public const int ANGERED_BEE_PATTERN_2_y_1 = 300;
    public const int ANGERED_BEE_PATTERN_2_y_1Stage = 200;
    public const int ANGERED_BEE_PATTERN_2_y_2 = 30;
    public const int ANGERED_BEE_PATTERN_2_y_2Stage = 550;

    public static int curDrunkProb = DRUNK_SPAWN_PROB;
    public static int curSimpleProb = SIMPLE_SPAWN_PROB;
    public static int curChargerProb = CHARGER_SPAWN_PROB;
    public static int curQueenBeeProb = QUEENBEE_SPAWN_PROB;
    public static int curBeeProb = BEE_SPAWN_PROB;
    public static int angeredBeePattern1Y1 = ANGERED_BEE_PATTERN_1_y_1;
    public static int angeredBeePattern1Y2 = ANGERED_BEE_PATTERN_1_y_2;
    public static int angeredBeePattern2Y1 = ANGERED_BEE_PATTERN_2_y_1;
    public static int angeredBeePattern2Y1stage = ANGERED_BEE_PATTERN_2_y_1Stage;
    public static int angeredBeePattern2Y2 = ANGERED_BEE_PATTERN_2_y_2;
    public static int angeredBeePattern2Y2stage = ANGERED_BEE_PATTERN_2_y_2Stage;

    public static int ANGERED_BEES_MODE_DURATION = 26;
    public static bool queenBeeOnStage = false;
    public static int angerBeePattern;
    public static int angerBeePattern1case;
    public static int angerBeePattern2case;

    private int SPAWN_MAX_X = -200;
    private int SPAWN_MIN_X = -300;
    private int SPAWN_MIN_Y = 100;
    private int SPAWN_MAX_Y = 360;

    private float spawner = 0;
    public static float break_counter = 0;
    public static float SPAWN_INTERVAL_BASE = 1.6f;
    public static float BREAK_FREQ_BASE_MIN = 13;
    public static float BREAK_FREQ_BASE_MAX = 20;
    public static float BREAK_LENGTH_BASE_MIN = 5;
    public static float BREAK_LENGTH_BASE_MAX = 8;

    public static float curSpawnInterval = SPAWN_INTERVAL_BASE;
    public static float curBreakFreqMin = BREAK_FREQ_BASE_MIN;
    public static float curBreakFreqMax = BREAK_FREQ_BASE_MAX;
    public static float curBreakLengthMin = BREAK_LENGTH_BASE_MIN;
    public static float curBreakLengthMax = BREAK_LENGTH_BASE_MAX;

    public static List<Multiplier> mulipliers;
    public static Multiplier currentMultiplier;
    public static bool isFirst;
    public static int bugsSpawned;
    public static int cocconBugsSpawned;
    public static int umbrellaBugsSpawned;

  
    private float angryBeeLinePosY = 150;
    private float angryBeeLinePosX = -300;

    public static bool isAngeredBeesMode = false;
    public static int angeredBeesModeTimer = ANGERED_BEES_MODE_DURATION;


    private void Start()
    {
        DataController.LoadAllMultipliers();
        SPAWN_MIN_X = -400;
        SPAWN_MIN_Y = 35;
        SPAWN_MAX_X = -300;
        SPAWN_MAX_Y = 515;

        break_counter = Random.Range(curBreakFreqMax, curBreakFreqMin);
        resetMultipliers();
    }

    private void Update()
    {
        curSpawnInterval = SPAWN_INTERVAL_BASE * currentMultiplier.spawnInterval * GameManager.gameManager.level.spawnInterval;
        curBreakFreqMin = BREAK_FREQ_BASE_MIN * currentMultiplier.breakFreqMin * GameManager.gameManager.level.breakFreqMin;
        curBreakFreqMax = BREAK_FREQ_BASE_MAX * currentMultiplier.breakFreqMax * GameManager.gameManager.level.breakFreqMax;
        curBreakLengthMin = BREAK_LENGTH_BASE_MIN * currentMultiplier.breakLengthMin * GameManager.gameManager.level.breakLengthMin;
        curBreakLengthMax = BREAK_LENGTH_BASE_MAX * currentMultiplier.breakLengthMax * GameManager.gameManager.level.breakLengthMax;

        curDrunkProb = (int)(DRUNK_SPAWN_PROB * currentMultiplier.drunkBugSpawnChance * GameManager.gameManager.level.drunkBugSpawnChance);
        curSimpleProb = (int)(SIMPLE_SPAWN_PROB * currentMultiplier.simpleBugSpawnChance * GameManager.gameManager.level.simpleBugSpawnChance);
        curChargerProb = (int)(CHARGER_SPAWN_PROB * currentMultiplier.chargerBugSpawnChance * GameManager.gameManager.level.chargerBugSpawnChance);
        curQueenBeeProb = (int)(QUEENBEE_SPAWN_PROB * currentMultiplier.queenBeeSpawnChance * GameManager.gameManager.level.queenBeeSpawnChance);
        curBeeProb = (int)(BEE_SPAWN_PROB * currentMultiplier.beeSpawnChance * GameManager.gameManager.level.beeSpawnChance);

        spawn();
        // SpawnBugWithInterval();
    }

    public void spawn()
    {
        if (!isAngeredBeesMode)
        {
            break_counter -= Time.deltaTime;
        }
        if (spawner <= 0/* && !blowUpAllBugs*/)
        {
            if (isAngeredBeesMode)
            {
                if (angerBeePattern == 0)
                {
                    curSpawnInterval = 0.2f;
                }
                else if (angerBeePattern == 1)
                {
                    curSpawnInterval = 0.5f;
                }
                else
                {
                    curSpawnInterval = 0.5f;
                }
                resetBreakCounter();

                createAngryBee(currentMultiplier);
            }
            else
            {
                int probabilityValue = Random.Range(0, curDrunkProb + curSimpleProb + curChargerProb + curQueenBeeProb + curBeeProb); // or 100, I dono
                if (probabilityValue <= curDrunkProb)
                {
                    createBug(DRUNK, currentMultiplier);  // Drunk
                }
                else if (probabilityValue > curDrunkProb && probabilityValue < curDrunkProb + curSimpleProb)
                {
                    createBug(SIMPLE, currentMultiplier);   // Simple
                }
                else if (probabilityValue >= curDrunkProb + curSimpleProb + 1 && probabilityValue < curDrunkProb + curSimpleProb + curChargerProb)
                {
                    createBug(CHARGER, currentMultiplier);  // Charger
                }
                else if (probabilityValue >= curDrunkProb + curSimpleProb + curChargerProb + 1 && probabilityValue < curDrunkProb + curSimpleProb + curChargerProb + curQueenBeeProb)
                {
                    if (!queenBeeOnStage)
                    {
                        createBug(QUEENBEE, currentMultiplier);    // Queen Bee, duh
                        queenBeeOnStage = true;
                    }
                }
                else if (probabilityValue >= curDrunkProb + curSimpleProb + curChargerProb + curQueenBeeProb + 1 &&
                      probabilityValue < curDrunkProb + curSimpleProb + curChargerProb + curQueenBeeProb + curBeeProb)
                {
                    createBug(BEE, currentMultiplier);   // Bee
                }
                bugsSpawned++;
                //if (PowerupSystem.canCocoonSpawn(gameStage))
                //{
                //    cocconBugsSpawned++;
                //}
                //if (PowerupSystem.canUmbrellaSpawn(gameStage))
                //{
                //    umbrellaBugsSpawned++;
                //}

                //                System.out.println("bugSpawned: " + bugsSpawned);
                //                System.out.println("currentMultimplierDrunkBug: " + currentMultiplier.drunkBugSpawnChance);
            }

            if (break_counter > 0.1f)
            {
                if (isAngeredBeesMode)
                {
                    break_counter -= Time.deltaTime;
                }
                spawner = curSpawnInterval;
                isFirst = true;
            }
            else
            {
                spawner = Random.Range(0, (int)curBreakLengthMax - (int)curBreakLengthMin) + curBreakLengthMin;
                break_counter = Random.Range(0, (int)(curBreakFreqMax * 100) - (int)(curBreakFreqMin * 100)) + (curBreakFreqMin * 100);
                break_counter /= 100;
                angerBeePattern1case = Random.Range(0, 2);
                angerBeePattern2case = Random.Range(0, 2);
                angeredBeePattern1Y1 = ANGERED_BEE_PATTERN_1_y_1;
                angeredBeePattern1Y2 = ANGERED_BEE_PATTERN_1_y_2;
                angeredBeePattern2Y1 = ANGERED_BEE_PATTERN_2_y_1;
                angeredBeePattern2Y1stage = ANGERED_BEE_PATTERN_2_y_1Stage;
                angeredBeePattern2Y2 = ANGERED_BEE_PATTERN_2_y_2;
                angeredBeePattern2Y2stage = ANGERED_BEE_PATTERN_2_y_2Stage;

                //new angry bee row
                angryBeeLinePosY = Random.Range(0, SPAWN_MAX_Y - SPAWN_MIN_Y) + SPAWN_MIN_Y;
            }

        }
        else
        {
            spawner -= Time.deltaTime;
        }
        //        System.out.println("spanwer: " + spawner);
        //        System.out.println("break_counter: " + break_counter);
    }


    private void createBug(string tempType, Multiplier currentMultiplier)
    {
        bugPrefab = GetBugPrefabByName(tempType);
        Instantiate(bugPrefab);
        BugController bc = bugPrefab.GetComponent<BugController>();
        //   BugComponent bc = new BugComponent(gameStage, tempType, currentMultiplier);
        if (bugPrefab == null)
        {
            //            System.out.println("temp bug type " + tempType);
        }
        Bug bug = bugPrefab.GetComponent<Bug>();
        bug.applyMultiplier(currentMultiplier);

        setPos(bugPrefab, bc);
        //bc.startYPosition = tc.y;
        //bugEntity.getComponent(TransformComponent.class).x = tc.x;
        //bugEntity.getComponent(TransformComponent.class).y = tc.y;
    }

    private void createAngryBee(Multiplier currentMultiplier)
    {
        bugPrefab = bugPrefab = GetBugPrefabByName("Bee");
        Instantiate(bugPrefab);

        BugController bugController = bugPrefab.GetComponent<BugController>();
        Bug bug = bugPrefab.GetComponent<Bug>();

        bug.isAngeredBee = true;
        //bug.interpolation = null;

        Vector2 bugPosition = new Vector2();
        bugPosition.x = angryBeeLinePosX;

        if (angerBeePattern == 0)
        {
            if (isFirst)
            {
                //            System.out.println("YES, I AM WORKING!");
                bugPosition.y = angryBeeLinePosY - 60;
                isFirst = false;
            }
            else
            {
                bugPosition.y = angryBeeLinePosY;
            }

            bug.endX = 1450;
            bug.endY = bugPosition.y;

            bugPrefab.transform.position = bugPosition;
            bug.startY = bugPosition.y;
        }
        else if (angerBeePattern == 1)
        {
            if (angerBeePattern1case == 1)
            {
                bugPosition.y = angeredBeePattern1Y1 += 100;
                bug.endX = 1450;
                bug.endY = bugPosition.y;
            }
            else
            {
                bugPosition.y = angeredBeePattern1Y2 -= 100;
                bug.endX = 1450;
                bug.endY = bugPosition.y;
            }
        }
        else
        {
            if (angerBeePattern2case == 1)
            {
                if (angeredBeePattern2Y1 < 490)
                {
                    bugPosition.y = angeredBeePattern2Y1 += 100;
                }
                else
                {
                    if (angeredBeePattern2Y1stage > 150)
                    {
                        bugPosition.y = angeredBeePattern2Y1stage -= 100;
                    }
                    else
                    {
                        bugPosition.y = angeredBeePattern2Y1stage += 100;
                    }
                }

                bug.endX = 1450;
                bug.endY = bugPosition.y;
            }
            else
            {
                if (angeredBeePattern2Y2 < 150)
                {
                    bugPosition.y = angeredBeePattern2Y2 += 100;
                }
                else
                {
                    if (angeredBeePattern2Y2stage > 150)
                    {
                        bugPosition.y = angeredBeePattern2Y2stage -= 100;
                    }
                    else
                    {
                        bugPosition.y = angeredBeePattern2Y2stage += 100;
                    }
                }
                bug.endX = 1450;
                bug.endY = bugPosition.y;
            }
        }
    }

    private void setPos(GameObject g, BugController bc)
    {
        Vector2 res = new Vector2();
        res.x = Random.Range(0, SPAWN_MAX_X - SPAWN_MIN_X) + SPAWN_MIN_X;
        res.y = Random.Range(0, SPAWN_MAX_Y - SPAWN_MIN_Y) + SPAWN_MIN_Y;
        transform.position = res;
        bc.vEndPos = new Vector3(1450, res.y, 0);
    }

    private void SpawnBugWithInterval()
    {

        if (GameManager.IsPaused == false)
        {
            i++;
            if (i == 150)
            {
                SpawnBug();
                i = 0;
            }
        }
    }

    private void SpawnBug()
    {
        // TODO: probability value based on level, time in the game...
        int i = Random.Range(0, 5);
        if (i == 0)
        {
            bugPrefab = GetBugPrefabByName("Simple");
        }
        else if (i == 1)
        {
            bugPrefab = GetBugPrefabByName("Drunk");
        }
        else if (i == 2)
        {
            bugPrefab = GetBugPrefabByName("Bee");
        }
        else if (i == 3)
        {
            bugPrefab = GetBugPrefabByName("Simple");
        }
        else
        {
            bugPrefab = GetBugPrefabByName("Charger");
        }

        Instantiate(bugPrefab);
        bugPrefab.transform.position = GenerateSpawnPos();

        AdjustBugValues(bugPrefab);
    }

    private void AdjustBugValues(GameObject _b)
    {
        // Adjust bug values based on time / level
        //_b.speed = 0.5f;
    }

    private GameObject GetBugPrefabByName(string name)
    {
        for (int i = 0; i < allBugPrefabs.Length; i++)
        {
            if (allBugPrefabs[i].GetComponent<Bug>().name == name)
            {
                return allBugPrefabs[i];
            }
        }
        return null;
    }

    private Vector2 GenerateSpawnPos()
    {
        Vector2 pos = new Vector2();
        pos.y = Random.Range(0f, 3.5f);
        pos.x = Random.Range(-10, -9);

        return pos;
    }

    public bool isBlewUp()
    {
        return isAngeredBeesMode & angeredBeesModeTimer == ANGERED_BEES_MODE_DURATION - 10;
    }

    public static void resetMultipliers()
    {
        currentMultiplier = mulipliers[0];
    }

    public static void resetBreakCounter()
    {
        curBreakFreqMin = 0.12f;
        curBreakFreqMax = 0.16f;
        curBreakLengthMin = BREAK_LENGTH_BASE_MIN / 2;
        curBreakLengthMax = BREAK_LENGTH_BASE_MAX / 2;
    }
}
