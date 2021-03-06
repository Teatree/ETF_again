﻿using System.Collections.Generic;
using UnityEngine;

public class GoalConstants
{
    public static string PERIOD_TOTAL = "TOTAL";
    public static string PERIOD_IN_LIFE = "IN_ONE_LIFE";

    public static int EAT_N_BUGS_EASY_MIN = 20;
    public static int EAT_N_BUGS_EASY_MAX = 25;
    public static int EAT_N_BUGS_MED_MIN = 20;
    public static int EAT_N_BUGS_MED_MAX = 30;
    public static int EAT_N_BUGS_HARD_MIN = 31;
    public static int EAT_N_BUGS_HARD_MAX = 53;
    public static int EAT_N_BUGS_1LIFE_EASY_MIN = 7;
    public static int EAT_N_BUGS_1LIFE_EASY_MAX = 14;
    public static int EAT_N_BUGS_1LIFE_MED_MIN = 15;
    public static int EAT_N_BUGS_1LIFE_MED_MAX = 19;
    public static int EAT_N_BUGS_1LIFE_HARD_MIN = 20;
    public static int EAT_N_BUGS_1LIFE_HARD_MAX = 25;
    public static string PET_EAT_N_BUGS_DESC = "FEED PET WITH # BUGS";

    public static int DESTROY_N_COCOON_EASY_MIN = 1;
    public static int DESTROY_N_COCOON_EASY_MAX = 2;
    public static int DESTROY_N_COCOON_MED_MIN = 2;
    public static int DESTROY_N_COCOON_MED_MAX = 2;
    public static int DESTROY_N_COCOON_HARD_MIN = 3;
    public static int DESTROY_N_COCOON_HARD_MAX = 4;
    public static int DESTROY_N_COCOON_1LIFE_EASY_MIN = 1;
    public static int DESTROY_N_COCOON_1LIFE_EASY_MAX = 1;
    public static int DESTROY_N_COCOON_1LIFE_MED_MIN = 1;
    public static int DESTROY_N_COCOON_1LIFE_MED_MAX = 1;
    public static int DESTROY_N_COCOON_1LIFE_HARD_MIN = 1;
    public static int DESTROY_N_COCOON_1LIFE_HARD_MAX = 1;
    public static string DESTROY_N_COCOON_DESC = "BREAK # COCOONS";

    public static int EAT_N_BUTTERFLIES_EASY_MIN = 1;
    public static int EAT_N_BUTTERFLIES_EASY_MAX = 2;
    public static int EAT_N_BUTTERFLIES_MED_MIN = 2;
    public static int EAT_N_BUTTERFLIES_MED_MAX = 3;
    public static int EAT_N_BUTTERFLIES_HARD_MIN = 3;
    public static int EAT_N_BUTTERFLIES_HARD_MAX = 5;
    public static int EAT_N_BUTTERFLIES_1LIFE_EASY_MIN = 1;
    public static int EAT_N_BUTTERFLIES_1LIFE_EASY_MAX = 1;
    public static int EAT_N_BUTTERFLIES_1LIFE_MED_MIN = 1;
    public static int EAT_N_BUTTERFLIES_1LIFE_MED_MAX = 1;
    public static int EAT_N_BUTTERFLIES_1LIFE_HARD_MIN = 1;
    public static int EAT_N_BUTTERFLIES_1LIFE_HARD_MAX = 1;
    public static string EAT_N_BUTTERFLIES_DESC = "EAT # BUTTERFLIES";

    public static int GET_N_POINTS_EASY_MIN = 200;
    public static int GET_N_POINTS_EASY_MAX = 500;
    public static int GET_N_POINTS_MED_MIN = 501;
    public static int GET_N_POINTS_MED_MAX = 700;
    public static int GET_N_POINTS_HARD_MIN = 701;
    public static int GET_N_POINTS_HARD_MAX = 1000;
    public static int GET_N_POINTS_1LIFE_EASY_MIN = 200;
    public static int GET_N_POINTS_1LIFE_EASY_MAX = 500;
    public static int GET_N_POINTS_1LIFE_MED_MIN = 501;
    public static int GET_N_POINTS_1LIFE_MED_MAX = 700;
    public static int GET_N_POINTS_1LIFE_HARD_MIN = 701;
    public static int GET_N_POINTS_1LIFE_HARD_MAX = 1000;
    public static string GET_N_POINTS_DESC = "GET # POINTS";

