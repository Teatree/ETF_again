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
    public static Dictionary<int, string> periodTypeMap;
    //public static Dictionary<int, PetComponent> petType;

    public int counter;
    public bool achieved;
    public bool justAchieved;
    public string description;
    public GoalType type;
    public string periodType;
    public int n;
    // public PetComponent pet;

    public Goal()
    {
        init();
    }

    public Goal(GoalType goalType, int difficulty, float goalMultiplier)
    {
        init();
        this.type = goalType;
        description = goalType.desc;
        periodType = periodTypeMap[Random.Range(0, goalType.periodTypeMax)];
        if (periodType.Equals(GoalConstants.PERIOD_TOTAL))
        {
            if (GoalConstants.getbParameters()[goalType.name][difficulty * 2 + 1] != GoalConstants.getbParameters()[goalType.name][difficulty * 2])
            {
                n = Random.Range(0, GoalConstants.getbParameters()[goalType.name][difficulty * 2 + 1] - GoalConstants.getbParameters()[goalType.name][difficulty * 2]) + GoalConstants.getbParameters()[goalType.name][difficulty * 2];
            }
            else
            {
                n = GoalConstants.getbParameters()[goalType.name][difficulty * 2];
            }
        }
        else
        {
            if (GoalConstants.getbParameters()[goalType.name][difficulty * 2 + 7] != GoalConstants.getbParameters()[goalType.name][difficulty * 2 + 6])
            {
                n = Random.Range(0, GoalConstants.getbParameters()[goalType.name][difficulty * 2 + 7] - GoalConstants.getbParameters()[goalType.name][difficulty * 2 + 6]) + GoalConstants.getbParameters()[goalType.name][difficulty * 2 + 6];
            }
            else
            {
                n = GoalConstants.getbParameters()[goalType.name][difficulty * 2 + 6];
            }
        }
        n = (int)(n * goalMultiplier);
    }

    public void update()
    {
        if (counter >= n && !achieved)
        {
            Level.goalStatusChanged = true;
            achieved = true;
            justAchieved = true;
            //    if (!GoalFeedbackScreen.shouldShow)
            //    {
            //        GoalFeedbackScreen.shouldShow = true;
            //    }
            //}
        }
    }

    public string getDescriptionText()
    {
        if (periodType.Equals(GoalConstants.PERIOD_TOTAL))
        {
            return description.Replace("#", " " + n + " ") + " " + "IN TOTAL";
        }
        else
        {
            return description.Replace("#", " " + n + " ") + " " + "IN ONE LIFE";
        }
    }

    public static void init()
    {
        periodTypeMap = new Dictionary<int, string>();
        periodTypeMap[0] = GoalConstants.PERIOD_IN_LIFE;
        periodTypeMap[1] = GoalConstants.PERIOD_TOTAL;

       // petType = new HashMap<>();
        //int ba = 0;
        //for (PetComponent p : fpc.pets)
        //{
        //    petType.put(ba++, p);
        //}
    }

    public string getProgress()
    {
        return "Progress: " + counter + "/" + n;
    }

    public void checkBugGoal(Bug bug)
    {
        if (!achieved)
        {
            if (type.name == "EAT_N_BUGS")
            {
                counter++;
            }
            if (type.name == "EAT_N_DRUNKS" && bug._type == Bug._TYPE.DRUNK)
            {
                counter++;
            }
            if (type.name == "EAT_N_SIMPLE" && bug._type == Bug._TYPE.SIMPLE)
            {
                counter++;
            }
            if (type.name == "EAT_N_BEES" && bug._type == Bug._TYPE.BEE)
            {
                counter++;
            }
            if (type.name == "EAT_N_CHARGERS" && bug._type == Bug._TYPE.CHARGER)
            {
                counter++;
            }
            if (type.name == "EAT_N_QUEENS" && bug._type == Bug._TYPE.QUEENBEE)
            {
                counter++;
            }
        }
        update();
    }

    public void checkX2Bounce()
    {
        if (type.name == "BOUNCE_UMBRELLA_N_TIMES" && !achieved)
        {
            counter++;
        }
        update();
    }
    public void checkCocoonDestroy()
    {
        if (type.name == "DESTROY_N_COCOON" && !achieved)
        {
            counter++;
        }
        update();
    }
    public void checkEatX2()
    {
        if (type.name == "EAT_N_UMBRELLA" && !achieved)
        {
            counter++;
        }
        update();
    }
    public void checkEatButterfly()
    {
        if (type.name == "EAT_N_BUTTERFLIES" && !achieved)
        {
            counter++;
        }
        update();
    }
}

    public struct GoalType {
        public string desc;
        public int periodTypeMax;
        public string name;

        public static GoalType EAT_N_BUGS = new GoalType("EAT_N_BUGS", GoalConstants.EAT_N_BUGS_DESC, 2);
        public static GoalType GET_N_POINTS = new GoalType("GET_N_POINTS", GoalConstants.GET_N_POINTS_DESC, 2);
        public static GoalType SPEND_MONEYZ = new GoalType("SPEND_MONEYZ", GoalConstants.SPEND_MONEYZ_DESC, 1);
        public static GoalType EAT_N_DRUNKS = new GoalType("EAT_N_DRUNKS", GoalConstants.EAT_N_DRUNKS_DESC, 2);
        public static GoalType EAT_N_CHARGERS = new GoalType("EAT_N_CHARGERS", GoalConstants.EAT_N_CHARGERS_DESC, 2);
        public static GoalType EAT_N_SIMPLE = new GoalType("EAT_N_SIMPLE", GoalConstants.EAT_N_SIMPLE_DESC, 2);
        public static GoalType EAT_N_BEES = new GoalType("EAT_N_BEES", GoalConstants.EAT_N_BEES_DESC, 2);
        public static GoalType DESTROY_N_COCOON = new GoalType("DESTROY_N_COCOON", GoalConstants.DESTROY_N_COCOON_DESC, 2);
        public static GoalType EAT_N_UMBRELLA = new GoalType("EAT_N_UMBRELLA", GoalConstants.EAT_N_UMBRELLA_DESC, 2);
        public static GoalType EAT_N_BUTTERFLIES = new GoalType("EAT_N_BUTTERFLIES", GoalConstants.EAT_N_BUTTERFLIES_DESC, 2);
        public static GoalType BOUNCE_UMBRELLA_N_TIMES = new GoalType("BOUNCE_UMBRELLA_N_TIMES", GoalConstants.BOUNCE_UMBRELLA_N_TIMES_DESC, 1);
        public static GoalType TAP = new GoalType("TAP", GoalConstants.TAP_DESC, 2);
        public static GoalType EAT_N_QUEENS = new GoalType("EAT_N_QUEENS", GoalConstants.EAT_N_QUEENS_DESC, 2);
        public static GoalType SURVIVE_N_ANGERED_MODES = new GoalType("SURVIVE_N_ANGERED_MODES", GoalConstants.SURVIVE_N_ANGERED_MODES_DESC, 2);
        public static GoalType PET_THE_PET = new GoalType("PET_THE_PET", GoalConstants.PET_THE_PET_DESC, 2);
        public static GoalType PET_EAT_N_BUGS = new GoalType("PET_EAT_N_BUGS", GoalConstants.PET_EAT_N_BUGS_DESC, 2);
        public static GoalType PET_DASH_N_TIMES = new GoalType("PET_DASH_N_TIMES", GoalConstants.PET_CHARGE_N_TIMES_DESC, 2);

    GoalType(string name,string desc, int periodTypeMax)
    {
        this.name = name;
        this.desc = desc;
        this.periodTypeMax = periodTypeMax;
    }


    public static GoalType getByName(string name)
    {
        if (name == "EAT_N_BUGS") return EAT_N_BUGS;
        if (name == "GET_N_POINTS") return GET_N_POINTS;
        if (name == "SPEND_MONEYZ") return SPEND_MONEYZ;
        if (name == "EAT_N_DRUNKS") return EAT_N_DRUNKS;
        if (name == "EAT_N_CHARGERS") return EAT_N_CHARGERS;
        if (name == "EAT_N_SIMPLE") return EAT_N_SIMPLE;
        if (name == "EAT_N_BEES") return EAT_N_BEES;
        if (name == "DESTROY_N_COCOON") return DESTROY_N_COCOON;
        if (name == "EAT_N_UMBRELLA") return EAT_N_UMBRELLA;
        if (name == "EAT_N_BUTTERFLIES") return EAT_N_BUTTERFLIES;
        if (name == "BOUNCE_UMBRELLA_N_TIMES") return BOUNCE_UMBRELLA_N_TIMES;
        if (name == "TAP") return TAP;

        if (name == "EAT_N_QUEENS") return EAT_N_QUEENS;
        if (name == "SURVIVE_N_ANGERED_MODES") return SURVIVE_N_ANGERED_MODES;
        if (name == "PET_THE_PET") return PET_THE_PET;
        if (name == "PET_EAT_N_BUGS") return PET_EAT_N_BUGS;
        if (name == "PET_DASH_N_TIMES") return PET_DASH_N_TIMES;
        return EAT_N_BUGS;
    }

}