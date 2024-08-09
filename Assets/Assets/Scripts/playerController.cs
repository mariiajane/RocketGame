using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerController : MonoBehaviour
{
    bool _isAcel;
    int _turnDirection;

    [SerializeField] AudioSource _engineSound;
    public UnityEvent turnLeft;
    public UnityEvent turnRight;
    public UnityEvent acelerate;

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    acelerate.Invoke();
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    turnLeft.Invoke();
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    turnRight.Invoke();
        //}
        _isAcel = Input.GetKey(KeyCode.W);
        if (Input.GetKey(KeyCode.A))
        {
            _turnDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _turnDirection = 1;
        }
        else
        {
            _turnDirection = 0;
        }
        PlayerLogic.Instance.Acelerate(_isAcel);
        PlayerLogic.Instance.Turn(_turnDirection);
    }

    public void StartAceleration()
    {
        _isAcel = true;
    }

    public void FinishAceleration()
    {
        _isAcel = false;
    }

    public void Turn(int direction)
    {
        _turnDirection = direction;
    }
}
