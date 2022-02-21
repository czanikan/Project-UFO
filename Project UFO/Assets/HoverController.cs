using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverController : MonoBehaviour
{   
    [Header("Hover Stats")]

    [SerializeField] private float strength;
    [SerializeField] private float dampening;
    [SerializeField] private float rayLength;
    [SerializeField] private Transform body;

    [Header("Movement Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    private Vector3 moveInput;

    private float lastHitDistance;
    private float speedTarget, rotateTarget;
    [SerializeField] private Vector3 offset;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveInput = new Vector3(h, 0, v);

        speedTarget = Mathf.SmoothStep(speedTarget, speed, Time.deltaTime * 12f);
        rotateTarget = Mathf.Lerp(rotateTarget, rotSpeed, Time.deltaTime * 4f);

        body.localRotation = Quaternion.Slerp(body.localRotation, Quaternion.Euler((moveInput + offset) * rotSpeed), Time.deltaTime * 4.0f);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, rayLength))
        {
            float forceAmount = HooksLawDampen(hit.distance);

            rb.AddForceAtPosition(transform.up * forceAmount, transform.position);
        }
        else
        {
            lastHitDistance = rayLength * 1.1f;
        }

        rb.MovePosition(rb.position + moveInput * speed);
    }

    private float HooksLawDampen(float hitDistance)
    {
        float forceAmount = strength * rb.mass * (rayLength - hitDistance) + 
            (dampening * rb.mass * (lastHitDistance - hitDistance));
        forceAmount = Mathf.Max(0f, forceAmount);
        lastHitDistance = hitDistance;

        return forceAmount;
    }
}
