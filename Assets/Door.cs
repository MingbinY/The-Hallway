using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;

    public AudioClip openClip;
    public AudioClip closeClip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void DoorOpen()
    {
        animator.SetTrigger("Open");
        audioSource.PlayOneShot(openClip);
    }

    public void DoorClose()
    {
        animator.SetTrigger("Close");
        audioSource.PlayOneShot(closeClip);
    }
}
