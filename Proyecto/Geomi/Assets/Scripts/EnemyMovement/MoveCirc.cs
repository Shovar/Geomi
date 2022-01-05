using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCirc : MonoBehaviour
{
    public float speed = 2;
    Vector3 AngleVel;
    private Transform t;
    private Rigidbody rb;
    public int rot;

    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();
        AngleVel = new Vector3(0, rot, 0);
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = t.forward * speed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(AngleVel * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + forwardMove);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
