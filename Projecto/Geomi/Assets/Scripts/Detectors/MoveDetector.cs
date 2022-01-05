using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDetector : MonoBehaviour
{
    public Rigidbody rb;
    public Transform t;
    public bool leftright;
    public float speed = 0;

    private bool move = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = t.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    void Update()
    {
        if (move && leftright && t.position.x <= 10)
        {
            speed = 4;
        }
        if (move && !leftright && t.position.x >= -10)
        {
            speed = 4;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) move = true;
    }
}
