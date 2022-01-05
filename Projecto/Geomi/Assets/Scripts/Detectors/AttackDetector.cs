using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    public GameObject plant;
    Animator a;
    AudioSource m_MyAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        a = plant.GetComponent<Animator>();
        m_MyAudioSource = GetComponent<AudioSource>();
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            a.SetBool("Ataca", true);
            StartCoroutine("Waiter");
        }
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1.3f);
        m_MyAudioSource.Play();
    }

}
