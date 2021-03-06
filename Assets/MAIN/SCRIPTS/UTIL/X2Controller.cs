﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X2Controller : MonoBehaviour {
    public _State _state;

    public static X2Controller x2Controller;

    private IEnumerator flyCouroutine;
    private IEnumerator waitBeforeFlyCouroutine;
    private float durationCount = 5f;

    bool isFlyingFirstTime;
    GameObject x2Go;

    // Start is called before the first frame update
    void Start()
    {
        x2Controller = this;

        x2Go = this.gameObject;
    }

    public void Spawn()
    {
        isFlyingFirstTime = true;

        x2Go.transform.position = new Vector3(14.47f, UnityEngine.Random.Range(3.5f, -5f), 0f);

        waitBeforeFlyCouroutine = WaitBeforeFly(3f);
        StartCoroutine(waitBeforeFlyCouroutine);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideX2()
    {
        StopCoroutine(flyCouroutine);
        x2Go.transform.position = new Vector3(18.47f, 7f, 0f);

        PowerUpManager.isPowerUpOnScene = false;
    }

    public IEnumerator WaitBeforeFly(float duration)
    {
        float elapsed_time = 0; //Elapsed time

        while (elapsed_time <= duration) //Inside the loop until the time expires
        {
            while (GameManager.IsPaused)
            {
                yield return null;
            }

            yield return null; //Waits/skips one frame

            elapsed_time += Time.deltaTime; //Adds to the elapsed time the amount of time needed to skip/wait one frame
        }

        flyCouroutine = x2FlyFly(x2Go.transform, x2Go.transform.position, new Vector3(14.47f, UnityEngine.Random.Range(3.5f, -5f), 0f), durationCount);
        StartCoroutine(flyCouroutine);
    }

    // Fly
    public IEnumerator x2FlyFly(Transform tr, Vector3 start, Vector3 target, float duration)
    {
        float elapsed_time = 0; //Elapsed time

        Vector3 pos = start; //Start object's position

       
        if (isFlyingFirstTime)
        {
            tr.gameObject.layer = 10; // No Colission Layer
        }
        else
        {
            // check goals
            foreach (Goal goal in PlayerController.player.level.goals.Values)
            {
                goal.checkX2Bounce();
            }
        }

        while (elapsed_time <= duration) //Inside the loop until the time expires
        {
            while (GameManager.IsPaused)
            {
                yield return null;
            }

            if (elapsed_time >= duration / 2 && isFlyingFirstTime) tr.gameObject.layer = 9; // Butterfly Layer
            //Time.timeScale = 0;

            pos = Parabola(start, target, -15f, elapsed_time / duration);
            tr.position = pos; //Changes the object's position

            yield return null; //Waits/skips one frame

            elapsed_time += Time.deltaTime; //Adds to the elapsed time the amount of time needed to skip/wait one frame
        }

        isFlyingFirstTime = false;
        durationCount -= 0.15f;
        flyCouroutine = x2FlyFly(x2Go.transform, x2Go.transform.position, new Vector3(14.47f, UnityEngine.Random.Range(3.5f, -5f), 0f), durationCount);
        StartCoroutine(flyCouroutine);
        //tr.position = start;
    }

    public Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = y => -4 * height * y * y + 4 * height * y;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(f(t) + Mathf.Lerp(start.x, end.x, t), mid.y, mid.z);
    }

    public enum _State { WAITING, FLYING };
}
