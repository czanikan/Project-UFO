using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Activate,
        TurnOnOff
    }

    public InteractionType interactionType;

    public abstract void interaction();
    public abstract void turnOnOff(bool state);


}
