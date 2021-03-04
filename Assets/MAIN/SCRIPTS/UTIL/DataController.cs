using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class DataController
{
    private static string shopItemsFileName = "shopItems.json";
    private static string playerFileName = "playerInfo.json";

    public static string AjsonData;
    private const string CASHE_FOLDER = "LocalStorage";

#if UNITY_EDITOR
    public static string shopItemsFilePath = Path.Combine(Application.dataPath + "/StreamingAssets", shopItemsFileName);
    public static string playerfilePath = Path.Combine(Application.dataPath + "/StreamingAssets", playerFileName);
    //public static string playerfilePath = Path.Combine(Application.persistentDataPath, playerFileName);

#elif UNITY_ANDROID
    public static string shopItemsFilePath = Path.Combine ("jar:file://" + Application.dataPath + "!/assets/", shopItemsFileName);
    public static string playerfilePath = Path.Combine(Application.dataPath + "/StreamingAssets", playerFileName);

#elif UNITY_IOS
    private static string shopItemsFilePath = Path.Combine (Application.persistentDataPath  + "/Raw", shopItemsFileName);
    public static string playerfilePath = Path.Combine(Application.dataPath + "/StreamingAssets", playerFileName);
#endif

    //--------- Player Info ----------
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
            Debug.Log(">>>> jsonData > " + jsonData);
            return pi;

        }
        // PlayerData pi = JsonUtility.FromJson<PlayerData>(jsonData);
        //   AjsonData = "<color=#a52a2aff> " + jsonData + "</color>";

    }

    public static void SavePlayer(PlayerData pi)
    {
        string jsonData = JsonUtility.ToJson(pi);
       Debug.Log(">>> player info > " + jsonData);
      if (Application.platform == RuntimePlatform.Android)
        {
            StreamWriter writer = new StreamWriter(playerfilePath, false);
        writer.WriteLine(jsonData);
        writer.Close();
    } else {
            File.WriteAllText(playerfilePath, jsonData);
        } 
    }

    //------------Items ---------------------------

    // items
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

}

//// PLAYER DATA
[System.Serializable]
public class PlayerData
{
    public int bjAmount = 0;
    public int bjAmountBest = 0;
    public string uniqueId = ""; 
    public List<ItemShopData> items = new List<ItemShopData>();

    public void setItems (Dictionary<string, ShopItemObject> itemObj)
    {
        List<ItemShopData> data = new List<ItemShopData>();
        foreach(ShopItemObject o in itemObj.Values) {
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
        isBought = sio.isBought;
        isEquipped = sio.isEquipped;
        name = sio.name;
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
