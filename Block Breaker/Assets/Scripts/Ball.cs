using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle Paddle;
    private Vector3 PaddleToBallVector;
    private bool HasStarted;
    private AudioSource Audio;
    private Rigidbody2D Rigidbody;

    private void Start()
    {
        Paddle = FindObjectOfType<Paddle>();
        PaddleToBallVector = transform.position - Paddle.transform.position;
        Audio = GetComponent<AudioSource>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!HasStarted)
        {
            transform.position = Paddle.transform.position + PaddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                HasStarted = true;
                Rigidbody.velocity = new Vector2(2f, 10f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (HasStarted)
        {
            Audio.Play();
            var tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            Rigidbody.velocity += tweak;
        }
    }
}
