using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movementscript : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator ani;


    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 4f;
   



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            agent.speed = runSpeed;
        }
        else
        {
            agent.speed = walkSpeed;
        }
        ani.SetFloat("speed", agent.desiredVelocity.magnitude);
    }
}