using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorValeriana : MonoBehaviour
{
    public PlayerMovement a;
    AudioSource m_MyAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        a = FindObjectOfType<PlayerMovement>();
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            a.valeria++;
            StartCoroutine("Waiter");

        }
    }
    private IEnumerator Waiter()
    {
        m_MyAudioSource.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
