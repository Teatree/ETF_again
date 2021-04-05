using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnManager : MonoBehaviour
{
    public static BugSpawnManager bugSpawn;

    public const int DRUNK_SPAWN_PROB = 25;
    public const int SIMPLE_SPAWN_PROB = 63;
    public const int CHARGER_SPAWN_PROB = 10;
    public const int QUEENBEE_SPAWN_PROB = 1;
    public const int BEE_SPAWN_PROB = 1;
    public const float ANGERED_BEE_PATTERN_1_y_1 = -2.43f;
    public const float ANGERED_BEE_PATTERN_1_y_2 = 3.360f;
    public const float ANGERED_BEE_PATTERN_2_y_1 = -1.43f;
    public const float ANGERED_BEE_PATTERN_2_y_1Stage = 1.360f;
    public const float ANGERED_BEE_PATTERN_2_y_2 = 1;
    public const float ANGERED_BEE_PATTERN_2_y_2Stage = 3;

    public static int curDrunkProb = DRUNK_SPAWN_PROB;
    public static int curSimpleProb = SIMPLE_SPAWN_PROB;
    public static int curChargerProb = CHARGER_SPAWN_PROB;
    public static int curQueenBeeProb = QUEENBEE_SPAWN_PROB;
    public static int curBeeProb = BEE_SPAWN_PROB;
    public static float angeredBeePattern1Y1 = ANGERED_BEE_PATTERN_1_y_1;
    public static float angeredBeePattern1Y2 = ANGERED_BEE_PATTERN_1_y_2;
    public static float angeredBeePattern2Y1 = ANGERED_BEE_PATTERN_2_y_1;
    public static float angeredBeePattern2Y1stage = ANGERED_BEE_PATTERN_2_y_1Stage;
    public static float angeredBeePattern2Y2 = ANGERED_BEE_PATTERN_2_y_2;
    public static float angeredBeePattern2Y2stage = ANGERED_BEE_PATTERN_2_y_2Stage;

    public static int ANGERED_BEES_MODE_DURATION = 26;
    public static bool queenBeeOnStage = false;
    public static int angerBeePattern;
    public static int angerBeePattern1case;
    public static int angerBeePattern2case;

    private float SPAWN_MAX_X = -10;
    private float SPAWN_MIN_X = -20;
    private float SPAWN_MIN_Y = -2.43f;
    private float SPAWN_MAX_Y = 3.360f;

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


    private float angryBeeLinePosY = 2.550f;
    private float angryBeeLinePosX = -20;

    public static bool isAngeredBeesMode = false;
    public static int angeredBeesModeTimer = ANGERED_BEES_MODE_DURATION;


    private void Start()
    {
        bugSpawn = this;

        break_counter = Random.Range(curBreakFreqMax, curBreakFreqMin);
        resetMultipliers();
    }

    private void Awake()
    {
        //DataController.LoadAllMultipliers();

        //break_counter = Random.Range(curBreakFreqMax, curBreakFreqMin);

        //Debug.Log("YES!!! ``````````");
        //resetMultipliers();
    }

    private void Update()
    {
        if (!GameManager.IsPaused)
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
        }
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
                    createBug(BugsPool.DRUNK, currentMultiplier);  // Drunk
                }
                else if (probabilityValue > curDrunkProb && probabilityValue < curDrunkProb + curSimpleProb)
                {
                    createBug(BugsPool.SIMPLE, currentMultiplier);   // Simple
                }
                else if (probabilityValue >= curDrunkProb + curSimpleProb + 1 && probabilityValue < curDrunkProb + curSimpleProb + curChargerProb)
                {
                    createBug(BugsPool.CHARGER, currentMultiplier);  // Charger
                }
                else if (probabilityValue >= curDrunkProb + curSimpleProb + curChargerProb + 1 && probabilityValue < curDrunkProb + curSimpleProb + curChargerProb + curQueenBeeProb)
                {
                    if (!queenBeeOnStage)
                    {
                        createBug(BugsPool.QUEENBEE, currentMultiplier);    // Queen Bee, duh
                        queenBeeOnStage = true;
                    }
                }
                else if (probabilityValue >= curDrunkProb + curSimpleProb + curChargerProb + curQueenBeeProb + 1 &&
                      probabilityValue < curDrunkProb + curSimpleProb + curChargerProb + curQueenBeeProb + curBeeProb)
                {
                    createBug(BugsPool.BEE, currentMultiplier);   // Bee
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


    public void AngerBees()
    {
        
        isFirst = true;

        isAngeredBeesMode = true;
        BugsPool.bugsPool.DeactivateAllBugs();
        queenBeeOnStage = false;

        angerBeePattern = Random.Range(0, 3);
        resetBreakCounter();
        break_counter = Random.Range(0, (int)(curBreakFreqMax * 100) - (int)(curBreakFreqMin * 100)) + (curBreakFreqMin * 100);
        break_counter /= 100;
    }

    private void createBug(string tempType, Multiplier currentMultiplier)
    {
        GameObject aBug = BugsPool.bugsPool.GetBugByType(tempType);
        BugController bc = aBug.GetComponent<BugController>();
        //   BugComponent bc = new BugComponent(gameStage, tempType, currentMultiplier);
        if (aBug == null)
        {
            //            System.out.println("temp bug type " + tempType);
        }
        Bug bug = aBug.GetComponent<Bug>();
        bug.applyMultiplier(currentMultiplier);
        bc.bug = bug;

        setPos(aBug, bc);
        //bc.startYPosition = tc.y;
        //bugEntity.getComponent(TransformComponent.class).x = tc.x;
        //bugEntity.getComponent(TransformComponent.class).y = tc.y;
    }

    private void createAngryBee(Multiplier currentMultiplier)
    {
        GameObject bugPrefab = BugsPool.bugsPool.GetBugByType(BugsPool.BEE);

        BugController bugController = bugPrefab.GetComponent<BugController>();
        Bug bug = bugPrefab.GetComponent<Bug>();
        bugController.bug = bug;

        bug.isAngeredBee = true;
        //bug.interpolation = null;

        Vector2 bugPosition = new Vector2();
        bugPosition.x = angryBeeLinePosX;

        if (angerBeePattern == 0)
        {
            if (isFirst)
            {
                //            System.out.println("YES, I AM WORKING!");
                bugPosition.y = angryBeeLinePosY - 1;
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
                bugPosition.y = angeredBeePattern1Y1 += 2;
                bug.endX = 1450;
                bug.endY = bugPosition.y;
            }
            else
            {
                bugPosition.y = angeredBeePattern1Y2 -= 2;
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
                    bugPosition.y = angeredBeePattern2Y1 += 2;
                }
                else
                {
                    if (angeredBeePattern2Y1stage > 150) // ???
                    {
                        bugPosition.y = angeredBeePattern2Y1stage -= 2;
                    }
                    else
                    {
                        bugPosition.y = angeredBeePattern2Y1stage += 2;
                    }
                }

                bug.endX = 1450;
                bug.endY = bugPosition.y;
            }
            else
            {
                if (angeredBeePattern2Y2 < 150)
                {
                    bugPosition.y = angeredBeePattern2Y2 += 1;
                }
                else
                {
                    if (angeredBeePattern2Y2stage > 150)
                    {
                        bugPosition.y = angeredBeePattern2Y2stage -= 1;
                    }
                    else
                    {
                        bugPosition.y = angeredBeePattern2Y2stage += 1;
                    }
                }
                bug.endX = 1450;
                bug.endY = bugPosition.y;
            }
        }
        //setPos(bugPrefab, bugController);
    }

    private void setPos(GameObject g, BugController bc)
    {
        Vector2 res = new Vector2();
        res.x = Random.Range(0, SPAWN_MAX_X - SPAWN_MIN_X) + SPAWN_MIN_X;
        res.y = Random.Range(0, SPAWN_MAX_Y - SPAWN_MIN_Y) + SPAWN_MIN_Y;
        g.transform.position = res;
        bc.vEndPos = new Vector3(1450, res.y, 0);
    }

    private void AdjustBugValues(GameObject _b)
    {
        // Adjust bug values based on time / level
        //_b.speed = 0.5f;
    }

    //private GameObject GetBugPrefabByName(string name)
    //{
    //    for (int i = 0; i < allBugPrefabs.Length; i++)
    //    {
    //        if (allBugPrefabs[i].GetComponent<Bug>().name == name)
    //        {
    //            return allBugPrefabs[i];
    //        }
    //    }
    //    return null;
    //}

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
