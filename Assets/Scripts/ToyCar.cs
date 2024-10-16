using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCar : MonoBehaviour
{
    public Vector3 targetPos;
    public float moveSpeed;
    bool move = false;
    public AudioClip moveSound;

    private void Update()
    {
        if (move) Move();
    }

    public void TriggerMove()
    {
        move = true;

        GetComponent<AudioSource>().PlayOneShot(moveSound);
    }

    public void Move()
    {
        float step = moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if (Vector3.Distance(transform.position, targetPos) < 0.001f)
        {
            move = false; // Stop moving once reached
        }

    }

}
