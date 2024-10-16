using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Door door;

    public bool isOpenTrigger;

    private void Awake()
    {
        door = GetComponentInParent<Door>();
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            if (isOpenTrigger)
            {
                door.DoorOpen();
            }
            else
            {
                door.DoorClose();
            }
        }
    }
}
