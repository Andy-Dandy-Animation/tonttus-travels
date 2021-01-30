﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class PatrolScript : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {

        if (points.Length == 0)
            return;


        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}