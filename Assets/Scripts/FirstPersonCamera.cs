using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;

    [SerializeField]
    private float sensitivityX = 100f;

    [SerializeField]
    private float sensitivityY = 0.5f;

    [SerializeField]
    private float xClamp = 85f;

    private Vector2 cameraInput;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float lookX = cameraInput.x * sensitivityX * Time.deltaTime;
        float lookY = cameraInput.y * sensitivityY;

        playerBody.Rotate(Vector3.up, lookX);

        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = new Vector3(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(targetRotation);
    }

    private void OnCameraMoved()
    {
        cameraInput = PlayerInput.CameraMoveInput;
    }

    private void OnEnable()
    {
        PlayerInput.cameraMoved += OnCameraMoved;
    }

    private void OnDisable()
    {
        PlayerInput.cameraMoved -= OnCameraMoved;
    }
}