    public static int SPEND_MONEYZ_EASY_MIN = 200;
    public static int SPEND_MONEYZ_EASY_MAX = 500;
    public static int SPEND_MONEYZ_MED_MIN = 376;
    public static int SPEND_MONEYZ_MED_MAX = 525;
    public static int SPEND_MONEYZ_HARD_MIN = 526;
    public static int SPEND_MONEYZ_HARD_MAX = 750;
    public static int SPEND_MONEYZ_1LIFE_EASY_MIN = 200;
    public static int SPEND_MONEYZ_1LIFE_EASY_MAX = 500;
    public static int SPEND_MONEYZ_1LIFE_MED_MIN = 501;
    public static int SPEND_MONEYZ_1LIFE_MED_MAX = 700;
    public static int SPEND_MONEYZ_1LIFE_HARD_MIN = 701;
    public static int SPEND_MONEYZ_1LIFE_HARD_MAX = 1000;
    public static string SPEND_MONEYZ_DESC = "SPEND # MONEYZ";

    public static int EAT_N_UMBRELLA_EASY_MIN = 2;
    public static int EAT_N_UMBRELLA_EASY_MAX = 4;
    public static int EAT_N_UMBRELLA_MED_MIN = 3;
    public static int EAT_N_UMBRELLA_MED_MAX = 4;
    public static int EAT_N_UMBRELLA_HARD_MIN = 5;
    public static int EAT_N_UMBRELLA_HARD_MAX = 7;
    public static int EAT_N_UMBRELLA_1LIFE_EASY_MIN = 1;
    public static int EAT_N_UMBRELLA_1LIFE_EASY_MAX = 1;
    public static int EAT_N_UMBRELLA_1LIFE_MED_MIN = 1;
    public static int EAT_N_UMBRELLA_1LIFE_MED_MAX = 1;
    public static int EAT_N_UMBRELLA_1LIFE_HARD_MIN = 2;
    public static int EAT_N_UMBRELLA_1LIFE_HARD_MAX = 2;
    public static string EAT_N_UMBRELLA_DESC = "CATCH # X2 BONUSES";

    public static int BOUNCE_UMBRELLA_N_TIMES_EASY_MIN = 5;
    public static int BOUNCE_UMBRELLA_N_TIMES_EASY_MAX = 7;
    public static int BOUNCE_UMBRELLA_N_TIMES_MED_MIN = 5;
    public static int BOUNCE_UMBRELLA_N_TIMES_MED_MAX = 9;
    public static int BOUNCE_UMBRELLA_N_TIMES_HARD_MIN = 9;
    public static int BOUNCE_UMBRELLA_N_TIMES_HARD_MAX = 12;
    public static int BOUNCE_UMBRELLA_1LIFE_N_TIMES_EASY_MIN = 2;
    public static int BOUNCE_UMBRELLA_1LIFE_N_TIMES_EASY_MAX = 3;
    public static int BOUNCE_UMBRELLA_1LIFE_N_TIMES_MED_MIN = 4;
    public static int BOUNCE_UMBRELLA_1LIFE_N_TIMES_MED_MAX = 4;
    public static int BOUNCE_UMBRELLA_1LIFE_N_TIMES_HARD_MIN = 4;
    public static int BOUNCE_UMBRELLA_1LIFE_N_TIMES_HARD_MAX = 4;
    public static string BOUNCE_UMBRELLA_N_TIMES_DESC = "LET X2 BONUS BOUNCE # TIMES";

