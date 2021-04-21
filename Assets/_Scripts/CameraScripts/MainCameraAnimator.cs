using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraAnimator : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Dead(bool dead)
    {
        anim.SetBool(AnimationTags.DEAD_TRIGGER, dead);
    }
}
