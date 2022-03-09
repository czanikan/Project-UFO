using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactableTarget;

    private void OnCollisionStay(Collision col)
    {
        HandleInteraction(interactableTarget.GetComponent<Interactable>());
    }

    void HandleInteraction(Interactable interactable)
    {
        switch (interactable.interactionType)
        {

        }
    }
}
