using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {

    public string name;

    public float speed;
    public float acceleration = 0.0001f;
    public enum _STATE {IDLE, PREPARING, CHARGING, SCARED, DEAD, EXPLODING, UBR};
    public _STATE _state;
    public enum _TYPE {SIMPLE, DRUNK, CHARGER, BEE, QUEENBEE};
    public _TYPE _type;

    public float blowUpCoutner;

    public float startX, startY;
    public float endX;
    public float endY;
    public float y;
    public float duration = 14;
    public float curveSpeed = 2;
    public float amplitude = 9;
    public float time;
    public bool reverse, began, complete;

    public bool isAngeredBee;

    // charger
    public float IDLE_MVMNT_SPEED;
    public float PREPARING_MVMNT_SPEED;
    public float CHARGING_MVMNT_SPEED;

    public int bjAmount = 0;

    public void Awake()
    {
        bjAmount = Random.Range(1, 5);
    }
}
