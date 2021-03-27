using SpriterDotNetUnity;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoccoonController : MonoBehaviour {

    public static CoccoonController coccoonController;

    public _State _state;

    public UnityAnimator uAnimator;

    public GameObject butterflyGo;

    string currentPlayingAnimation;

    private IEnumerator butterflyCouroutine;

    Vector3 hidePosition= new Vector3(5.95f, 6.95f, 0f);
    int hitCounter = 0;

    // Use this for initialization
    void Start()
    {
        coccoonController = this;
        Screen.SetResolution(1200, 786, true);
    }

    // Update is called once per frame
    void Update()
    {
        // Weird skip assign workaround
        if (uAnimator == null)
        {
            uAnimator = GetComponent<SpriterDotNetBehaviour>().Animator;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hitCounter == 0)
        {
            SetAnimation("hit1");
        }
        else if (hitCounter == 1)
        {
            SetAnimation("hit2");
        }
        else if (hitCounter == 2)
        {
            SetAnimation("hit3");

            butterflyCouroutine = ButterflyFlyFly(butterflyGo.transform, new Vector3(5.95f, 2.95f, 0f), new Vector3(8.47f, UnityEngine.Random.Range(1f, -5f), 0f), 4f);
            StartCoroutine(butterflyCouroutine);
        }
        hitCounter++;
    }

    void SetAnimation(string animaitonName)
    {
        if (currentPlayingAnimation != animaitonName)
        {
            uAnimator.Play(animaitonName);
            currentPlayingAnimation = animaitonName;

            if (_state.Equals(_State.TRANSITION_BACK))
            {
                uAnimator.Time = uAnimator.Length;
            }
        }
    }

    public void HideButterfly()
    {
        // stop corutine
        StopCoroutine(butterflyCouroutine);

        // set position
        butterflyGo.transform.position = hidePosition;
        
    } 

    public IEnumerator ButterflyFlyFly(Transform tr, Vector3 start, Vector3 target, float duration)
    {
        float elapsed_time = 0; //Elapsed time

        Vector3 pos = start; //Start object's position
        tr.GetChild(0).gameObject.layer = 10; // No Colission Layer

        while (elapsed_time <= duration) //Inside the loop until the time expires
        {
            if(elapsed_time >= duration/2) tr.GetChild(0).gameObject.layer = 9; // Butterfly Layer
            //Time.timeScale = 0;

            pos = Parabola(start, target, -15f, elapsed_time / duration);
            tr.position = pos; //Changes the object's position

            yield return null; //Waits/skips one frame

            elapsed_time += Time.deltaTime; //Adds to the elapsed time the amount of time needed to skip/wait one frame
        }

        tr.position = hidePosition;
        hitCounter = 0;
    }

    public Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = y => -4 * height * y * y + 4 * height * y;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(f(t) + Mathf.Lerp(start.x, end.x, t), mid.y, mid.z);
    }

    public enum _State { IDLE, ATTACK, ATTACK_BITE, IDLE_BITE, RETREAT, TRANSITION, TRANSITION_BACK };
}
