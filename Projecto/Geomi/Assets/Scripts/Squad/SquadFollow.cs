using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadFollow : MonoBehaviour
{
    public GameObject DeadAnim;
    public Rigidbody rb;

    public Transform target;
    public float speed;
    public PlayerMovement a;

    private Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position;
        rb = GetComponent<Rigidbody>();
        a = FindObjectOfType<PlayerMovement>();
    }

    void FixedUpdate()
    {
        //Velocidad fija
        transform.position = Vector3.MoveTowards(transform.position, target.position - offset, speed * Time.deltaTime);
    }

    void Update()
    {
        if (a.stage == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!a.GodMode && other.CompareTag("Deadly"))
        {
            int x = 0;
            if (offset.x < 0) x++;

            int z = (int)((offset.z - 0.5f) / 0.25f) * 2 + x;
            a.chikitos--;
            a.dpos.Enqueue(z);
            GameObject danim = Instantiate(DeadAnim, new Vector3(rb.position.x, rb.position.y + 0.5f, rb.position.z), Quaternion.AngleAxis(90, Vector3.right));
            danim.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(gameObject);
        }
    }
}
