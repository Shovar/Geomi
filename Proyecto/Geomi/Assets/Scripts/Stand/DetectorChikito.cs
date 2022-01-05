using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorChikito : MonoBehaviour
{
    public GameObject obj;
    public Transform mama;
    public PlayerMovement a;

    // Start is called before the first frame update
    void Start()
    {
        a = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a.stage != 0) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int aux;
            if (a.dpos.Count != 0)
            {
                aux = a.dpos.Dequeue();
            }
            else aux = a.chikitos;
            a.chikitos++;
            float x = (aux % 2)*0.5f - 0.25f;

            float z = (aux/2 % 6)*0.25f + 0.5f;

            if (a.stage == 0) Instantiate(obj, new Vector3(mama.position.x + x, mama.position.y, mama.position.z - z), Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
