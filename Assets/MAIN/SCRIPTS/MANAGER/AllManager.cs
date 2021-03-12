using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllManager : MonoBehaviour
{
    public static AllManager allManager;

    public List<Sprite> iconImages;
    // Start is called before the first frame update
    void Awake()
    {
        allManager = this;
        loadEverything();
    }

    public Sprite GetSpriteByName(string iconName)
    {
        foreach (Sprite s in iconImages)
        {
            if (s.name == iconName)
            {
                return s;
            }
        }
        return null;
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        PlayerController.player.SavePlayerData();
    }
   
}
