using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionTurrets : MonoBehaviour
{
    [SerializeField] GameObject[] interactableTurrets;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetBool("isOn", true);
    }

    private void OnTriggerStay(Collider col)
    {
        foreach(GameObject turret in interactableTurrets)
        {
            turret.GetComponent<Interactable>().turnOnOff(true);
        }
        anim.SetBool("isOn", true);
    }

    private void OnTriggerExit(Collider col)
    {
        foreach (GameObject turret in interactableTurrets)
        {
            turret.GetComponent<Interactable>().turnOnOff(false);
        }
        anim.SetBool("isOn", false);
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
