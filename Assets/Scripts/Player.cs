using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float waitForSeconds = 1f;
    public float wait = 0;

    //Booleans
    public bool levelFinished;
    public bool levelLosed;

    private void Start()
    {
        levelFinished = false;
        levelLosed = false;
    }



    private void Update()
    {
        if (levelFinished)
        {
            StartCoroutine(Finish());
        }

        if (levelLosed)
        {
            StartCoroutine(Lose());
        }
    }



    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            // If player touches safe
            case "Safe":
                levelFinished = true;
                break;

            // If player touches Monster
            case "Monster":
                levelLosed = true;
                break;

        }

    }
    IEnumerator Finish()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("WinScene");                
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LoseScene");
    }
}
