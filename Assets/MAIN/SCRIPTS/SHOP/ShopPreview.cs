using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPreview : MonoBehaviour
{
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

    // ShowInfo

    // Next

    // Previous
}
