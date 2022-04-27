using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGateInteraction : Interactable
{
    public bool isOpen = false;
    [SerializeField] GameObject lasers;

    private void Update()
    {
        if (isOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Open()
    {
        lasers.SetActive(false);
    }

    void Close()
    {
        lasers.SetActive(true);
    }
    public override void interaction()
    {

    }
    public override void turnOnOff(bool state)
    {
        isOpen = state;
    }
}
