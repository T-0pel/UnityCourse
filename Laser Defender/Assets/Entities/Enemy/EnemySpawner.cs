using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Width;
    public float Height;
    public bool MovingRight;
    public float Padding;
    public float Speed;

    private float XMin;
    private float XMax;

    private void Start()
    {
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        XMin = leftmost.x + Padding;
        XMax = rightmost.x - Padding;

        foreach (Transform child in transform)
        {
            var enemy = Instantiate(EnemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
    }

    private void Update()
    {
        if (MovingRight)
        {
            if (transform.position.x + Width / 2 >= XMax)
            {
                MovingRight = false;
            }
            else
            {
                transform.position += Vector3.right * Speed * Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.x - Width / 2 <= XMin)
            {
                MovingRight = true;
            }
            else
            {
                transform.position += Vector3.left * Speed * Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height));
    }
}
