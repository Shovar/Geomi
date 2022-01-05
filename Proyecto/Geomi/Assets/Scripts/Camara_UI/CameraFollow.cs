using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    public Transform target;
    public float speed;
    public PlayerMovement a;

    private int change = 100;
    private int st = 0;

    void Start()
    {
        offset = target.position - transform.position;
        a = FindObjectOfType<PlayerMovement>();
        st = a.stage;
    }

    void FixedUpdate()
    {
        //Velocidad fija
        if (a.Geomi_alive) transform.position = Vector3.MoveTowards(transform.position, target.position - offset, speed * Time.deltaTime);
        if (st < a.stage)
        {
            st = a.stage;
            change = 0;
        }

        if (change < 100)
        {
            transform.position += new Vector3(0, 0.015f, -0.02f);
            offset = target.position - transform.position;
            change++;
        }
    }
}
