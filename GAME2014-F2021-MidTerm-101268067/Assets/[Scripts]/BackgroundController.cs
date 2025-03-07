﻿/*
GAME2014-F2021
Mid Term Script
Nathan Nguyen
101268067

Description:
Move the gameobject in a direction until it reaches a boundary
change the objects transform to its initial position.

Change Log:
Added Horizontal and Vertical Spawn locations to pick specifically where to spawn
HorizontalBoundary kept as the boundary

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

    public float horizontalSpawnLocation;
    public float verticalSpawnLocation;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(horizontalSpawnLocation, verticalSpawnLocation);
    }

    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