    public static int EAT_N_QUEENS_EASY_MIN = 1;
    public static int EAT_N_QUEENS_EASY_MAX = 3;
    public static int EAT_N_QUEENS_MED_MIN = 3;
    public static int EAT_N_QUEENS_MED_MAX = 5;
    public static int EAT_N_QUEENS_HARD_MIN = 6;
    public static int EAT_N_QUEENS_HARD_MAX = 9;
    public static int EAT_N_QUEENS_1LIFE_EASY_MIN = 1;
    public static int EAT_N_QUEENS_1LIFE_EASY_MAX = 1;
    public static int EAT_N_QUEENS_1LIFE_MED_MIN = 1;
    public static int EAT_N_QUEENS_1LIFE_MED_MAX = 1;
    public static int EAT_N_QUEENS_1LIFE_HARD_MIN = 1;
    public static int EAT_N_QUEENS_1LIFE_HARD_MAX = 1;
    public static string EAT_N_QUEENS_DESC = "EAT # QUEENS";

    public static int SURVIVE_N_ANGERED_MODES_EASY_MIN = 1;
    public static int SURVIVE_N_ANGERED_MODES_EASY_MAX = 2;
    public static int SURVIVE_N_ANGERED_MODES_MED_MIN = 2;
    public static int SURVIVE_N_ANGERED_MODES_MED_MAX = 4;
    public static int SURVIVE_N_ANGERED_MODES_HARD_MIN = 5;
    public static int SURVIVE_N_ANGERED_MODES_HARD_MAX = 8;
    public static int SURVIVE_N_ANGERED_MODES_1LIFE_EASY_MIN = 1;
    public static int SURVIVE_N_ANGERED_MODES_1LIFE_EASY_MAX = 1;
    public static int SURVIVE_N_ANGERED_MODES_1LIFE_MED_MIN = 2;
    public static int SURVIVE_N_ANGERED_MODES_1LIFE_MED_MAX = 2;
    public static int SURVIVE_N_ANGERED_MODES_1LIFE_HARD_MIN = 2;
    public static int SURVIVE_N_ANGERED_MODES_1LIFE_HARD_MAX = 2;
    public static string SURVIVE_N_ANGERED_MODES_DESC = "SURVIVE # BEE ATTACKS";

    public static int EAT_N_BEES_EASY_MIN = 10;
    public static int EAT_N_BEES_EASY_MAX = 15;
    public static int EAT_N_BEES_MED_MIN = 12;
    public static int EAT_N_BEES_MED_MAX = 19;
    public static int EAT_N_BEES_HARD_MIN = 20;
    public static int EAT_N_BEES_HARD_MAX = 30;
    public static int EAT_N_BEES_1LIFE_EASY_MIN = 3;
    public static int EAT_N_BEES_1LIFE_EASY_MAX = 6;
    public static int EAT_N_BEES_1LIFE_MED_MIN = 7;
    public static int EAT_N_BEES_1LIFE_MED_MAX = 12;
    public static int EAT_N_BEES_1LIFE_HARD_MIN = 13;
    public static int EAT_N_BEES_1LIFE_HARD_MAX = 22;
    public static string EAT_N_BEES_DESC = "EAT # BEES";

    public static int EAT_N_CHARGERS_EASY_MIN = 10;
    public static int EAT_N_CHARGERS_EASY_MAX = 15;
    public static int EAT_N_CHARGERS_MED_MIN = 12;
    public static int EAT_N_CHARGERS_MED_MAX = 19;
    public static int EAT_N_CHARGERS_HARD_MIN = 20;
    public static int EAT_N_CHARGERS_HARD_MAX = 30;
    public static int EAT_N_CHARGERS_1LIFE_EASY_MIN = 3;
    public static int EAT_N_CHARGERS_1LIFE_EASY_MAX = 6;
    public static int EAT_N_CHARGERS_1LIFE_MED_MIN = 7;
    public static int EAT_N_CHARGERS_1LIFE_MED_MAX = 12;
    public static int EAT_N_CHARGERS_1LIFE_HARD_MIN = 13;
    public static int EAT_N_CHARGERS_1LIFE_HARD_MAX = 22;
    public static string EAT_N_CHARGERS_DESC = "EAT # STAG BEETLES";

