using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : Singleton<AnimationManager>
{
    public bool isGameActive;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isGameActive = false;
    }
    void Update()
    {
        if (!isGameActive)
        {
            if (Input.GetMouseButtonUp(0))
            {
                isGameActive = true;
                animator.Play("Running");
            }
        }
    }
}
