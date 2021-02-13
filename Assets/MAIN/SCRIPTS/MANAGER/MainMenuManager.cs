using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour 
{
    public Camera cam;
    public GameObject GameManager;

    void Start()
    {
        RollInSequence();
    }

    private void Update()
    {
        
    }

    public void RollInSequence()
    {
        // Roll In Sequence
        StartCoroutine(ChangeObjectXPos(cam.gameObject.transform, -2.44f, 2.17f, 2f));

        // Logo Appear
        // Camera ride in
        // Buttons appear
    }

    public IEnumerator ChangeObjectXPos(Transform transform, float x_start, float x_target, float duration)
    {
        float elapsed_time = 0; //Elapsed time

        Vector3 pos = transform.position; //Start object's position

        while (elapsed_time <= duration) //Inside the loop until the time expires
        {
            pos.x = Mathf.Lerp(x_start, x_target, EaseOut(elapsed_time / duration)); //Changes and interpolates the position's "x" value

            transform.position = pos;//Changes the object's position

            yield return null; //Waits/skips one frame

            elapsed_time += Time.deltaTime; //Adds to the elapsed time the amount of time needed to skip/wait one frame
        }
    }

    float EaseOut(float t)
    {
        return Flip(Mathf.Pow(Flip(t),8f));
    }

    float Flip(float x)
    {
        return 1 - x;
    }

    public void StartGame()
    {
        GameManager.SetActive(true);
    }

    public void RollOutToGameplay()
    {
        StartCoroutine(MoveAndScaleOverSeconds(cam.gameObject, new Vector3(2.17f, -1.44f, -10), new Vector3(0, 0, -10), 3.5f, 5f, 3f));
    }

    public IEnumerator MoveAndScaleOverSeconds(GameObject g, Vector3 startPos, Vector3 endPos, float startZoom, float endZoom, float seconds)
    {
        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            g.transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / seconds));
            g.GetComponent<Camera>().orthographicSize = Mathf.Lerp(startZoom, endZoom, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        g.transform.position = endPos;
        g.GetComponent<Camera>().orthographicSize = endZoom;

        StartGame();
    }

}
