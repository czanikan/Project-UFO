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
    [SerializeField] private LayerMask whatIsGround;

    [Header("Movement Stats")]

    public bool isControllable;
    [SerializeField] private float maxSpeed;
    private float curSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float rotSpeed;

    private float lastHitDistance;
    private float speedTarget, rotateTarget;
    private Vector3 offset;
    private Vector3 moveInput;

    private Rigidbody rb;


    private void Start()
    {
        offset = new Vector3(0, 90, 0);
        rb = GetComponent<Rigidbody>();
        isControllable = true;
    }

    private void Update()
    {
        if (isControllable)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            moveInput = new Vector3(h, 0, v);

            float curMaxSpeed = Input.GetButton("Jump") ? maxSpeed / 2 : maxSpeed;

            if (moveInput != Vector3.zero)
            {
                if (curSpeed < curMaxSpeed)
                {
                    curSpeed = curSpeed + acceleration * Time.deltaTime;
                }
                else
                {
                    curSpeed = curSpeed - deceleration * Time.deltaTime;
                }
            }
            else
            {
                if (curSpeed > 0)
                {
                    curSpeed = curSpeed - deceleration * Time.deltaTime;
                }
            }

            body.localRotation = Quaternion.Slerp(body.localRotation, Quaternion.Euler((moveInput + offset) * rotSpeed), Time.deltaTime * 4.0f);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, rayLength, whatIsGround))
        {
            float forceAmount = HooksLawDampen(hit.distance);

            rb.AddForceAtPosition(transform.up * forceAmount, transform.position);
        }
        else
        {
            lastHitDistance = rayLength * 1.1f;
        }

        rb.MovePosition(rb.position + moveInput * Time.deltaTime * curSpeed);
        //rb.velocity = moveInput * maxSpeed * Time.deltaTime;
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
