using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class DataController {
    private static string shopItemsFileName = "shopItems.json";
    //private static string playerFileName = "playerInfo.json";

    public static string AjsonData;
    private const string CASHE_FOLDER = "LocalStorage";

#if UNITY_EDITOR
    public static string shopItemsFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", shopItemsFileName);
    //public static string playerfilePath = Path.Combine(Application.dataPath + "/StreamingAssets", playerFileName);
    //public static string playerfilePath = Path.Combine(Application.persistentDataPath, playerFileName);

#elif UNITY_ANDROID
    public static string shopItemsFilePath = Path.Combine ("jar:file://" + Application.dataPath + "!/assets/", shopItemsFileName);

#elif UNITY_IOS
    private static string shopItemsFilePath = Path.Combine (Application.persistentDataPath  + "/Raw", shopItemsFileName);
#endif

    ////--------- Player Info ----------
    //public static PlayerData LoadPlayer()
    //{
    //    string jsonData = "";
    //    //if (Application.platform == RuntimePlatform.Android) {

    //    if (!File.Exists(playerfilePath))
    //    {
    //        TextAsset file = Resources.Load("playerInfo") as TextAsset;
    //        jsonData = file.ToString();
    //        PlayerData pi = JsonUtility.FromJson<PlayerData>(jsonData);
    //        pi.firstLoginAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    //        return pi;
    //        //StreamReader f = new StreamReader(playerfilePath);
    //        //jsonData = f.ReadToEnd();
    //        //f.Close();


    //        //WWW reader = new WWW(playerfilePath);
    //        //while (!reader.isDone) { }
    //        //jsonData = reader.text;
    //    }
    //    else
    //    {
    //        jsonData = File.ReadAllText(playerfilePath);
    //        PlayerData pi = JsonUtility.FromJson<PlayerData>(jsonData);
    //        Debug.Log(">>>> jsonData > " + jsonData);
    //        return pi;

    //    }
    //    // PlayerData pi = JsonUtility.FromJson<PlayerData>(jsonData);
    //    //   AjsonData = "<color=#a52a2aff> " + jsonData + "</color>";

    //}

    //public static void SavePlayer(PlayerData pi)
    //{
    //    string jsonData = JsonUtility.ToJson(pi);
    //    // Debug.Log(">>> player info > " + jsonData);
    //    // if (Application.platform == RuntimePlatform.Android) {
    //    StreamWriter writer = new StreamWriter(playerfilePath, false);
    //    writer.WriteLine(jsonData);
    //    writer.Close();
    //    //} else {
    //    //    File.WriteAllText(playerfilePath, jsonData);
    //    //} 
    //}

    //------------Items ---------------------------

    // items
    public static List<ItemShopData> LoadShopItems()
    {
        string jsonData = "";
        //if (Application.platform == RuntimePlatform.Android)
        //{
            WWW reader = new WWW("https://raw.githubusercontent.com/Teatree/ETF_again/master/Assets/StreamingAssets/shopItems.json");
            while (!reader.isDone) { }
            jsonData = reader.text;
        //}
        //else
        //{
        //    jsonData = File.ReadAllText(shopItemsFilePath);
        //}
        ItemShopData[] id = JsonHelper.FromJson<ItemShopData>(jsonData);
        return new List<ItemShopData>(id);
    }

//    //------------Load Levels --------------------
//    public static List<LevelData> LoadLevels()
//    {
//        List<LevelData> lvlsData = new List<LevelData>();
//        string jsonData = "";
//        if (Application.platform == RuntimePlatform.Android)
//        {
//            WWW reader = new WWW(levelfilePath);
//            while (!reader.isDone) { }

//            jsonData = reader.text;
//        }
//        else
//        {
//            jsonData = File.ReadAllText(levelfilePath);
//        }


//        if (jsonData != null)
//        {
//            string separ = "Level_[0-9][0-9][0-9]";
//            string[] lvls = System.Text.RegularExpressions.Regex.Split(jsonData, separ);

//            for (int i = 1; i < lvls.Length; i++)
//            {

//                string editedLvl = "{ \"Rows" + lvls[i].Substring(1, lvls[i].Length - 7);
//                if (editedLvl.LastIndexOf("]") == editedLvl.Length - 1)
//                {
//                    editedLvl += "}";
//                }
//                else
//                {
//                    editedLvl += "]}";
//                }
//                RowData[] rows = JsonHelper.FromJson<RowData>(editedLvl);
//                LevelData lvlData = new LevelData();
//                System.Array.Reverse(rows);

//                foreach (RowData row in rows)
//                {
//                    if (!row.IsEmpty())
//                    {
//                        lvlData.rows.Add(row);
//                    }
//                }

//                foreach (RowData row in rows)
//                {
//                    if (row.IsEmpty())
//                    {
//                        lvlData.emptyRowsCount++;
//                    }
//                    else
//                    {
//                        break;
//                    }
//                }

//                lvlsData.Add(lvlData);
//            }
//            return lvlsData;
//        }
//        else
//        {
//            //Debug.LogError("Cannot find the file " + levelfilePath);
//            //AjsonData = "<color=#a52a2aff>JSON IS NULL</color>";
//            return lvlsData;
//        }
//    }

}

//// PLAYER DATA
//[System.Serializable]
//public class PlayerData {
//    public int gems;
//    public int stars;
//    public int progressTowardsNextStarBox; // how many stars player already gathered for the current star box
//    public int numStarBoxesOpened; // how many boxs were already opened
//    public string giveBoxAt;
//    public string firstLoginAt;
//    public bool noAds;
//    public string specialBallImageName;
//    public string specialBallName;
//    public bool boughtStarter;

//    public List<CompletedLevel> completedLvls = new List<CompletedLevel>();
//    public List<ItemData> items = new List<ItemData>();

//    public int GetStarsAmount()
//    {
//        int sum = 0;
//        foreach (CompletedLevel lvl in completedLvls)
//        {
//            sum += lvl.stars;
//        }
//        stars = sum;
//        return sum;
//    }
//}

[System.Serializable]
public class ItemShopData {
    public bool isBought;
    public string name;
    public string description;
    public int priceBJ;
    //public string idSKU;
    //public string priceSKU;
    public string imageIcon;
    public string imageAsset;
    public string bodyPart;

    public ItemShopData(ShopItemObject sio)
    {
        isBought = sio.isBought;
        name = sio.name;
        description = sio.description;
        priceBJ = sio.priceBJ;
        imageIcon = sio.imageIcon;
        imageAsset = sio.imageAsset;
        bodyPart = sio.bodyPart;
    }
    public ItemShopData()
    {

    }
}

public static class JsonHelper {
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
    private class Wrapper<T> {
        public T[] Rows;
    }
}
