using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public PlayerMovement a;
    public float speed = 0;

    private Transform t;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = t.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (a.first_touch) speed = 3;
    }
}
