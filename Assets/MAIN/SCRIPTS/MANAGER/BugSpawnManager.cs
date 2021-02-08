using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnManager : MonoBehaviour {
    int i;
    public GameObject bugPrefab;
    public GameObject[] allBugPrefabs;

    private void Start() {

    }

    private void Update() {
        SpawnBugWithInterval();
    }

    private void SpawnBugWithInterval() {
        // TODO: Interval based on level/time of the game.

        i++;
        if (i == 150) {
            SpawnBug();
            i = 0;
        }
    }

    private void SpawnBug() {   
        // TODO: probability value based on level, time in the game...
        int i = Random.Range(0, 5);
        if (i == 0) {
            bugPrefab = GetBugPrefabByName("Simple");
        }
        else if(i == 1) {
            bugPrefab = GetBugPrefabByName("Drunk");
        }
        else if (i == 2) {
            bugPrefab = GetBugPrefabByName("Bee");
        }
        else if (i == 3) {
            bugPrefab = GetBugPrefabByName("Simple");
        }
        else {
            bugPrefab = GetBugPrefabByName("Charger");
        }

        Instantiate(bugPrefab);
        bugPrefab.transform.position = GenerateSpawnPos();

        AdjustBugValues(bugPrefab);
    }

    private void AdjustBugValues(GameObject _b) {
        // Adjust bug values based on time / level
        //_b.speed = 0.5f;
    }

    private GameObject GetBugPrefabByName(string name) {
        for (int i = 0; i < allBugPrefabs.Length; i++) {
            if(allBugPrefabs[i].GetComponent<Bug>().name == name) {
                return allBugPrefabs[i];
            }
        }
        return null;
    }

    private Vector2 GenerateSpawnPos() {
        Vector2 pos = new Vector2();
        pos.y = Random.Range(0f, 3.5f);
        pos.x = Random.Range(-10, -9);

        return pos;
    }
}
