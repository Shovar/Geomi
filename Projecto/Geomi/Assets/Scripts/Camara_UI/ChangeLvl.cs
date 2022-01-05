using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLvl : MonoBehaviour
{
    private float input;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            SceneManager.LoadScene("TitleScreen");
        }
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("Level1");
        }
        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("Level2");
        }
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("Level3");
        }
        if (Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene("Level4");
        }
        if (Input.GetKeyDown("5"))
        {
            SceneManager.LoadScene("Level5");
        }
        if (Input.GetKeyDown("6"))
        {
            SceneManager.LoadScene("Level6");
        }
        if (Input.GetKeyDown("7"))
        {
            SceneManager.LoadScene("Level7");
        }
    }
}
