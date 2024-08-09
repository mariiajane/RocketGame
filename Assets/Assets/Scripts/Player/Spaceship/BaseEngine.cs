using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEngine : MonoBehaviour {


    [SerializeField] protected float a_power = 1f;

    protected PlayerLogic a_player;

    protected Rigidbody2D a_rigitbody;

    public bool IsAcelerate;

    public virtual void Acelerate(bool isAcel)
    {
        if (isAcel)
        {
            a_rigitbody.AddForceAtPosition(transform.up * a_power * Time.deltaTime * 50, transform.position);
        }
        IsAcelerate = isAcel;   
    }
    public void SetPlayer(PlayerLogic pl)
    {
        a_player = pl;
        a_rigitbody = pl.GetComponent<Rigidbody2D>();
    }

}
