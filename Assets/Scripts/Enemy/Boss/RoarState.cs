﻿using UnityEngine;
using System.Collections;

public class RoarState : State {

    [SerializeField]    private float _RoarDuration;
    private float _CurrentRoarTime;
    private int _RandomState;

    public override void Enter()
    {
        _CurrentRoarTime = 0f;
        Debug.Log("Roar State Enter");
    }

    public override void Act()
    {
        Debug.Log("Roar");
        _CurrentRoarTime += Time.deltaTime;
    }

    public override void Reason()
    {
        if (_CurrentRoarTime > _RoarDuration)
        {
            //pick random number
            _RandomState = Random.Range(0, 2);

            //switch state depending on randomly picked number
            switch (_RandomState)
            {
                case 0:
                    GetComponent<StateMachine>().SetState(StateID.SwitchSide);
                    break;
                case 1:
                    GetComponent<StateMachine>().SetState(StateID.LightAttack);
                    break;
                case 2:
                    GetComponent<StateMachine>().SetState(StateID.HeavyAttack);
                    break;
            }
        }    
    }
}