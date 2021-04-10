using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public static bool goalStatusChanged;

    public static List<LevelInfo> allLevelsInfo;
    public int difficultyLevel = 1;
    public string name;
    public Dictionary<string, Goal> goals = new Dictionary<string, Goal>();
    public GoalGenerator goalGenerator = new GoalGenerator();
    public Gift gift;

    public float spawnInterval = 1;
    public float breakFreqMin = 1;
    public float breakFreqMax = 1;
    public float breakLengthMin = 1;
    public float breakLengthMax = 1;
    public float simpleBugSpawnChance = 1;
    public float drunkBugSpawnChance = 1;
    public float chargerBugSpawnChance = 1;
    public float queenBeeSpawnChance = 1;
    public float beeSpawnChance = 1;

    public float simpleBugMoveDuration = 1;
    public float simpleBugAmplitude = 1;
    public float drunkBugMoveDuration = 1;
    public float drunkBugAmplitude = 1;
    public float beeMoveDuration = 1;
    public float beeAmplitude = 1;
    public float queenBeeMoveDuration = 1;
    public float queenBeeAmplitude = 1;
    public float chargerBugMove = 1;

    public int maxGoalsAmount = 5;
    public int minGoalsAmount = 3;
    public int easyGoalsAmount = 1;
    public int mediumGoalsAmount = 1;
    public int hardGoalsAmount = 1;
    public float goalMultiplier = 1.05f;

    public float prob_eat_n_bugs;
    public float prob_eat_n_drunks;
    public float prob_eat_n_chargers;
    public float prob_eat_n_simple;
    public float prob_eat_n_bees;
    public float prob_eat_n_queens;
    public float prob_eat_n_umrellas;
    public float prob_eat_n_butterflies;
    public float prob_destroy_n_cocoon;
    public float prob_bounce_umbrella_n_times;
    public float prob_tap;
    public float prob_survive_n_angered_modes;
    public float prob_spend_n_moneyz;
    public float prob_get_n_moneyz;
    public float prob_pet_the_pet_n_times;
    public float prob_pet_eat_n_bugs;
    public float prob_pet_dash_n_times;
    public Dictionary<string, int> rewardChanceGroups;

    public Level()
    {
        name = allLevelsInfo[difficultyLevel].name;

        //BUG'S PARAMS
        spawnInterval = allLevelsInfo[difficultyLevel].spawnInterval;
        breakFreqMin = allLevelsInfo[difficultyLevel].breakFreqMin;
        breakFreqMax = allLevelsInfo[difficultyLevel].breakFreqMax;
        breakLengthMin = allLevelsInfo[difficultyLevel].breakLengthMin;
        breakLengthMax = allLevelsInfo[difficultyLevel].breakLengthMax;
        simpleBugSpawnChance = allLevelsInfo[difficultyLevel].simpleBugSpawnChance;
        drunkBugSpawnChance = allLevelsInfo[difficultyLevel].drunkBugSpawnChance;
        chargerBugSpawnChance = allLevelsInfo[difficultyLevel].chargerBugSpawnChance;
        queenBeeSpawnChance = allLevelsInfo[difficultyLevel].queenBeeSpawnChance;
        beeSpawnChance = allLevelsInfo[difficultyLevel].beeSpawnChance;

        simpleBugMoveDuration = allLevelsInfo[difficultyLevel].simpleBugMoveDuration;
        simpleBugAmplitude = allLevelsInfo[difficultyLevel].simpleBugAmplitude;
        drunkBugMoveDuration = allLevelsInfo[difficultyLevel].drunkBugMoveDuration;
        drunkBugAmplitude = allLevelsInfo[difficultyLevel].drunkBugAmplitude;
        beeMoveDuration = allLevelsInfo[difficultyLevel].beeMoveDuration;
        beeAmplitude = allLevelsInfo[difficultyLevel].beeAmplitude;
        queenBeeMoveDuration = allLevelsInfo[difficultyLevel].queenBeeMoveDuration;
        queenBeeAmplitude = allLevelsInfo[difficultyLevel].queenBeeAmplitude;
        chargerBugMove = allLevelsInfo[difficultyLevel].chargerBugMove;

        //GOALS
        maxGoalsAmount = allLevelsInfo[difficultyLevel].maxGoalsAmount;
        minGoalsAmount = allLevelsInfo[difficultyLevel].minGoalsAmount;
        easyGoalsAmount = allLevelsInfo[difficultyLevel].easyGoalsAmount;
        mediumGoalsAmount = allLevelsInfo[difficultyLevel].mediumGoalsAmount;
        hardGoalsAmount = allLevelsInfo[difficultyLevel].hardGoalsAmount;

        prob_eat_n_bugs = allLevelsInfo[difficultyLevel].prob_eat_n_bugs;
        prob_eat_n_drunks = allLevelsInfo[difficultyLevel].prob_eat_n_drunks;
        prob_eat_n_chargers = allLevelsInfo[difficultyLevel].prob_eat_n_chargers;
        prob_eat_n_simple = allLevelsInfo[difficultyLevel].prob_eat_n_simple;
        prob_eat_n_bees = allLevelsInfo[difficultyLevel].prob_eat_n_bees;
        prob_eat_n_queens = allLevelsInfo[difficultyLevel].prob_eat_n_queens;
        prob_eat_n_umrellas = allLevelsInfo[difficultyLevel].prob_eat_n_umrellas;
        prob_eat_n_butterflies = allLevelsInfo[difficultyLevel].prob_eat_n_butterflies;
        prob_destroy_n_cocoon = allLevelsInfo[difficultyLevel].prob_destroy_n_cocoon;
        prob_bounce_umbrella_n_times = allLevelsInfo[difficultyLevel].prob_bounce_umbrella_n_times;
        prob_tap = allLevelsInfo[difficultyLevel].prob_tap;
        prob_survive_n_angered_modes = allLevelsInfo[difficultyLevel].prob_survive_n_angered_modes;
        prob_spend_n_moneyz = allLevelsInfo[difficultyLevel].prob_spend_n_moneyz;
        prob_get_n_moneyz = allLevelsInfo[difficultyLevel].prob_get_n_moneyz;
        prob_pet_the_pet_n_times = allLevelsInfo[difficultyLevel].prob_pet_the_pet_n_times;
        prob_pet_eat_n_bugs = allLevelsInfo[difficultyLevel].prob_pet_eat_n_bugs;
        prob_pet_dash_n_times = allLevelsInfo[difficultyLevel].prob_pet_dash_n_times;
        //   rewardChanceGroups = allLevelsInfo.get(difficultyLevel).getRewardChanceGroups();
    }

    public Goal getGoalByType(GoalType type)
    {
        return goals[type.name];
    }

    public bool checkAllGoals()
    {
        bool allAchieved = true;
        foreach (Goal goal in goals.Values)
        {
            allAchieved = allAchieved && goal.achieved;
        }
        return allAchieved;
    }

    public List<Goal> getGoals()
    {
        return new List<Goal>(goals.Values);
    }

    public void updateLevel()
    {
        if (checkAllGoals())
        {
            resetNewInfo();
            goals = goalGenerator.getGoals();
        }
    }

    public void setNextLevel()
    {
        difficultyLevel++;
        resetNewInfo();
        goals = null;
        goals = goalGenerator.getGoals();
    }

    public void resetNewInfo()
    {
        if (difficultyLevel < allLevelsInfo.Count)
        {
            LevelInfo info = allLevelsInfo[difficultyLevel - 1];
            name = info.name;
            spawnInterval = info.spawnInterval;
            breakFreqMin = info.breakFreqMin;
            breakFreqMax = info.breakFreqMax;
            breakLengthMin = info.breakLengthMin;
            breakLengthMax = info.breakLengthMax;
            simpleBugSpawnChance = info.simpleBugSpawnChance;
            drunkBugSpawnChance = info.drunkBugSpawnChance;
            chargerBugSpawnChance = info.chargerBugSpawnChance;
            queenBeeSpawnChance = info.queenBeeSpawnChance;
            beeSpawnChance = info.beeSpawnChance;

            simpleBugMoveDuration = info.simpleBugMoveDuration;
            simpleBugAmplitude = info.simpleBugAmplitude;
            drunkBugMoveDuration = info.drunkBugMoveDuration;
            drunkBugAmplitude = info.drunkBugAmplitude;
            beeMoveDuration = info.beeMoveDuration;
            beeAmplitude = info.beeAmplitude;
            queenBeeMoveDuration = info.queenBeeMoveDuration;
            queenBeeAmplitude = info.queenBeeAmplitude;
            chargerBugMove = info.chargerBugMove;

            maxGoalsAmount = info.maxGoalsAmount;
            minGoalsAmount = info.minGoalsAmount;
            easyGoalsAmount = info.easyGoalsAmount;
            mediumGoalsAmount = info.mediumGoalsAmount;
            hardGoalsAmount = info.hardGoalsAmount;
            rewardChanceGroups = info.getRewardChanceGroups();
        }

        gift = Gift.getRandomGift();

    }



    public string getRemainingGoals()
    {
        int remainingCounter = 0;
        foreach (Goal g in goals.Values)
        {
            if (!g.achieved)
            {
                remainingCounter++;
            }
        }
        return "" + remainingCounter;
    }
}
