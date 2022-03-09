using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Open,
        TurnOn,
        TurnOff
    }

    public InteractionType interactionType;

    public abstract void interaction();


}
