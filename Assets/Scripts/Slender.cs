using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
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
    float maxTimeDeath = 10.0f;
    public int maxRange = 42;
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
        if (Time.time > nextMovement && !isInFront())
        {
            nextMovement = Time.time + movementPeriod;
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
            timeDeath = 0.0f;
        }
        Debug.Log("Player looked for: " + timeDeath);
    }

    private bool isInFront()
    {
        Vector3 directionOfPlayer = transform.position - player.position;
        float distanceToTarget = directionOfPlayer.magnitude;
        float angle = Vector3.Angle(player.forward, directionOfPlayer);
        if ((Mathf.Abs(angle) > 50 && Mathf.Abs(angle) < 310) || distanceToTarget > maxRange)
        {
            return false;
        }
        return true;
    }
}