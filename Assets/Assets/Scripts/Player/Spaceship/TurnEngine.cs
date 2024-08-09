using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEngine : BaseEngine
{
    public PlayerData rocket;
    void Start()
    {
        base.a_power = rocket.PowerTurn;
    }
}