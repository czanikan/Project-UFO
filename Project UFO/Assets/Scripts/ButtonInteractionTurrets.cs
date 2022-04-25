using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionTurrets : MonoBehaviour
{
    [SerializeField] GameObject[] interactableTurrets;

    private void OnCollisionStay(Collision col)
    {
        foreach(GameObject turret in interactableTurrets)
        {
            turret.GetComponent<Interactable>().turnOnOff(true);
        }
    }

    private void OnCollisionExit(Collision col)
    {
        foreach (GameObject turret in interactableTurrets)
        {
            turret.GetComponent<Interactable>().turnOnOff(false);
        }
    }

    void HandleInteraction(Interactable interactable)
    {
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Activate:
                interactable.interaction();
                break;

            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }
}
