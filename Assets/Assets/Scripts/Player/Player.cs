﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public PlayerData Rocket;
    public static Player Instance;
    PlayerLogic _playerLogic;

    [SerializeField] float _maxFuelLevel;

    float _fuelLevel;

    [SerializeField] int _maxHp;

    [SerializeField] float _demageForse = 100;

    [SerializeField] float _demageTime = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AddDemageForse(collision.relativeVelocity.magnitude);
    }

    int _hp;

    public event Action onFuelLevelChanged = delegate { };
    public event Action onHpChanged = delegate { };

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        if (transform.position.y < -20)
        {
            Kill();
        }
    }

    void Start () {
        _playerLogic = GetComponent<PlayerLogic>();
        _fuelLevel = _maxFuelLevel;
        _maxHp = Rocket.HP;
        _maxFuelLevel = Rocket.FluelLevel;
        _demageForse = Rocket.DamageForce;
        _demageTime = Rocket.DamageTime;
        _hp = _maxHp;
    }

    public void WasteFuel(float how)
    {
        _fuelLevel -= how;
        onFuelLevelChanged();
    }

    public void AddFuel(float how)
    {
        _fuelLevel = Mathf.Min(_fuelLevel + how, _maxFuelLevel);
        onFuelLevelChanged();
    }

    public bool HasFuel()
    {
        return _fuelLevel > 0;
    }

   

    public void Demage()
    {
        Demage(1);
    }

    float lastHpDemaged = 0;

    public void Demage(int time)
    {
        if (Time.time - lastHpDemaged < _demageTime) return;
        lastHpDemaged = Time.time;
        _hp -=time;
        onHpChanged();
        if (_hp <= 0)
        {
            LevelController.Instance.LooseLevel(); //сцена поражения
        }
       
    }

    public void AddDemageForse(float val)
    {
        int time = 0;
        for(int i = 1; i < 4; i++)
        {
            if(val > _demageForse * i)
            {
                ++time;
            }
        }
        if (time > 0)
        {
            Demage(time);
        }

    }

    public void Kill()
    {
        _hp = 0;
        Demage();
    }

    public int HpCount()
    {
        return Mathf.Max(_hp,0);
    }
    public float FuelLevel01()
    {
        return _fuelLevel / _maxFuelLevel;
    }

}
