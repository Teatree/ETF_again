using SpriterDotNetUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPreview : MonoBehaviour
{
    //public SpriterData oldIdle;
    //public SpriterData oldPot;
    public ShopItemObject sio;
   // public List<Sprite> sprites;

    public Text name;
    public Text price;
    public Text priceShadow;
    public Image icon;
    public GameObject buyButton;

    void Start()
    {
        // 
    }

    private void OnEnable()
    {
        if (sio != null)
        RollOut();
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

    public void RollOut()
    {
        StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3(0.0f, 0f, 0f), 1f));
        Debug.Log(">>>> show preview > " + sio.name + " > " + sio.priceBJ + " > " + sio.isBought + " > " + PlayerController.player.BJamount);
        
        if (sio != null &&  (sio.isBought || sio.priceBJ > PlayerController.player.BJamount))
        {
            buyButton.SetActive(false);
        } else
        {
            buyButton.SetActive(true);
        }

      
    }

    public void BuyShopItem()
    {

        PlayerController.player.BuyShopItem(sio);
        buyButton.SetActive(false);
        ShopUIManager.shopUIManager.setBJAmiountText();
        // if first time buying
        //sio.isBought = true;
        //EquipShopItem();

        //ShopUIManager.shopUIManager.updateShopItemsStates();
        // if not enough money
    }

    public void EquipShopItem()
    {

        PlayerController.player.EquipShopItem(sio);
    }

    // ShowInfo

    // Next

    // Previous
}
