using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactableTarget;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        interactableTarget.GetComponent<Interactable>().turnOnOff(true);
        anim.SetBool("isOn", true);
    }

    private void OnTriggerExit(Collider other)
    {
        interactableTarget.GetComponent<Interactable>().turnOnOff(false);
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
