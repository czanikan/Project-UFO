using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactableTarget;

    private void OnCollisionStay(Collision col)
    {
        //HandleInteraction(interactableTarget.GetComponent<Interactable>());
        interactableTarget.GetComponent<Interactable>().turnOnOff(true);
    }

    private void OnCollisionExit(Collision col)
    {
        //HandleInteraction(interactableTarget.GetComponent<Interactable>());
        interactableTarget.GetComponent<Interactable>().turnOnOff(false);
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
