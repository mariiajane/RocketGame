using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStar : MonoBehaviour
{
    private Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        anim.Play("animationStar");
    }
}
