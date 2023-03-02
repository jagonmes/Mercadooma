using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = Time.time + 35;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Timer) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.anyKey) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
