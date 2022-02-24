using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] private Transform decal;

    private void LateUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, 5))
        {
            decal.position = new Vector3(decal.position.x, hit.point.y, decal.position.z);
        }
    }
}
