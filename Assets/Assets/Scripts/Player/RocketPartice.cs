using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPartice : MonoBehaviour 
{
	private Animator m_Animator;
    private BaseEngine _engine;
	
	private void Start () 
	{
		m_Animator = GetComponent<Animator>();
        _engine = GetComponent<BaseEngine>();
	}

	private void Update () 
	{
		if(_engine.IsAcelerate)
			m_Animator.SetBool("Gas", true);
		else
			m_Animator.SetBool("Gas", false);

		if (Input.GetKeyDown(KeyCode.A))
		{
			if (transform.name == "LeftEngine")
				m_Animator.SetBool("Gas", true);
		}
		else if (Input.GetKeyUp(KeyCode.A))
		{
			if (transform.name == "LeftEngine")
				m_Animator.SetBool("Gas", false);
		}
		
		if (Input.GetKeyDown(KeyCode.D))
		{
			if (transform.name == "RightEngine")
				m_Animator.SetBool("Gas", true);
		}
		else if (Input.GetKeyUp(KeyCode.D))
		{
			if (transform.name == "RightEngine")
				m_Animator.SetBool("Gas", false);
		}
	}
}
