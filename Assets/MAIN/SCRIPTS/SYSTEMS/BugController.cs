using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour {

    public Bug bug;
    Animator anim;

    public float chargerChangePostionIdle;
    public int chargerPreparingTimer;

    public float velocity;
    public float curveSpeed;
    public float amplitude;

    float percent;
    float fTime = 0;
    Vector3 vLastPos = Vector3.zero;

    //DeGub
    Color debugColor;

    public void Start() {
        bug = GetComponent<Bug>();
        anim = GetComponentInChildren<Animator>();
                            
        chargerChangePostionIdle = Random.Range(-10, -5);

        velocity = bug.speed;
        curveSpeed = bug.curveSpeed;
        amplitude = bug.amplitude;

        vLastPos = transform.position;

        debugColor = Random.ColorHSV();
    }

    public void Update() {
        if (GameManager.IsPaused == false)
        {
            anim.speed = 1;
            velocity += bug.acceleration;

            if (bug.name == "Charger")
            {
                MoveCharger();
            }
            else
            {
                MoveBug();
            }

            if (transform.position.x > 12) { KillMeWithoutAni(); }
        }
        else
        {
            anim.speed = 0;
        }
    }

    public void MoveBug() {
        if (bug.name == "Drunk" || bug.name == "QueenBee") {

            //Debug.Log("x: " + x + " y: " + y);
            fTime += Time.deltaTime * curveSpeed;
            vLastPos = transform.position;

            transform.position = new Vector3(transform.position.x + velocity, (Mathf.Sin(fTime) * amplitude)/100 + vLastPos.y);
        }
        else {
            // move me regularly
            transform.position = new Vector2(transform.position.x + velocity, transform.position.y);
        }
        Debug.DrawLine(vLastPos, transform.position, debugColor, 10);
    }

    public void MoveCharger() {
        transform.position = new Vector2(transform.position.x + velocity, transform.position.y);

        // Preparing
        if (bug._state == Bug._STATE.IDLE && transform.position.x > chargerChangePostionIdle) {
            bug._state = Bug._STATE.PREPARING;
            anim.SetTrigger("Preparing");

            velocity = bug.PREPARING_MVMNT_SPEED;
        }

        // Charging
        if(bug._state == Bug._STATE.PREPARING && chargerPreparingTimer > 2) {
            bug._state = Bug._STATE.CHARGING;
            anim.SetTrigger("Charging");

            velocity = bug.CHARGING_MVMNT_SPEED;
            chargerPreparingTimer = 0;
        }

    } 

    void IncreaseChargerPreparingTimer() {
        chargerPreparingTimer++;
    }

    public void KillMeWithoutAni() {
        PlayerController.player.BJamountSession += bug.bjAmount;
        Destroy(this.gameObject);
    }

}
