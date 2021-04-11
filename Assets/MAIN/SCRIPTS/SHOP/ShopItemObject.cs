using System.Collections;
using System.Collections.Generic;

public class ShopItemObject
{

    public const string CURR_HARD = "HARD";
    public const string CURR_SOFT = "SOFT";

    public bool isBought;
    public bool isEquipped;
    public bool wasATarget;
    public string name;
    public string description;
    public string type; // type iap or not
    public int priceBJ;
    public string imageIcon;
    public string image_Head_Top;
    public string image_Head_Bottom;
    public string image_Leaf_Left;
    public string image_Leaf_Right;
    public string image_Middle_Leafs;
    public string image_Pot;

    public string idSKU;
    public string idSKUDisc;
    public string priceSKU;
    public string priceSKUDisc;
    public string currencyType;

    public bool isTrial;
    public float trialPeriodDuration;
    public System.DateTime trialPeriodStart;
    public float trialPeriodTimer;

    public ShopItemObject() {}
    public ShopItemObject(ItemShopData sio)
    {
        isBought = sio.isBought;
        isEquipped = sio.isEquipped;
        wasATarget = sio.wasATarget;

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
}
