using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    public float magnitude = 2500;
    public GameObject hitEffect;

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();

            Vector3 force = transform.position - col.transform.position;
            force.y = 0;

            force.Normalize();

            Instantiate(hitEffect, transform.position, Quaternion.identity);

            rb.AddForce(-force * magnitude, ForceMode.Impulse);
        }
    }
}
