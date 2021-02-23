using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemController : MonoBehaviour
{
    public ItemShopData sio;

    public void OpenShopItemPreview()
    {
        Debug.Log(" you name is: " + gameObject.name);
        ShopUIManager.shopUIManager.OpenShopPreview(sio);
    }
}