    public static int EAT_N_DRUNKS_EASY_MIN = 10;
    public static int EAT_N_DRUNKS_EASY_MAX = 15;
    public static int EAT_N_DRUNKS_MED_MIN = 12;
    public static int EAT_N_DRUNKS_MED_MAX = 19;
    public static int EAT_N_DRUNKS_HARD_MIN = 20;
    public static int EAT_N_DRUNKS_HARD_MAX = 30;
    public static int EAT_N_DRUNKS_1LIFE_EASY_MIN = 3;
    public static int EAT_N_DRUNKS_1LIFE_EASY_MAX = 6;
    public static int EAT_N_DRUNKS_1LIFE_MED_MIN = 7;
    public static int EAT_N_DRUNKS_1LIFE_MED_MAX = 12;
    public static int EAT_N_DRUNKS_1LIFE_HARD_MIN = 13;
    public static int EAT_N_DRUNKS_1LIFE_HARD_MAX = 22;
    public static string EAT_N_DRUNKS_DESC = "EAT # FLIES";

    public static int EAT_N_SIMPLE_EASY_MIN = 10;
    public static int EAT_N_SIMPLE_EASY_MAX = 15;
    public static int EAT_N_SIMPLE_MED_MIN = 12;
    public static int EAT_N_SIMPLE_MED_MAX = 19;
    public static int EAT_N_SIMPLE_HARD_MIN = 20;
    public static int EAT_N_SIMPLE_HARD_MAX = 30;
    public static int EAT_N_SIMPLE_1LIFE_EASY_MIN = 3;
    public static int EAT_N_SIMPLE_1LIFE_EASY_MAX = 6;
    public static int EAT_N_SIMPLE_1LIFE_MED_MIN = 7;
    public static int EAT_N_SIMPLE_1LIFE_MED_MAX = 12;
    public static int EAT_N_SIMPLE_1LIFE_HARD_MIN = 13;
    public static int EAT_N_SIMPLE_1LIFE_HARD_MAX = 22;
    public static string EAT_N_SIMPLE_DESC = "EAT # MOSQUITOES";

    public static int PET_EAT_N_BUGS_EASY_MIN = 20;
    public static int PET_EAT_N_BUGS_EASY_MAX = 25;
    public static int PET_EAT_N_BUGS_MED_MIN = 20;
    public static int PET_EAT_N_BUGS_MED_MAX = 30;
    public static int PET_EAT_N_BUGS_HARD_MIN = 31;
    public static int PET_EAT_N_BUGS_HARD_MAX = 53;
    public static int PET_EAT_N_BUGS_1LIFE_EASY_MIN = 7;
    public static int PET_EAT_N_BUGS_1LIFE_EASY_MAX = 14;
    public static int PET_EAT_N_BUGS_1LIFE_MED_MIN = 15;
    public static int PET_EAT_N_BUGS_1LIFE_MED_MAX = 19;
    public static int PET_EAT_N_BUGS_1LIFE_HARD_MIN = 20;
    public static int PET_EAT_N_BUGS_1LIFE_HARD_MAX = 22;
    public static string EAT_N_BUGS_DESC = "EAT # BUGS";

    public static int PET_THE_PET_EASY_MIN = 20;
    public static int PET_THE_PET_EASY_MAX = 35;
    public static int PET_THE_PET_MED_MIN = 27;
    public static int PET_THE_PET_MED_MAX = 41;
    public static int PET_THE_PET_HARD_MIN = 42;
    public static int PET_THE_PET_HARD_MAX = 60;
    public static int PET_THE_PET_1LIFE_EASY_MIN = 5;
    public static int PET_THE_PET_1LIFE_EASY_MAX = 10;
    public static int PET_THE_PET_1LIFE_MED_MIN = 11;
    public static int PET_THE_PET_1LIFE_MED_MAX = 20;
    public static int PET_THE_PET_1LIFE_HARD_MIN = 21;
    public static int PET_THE_PET_1LIFE_HARD_MAX = 30;
    public static string PET_THE_PET_DESC = "PET THE PET # TIMES";

