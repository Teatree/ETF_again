using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {


    public const int DRUNK_BUG_MOVE_DURATION_BASE = 18;
    public const int DRUNK_BUG_AMPLITUDE_BASE = 5;
    public const int BEE_MOVE_DURATION_BASE = 16;
    public const int BEE_AMPLITUDE_BASE = 0;
    public const int QUEENBEE_MOVE_DURATION_BASE = 18;
    public const int QUEENBEE_AMPLITUDE_BASE = 50;
    public const int CHARGER_BUG_MOVE_BASE = 115;
    public const int SIMPLE_BUG_MOVE_DURATION_BASE = 16;
    public const int SIMPLE_BUG_AMPLITUDE_BASE = 0;


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
    public float interpolation;
    public bool reverse, began, complete;

    public bool isAngeredBee;

    // charger
    public float IDLE_MVMNT_SPEED;
    public float PREPARING_MVMNT_SPEED;
    public float CHARGING_MVMNT_SPEED;

    public int bjAmount = 0;

    public void Awake()
    {
       // bjAmount = Random.Range(1, 5);
    }

    public void applyMultiplier(Multiplier m)
    {
        switch (_type)
        {
            case _TYPE.DRUNK:
                {
                    duration = DRUNK_BUG_MOVE_DURATION_BASE * m.drunkBugMoveDuration * GameManager.gameManager.level.drunkBugMoveDuration;
                    amplitude = DRUNK_BUG_AMPLITUDE_BASE * m.drunkBugAmplitude * GameManager.gameManager.level.drunkBugAmplitude;
                    bjAmount = 2;
                    break;
                }
            case _TYPE.BEE:
                {
                    duration = BEE_MOVE_DURATION_BASE * m.beeMoveDuration * GameManager.gameManager.level.beeMoveDuration;
                    amplitude = BEE_AMPLITUDE_BASE * m.beeAmplitude * GameManager.gameManager.level.beeAmplitude;
                    bjAmount = 2;
                    break;
                }
            case _TYPE.CHARGER:
                {
                    bjAmount = 3;
                    IDLE_MVMNT_SPEED = CHARGER_BUG_MOVE_BASE * m.chargerBugMove * GameManager.gameManager.level.chargerBugMove;
                    PREPARING_MVMNT_SPEED = 40 * m.chargerBugMove * GameManager.gameManager.level.chargerBugMove;
                    CHARGING_MVMNT_SPEED = 505 * m.chargerBugMove * GameManager.gameManager.level.chargerBugMove;
                    break;
                }
            case _TYPE.QUEENBEE:
                {
                    duration = QUEENBEE_MOVE_DURATION_BASE * m.queenBeeMoveDuration * GameManager.gameManager.level.queenBeeMoveDuration;
                    amplitude = QUEENBEE_AMPLITUDE_BASE * m.queenBeeAmplitude * GameManager.gameManager.level.queenBeeAmplitude;
                    bjAmount = 3;
                    break;
                }
            default:
                {
                    duration = SIMPLE_BUG_MOVE_DURATION_BASE * m.simpleBugMoveDuration * GameManager.gameManager.level.simpleBugMoveDuration;
                    amplitude = SIMPLE_BUG_AMPLITUDE_BASE * m.simpleBugAmplitude * GameManager.gameManager.level.simpleBugAmplitude;
                    bjAmount = 1;
                    break;
                }
        }
    }
    
    public bool isQueen ()
    {
        return _type == _TYPE.QUEENBEE;
    }
}
