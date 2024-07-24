using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    // переменные
    public static TMP_Text hpInfo;

    private void Awake()
    {
        hpInfo = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        crosshair();
        hpInfo.text = "HP: " + Player_Movement.Player_hp;
    }

    private void crosshair()
    {

    }
}