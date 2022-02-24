using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] private Transform decal;
    [SerializeField] private GameObject holo;

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
}
