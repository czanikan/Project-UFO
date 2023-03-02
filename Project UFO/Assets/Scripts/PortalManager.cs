using System.Collections;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField] GameObject portalPair;
    [SerializeField] int layerId;   // id of the "Pickable" layer

    [SerializeField] float cooldownTime = 0.5f;

    public bool canTeleport = false;

    private void Start()
    {
        canTeleport = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerId)
        {
            if(canTeleport)
            {
                canTeleport = false;
                portalPair.GetComponent<PortalManager>().canTeleport = false;

                // Get the velocity of the object so we can use to simulate exiting force
                // from the other portal.
                Rigidbody _rb = other.GetComponent<Rigidbody>();
                float v = _rb.velocity.magnitude;
                Debug.Log("The velocity of the object: " + v);

                other.transform.position = portalPair.transform.position;
                _rb.velocity = Vector3.zero;
                _rb.AddForce(portalPair.transform.forward * v * 30f);

                // Sets portals to cooldown.
                StartCoroutine(TeleportCooldown());
            }
        }
    }

    IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);

        canTeleport = true;
        portalPair.GetComponent<PortalManager>().canTeleport = true;
    }
}
