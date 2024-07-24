using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock19_use : MonoBehaviour
{
    // переменные
    [SerializeField] private Transform Glock19_Transform;

    private void Awake()
    {
        Glock19_Transform = GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        Glock19();
    }

    // функционал Glock19
    private void Glock19()
    {
        Glock19_Transform.RotateAround(Glock19_Transform.transform.position, Glock19_Transform.transform.up, 0);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(FirstPersonCamera.Camera_Transform.transform.position, FirstPersonCamera.Camera_Transform.transform.forward, out hitInfo, 100))
            {
                Player_Movement.Player_hp -= 10f;
            }
        }
    }
}