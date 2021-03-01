using SpriterDotNetUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPreview : MonoBehaviour
{
    public SpriterData old;
    public ShopItemObject sio;
    public List<Sprite> sprites;

    public Text name;
    public Text price;
    public Text priceShadow;
    public Image icon;

    void Start()
    {
        // 
    }

    private void OnEnable()
    {
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
    }

    public void BuyShopItem()
    {
        // if first time buying

        EquipShopItem();

        // if not enough money
    }

    public void EquipShopItem()
    {
        // head bottom
        if (sio.image_Head_Bottom != "" && old.FileEntries[0].Sprite.name != sio.image_Head_Bottom)
        {
            old.FileEntries[0].Sprite = GetSpriteFromList(sio.image_Head_Bottom);
        }

        if (sio.image_Head_Top != "" && old.FileEntries[1].Sprite.name != sio.image_Head_Top)
        {
            old.FileEntries[1].Sprite = GetSpriteFromList(sio.image_Head_Top);
        }

        //old.FileEntries[1].Sprite = flowerHatCustomizable.sprite;
    }

    public Sprite GetSpriteFromList(string name)
    {
        Sprite result = null;
        foreach (Sprite s in sprites)
        {
            if (s.name == sio.imageIcon)
            {
                result = s;
                break;
            }
        }

        return result;
    }

    // ShowInfo

    // Next

    // Previous
}
