using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOfStar : MonoBehaviour
{
    public GameObject star;
    private Animator animationStar;

    void Start()
    {
        animationStar = star.GetComponent<Animator>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animationStar.SetBool("flag", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animationStar.SetBool("flag", false);
        }
    }
}