    public static int PET_CHARGE_N_TIMES_EASY_MIN = 7;
    public static int PET_CHARGE_N_TIMES_EASY_MAX = 10;
    public static int PET_CHARGE_N_TIMES_MED_MIN = 8;
    public static int PET_CHARGE_N_TIMES_MED_MAX = 12;
    public static int PET_CHARGE_N_TIMES_HARD_MIN = 13;
    public static int PET_CHARGE_N_TIMES_HARD_MAX = 19;
    public static int PET_CHARGE_N_TIMES_1LIFE_EASY_MIN = 1;
    public static int PET_CHARGE_N_TIMES_1LIFE_EASY_MAX = 2;
    public static int PET_CHARGE_N_TIMES_1LIFE_MED_MIN = 3;
    public static int PET_CHARGE_N_TIMES_1LIFE_MED_MAX = 4;
    public static int PET_CHARGE_N_TIMES_1LIFE_HARD_MIN = 5;
    public static int PET_CHARGE_N_TIMES_1LIFE_HARD_MAX = 6;
    public static string PET_CHARGE_N_TIMES_DESC = "LAUNCH PET # TIMES";

    public static int TAP_EASY_MIN = 100;
    public static int TAP_EASY_MAX = 200;
    public static int TAP_MED_MIN = 151;
    public static int TAP_MED_MAX = 375;
    public static int TAP_HARD_MIN = 376;
    public static int TAP_HARD_MAX = 750;
    public static int TAP_1LIFE_EASY_MIN = 30;
    public static int TAP_1LIFE_EASY_MAX = 50;
    public static int TAP_1LIFE_MED_MIN = 51;
    public static int TAP_1LIFE_MED_MAX = 80;
    public static int TAP_1LIFE_HARD_MIN = 81;
    public static int TAP_1LIFE_HARD_MAX = 120;
    public static string TAP_DESC = "TAP # TIMES";

    private static Dictionary<string, List<int>> bParameters;

