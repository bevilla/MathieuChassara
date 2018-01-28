﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool isMovingToTube = true;
    [HideInInspector]
    public Vector3 destination;
    public OrgansInfos.Organ organDestination;

    UnitStats unitStats;
    MoveThroughOrgans mto;

    void Awake()
    {
        unitStats = GetComponent<UnitStats>();
        mto = GetComponent<MoveThroughOrgans>();
    }

    void Update()
    {
        if (isMovingToTube)
        {
            Vector3 direction = (destination - transform.position).normalized;
            Vector3 movement = direction * unitStats.speed * Time.deltaTime;
            Vector3 newPosition = transform.position + movement;

            transform.LookAt(newPosition);
            transform.position = newPosition;
            if (Vector3.Distance(transform.position, destination) < 0.5f)
            {
                isMovingToTube = false;
                mto.currentPosition = organDestination;
                mto.MoveToNext();
            }
        }
    }
}