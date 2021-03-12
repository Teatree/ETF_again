using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    private static Dictionary<string, bool> sceneStateTracker;
    public static SceneController sceneController;
    bool gameStart;
    public static string initScene = "";

    //public AdmobController admob;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        if (!gameStart)
        {
            if (sceneStateTracker == null)
            {
                sceneStateTracker = new Dictionary<string, bool> {
                    { "main", false },
                    { "result", false },
                    { "shop", false }
                };
            }
            sceneController = this;
            if (initScene != null && "main".Equals(initScene))
            {
                sceneStateTracker["main"] = false;
                LoadGame();
            }
            else if (initScene != null && "result".Equals(initScene))
            {
                sceneStateTracker["result"] = false;
                LoadResult();
            }
            else if (initScene != null && "shop".Equals(initScene))
            {
                sceneStateTracker["shop"] = false;
                LoadShop();
            }
            else
            {
                LoadGame();
            }
            loadEverything();
            gameStart = true;
        }
    }

    public static void loadEverything()
    {
        DataController.LoadAllMultipliers();
        DataController.LoadAllLevels();
        DataController.LoadShopItems();
        PlayerController.player.LoadSave();
    }
    private void UnloadScene(string scene)
    {
        //Debug.Log("> u >" + sceneStateTracker[scene]);
        if (sceneStateTracker[scene])
        {
            StartCoroutine(Unload(scene));
            sceneStateTracker[scene] = false;
        }
    }

    private void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    private void LoadScene(string scene)
    {
        if (!sceneStateTracker[scene])
        {
            //Debug.Log("> l >" + scene);
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            sceneStateTracker[scene] = true;
        }
    }

    public void LoadGame()
    {
        UnloadScene("result");
        UnloadScene("shop");
        LoadScene("main"); 
    }

    public void LoadResult()
    {
        UnloadScene("main");
        UnloadScene("shop");
        LoadScene("result");
    }

    public void LoadShop()
    {
        UnloadScene("main");
        UnloadScene("result");
        LoadScene("shop");
        
    }

    //public void UnloadGame()
    //{
    //    UnloadScene("main");
    //}

    //public void UnloadMenu()
    //{
    //    UnloadScene("result");
    //}

    private IEnumerator Unload(string scene)
    {
        yield return null;
        SceneManager.UnloadSceneAsync(scene);
    }

    private IEnumerator Unload(int scene)
    {
        yield return null;
        SceneManager.UnloadSceneAsync(scene);
    }

    public void RestartGame()
    {
        initScene = "main";
        LoadGame();
    }

    public void OnDestroy()
    {
      //  PlayerController.player.SavePlayerData();
    }
}
