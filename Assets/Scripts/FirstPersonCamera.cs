using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;using UnityEngine.UI;

public class FirstPersonCamera : MonoBehaviour
{
    // переменные
    [SerializeField] private Camera MainCamera;
    public static Transform Camera_Transform;
    public static float RotationX;
    public static float RotationY;

    // чувствительность
    [SerializeField] private float Speed_sensitivity = 1.0f;

    private void Awake()
    {
        MainCamera = GetComponent<Camera>();
        Camera_Transform = GetComponent<Transform>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        FirstPerson();
        // показать курсор
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Cursor.visible == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    // камера от первого лица
    private void FirstPerson()
    {
        Camera_Transform.position = new Vector3(Player_Movement.Player_Transform.position.x, Player_Movement.Player_Transform.position.y + 0.5f, Player_Movement.Player_Transform.position.z);
        float MouseX = Input.GetAxis("Mouse X") * Speed_sensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * Speed_sensitivity;

        RotationX -= MouseY;

        RotationY += MouseX;

        RotationX = Mathf.Clamp(RotationX, -90, 90);

        Camera_Transform.localRotation = Quaternion.Euler(RotationX, RotationY, 0);
        Player_Movement.Player_Transform.localRotation = Quaternion.Euler(0, RotationY, 0);
    }
}