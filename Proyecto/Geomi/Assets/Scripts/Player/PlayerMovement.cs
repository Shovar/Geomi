using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject joinAnim;
    public GameObject DeadAnim;
    public float speed = 0;
    public float lat_speed = 2;
    public int chikitos = 0;
    public int stage = 0;
    public int valeria = 0;
    public Rigidbody rb;
    public TMPro.TextMeshProUGUI displayText;
    public bool Geomi_alive = true;
    public Queue<int> dpos = new Queue<int>();
    public bool GodMode = false;
    public bool first_touch = false;
    public int lvl;
    public AudioClip dead;
    public AudioClip upgrade;
    public AudioClip win;

    Animator a;
    private int change = 100;
    private float input;
    private bool finish = false;
    private AudioSource aud;


    void Start()
    {
        a = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        speed = 0;
    }


    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 movement = transform.right * input * lat_speed * Time.fixedDeltaTime;
        if(!finish) rb.MovePosition(rb.position + forwardMove + movement);
    }

    // Update is called once per frame
    private void Update()
    {
        input = Input.GetAxis("Horizontal");
        if( Input.GetKeyDown("g"))
        {
            GodMode = !GodMode;
        }

        if (finish)
        {
            displayText.fontSize = 200;
            if (valeria == 8)
            {
                displayText.color = new Color(255, 255, 0, 255);
                displayText.text = "Tier S";
            }
            else if (valeria > 5)
            {
                displayText.color = new Color(255, 0, 0, 255);
                displayText.text = "Tier A";
            }
            else if (valeria > 3)
            {
                displayText.color = new Color(0, 255, 0, 255);
                displayText.text = "Tier B";
            }
            else if (valeria > 1)
            {
                displayText.color = new Color(0, 255, 255, 255);
                displayText.text = "Tier C";
            }
            else if (valeria > 0)
            {
                displayText.color = new Color(0, 0, 255, 255);
                displayText.text = "Tier D";
            }
            else
            {
                displayText.color = new Color(255, 0, 255, 255);
                displayText.text = "Tier E";
            }

        }

        if (!first_touch && input != 0)
        {
            first_touch = true;
            displayText.text = "";
            a.SetBool("start", true);
            speed = 5;
        }

        if (chikitos > 11 && (stage == 0 || stage == 1))
        {
            dpos.Clear();

            change = 0;
            chikitos = 0;
            stage++;
            aud.PlayOneShot(upgrade, 0.1f);
            Instantiate(joinAnim, new Vector3(rb.position.x, rb.position.y +0.5f, rb.position.z), Quaternion.AngleAxis(90, Vector3.right));
        }
        if(change < 100)
        {
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            change++;
        }

        if (Input.GetKeyDown("m"))
        {
            if (stage == 0 || stage == 1) chikitos++;
            else valeria++;
        }
        if (Input.GetKeyDown("n"))
        {
            if (chikitos > 0) chikitos--;
            else if(stage == 2 && valeria >0) valeria--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GodMode && other.CompareTag("Deadly"))
        {
            Instantiate(DeadAnim, new Vector3(rb.position.x, rb.position.y + 0.5f, rb.position.z), Quaternion.AngleAxis(90, Vector3.right));
            transform.position = new Vector3(0, -200, 0);
            speed = 0;
            Geomi_alive = false;
            StartCoroutine("Waiter");
        }

        if (other.CompareTag("Finish"))
        {
            finish = true;
            a.SetBool("finish", true);
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            speed = 0;
            StartCoroutine("WaiterNextLvl");
        }
    }

    private IEnumerator Waiter()
    {
        aud.PlayOneShot(dead, 1f);
        yield return new WaitForSeconds(1.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator WaiterNextLvl()
    {
        aud.PlayOneShot(win, 0.5f);
        yield return new WaitForSeconds(4f);
        lvl = lvl + 1;
        SceneManager.LoadScene("Level" + lvl);
    }
}
