using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class DataController
{
    private static string shopItemsFileName = "shopItems.json";
    private static string playerFileName = "playerInfo.json";
    private static string multipliersFileName = "bugMultipliers.json";
    private static string levelsFileName = "levels.json";

    public static string AjsonData;
    private const string CASHE_FOLDER = "LocalStorage";

#if UNITY_EDITOR
    public static string shopItemsFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", shopItemsFileName);
    public static string playerfilePath = Path.Combine(Application.dataPath + "/StreamingAssets", playerFileName);
    public static string multipliersFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", multipliersFileName);
    public static string levelsFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", levelsFileName);
#elif UNITY_ANDROID
    public static string shopItemsFilePath = Path.Combine ("jar:file://" + Application.dataPath + "!/assets/", shopItemsFileName);
    public static string playerfilePath = Path.Combine(Application.dataPath + "/StreamingAssets", playerFileName);
    public static string multipliersFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", multipliersFileName);
    public static string levelsFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", levelsFileName);

#elif UNITY_IOS
    private static string shopItemsFilePath = Path.Combine (Application.persistentDataPath  + "/Raw", shopItemsFileName);
    public static string playerfilePath = Path.Combine(Application.dataPath + "/StreamingAssets", playerFileName);
    public static string multipliersFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", multipliersFileName);
    public static string levelsFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", levelsFileName);
#endif

    #region PlayerData
    public static PlayerData LoadPlayer()
    {
        string jsonData = "";
        if (Application.platform == RuntimePlatform.Android)
        {

            if (File.Exists(playerfilePath))
            {
                TextAsset file = Resources.Load("playerInfo") as TextAsset;
                jsonData = file.ToString();
                PlayerData pi = JsonUtility.FromJson<PlayerData>(jsonData);
                return pi;
                //StreamReader f = new StreamReader(playerfilePath);
                //jsonData = f.ReadToEnd();
                //f.Close();


                //WWW reader = new WWW(playerfilePath);
                //while (!reader.isDone) { }
                //jsonData = reader.text;
            }
            return new PlayerData();
        }
        else
        {
            jsonData = File.ReadAllText(playerfilePath);
            PlayerData pi = JsonUtility.FromJson<PlayerData>(jsonData);
           // Debug.Log(">>>> jsonData > " + jsonData);
            return pi;

        }
        // PlayerData pi = JsonUtility.FromJson<PlayerData>(jsonData);
        //   AjsonData = "<color=#a52a2aff> " + jsonData + "</color>";

    }

    public static void SavePlayer(PlayerData pi)
    {
        string jsonData = JsonUtility.ToJson(pi);
      //  Debug.Log(">>> player info > " + jsonData);
        if (Application.platform == RuntimePlatform.Android)
        {
            StreamWriter writer = new StreamWriter(playerfilePath, false);
            writer.WriteLine(jsonData);
            writer.Close();
        }
        else
        {
            File.WriteAllText(playerfilePath, jsonData);
        }
    }
    #endregion

    #region Shop Items
    public static List<ShopItemObject> LoadShopItems()
    {
        string jsonData = "";
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW("https://raw.githubusercontent.com/Teatree/ETF_again/master/Assets/StreamingAssets/shopItems.json");
            while (!reader.isDone) { }
            jsonData = reader.text;
        }
        else
        {

        }
        {
            jsonData = File.ReadAllText(shopItemsFilePath);
        }
        ItemShopData[] sid = JsonHelper.FromJson<ItemShopData>(jsonData);
        List<ShopItemObject> res = new List<ShopItemObject>();
        foreach (ItemShopData si in sid)
        {
            res.Add(new ShopItemObject(si));
        }
        return res;
    }
    #endregion


    public static List<Multiplier> LoadAllMultipliers()
    {
        string jsonData = "";
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW("https://github.com/Teatree/Krashe3/blob/flowers_fiddle_sticks/android/assets/BugMultipliersByDuration.json");
            while (!reader.isDone) { }
            jsonData = reader.text;
        }
        else
        {

        }
        {
            jsonData = File.ReadAllText(multipliersFilePath);
        }
        Multiplier[] sid = JsonHelper.FromJson<Multiplier>(jsonData);
        List<Multiplier> res = new List<Multiplier>(sid);
        BugSpawnManager.mulipliers = res;
        return res;

    }

    public static List<LevelInfo> LoadAllLevels()
    {
        string jsonData = "";
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW("https://github.com/Teatree/Krashe3/blob/flowers_fiddle_sticks/android/assets/BugMultipliersByDuration.json");
            while (!reader.isDone) { }
            jsonData = reader.text;
        }
        else
        {

        }
        {
            jsonData = File.ReadAllText(multipliersFilePath);
        }
        LevelInfo[] sid = JsonHelper.FromJson<LevelInfo>(jsonData);
        List<LevelInfo> res = new List<LevelInfo>(sid);
       // BugSpawnManager.mulipliers = res;
        return res;

    }
}

//// PLAYER DATA
[System.Serializable]
public class PlayerData
{
    public int bjAmount = 0;
    public int bjAmountBest = 0;
    public string uniqueId = "";
    public List<ItemShopData> items = new List<ItemShopData>();

