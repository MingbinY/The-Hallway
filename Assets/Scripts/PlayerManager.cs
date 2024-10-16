using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterController characterController{  get; private set; }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
}
