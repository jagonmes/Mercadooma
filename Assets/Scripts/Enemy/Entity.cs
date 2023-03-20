using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
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
                Destroy(gameObject);
            }
        }
  
    }
    void Start()
    {
        Health = StartingHealth;
    }

}
