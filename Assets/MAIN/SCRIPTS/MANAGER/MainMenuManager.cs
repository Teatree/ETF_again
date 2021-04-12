using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour 
{
    public Camera cam;
    public GameObject GameManagerGo;

    public GameObject buttonShop; 
    public GameObject buttonPause; 
    public GameObject buttonStart;

    public AnimationCurve curveScaleAndMove;
    public AnimationCurve curveRollIn;
    public AnimationCurve curveFadeIn;

    void Start()
    {
        buttonPause.SetActive(false);
        RollInSequence();
    }

    public void RollInSequence()
    {
        // Roll In Sequence
        StartCoroutine(ChangeObjectXPos(cam.gameObject.transform, -2.44f, 2.17f, 1.5f));

        buttonShop.SetActive(true);
        // Logo Appear
        // Camera ride in
        // Buttons appear
    }

    public IEnumerator ChangeObjectXPos(Transform transform, float x_start, float x_target, float duration)
    {
        float elapsed_time = 0; //Elapsed time

        Vector3 pos = transform.position; //Start object's position

        Color txtColor = buttonStart.transform.GetChild(0).GetComponent<Text>().color;

        buttonStart.GetComponent<Button>().interactable = false;

        while (elapsed_time <= duration) //Inside the loop until the time expires
        {
            //pos = Vector3.Lerp(pos, new Vector3(x_target, pos.y, -10), curveFadeIn.Evaluate(elapsed_time / duration));
            txtColor.a = Mathf.Lerp(0, 1, curveFadeIn.Evaluate(elapsed_time*2 / duration));
            buttonStart.transform.GetChild(0).GetComponent<Text>().color = txtColor;

            pos = new Vector3(Mathf.Lerp(pos.x, x_target, curveRollIn.Evaluate(elapsed_time/8 / duration)), pos.y, pos.z);
            transform.position = pos; //Changes the object's position

            yield return null; //Waits/skips one frame


            elapsed_time += Time.deltaTime; //Adds to the elapsed time the amount of time needed to skip/wait one frame
        }

        buttonStart.GetComponent<Button>().interactable = true;     
    }

    public void StartGame()
    {
        GameManagerGo.SetActive(true);
        GameManager.IsGameStarted = true;
        buttonPause.SetActive(true);
    }

    public void RollOutToGameplay()
    {
        buttonShop.SetActive(false);
        StartCoroutine(MoveAndScaleOverSeconds(cam.gameObject, cam.transform.position, new Vector3(0, 0, -10), 3.5f, 5f, 1.5f));
    }

    public IEnumerator MoveAndScaleOverSeconds(GameObject g, Vector3 startPos, Vector3 endPos, float startZoom, float endZoom, float seconds)
    {
        float elapsedTime = 0;
        //buttonStart.interactable = false;

        while (elapsedTime < seconds)
        {
            g.transform.position = Vector3.Lerp(startPos, endPos, curveScaleAndMove.Evaluate(elapsedTime / seconds));

            g.GetComponent<Camera>().orthographicSize = Mathf.Lerp(startZoom, endZoom, curveScaleAndMove.Evaluate(elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        g.transform.position = endPos;
        g.GetComponent<Camera>().orthographicSize = endZoom;

        //buttonStart.interactable = true;
        StartGame();
    }

    public void OnDisable()
    {
        GameManager.IsGameStarted = false;
    }
}
