using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (!GameManager.Instance.IsGameActive)
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameManager.Instance.IsGameActive = true;
                animator.SetBool("isRunning", true);
            }
        }
    }
}
