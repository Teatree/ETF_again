using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public static bool goalStatusChanged;

    public List<LevelInfo> levelsInfo;
    public int difficultyLevel;
    public string name;
    //public Dictionary<Goal.GoalType, Goal> goals = new HashMap<>();
    //public GoalGenerator goalGenerator = new GoalGenerator();

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
    //public Map<String, Integer> rewardChanceGroups;

    public Level()
    {
        name = levelsInfo[difficultyLevel].name;

        //BUG'S PARAMS
        spawnInterval = levelsInfo[difficultyLevel].spawnInterval;
        breakFreqMin = levelsInfo[difficultyLevel].breakFreqMin;
        breakFreqMax = levelsInfo[difficultyLevel].breakFreqMax;
        breakLengthMin = levelsInfo[difficultyLevel].breakLengthMin;
        breakLengthMax = levelsInfo[difficultyLevel].breakLengthMax;
        simpleBugSpawnChance = levelsInfo[difficultyLevel].simpleBugSpawnChance;
        drunkBugSpawnChance = levelsInfo[difficultyLevel].drunkBugSpawnChance;
        chargerBugSpawnChance = levelsInfo[difficultyLevel].chargerBugSpawnChance;
        queenBeeSpawnChance = levelsInfo[difficultyLevel].queenBeeSpawnChance;
        beeSpawnChance = levelsInfo[difficultyLevel].beeSpawnChance;

        simpleBugMoveDuration = levelsInfo[difficultyLevel].simpleBugMoveDuration;
        simpleBugAmplitude = levelsInfo[difficultyLevel].simpleBugAmplitude;
        drunkBugMoveDuration = levelsInfo[difficultyLevel].drunkBugMoveDuration;
        drunkBugAmplitude = levelsInfo[difficultyLevel].drunkBugAmplitude;
        beeMoveDuration = levelsInfo[difficultyLevel].beeMoveDuration;
        beeAmplitude = levelsInfo[difficultyLevel].beeAmplitude;
        queenBeeMoveDuration = levelsInfo[difficultyLevel].queenBeeMoveDuration;
        queenBeeAmplitude = levelsInfo[difficultyLevel].queenBeeAmplitude;
        chargerBugMove = levelsInfo[difficultyLevel].chargerBugMove;

        //GOALS
        maxGoalsAmount = levelsInfo[difficultyLevel].maxGoalsAmount;
        minGoalsAmount = levelsInfo[difficultyLevel].minGoalsAmount;
        easyGoalsAmount = levelsInfo[difficultyLevel].easyGoalsAmount;
        mediumGoalsAmount = levelsInfo[difficultyLevel].mediumGoalsAmount;
        hardGoalsAmount = levelsInfo[difficultyLevel].hardGoalsAmount;

        prob_eat_n_bugs = levelsInfo[difficultyLevel].prob_eat_n_bugs;
        prob_eat_n_drunks = levelsInfo[difficultyLevel].prob_eat_n_drunks;
        prob_eat_n_chargers = levelsInfo[difficultyLevel].prob_eat_n_chargers;
        prob_eat_n_simple = levelsInfo[difficultyLevel].prob_eat_n_simple;
        prob_eat_n_bees = levelsInfo[difficultyLevel].prob_eat_n_bees;
        prob_eat_n_queens = levelsInfo[difficultyLevel].prob_eat_n_queens;
        prob_eat_n_umrellas = levelsInfo[difficultyLevel].prob_eat_n_umrellas;
        prob_eat_n_butterflies = levelsInfo[difficultyLevel].prob_eat_n_butterflies;
        prob_destroy_n_cocoon = levelsInfo[difficultyLevel].prob_destroy_n_cocoon;
        prob_bounce_umbrella_n_times = levelsInfo[difficultyLevel].prob_bounce_umbrella_n_times;
        prob_tap = levelsInfo[difficultyLevel].prob_tap;
        prob_survive_n_angered_modes = levelsInfo[difficultyLevel].prob_survive_n_angered_modes;
        prob_spend_n_moneyz = levelsInfo[difficultyLevel].prob_spend_n_moneyz;
        prob_get_n_moneyz = levelsInfo[difficultyLevel].prob_get_n_moneyz;
        prob_pet_the_pet_n_times = levelsInfo[difficultyLevel].prob_pet_the_pet_n_times;
        prob_pet_eat_n_bugs = levelsInfo[difficultyLevel].prob_pet_eat_n_bugs;
        prob_pet_dash_n_times = levelsInfo[difficultyLevel].prob_pet_dash_n_times;
     //   rewardChanceGroups = levelsInfo.get(difficultyLevel).getRewardChanceGroups();
    }

    //public Goal getGoalByType(Goal.GoalType type)
    //{
    //    return goals.get(type);
    //}

    //public boolean checkAllGoals()
    //{
    //    boolean allAchieved = true;
    //    for (Goal goal : goals.values())
    //    {
    //        allAchieved = allAchieved && goal.achieved;
    //    }
    //    return allAchieved;
    //}



    //public List<Goal> getGoals()
    //{
    //    return new ArrayList<>(goals.values());
    //}

    //public void updateLevel(FlowerPublicComponent fpc)
    //{
    //    if (checkAllGoals())
    //    {
    //        //resetNewInfo();
    //        goals = goalGenerator.getGoals(fpc);
    //    }
    //}

    //public void resetNewInfo()
    //{
    //    if (difficultyLevel < levelsInfo.size())
    //    {
    //        difficultyLevel++;
    //        SaveMngr.LevelInfo info = levelsInfo.get(difficultyLevel - 1);
    //        name = info.name;
    //        spawnInterval = info.spawnInterval;
    //        breakFreqMin = info.breakFreqMin;
    //        breakFreqMax = info.breakFreqMax;
    //        breakLengthMin = info.breakLengthMin;
    //        breakLengthMax = info.breakLengthMax;
    //        simpleBugSpawnChance = info.simpleBugSpawnChance;
    //        drunkBugSpawnChance = info.drunkBugSpawnChance;
    //        chargerBugSpawnChance = info.chargerBugSpawnChance;
    //        queenBeeSpawnChance = info.queenBeeSpawnChance;
    //        beeSpawnChance = info.beeSpawnChance;

    //        simpleBugMoveDuration = info.simpleBugMoveDuration;
    //        simpleBugAmplitude = info.simpleBugAmplitude;
    //        drunkBugMoveDuration = info.drunkBugMoveDuration;
    //        drunkBugAmplitude = info.drunkBugAmplitude;
    //        beeMoveDuration = info.beeMoveDuration;
    //        beeAmplitude = info.beeAmplitude;
    //        queenBeeMoveDuration = info.queenBeeMoveDuration;
    //        queenBeeAmplitude = info.queenBeeAmplitude;
    //        chargerBugMove = info.chargerBugMove;

    //        maxGoalsAmount = info.maxGoalsAmount;
    //        minGoalsAmount = info.minGoalsAmount;
    //        easyGoalsAmount = info.easyGoalsAmount;
    //        mediumGoalsAmount = info.mediumGoalsAmount;
    //        hardGoalsAmount = info.hardGoalsAmount;
    //        rewardChanceGroups = info.getRewardChanceGroups();
    //    }
    //}

    //public String getRemainingGoals()
    //{
    //    int remainingCounter = 0;
    //    for (Goal g : goals.values())
    //    {
    //        if (!g.achieved)
    //        {
    //            remainingCounter++;
    //        }
    //    }
    //    return String.valueOf(remainingCounter);
    //}
}
