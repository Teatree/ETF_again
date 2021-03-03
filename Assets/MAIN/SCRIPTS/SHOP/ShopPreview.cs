using SpriterDotNetUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPreview : MonoBehaviour
{
    public ShopItemObject sio;

    public Text name;
    public Text price;
    public Text priceShadow;
    public Image icon;
    public GameObject buyButton;
    public GameObject equipButton;
    public GameObject unequipButton;
    public GameObject equippedMarker;
    public GameObject notEnoughLabel;

    void Start()
    {
        // 
    }

    private void OnEnable()
    {
        if (sio != null)
        {
            init();
            RollOut();
        }
        
    }

    public void CloseWindow()
    {
        GameObject g = gameObject;

        g.transform.position = new Vector3(900.0f, 900f, 0f);
        g.SetActive(false);
    }

    public IEnumerator MoveOverSeconds(GameObject g, Vector3 end, float seconds) {
        float elapsedTime = 0;
        Vector3 startingPos = g.transform.position;
        while (elapsedTime < seconds)
        {
            transform.localPosition = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = end;
    }

    public void init()
    {
        buyButton.SetActive(false);
        equipButton.SetActive(false);
        unequipButton.SetActive(false);
        equippedMarker.SetActive(false);
        notEnoughLabel.SetActive(true);

        // if bought not equiped
        if (sio != null && (sio.isBought == true && sio.isEquipped == false))
        {
            buyButton.SetActive(false);
            equipButton.SetActive(true);
            unequipButton.SetActive(false);
            equippedMarker.SetActive(false);
            notEnoughLabel.SetActive(false);
        }

        // if bought and equipped
        if (sio != null && (sio.isBought == true && sio.isEquipped == true))
        {
            buyButton.SetActive(false);
            equipButton.SetActive(false);
            unequipButton.SetActive(true);
            equippedMarker.SetActive(true);
            notEnoughLabel.SetActive(false);
        }

        // if not bought not enoguh mney
        if (sio != null && (sio.isBought == false && sio.priceBJ <= PlayerController.player.BJamount))
        {
            buyButton.SetActive(true);
            equipButton.SetActive(false);
            unequipButton.SetActive(false);
            equippedMarker.SetActive(false);
            notEnoughLabel.SetActive(false);
        }

        // if not bought enough money
        if (sio != null && (sio.isBought == false && sio.priceBJ > PlayerController.player.BJamount))
        {
            buyButton.SetActive(false);
            equipButton.SetActive(false);
            unequipButton.SetActive(false);
            equippedMarker.SetActive(false);
            notEnoughLabel.SetActive(true);
        }
    }

    public void RollOut()
    {
        StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3(0.0f, 0f, 0f), 1f));
        Debug.Log(">>>> show preview > " + sio.name + " > " + sio.priceBJ + " > " + sio.isBought + " > " + PlayerController.player.BJamount);
    }

    public void BuyShopItem()
    {
        PlayerController.player.BuyShopItem(sio);
        buyButton.SetActive(false);
        ShopUIManager.shopUIManager.setBJAmiountText();
        icon.sprite = ShopUIManager.shopUIManager.GetSpriteByName(sio.imageIcon);
        ShopUIManager.shopUIManager.UpdateShopItemList(sio.imageIcon, sio.name, true);

        // if first time buying
        // sio.isBought = true;
        // EquipShopItem();

        //ShopUIManager.shopUIManager.updateShopItemsStates();
        // if not enough money
    }

    public void EquipShopItem()
    {
        PlayerController.player.EquipShopItem(sio);
        ShopUIManager.shopUIManager.UpdateShopItemList(sio.imageIcon, sio.name, true);
    }

    public void UnEquipShopItem()
    {
        PlayerController.player.UnEquipShopItem(sio);
        ShopUIManager.shopUIManager.UpdateShopItemList(sio.imageIcon, sio.name, false);
    }

    // ShowInfo

    // Next

    // Previous
}
