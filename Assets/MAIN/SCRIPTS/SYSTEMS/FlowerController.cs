using SpriterDotNetUnity;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {

    public _State _state;

    public float FLOWER_MOVE_SPEED; // something like 4
    public UnityAnimator uAnimator;

    string currentPlayingAnimation;

    // Use this for initialization
    void Start () {
        uAnimator = GetComponent<SpriterDotNetBehaviour>().Animator;
        Screen.SetResolution(1200, 786, true);
    }

	// Update is called once per frame
	void Update () {
        // Weird skip assign workaround
        //if (uAnimator == null) {
        //    uAnimator = GetComponent<SpriterDotNetBehaviour>().Animator;
        //}

        //Debug.Log("uAnimator.Time = " + uAnimator.Time);
        if (GameManager.IsPaused == false)
        {
            if (GameManager.IsGameStarted == true) {
                ProcessInput();
            }
            Transition();
            AttackAndRetreat();
            TransitionBack();
            Idle();
        }
        else
        {
            
        }

       // Debug.Log("State: " + _state);
        // TestSwapAssets();
    }

    void ProcessInput() {
        if (Input.touchCount > 0 || Input.GetMouseButton(0)) {
            // Construct a ray from the current touch coordinates
            if (_state != _State.ATTACK && _state != _State.RETREAT) {
                _state = _State.TRANSITION;

                StopAllCoroutines();
                StartCoroutine(Transition());
            }
            else {
                _state = _State.ATTACK;
            }
        }
    }

    void AttackAndRetreat() {
        if (_state.Equals(_State.ATTACK) || _state.Equals(_State.RETREAT)) {
            if (currentPlayingAnimation != "attack") {
                SetAnimation("attack");
            }

            MoveFlower();
            if(transform.localPosition.y > 6.49f && _state.Equals(_State.ATTACK)) {
                _state = _State.RETREAT;
            }

            if(transform.localPosition.y < 0 && _state.Equals(_State.RETREAT)) {
                transform.localPosition = new Vector2(0, 0);
                _state = _State.TRANSITION_BACK;
            }
        }
        

    }

    void Idle() {
        if (_state.Equals(_State.IDLE)){
            SetAnimation("idle");
        }
    }

    void TransitionBack() {
        if (_state.Equals(_State.TRANSITION_BACK)) {

            //StopAllCoroutines();
            StartCoroutine(Transition());
        }
    }

    void MoveFlower() {
        Vector2 v = transform.position;
        v.x = transform.position.x;
        v.y += _state.Equals(_State.ATTACK) ? FLOWER_MOVE_SPEED * Time.deltaTime : -FLOWER_MOVE_SPEED * Time.deltaTime;
        transform.position = v;
    }

    IEnumerator Transition() {
        if (_state.Equals(_State.TRANSITION)) {
            SetAnimation("attack_trans");
            //uAnimator.Speed = 10;

            yield return new WaitForSeconds(0.05f);
            _state = _State.ATTACK;
        }
        if (_state.Equals(_State.TRANSITION_BACK)) {
            SetAnimation("attack_trans");
            uAnimator.Speed = -1.0f;
            yield return new WaitForSeconds(0.05f);
            uAnimator.Speed = 1;
            _state = _State.IDLE;
        }
    }

    IEnumerator Bite() {
        if (_state.Equals(_State.ATTACK_BITE)) {
            SetAnimation("attack_bite");

             yield return new WaitForSeconds(0.41f);
            _state = _State.RETREAT;
        }
        if (_state.Equals(_State.IDLE_BITE)) {
            SetAnimation("attack_idle");

            yield return new WaitForSeconds(0.41f);
            _state = _State.IDLE;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("colliding! - " + collision.transform);
        BugController bc = collision.transform.gameObject.GetComponent<BugController>();
        if (bc != null)
        {
            bc.KillMeWithoutAni();
        }
        else if (collision.gameObject.name == "butterfly_000")
        {
            Debug.Log("Eating Butterfly, Yum!");

            GameManager.gameManager.CoinsFeedback(collision.transform.position, 50);
            PowerUpManager.isPowerUpOnScene = false;
            CoccoonController.coccoonController.HideButterfly();

            // check goals
            foreach (Goal goal in PlayerController.player.level.goals.Values)
            {
                goal.checkEatButterfly();
            }
        }
        else if (collision.gameObject.name == "x2")
        {
            Debug.Log("Eating some x2, Yum!");
            PlayerController.player.BJamountSession *= 2;
            UIController.uIController.animateBJ();

            X2Controller.x2Controller.HideX2();

            // check goals
            foreach (Goal goal in PlayerController.player.level.goals.Values)
            {
                goal.checkEatX2();
            }
        }
        else return;

        if (_state.Equals(_State.ATTACK) || _state.Equals(_State.RETREAT)) {
            _state = _State.ATTACK_BITE;
        }

        if (_state.Equals(_State.IDLE)) {
            _state = _State.IDLE_BITE;
        }

        StopAllCoroutines();
        StartCoroutine(Bite());
    }

    void SetAnimation(string animaitonName) {
        if (currentPlayingAnimation != animaitonName) {
            uAnimator.Play(animaitonName);
            currentPlayingAnimation = animaitonName;

            if (_state.Equals(_State.TRANSITION_BACK)) {
                uAnimator.Time = uAnimator.Length;
            }
        }
    }

    public enum _State { IDLE, ATTACK, ATTACK_BITE, IDLE_BITE, RETREAT, TRANSITION, TRANSITION_BACK };
}
