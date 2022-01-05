using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTitle : MonoBehaviour
{
    private float input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Level7");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Level6");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
