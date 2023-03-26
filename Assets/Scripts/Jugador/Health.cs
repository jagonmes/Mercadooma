using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    private float live;

    public float Live
    {
        get
        {
            return live;
        }
        set
        {
            live = value;

            if (live <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
            }
        }

    }
    void Start()
    {
        Live = StartingHealth;
    }

}
