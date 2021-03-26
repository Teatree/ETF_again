using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGenerator
{
    List<GoalType> goalTypes;

    public GoalGenerator()
    {
        goalTypes = new List<GoalType>();
        goalTypes.Add(GoalType.EAT_N_BUGS) ;
        goalTypes.Add(GoalType.SPEND_MONEYZ);
        goalTypes.Add(GoalType.GET_N_POINTS);
        goalTypes.Add(GoalType.EAT_N_DRUNKS);
        goalTypes.Add(GoalType.EAT_N_CHARGERS);
        goalTypes.Add(GoalType.EAT_N_SIMPLE);
        goalTypes.Add(GoalType.EAT_N_BEES);
        goalTypes.Add(GoalType.DESTROY_N_COCOON);
        goalTypes.Add(GoalType.EAT_N_UMBRELLA);
        goalTypes.Add(GoalType.EAT_N_BUTTERFLIES);
        goalTypes.Add(GoalType.BOUNCE_UMBRELLA_N_TIMES);
        goalTypes.Add(GoalType.TAP);
        goalTypes.Add(GoalType.EAT_N_QUEENS);
        goalTypes.Add(GoalType.SURVIVE_N_ANGERED_MODES);
        goalTypes.Add(GoalType.PET_EAT_N_BUGS);
        goalTypes.Add(GoalType.PET_DASH_N_TIMES);
        goalTypes.Add(GoalType.PET_THE_PET);
        goalTypes.Add(GoalType.PET_DASH_N_TIMES);
    }

    public Dictionary<string, Goal> getGoals()
    {
        Dictionary<string, Goal> goals = new Dictionary<string, Goal>();
        int goalsAmount = Random.Range(PlayerController.player.level.minGoalsAmount, PlayerController.player.level.maxGoalsAmount);
        int medGoalsCounter = PlayerController.player.level.mediumGoalsAmount;
        int hardGoalsCounter = PlayerController.player.level.hardGoalsAmount;
        for (int i = 0; i <= goalsAmount; i++)
        {
            if (hardGoalsCounter > 0)
            {
                Goal dg = createGoal(2, PlayerController.player);
                goals[dg.type.name] = dg;
                hardGoalsCounter--;
            }
            else if (medGoalsCounter > 0)
            {
                Goal dg = createGoal(1, PlayerController.player);
                goals[dg.type.name] = dg;
                medGoalsCounter--;
            }
            else
            {
                Goal dg = createGoal(0, PlayerController.player);
                goals[dg.type.name] = dg;
            }
            
        }
        return goals;
    }

    private Goal createGoal(int difficulty, PlayerController fpc)
    {
        int probabilityValueRandom = Random.Range(1, 100);
        int probabilityValueCheck = 0;
        GoalType goalType = GoalType.EAT_N_BUGS;

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_eat_n_bugs)
        {
            goalType = GoalType.EAT_N_BUGS;

            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_eat_n_bugs;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_eat_n_drunks)
        {
            goalType = GoalType.EAT_N_DRUNKS;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int) fpc.level.prob_eat_n_drunks;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_eat_n_chargers)
        {
            goalType = GoalType.EAT_N_CHARGERS;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_eat_n_chargers;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_eat_n_simple)
        {
            goalType = GoalType.EAT_N_SIMPLE;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_eat_n_simple;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_eat_n_bees)
        {
            goalType = GoalType.EAT_N_BEES;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_eat_n_bees;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_eat_n_queens)
        {
            goalType = GoalType.EAT_N_QUEENS;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_eat_n_queens;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_eat_n_umrellas)
        {
            goalType = GoalType.EAT_N_UMBRELLA;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_eat_n_umrellas;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_eat_n_butterflies)
        {
            goalType = GoalType.EAT_N_BUTTERFLIES;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_eat_n_butterflies;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_destroy_n_cocoon)
        {
            goalType = GoalType.DESTROY_N_COCOON;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_destroy_n_cocoon;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_bounce_umbrella_n_times)
        {
            goalType = GoalType.BOUNCE_UMBRELLA_N_TIMES;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_bounce_umbrella_n_times;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_tap)
        {
            goalType = GoalType.TAP;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_tap;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_survive_n_angered_modes)
        {
            goalType = GoalType.SURVIVE_N_ANGERED_MODES;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_survive_n_angered_modes;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_pet_the_pet_n_times)
        {
            goalType = GoalType.PET_THE_PET;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_pet_the_pet_n_times;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_pet_eat_n_bugs)
        {
            goalType = GoalType.PET_EAT_N_BUGS;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }
        else
        {
            probabilityValueCheck += (int)fpc.level.prob_pet_eat_n_bugs;
        }

        if (probabilityValueRandom > probabilityValueCheck
                && probabilityValueRandom <= probabilityValueCheck + fpc.level.prob_pet_dash_n_times)
        {
            goalType = GoalType.PET_DASH_N_TIMES;
            return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
        }

        return new Goal(goalType, difficulty, fpc.level.goalMultiplier);
    }
}
