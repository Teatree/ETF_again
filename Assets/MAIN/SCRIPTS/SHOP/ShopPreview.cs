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

    public Button left;
    public Button right;

    public GameObject buyButton;
    public GameObject equipButton;
    public GameObject unequipButton;
    public GameObject equippedMarker;
    public GameObject notEnoughLabel;
    public GameObject frameThing;

    void Start()
    {
        // 
    }

    private void OnEnable()
    {
        if (sio != null)
        {
            Init();
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

    public void Init()
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
        if (sio != null && (sio.isBought == false && sio.priceBJ <= PlayerController.player.BJamountTotal))
        {
            buyButton.SetActive(true);
            equipButton.SetActive(false);
            unequipButton.SetActive(false);
            equippedMarker.SetActive(false);
            notEnoughLabel.SetActive(false);
        }

        // if not bought enough money
        if (sio != null && (sio.isBought == false && sio.priceBJ > PlayerController.player.BJamountTotal))
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

    public void SwitchToLeft()
    {
        Debug.Log("||| ShopUIManager.shopUIManager.IsSioDirectionCap(sio, true): " + ShopUIManager.shopUIManager.IsSioDirectionCap(sio, true));
        if (ShopUIManager.shopUIManager.IsSioDirectionCap(sio, true) == true) return;
        StartCoroutine(SwtichToNext(frameThing, true, 0.25f));
    }

    public void SwitchToRight()
    {
        Debug.Log("||| ShopUIManager.shopUIManager.IsSioDirectionCap(sio, false): "+ ShopUIManager.shopUIManager.IsSioDirectionCap(sio, false));
        if (ShopUIManager.shopUIManager.IsSioDirectionCap(sio, false) == true) return;
        StartCoroutine(SwtichToNext(frameThing, false, 0.25f));
    }

    public IEnumerator SwtichToNext(GameObject g, bool isLeft, float seconds)
    {
        left.interactable = false;
        right.interactable = false;

        float elapsedTime = 0;
        Vector3 startingPos = g.transform.position;
        Vector3 itemRollOutPos = new Vector3(startingPos.x - 750, startingPos.y);
        Vector3 itemRollInPos = new Vector3(startingPos.x + 750, startingPos.y);

        if (isLeft)
        {
            itemRollOutPos = new Vector3(startingPos.x + 750, startingPos.y);
            itemRollInPos = new Vector3(startingPos.x - 750, startingPos.y);
        }

        while (elapsedTime < seconds)
        {
            g.transform.position = Vector3.Lerp(startingPos, itemRollOutPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        g.transform.position = itemRollInPos;
        elapsedTime = 0;
        // choose next sio
        sio = ShopUIManager.shopUIManager.FindSioInListAndSwitchToDirection(sio, isLeft);
        ShopUIManager.shopUIManager.UpdateShopPreview(sio);
        Init();
        while (elapsedTime < seconds)
        {
            g.transform.position = Vector3.Lerp(itemRollInPos, startingPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        g.transform.position = startingPos;

        left.interactable = true;
        right.interactable = true;
    }

    // ShowInfo

    // Next

    // Previous
}
