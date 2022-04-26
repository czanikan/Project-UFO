using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    [SerializeField] float magnitude = 2500;

    [SerializeField] GameObject hitEffect;
    
    private AudioSource hitSFX;

    private void Start()
    {
        hitSFX = GetComponent<AudioSource>();   
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();

            Vector3 force = transform.position - col.transform.position;
            force.y = 0;

            force.Normalize();

            hitSFX.Play();
            Instantiate(hitEffect, transform.position, Quaternion.identity);

            rb.AddForce(-force * magnitude, ForceMode.Impulse);
        }
    }
}