    public void setItems(Dictionary<string, ShopItemObject> itemObj)
    {
        List<ItemShopData> data = new List<ItemShopData>();
        foreach (ShopItemObject o in itemObj.Values)
        {
            data.Add(new ItemShopData(o));
        }
        items = data;
    }

    public List<ShopItemObject> getItems()
    {
        List<ShopItemObject> data = new List<ShopItemObject>();
        foreach (ItemShopData o in items)
        {
            data.Add(new ShopItemObject(o));
        }
        return data;
    }
}

[System.Serializable]
public class ItemShopData
{
    public bool isBought;
    public bool isEquipped;
    public bool wasATarget;
    public string name;
    public string description;
    public int priceBJ;
    //public string idSKU;
    //public string priceSKU;
    public string imageIcon;
    public string image_Head_Top;
    public string image_Head_Bottom;
    public string image_Leaf_Left;
    public string image_Leaf_Right;
    public string image_Middle_Leafs;
    public string image_Pot;

    public ItemShopData(ShopItemObject sio)
    {
        name = sio.name;
        isBought = sio.isBought;
        isEquipped = sio.isEquipped;
        wasATarget = sio.wasATarget;
        description = sio.description;
        priceBJ = sio.priceBJ;
        imageIcon = sio.imageIcon;
        image_Head_Top = sio.image_Head_Top;
        image_Head_Bottom = sio.image_Head_Bottom;
        image_Leaf_Left = sio.image_Leaf_Left;
        image_Leaf_Right = sio.image_Leaf_Right;
        image_Middle_Leafs = sio.image_Middle_Leafs;
        image_Pot = sio.image_Pot;
    }
    public ItemShopData()
    {

    }
}

[Serializable]
public class Multiplier
{
    public int startOn = 0;
    public int finishOn = 20;

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

}

[Serializable]
public class LevelInfo
{

    public static string MONEY_50 = "MONEY_50";
    public static string MONEY_100 = "MONEY_100";
    public static string MONEY_150 = "MONEY_150";
    public static string MONEY_200 = "MONEY_200";
    public static string MONEY_250 = "MONEY_250";
    public static string MONEY_300 = "MONEY_300";

    public static string PET = "RAVEN";
    public static string PET_2 = "CAT";
    public static string PET_3 = "DRAGON";

    public static string PHOENIX = "PHOENIX";
    public static string BJ_DOUBLE = "BJ_DOUBLE";

    public String name;
    public int difficultyLevel;
    public String type;

    //WHY???
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

    public int chanceMONEY_50 = 10;
    public int chanceMONEY_100 = 8;
    public int chanceMONEY_150 = 2;
    public int chanceMONEY_200 = 0;
    public int chanceMONEY_250 = 0;
    public int chancePHOENIX = 0;
    public int chancePET1 = 50;
    public int chancePET2 = 20;
    public int chancePET3 = 10;
    public int chanceBJ_DOUBLE = 0;

    public LevelInfo()
    {
    }

    public Dictionary<string, int> getRewardChanceGroups()
    {
        Dictionary<string, int> rewardChanceGroups = new Dictionary<string, int>();
        rewardChanceGroups[MONEY_50] = chanceMONEY_50;
        rewardChanceGroups[MONEY_100] = chanceMONEY_100 + chanceMONEY_50;
        rewardChanceGroups[MONEY_150] = chanceMONEY_150 + chanceMONEY_100 + chanceMONEY_50;
        rewardChanceGroups[MONEY_200] = chanceMONEY_200 + chanceMONEY_150 + chanceMONEY_100 + chanceMONEY_50;
        rewardChanceGroups[MONEY_250] = chanceMONEY_250 + chanceMONEY_200 + chanceMONEY_150 + chanceMONEY_100 + chanceMONEY_50;
        rewardChanceGroups[PHOENIX] = chancePHOENIX + chanceMONEY_250 + chanceMONEY_200 + chanceMONEY_150 + chanceMONEY_100 + chanceMONEY_50;
        rewardChanceGroups[PET] = chancePET1 + chancePHOENIX + chanceMONEY_250 + chanceMONEY_200 + chanceMONEY_150 + chanceMONEY_100 + chanceMONEY_50;
        rewardChanceGroups[PET_2] = chancePET2 + chancePET1 + chancePHOENIX + chanceMONEY_250 + chanceMONEY_200 + chanceMONEY_150 + chanceMONEY_100 + chanceMONEY_50;
        rewardChanceGroups[PET_3] = chancePET3 + chancePET2 + chancePET1 + chancePHOENIX + chanceMONEY_250 + chanceMONEY_200 + chanceMONEY_150 + chanceMONEY_100 + chanceMONEY_50;
        rewardChanceGroups[BJ_DOUBLE] = chanceBJ_DOUBLE + chancePET3 + chancePET2 + chancePET1 + chancePHOENIX + chanceMONEY_250 + chanceMONEY_200 + chanceMONEY_150 + chanceMONEY_100 + chanceMONEY_50;
        return rewardChanceGroups;
    }
}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Rows;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Rows = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Rows = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Rows;
    }
}
