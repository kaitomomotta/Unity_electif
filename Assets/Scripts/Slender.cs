using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Transform player;
    private float nextMovement = 5.0f;
    private float movementPeriod = 5.0f;
    public int speed = 5;
    float timeDeath = 0.0f;
    float maxTimeDeath = 13.0f;
    public float maxRange = 75f;
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
        speed = SC_FPSController.Instance._pages;
        if (Time.time > nextMovement - speed * 0.15f && !isInFront())
        {
            nextMovement = Time.time + movementPeriod - speed * 0.15f;
            Vector3 playerPosition = player.position;
            Vector3 direction = (playerPosition - transform.position).normalized;
            direction.y = 0;
            transform.position += direction * (speed * 2 + 5) ;
        }
        if(isInFront())
        {
            timeDeath += Time.deltaTime;
            if (timeDeath >= maxTimeDeath - speed)
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            timeDeath = timeDeath > 0 ? timeDeath - 0.2f : 0;
        }
    }

    public bool isInFront()
    {
        Vector3 directionOfPlayer = transform.position - player.position;
        float distanceToTarget = directionOfPlayer.magnitude;
        Debug.Log(distanceToTarget);
        Debug.Log(maxRange);
        float angle = Vector3.Angle(player.forward, directionOfPlayer);
        if (Mathf.Abs(angle) > 30 && Mathf.Abs(angle) < 330)
        {
            return false;
        }
        if(distanceToTarget > maxRange)
        {
            return false;
        }
        return true;
    }
}