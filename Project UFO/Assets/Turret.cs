using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform player;
    [SerializeField] Transform head;
    [SerializeField] float attackDist;
    [SerializeField] float damping;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < attackDist)
        {
            Vector3 lookPos = player.position - head.position;
            Quaternion lookRot = Quaternion.LookRotation(lookPos);
            lookRot.eulerAngles = new Vector3(head.rotation.eulerAngles.x, lookRot.eulerAngles.y, head.rotation.eulerAngles.z);
            head.rotation = Quaternion.Slerp(head.rotation, lookRot, Time.deltaTime * damping);
        }
    }
}
