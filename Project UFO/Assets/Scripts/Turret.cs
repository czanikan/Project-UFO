using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Interactable
{
    private Transform player;
    private Animator anim;
    private bool isOn;

    [SerializeField] Transform head;
    [SerializeField] Transform shotPoint;

    [SerializeField] float attackDist;
    [SerializeField] float damping;

    [SerializeField] float startTimeBetweenShoot = 2f;
    private float timeBetweenShoot;

    [SerializeField] GameObject bulletPrefab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        isOn = true;
        timeBetweenShoot = startTimeBetweenShoot;

        anim = GetComponent<Animator>();
        anim.SetBool("isOn", isOn);
    }

    void Update()
    {
        if (isOn)
        {
            if (Vector3.Distance(transform.position, player.position) < attackDist)
            {
                Vector3 lookPos = player.position - head.position;
                Quaternion lookRot = Quaternion.LookRotation(lookPos);
                lookRot.eulerAngles = new Vector3(head.rotation.eulerAngles.x, lookRot.eulerAngles.y - 90, head.rotation.eulerAngles.z);
                head.rotation = Quaternion.Slerp(head.rotation, lookRot, Time.deltaTime * damping);

                if(timeBetweenShoot <= 0)
                {
                    Shoot();
                }
            }

            timeBetweenShoot -= Time.deltaTime;

        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        timeBetweenShoot = startTimeBetweenShoot;
    }

    public override void interaction()
    {

    }
    public override void turnOnOff(bool state)
    {
        isOn = !state;
        anim.SetBool("isOn", isOn);
    }
}
