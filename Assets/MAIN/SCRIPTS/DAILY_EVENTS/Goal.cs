using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * goals:
 * 1. eat n butterflies +
 * 2. get n points +
 * 3. eat n umbrella +
 * 4. bounce umbrella +
 * 5. eat n queens +
 * 6. survive n angered bees mode +
 * 7. eat n bees +`
 * 8. eat n charge +
 * 9. eat n drunks +
 * 10. eat n simple bugs +
 * 11. eat n bugs +
 * 12. TAP +
 * 13. EAT_N_BUG_UPPER +
 * 14. EAT_N_BUG_LOWER +
 * 15. PET_THE_PET +
 * 16. PET_EAT_N_BUGS
 * 17. PET_DASH_N_TIMES +
 * 18. DESTROY_N_COCOON +
 */

public class Goal
    {

        public static Dictionary<int, PeriodType> periodTypeMap;
        //public static Dictionary<int, PetComponent> petType;

        public int counter;
        public bool achieved;
        public bool justAchieved;
        public string description;
        public GoalType type;
        public PeriodType periodType;
       public int n;
       // public PetComponent pet;

        public Goal()
        {
        }

        public Goal(GoalType goalType, int difficulty, float goalMultiplier)
        {
            this.type = goalType;
            description = goalType.desc;
            periodType = periodTypeMap[Random.Range(0, goalType.periodTypeMax)];
            if (periodType.Equals( PeriodType.TOTAL))
            {
                if (GoalConstants.getbParameters()[goalType][difficulty * 2 + 1] != GoalConstants.getbParameters()[goalType][difficulty * 2])
                {
                    n = Random.Range(0, GoalConstants.getbParameters()[goalType][difficulty * 2 + 1] - GoalConstants.getbParameters()[goalType][difficulty * 2]) + GoalConstants.getbParameters()[goalType][difficulty * 2];
                }
                else
                {
                    n = GoalConstants.getbParameters()[goalType][difficulty * 2];
                }
            }
            else
            {
                if (GoalConstants.getbParameters()[goalType][difficulty * 2 + 7] != GoalConstants.getbParameters()[goalType][difficulty * 2 + 6])
                {
                    n = Random.Range(0, GoalConstants.getbParameters()[goalType][difficulty * 2 + 7] - GoalConstants.getbParameters()[goalType][difficulty * 2 + 6]) + GoalConstants.getbParameters()[goalType][difficulty * 2 + 6];
                }
                else
                {
                    n = GoalConstants.getbParameters()[goalType][difficulty * 2 + 6];
                }
            }
            n = (int)(n * goalMultiplier);
        }

}


public struct GoalType {
        public string desc;
        public int periodTypeMax;
        public static GoalType EAT_N_BUGS = new GoalType(GoalConstants.EAT_N_BUGS_DESC, 2);
        public static GoalType GET_N_POINTS = new GoalType(GoalConstants.GET_N_POINTS_DESC, 2);
        public static GoalType SPEND_MONEYZ = new GoalType(GoalConstants.SPEND_MONEYZ_DESC, 1);
        public static GoalType EAT_N_DRUNKS = new GoalType(GoalConstants.EAT_N_DRUNKS_DESC, 2);
        public static GoalType EAT_N_CHARGERS = new GoalType(GoalConstants.EAT_N_CHARGERS_DESC, 2);
        public static GoalType EAT_N_SIMPLE = new GoalType(GoalConstants.EAT_N_SIMPLE_DESC, 2);
        public static GoalType EAT_N_BEES = new GoalType(GoalConstants.EAT_N_BEES_DESC, 2);
        public static GoalType DESTROY_N_COCOON = new GoalType(GoalConstants.DESTROY_N_COCOON_DESC, 2);
        public static GoalType EAT_N_UMBRELLA = new GoalType(GoalConstants.EAT_N_UMBRELLA_DESC, 2);
        public static GoalType EAT_N_BUTTERFLIES = new GoalType(GoalConstants.EAT_N_BUTTERFLIES_DESC, 2);
        public static GoalType BOUNCE_UMBRELLA_N_TIMES = new GoalType(GoalConstants.BOUNCE_UMBRELLA_N_TIMES_DESC, 1);
        public static GoalType TAP = new GoalType(GoalConstants.TAP_DESC, 2);
        public static GoalType EAT_N_QUEENS = new GoalType(GoalConstants.EAT_N_QUEENS_DESC, 2);
        public static GoalType SURVIVE_N_ANGERED_MODES = new GoalType(GoalConstants.SURVIVE_N_ANGERED_MODES_DESC, 2);
        public static GoalType PET_THE_PET = new GoalType(GoalConstants.PET_THE_PET_DESC, 2);
        public static GoalType PET_EAT_N_BUGS = new GoalType(GoalConstants.PET_EAT_N_BUGS_DESC, 2);
        public static GoalType PET_DASH_N_TIMES = new GoalType(GoalConstants.PET_CHARGE_N_TIMES_DESC, 2);

    GoalType(string desc, int periodTypeMax)
    {
        this.desc = desc;
        this.periodTypeMax = periodTypeMax;
    }

}

public struct PeriodType {
    public static PeriodType IN_ONE_LIFE = new PeriodType(5);
    public static PeriodType TOTAL = new PeriodType(1);

    public int adjustByTypeDivider;

    PeriodType(int divider)
    {
        this.adjustByTypeDivider = divider;
    }
}