    public static Dictionary<string, List<int>> getbParameters()
    {
        if (bParameters == null)
        {
            bParameters = new Dictionary<string, List<int>>();
            List<int> eat_n_bug_goals = new List<int>();
            eat_n_bug_goals.Add(EAT_N_BUGS_EASY_MIN);
            eat_n_bug_goals.Add(EAT_N_BUGS_EASY_MAX);
            eat_n_bug_goals.Add(EAT_N_BUGS_MED_MIN);
            eat_n_bug_goals.Add(EAT_N_BUGS_MED_MAX);
            eat_n_bug_goals.Add(EAT_N_BUGS_HARD_MIN);
            eat_n_bug_goals.Add(EAT_N_BUGS_HARD_MAX);
            eat_n_bug_goals.Add(EAT_N_BUGS_1LIFE_EASY_MIN);
            eat_n_bug_goals.Add(EAT_N_BUGS_1LIFE_EASY_MAX);
            eat_n_bug_goals.Add(EAT_N_BUGS_1LIFE_MED_MIN);
            eat_n_bug_goals.Add(EAT_N_BUGS_1LIFE_MED_MAX);
            eat_n_bug_goals.Add(EAT_N_BUGS_1LIFE_HARD_MIN);
            eat_n_bug_goals.Add(EAT_N_BUGS_1LIFE_HARD_MAX);
            bParameters["EAT_N_BUGS"] =  eat_n_bug_goals;

            List<int> pet_charge_n_times_goals = new List<int>();
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_EASY_MIN);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_EASY_MAX);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_MED_MIN);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_MED_MAX);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_HARD_MIN);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_HARD_MAX);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_1LIFE_EASY_MIN);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_1LIFE_EASY_MAX);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_1LIFE_MED_MIN);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_1LIFE_MED_MAX);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_1LIFE_HARD_MIN);
            pet_charge_n_times_goals.Add(PET_CHARGE_N_TIMES_1LIFE_HARD_MAX);
            bParameters["PET_DASH_N_TIMES"] = pet_charge_n_times_goals;

            List<int> destroy_n_cocoon_goals = new List<int>();
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_EASY_MIN);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_EASY_MAX);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_MED_MIN);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_MED_MAX);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_HARD_MIN);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_HARD_MAX);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_1LIFE_EASY_MIN);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_1LIFE_EASY_MAX);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_1LIFE_MED_MIN);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_1LIFE_MED_MAX);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_1LIFE_HARD_MIN);
            destroy_n_cocoon_goals.Add(DESTROY_N_COCOON_1LIFE_HARD_MAX);
            bParameters["DESTROY_N_COCOON"]=destroy_n_cocoon_goals;

            List<int> eat_n_butterflies_goals = new List<int>();
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_EASY_MIN);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_EASY_MAX);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_MED_MIN);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_MED_MAX);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_HARD_MIN);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_HARD_MAX);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_1LIFE_EASY_MIN);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_1LIFE_EASY_MAX);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_1LIFE_MED_MIN);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_1LIFE_MED_MAX);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_1LIFE_HARD_MIN);
            eat_n_butterflies_goals.Add(EAT_N_BUTTERFLIES_1LIFE_HARD_MAX);
            bParameters["EAT_N_BUTTERFLIES"] = eat_n_butterflies_goals;

            List<int> get_n_points_goals = new List<int>();
            get_n_points_goals.Add(GET_N_POINTS_EASY_MIN);
            get_n_points_goals.Add(GET_N_POINTS_EASY_MAX);
            get_n_points_goals.Add(GET_N_POINTS_MED_MIN);
            get_n_points_goals.Add(GET_N_POINTS_MED_MAX);
            get_n_points_goals.Add(GET_N_POINTS_HARD_MIN);
            get_n_points_goals.Add(GET_N_POINTS_HARD_MAX);
            get_n_points_goals.Add(GET_N_POINTS_1LIFE_EASY_MIN);
            get_n_points_goals.Add(GET_N_POINTS_1LIFE_EASY_MAX);
            get_n_points_goals.Add(GET_N_POINTS_1LIFE_MED_MIN);
            get_n_points_goals.Add(GET_N_POINTS_1LIFE_MED_MAX);
            get_n_points_goals.Add(GET_N_POINTS_1LIFE_HARD_MIN);
            get_n_points_goals.Add(GET_N_POINTS_1LIFE_HARD_MAX);
            bParameters["GET_N_POINTS"] = get_n_points_goals;

            List<int> spend_moneyz_goals = new List<int>();
            spend_moneyz_goals.Add(SPEND_MONEYZ_EASY_MIN);
            spend_moneyz_goals.Add(SPEND_MONEYZ_EASY_MAX);
            spend_moneyz_goals.Add(SPEND_MONEYZ_MED_MIN);
            spend_moneyz_goals.Add(SPEND_MONEYZ_MED_MAX);
            spend_moneyz_goals.Add(SPEND_MONEYZ_HARD_MIN);
            spend_moneyz_goals.Add(SPEND_MONEYZ_HARD_MAX);
            spend_moneyz_goals.Add(SPEND_MONEYZ_1LIFE_EASY_MIN);
            spend_moneyz_goals.Add(SPEND_MONEYZ_1LIFE_EASY_MAX);
            spend_moneyz_goals.Add(SPEND_MONEYZ_1LIFE_MED_MIN);
            spend_moneyz_goals.Add(SPEND_MONEYZ_1LIFE_MED_MAX);
            spend_moneyz_goals.Add(SPEND_MONEYZ_1LIFE_HARD_MIN);
            spend_moneyz_goals.Add(SPEND_MONEYZ_1LIFE_HARD_MAX);
            bParameters["SPEND_MONEYZ"]= spend_moneyz_goals;

            List<int> eat_n_umbrella_goals = new List<int>();
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_EASY_MIN);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_EASY_MAX);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_MED_MIN);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_MED_MAX);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_HARD_MIN);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_HARD_MAX);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_1LIFE_EASY_MIN);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_1LIFE_EASY_MAX);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_1LIFE_MED_MIN);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_1LIFE_MED_MAX);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_1LIFE_HARD_MIN);
            eat_n_umbrella_goals.Add(EAT_N_UMBRELLA_1LIFE_HARD_MAX);
            bParameters["EAT_N_UMBRELLA"]= eat_n_umbrella_goals;

            List<int> bounce_umbrella_goals = new List<int>();
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_N_TIMES_EASY_MIN);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_N_TIMES_EASY_MAX);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_N_TIMES_MED_MIN);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_N_TIMES_MED_MAX);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_N_TIMES_HARD_MIN);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_N_TIMES_HARD_MAX);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_1LIFE_N_TIMES_EASY_MIN);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_1LIFE_N_TIMES_EASY_MAX);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_1LIFE_N_TIMES_MED_MIN);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_1LIFE_N_TIMES_MED_MAX);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_1LIFE_N_TIMES_HARD_MIN);
            bounce_umbrella_goals.Add(BOUNCE_UMBRELLA_1LIFE_N_TIMES_HARD_MAX);
            bParameters["BOUNCE_UMBRELLA_N_TIMES"] = bounce_umbrella_goals;

            List<int> eat_n_queens_goals = new List<int>();
            eat_n_queens_goals.Add(EAT_N_QUEENS_EASY_MIN);
            eat_n_queens_goals.Add(EAT_N_QUEENS_EASY_MAX);
            eat_n_queens_goals.Add(EAT_N_QUEENS_MED_MIN);
            eat_n_queens_goals.Add(EAT_N_QUEENS_MED_MAX);
            eat_n_queens_goals.Add(EAT_N_QUEENS_HARD_MIN);
            eat_n_queens_goals.Add(EAT_N_QUEENS_HARD_MAX);
            eat_n_queens_goals.Add(EAT_N_QUEENS_1LIFE_EASY_MIN);
            eat_n_queens_goals.Add(EAT_N_QUEENS_1LIFE_EASY_MAX);
            eat_n_queens_goals.Add(EAT_N_QUEENS_1LIFE_MED_MIN);
            eat_n_queens_goals.Add(EAT_N_QUEENS_1LIFE_MED_MAX);
            eat_n_queens_goals.Add(EAT_N_QUEENS_1LIFE_HARD_MIN);
            eat_n_queens_goals.Add(EAT_N_QUEENS_1LIFE_HARD_MAX);
            bParameters["EAT_N_QUEENS"] = eat_n_queens_goals;

            List<int> survive_n_angered_goals = new List<int>();
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_EASY_MIN);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_EASY_MAX);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_MED_MIN);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_MED_MAX);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_HARD_MIN);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_HARD_MAX);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_1LIFE_EASY_MIN);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_1LIFE_EASY_MAX);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_1LIFE_MED_MIN);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_1LIFE_MED_MAX);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_1LIFE_HARD_MIN);
            survive_n_angered_goals.Add(SURVIVE_N_ANGERED_MODES_1LIFE_HARD_MAX);
            bParameters["SURVIVE_N_ANGERED_MODES"] = survive_n_angered_goals;

            List<int> eat_n_bees_goals = new List<int>();
            eat_n_bees_goals.Add(EAT_N_BEES_EASY_MIN);
            eat_n_bees_goals.Add(EAT_N_BEES_EASY_MAX);
            eat_n_bees_goals.Add(EAT_N_BEES_MED_MIN);
            eat_n_bees_goals.Add(EAT_N_BEES_MED_MAX);
            eat_n_bees_goals.Add(EAT_N_BEES_HARD_MIN);
            eat_n_bees_goals.Add(EAT_N_BEES_HARD_MAX);
            eat_n_bees_goals.Add(EAT_N_BEES_1LIFE_EASY_MIN);
            eat_n_bees_goals.Add(EAT_N_BEES_1LIFE_EASY_MAX);
            eat_n_bees_goals.Add(EAT_N_BEES_1LIFE_MED_MIN);
            eat_n_bees_goals.Add(EAT_N_BEES_1LIFE_MED_MAX);
            eat_n_bees_goals.Add(EAT_N_BEES_1LIFE_HARD_MIN);
            eat_n_bees_goals.Add(EAT_N_BEES_1LIFE_HARD_MAX);
            bParameters["EAT_N_BEES"] = eat_n_bees_goals;

            List<int> eat_n_chargers_goals = new List<int>();
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_EASY_MIN);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_EASY_MAX);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_MED_MIN);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_MED_MAX);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_HARD_MIN);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_HARD_MAX);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_1LIFE_EASY_MIN);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_1LIFE_EASY_MAX);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_1LIFE_MED_MIN);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_1LIFE_MED_MAX);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_1LIFE_HARD_MIN);
            eat_n_chargers_goals.Add(EAT_N_CHARGERS_1LIFE_HARD_MAX);
            bParameters["EAT_N_CHARGERS"] = eat_n_chargers_goals;

            List<int> eat_n_drunks_goals = new List<int>();
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_EASY_MIN);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_EASY_MAX);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_MED_MIN);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_MED_MAX);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_HARD_MIN);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_HARD_MAX);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_1LIFE_EASY_MIN);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_1LIFE_EASY_MAX);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_1LIFE_MED_MIN);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_1LIFE_MED_MAX);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_1LIFE_HARD_MIN);
            eat_n_drunks_goals.Add(EAT_N_DRUNKS_1LIFE_HARD_MAX);
            bParameters["EAT_N_DRUNKS"] = eat_n_drunks_goals;

            List<int> eat_n_simple_goals = new List<int>();
            eat_n_simple_goals.Add(EAT_N_SIMPLE_EASY_MIN);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_EASY_MAX);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_MED_MIN);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_MED_MAX);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_HARD_MIN);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_HARD_MAX);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_1LIFE_EASY_MIN);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_1LIFE_EASY_MAX);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_1LIFE_MED_MIN);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_1LIFE_MED_MAX);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_1LIFE_HARD_MIN);
            eat_n_simple_goals.Add(EAT_N_SIMPLE_1LIFE_HARD_MAX);
            bParameters["EAT_N_SIMPLE"] = eat_n_simple_goals;

            List<int> pet_eat_n_bugs_goals = new List<int>();
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_EASY_MIN);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_EASY_MAX);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_MED_MIN);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_MED_MAX);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_HARD_MIN);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_HARD_MAX);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_1LIFE_EASY_MIN);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_1LIFE_EASY_MAX);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_1LIFE_MED_MIN);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_1LIFE_MED_MAX);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_1LIFE_HARD_MIN);
            pet_eat_n_bugs_goals.Add(PET_EAT_N_BUGS_1LIFE_HARD_MAX);
            bParameters["PET_EAT_N_BUGS"] = pet_eat_n_bugs_goals;

            List<int> pet_the_pet_goals = new List<int>();
            pet_the_pet_goals.Add(PET_THE_PET_EASY_MIN);
            pet_the_pet_goals.Add(PET_THE_PET_EASY_MAX);
            pet_the_pet_goals.Add(PET_THE_PET_MED_MIN);
            pet_the_pet_goals.Add(PET_THE_PET_MED_MAX);
            pet_the_pet_goals.Add(PET_THE_PET_HARD_MIN);
            pet_the_pet_goals.Add(PET_THE_PET_HARD_MAX);
            pet_the_pet_goals.Add(PET_THE_PET_1LIFE_EASY_MIN);
            pet_the_pet_goals.Add(PET_THE_PET_1LIFE_EASY_MAX);
            pet_the_pet_goals.Add(PET_THE_PET_1LIFE_MED_MIN);
            pet_the_pet_goals.Add(PET_THE_PET_1LIFE_MED_MAX);
            pet_the_pet_goals.Add(PET_THE_PET_1LIFE_HARD_MIN);
            pet_the_pet_goals.Add(PET_THE_PET_1LIFE_HARD_MAX);
            bParameters["PET_THE_PET"] = pet_the_pet_goals;

            List<int> tap_goals = new List<int>();
            tap_goals.Add(TAP_EASY_MIN);
            tap_goals.Add(TAP_EASY_MAX);
            tap_goals.Add(TAP_MED_MIN);
            tap_goals.Add(TAP_MED_MAX);
            tap_goals.Add(TAP_HARD_MIN);
            tap_goals.Add(TAP_HARD_MAX);
            tap_goals.Add(TAP_1LIFE_EASY_MIN);
            tap_goals.Add(TAP_1LIFE_EASY_MAX);
            tap_goals.Add(TAP_1LIFE_MED_MIN);
            tap_goals.Add(TAP_1LIFE_MED_MAX);
            tap_goals.Add(TAP_1LIFE_HARD_MIN);
            tap_goals.Add(TAP_1LIFE_HARD_MAX);
            bParameters["TAP"] = tap_goals;
        }
        return bParameters;
    }
}
