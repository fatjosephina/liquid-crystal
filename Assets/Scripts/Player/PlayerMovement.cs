using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce;

    private Rigidbody rb;
    private Vector2 moveInput = PlayerInput.MoveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 muscleForce = new Vector3(moveInput.x, 0f, moveInput.y) * moveForce * Time.fixedDeltaTime;
        rb.AddForce(muscleForce, ForceMode.Acceleration);
    }

    private void OnMoved()
    {
        moveInput = PlayerInput.MoveInput;
    }

    private void OnEnable()
    {
        PlayerInput.moved += OnMoved;
    }

    private void OnDisable()
    {
        PlayerInput.moved -= OnMoved;
    }
}
