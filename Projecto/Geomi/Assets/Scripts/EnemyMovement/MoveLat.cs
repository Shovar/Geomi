using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLat : MonoBehaviour
{
    public float bound;
    public float speed = 2;

    private Transform t;
    public bool right;
    private Rigidbody rb;
    Animator a;

    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.transform;
        a = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 rightMove = t.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + rightMove);
    }

    // Update is called once per frame
    void Update()
    {
        if(t.position.x < -bound && right)
        {
            speed = -speed;
            right = false;
            a.SetBool("Right", false);
        }
        else if (t.position.x > bound && !right)
        {
            speed = -speed;
            right = true;
            a.SetBool("Right", true);
        }
    }
}
