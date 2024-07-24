using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // переменные
    public static Transform Player_Transform;
    [SerializeField] private Rigidbody Player_Rigidbody;
    [SerializeField] private bool inFloor;
    public static float Player_hp = 100f;
    // скорость игрока x, y, z
    [SerializeField] private float Player_Speed_h = 5.0f;
    [SerializeField] private float Player_Speed_v = 5.0f;
    [SerializeField] private float Player_Jump = 5.0f;

    private void Awake()
    {
        Player_Transform = GetComponent<Transform>();
        Player_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        inFloor = true;
    }

    private void Update()
    {
        JumpPlayer();
        Player_hp_full();
    }

    private void FixedUpdate()
    {
        MovementPlayer();
    }

    // передвижение 
    private void MovementPlayer()
    {
        float v = Input.GetAxis("Vertical") * Player_Speed_v;
        float h = Input.GetAxis("Horizontal") * Player_Speed_h;
        Vector3 movePlayer = new Vector3(h, 0, v);

        Player_Transform.Translate(movePlayer * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            Player_Speed_h = 7;
            Player_Speed_v = 7;
        }
        else
        {
            Player_Speed_h = 5.0f;
            Player_Speed_v = 5.0f;
        }
    }

    // прыжок
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inFloor == true)
            {
                Player_Rigidbody.velocity = new Vector3(0, Player_Jump, 0);
                inFloor = false;
            }
        }
    }

    // проверка столкновения с полом
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            inFloor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            inFloor = false;
        }
    }

    private void Player_hp_full()
    {
        if (Player_hp <= 0)
        {
            Player_hp = 0;
            Interface.hpInfo.text = "HP: " + Player_hp;
            Player_Transform.gameObject.SetActive(false);
            FirstPersonCamera.Camera_Transform.gameObject.SetActive(false);
        }
    }
}