using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] private Transform decal;
    [SerializeField] private GameObject holo;
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask whatIsObject;
    [SerializeField] private float smoothTime;
    [SerializeField] private float checkRadius;

    private void Update()
    {
        if(Input.GetButton("Jump"))
        {
            decal.gameObject.SetActive(false);
            holo.SetActive(true);
        }
        else
        {
            decal.gameObject.SetActive(true);
            holo.SetActive(false);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, 5))
            {
                decal.position = new Vector3(decal.position.x, hit.point.y, decal.position.z);
            }
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Jump"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(target.position, checkRadius, whatIsObject);
            foreach (var hitCollider in hitColliders)
            {
                hitCollider.GetComponent<Rigidbody>().MovePosition(Vector3.Slerp(hitCollider.transform.position,
                    target.position, smoothTime * Time.fixedDeltaTime));
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, checkRadius);
    }
}
