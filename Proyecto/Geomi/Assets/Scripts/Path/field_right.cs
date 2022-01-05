using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field_right : MonoBehaviour
{
    public PlayerMovement a;

    private int st;

    // Start is called before the first frame update
    void Start()
    {
        st = a.stage;
    }

    // Update is called once per frame
    void Update()
    {
        if (st < a.stage)
        {
            st = a.stage;
            transform.position += new Vector3(1.5f, 0, 0);
        }
    }
}
