using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool AutoPlay = false;
    private Ball Ball;
    // Use this for initialization
    void Start()
    {
        Ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AutoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoMovePaddle();
        }
    }

    private void AutoMovePaddle()
    {
        transform.position = new Vector3(Ball.transform.position.x, transform.position.y, transform.position.z);
    }

    private void MoveWithMouse()
    {
        var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), transform.position.y, transform.position.z);
    }
}
