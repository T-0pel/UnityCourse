﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Padding;

    private float XMin;
    private float XMax;
    private Rigidbody2D Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        XMin = leftmost.x + Padding;
        XMax = rightmost.x - Padding;
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var speedVector = new Vector3(horizontalInput * Speed, 0, 0);
        Rigidbody.velocity = speedVector;

        transform.position = new Vector3(Mathf.Clamp(Rigidbody.position.x, XMin, XMax), Rigidbody.position.y, 0);
    }
}
