using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    private float health;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;

            if (health <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
    void Start()
    {
        Health = StartingHealth;
    }

}
