using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerManager playerManager;
    Rigidbody rb;

    AudioSource audioSource;
    public AudioClip footstep;

    public float moveSpeed = 2f;
    public float runSpeed = 4f;
    float currentSpeed = 0;
    [SerializeField] bool canMove = true;
    [SerializeField] Vector3 moveDir = Vector3.zero;
    public bool isRunning = false;
    public float gravity = -9.8f;


    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = footstep;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        moveDir = transform.right * x + transform.forward * y;

        SpeedLimit();
        audioSource.mute = x <= 0 && y <= 0;
    }

    private void FixedUpdate()
    {
        PlayerMove();
        Gravity();
    }

    private void PlayerMove()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift) ? true : false;
        currentSpeed = isRunning ? runSpeed : moveSpeed;

        rb.AddForce(moveDir.normalized * currentSpeed * 10, ForceMode.Force);
    }

    private void Gravity()
    {
        rb.drag = GroundCheck() ? 0 : gravity;
    }

    bool GroundCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.2f);
    }

    void SpeedLimit()
    {
        Vector3 horizontalVelo = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        float currentVelo = horizontalVelo.magnitude;
        if (currentVelo > currentSpeed)
        {
            Vector3 newVelo = horizontalVelo.normalized * currentSpeed;
            rb.velocity = new Vector3(newVelo.x, rb.velocity.y, newVelo.z);

        }
    }
}
