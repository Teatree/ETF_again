using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsPool : MonoBehaviour
{
    public const string SIMPLE = "Simple";
    public const string DRUNK = "Drunk";
    public const string CHARGER = "Charger";
    public const string BEE = "Bee";
    public const string QUEENBEE = "QueenBee";


    public static BugsPool bugsPool;
    public GameObject[] allBugPrefabs;
    public Dictionary<string, List<GameObject>> bugsByType; 


    void Start()
    {
        bugsPool = this;
        bugsByType = new Dictionary<string, List<GameObject>>();
        bugsByType[BEE] = new List<GameObject>();
        bugsByType[DRUNK] = new List<GameObject>();
        bugsByType[SIMPLE] = new List<GameObject>();
        bugsByType[CHARGER] = new List<GameObject>();
        bugsByType[QUEENBEE] = new List<GameObject>();

    }

    private GameObject GetBugPrefabByName(string name)
    {
        for (int i = 0; i < allBugPrefabs.Length; i++)
        {
            if (allBugPrefabs[i].GetComponent<Bug>().name == name)
            {
                return allBugPrefabs[i];
            }
        }
        return null;
    }

    public GameObject GetBugByType (string bugType)
    {
        //Find inactive in the pool;
        foreach (GameObject abug in bugsByType[bugType])
        {
            if (!abug.activeSelf)
            {
                abug.SetActive(true);
                return abug;
            }
        }
        //If not found instantiate a new one
        GameObject newbug = BugsPool.bugsPool.GetBugPrefabByName(bugType);
        newbug = Instantiate(newbug);
        bugsByType[bugType].Add(newbug);
        return newbug;
    }

    public void DeactivateAllBugs()
    {
        foreach (string bugType in bugsByType.Keys)
        {
            for(int i = 0; i < bugsByType[bugType].Count; i++)
            {
                DeactivateBug(bugsByType[bugType][i]);
            }
        }
    }

    public void DeactivateBug (GameObject b)
    {
        b.transform.position = new Vector2(-1000, -1000);
        b.SetActive(false);
    }
}


