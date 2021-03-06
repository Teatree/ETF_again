using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsPool : MonoBehaviour
{
    public static BugsPool bugsPool;
    public GameObject[] allBugPrefabs;
    public Dictionary<string, List<GameObject>> bugsByType; 


    void Start()
    {
        bugsPool = this;
    }

    public GameObject GetBugPrefabByName(string name)
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

}
