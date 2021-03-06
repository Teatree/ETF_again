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
        //Find inactive in the pool
        foreach(GameObject abug in bugsByType[bugType])
        {
            if (!abug.activeSelf)
            {
                Debug.Log(">>> get bug from pool");
                abug.SetActive(true);
                return abug;
            }
        }
        //If not found instantiate a new one
        GameObject newbug= BugsPool.bugsPool.GetBugPrefabByName(bugType);
        Instantiate(newbug);
        bugsByType[bugType].Add(newbug);

        return newbug;
    }

    public void DeactivateAllBugs()
    {
        foreach (string bugType in bugsByType.Keys)
        {
            foreach (GameObject bug in bugsByType[bugType])
            {
                Debug.LogError(">>> deactivate all bugs > ");
                bug.SetActive(false);
            }
        }
    }
}


