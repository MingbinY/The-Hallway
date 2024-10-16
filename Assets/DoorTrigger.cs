using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Animator animator;

    public bool isOpenTrigger;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            if (isOpenTrigger)
            {
                animator.SetTrigger("Open");
            }
            else
            {
                animator.SetTrigger("Close");
            }
        }
    }
}
