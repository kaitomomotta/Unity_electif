using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    Transform player;
    private float nextMovement = 5.0f;
    private float movementPeriod = 5.0f;
    // Start is called before the first frame update
    public NavMeshAgent slender;
    public NavMeshPath path;
    void Start()
    {
        player = GameObject.Find("FPSPlayer").GetComponent<Transform>();
        path = new NavMeshPath();
    }



    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (Time.time > nextMovement)
        {
            nextMovement = Time.time + movementPeriod;
            Vector3 playerPosition = player.position;
            Vector3 direction = (playerPosition - transform.position).normalized;
            direction.y = 0;
            transform.position += direction * 10;
        }
    }
}