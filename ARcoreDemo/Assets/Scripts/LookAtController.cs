using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtController : MonoBehaviour
{
    private Animator animator;
    private Transform target;

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = Camera.main.transform;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtWeight(1.0f, 0.8f, 1.0f, 0.0f, 0f);
        animator.SetLookAtPosition(target.position);
    }
}
