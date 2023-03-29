using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }
    
    
    public GameObject[] vidas;
    private int life;
     
        


    void Start()
    {
        Instance = this;
        life = vidas.Length; 
    }

    private void CheckLife()
    {

        if(life < 1)
        {
            Destroy(vidas[0].gameObject);
            //Spawn.EnemyCount = 0;
            //activador.enemiesKilled = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if(life < 2)
        {
            Destroy(vidas[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(vidas[2].gameObject);
        }
        else if (life < 4)
        {
            Destroy(vidas[3].gameObject);
        }
        else if (life < 5)
        {
            Destroy(vidas[4].gameObject);
        }
        else if (life < 6)
        {
            Destroy(vidas[5].gameObject);
        }
        else if (life < 7)
        {
            Destroy(vidas[6].gameObject);
        }
        else if (life < 8)
        {
            Destroy(vidas[7].gameObject);
        }
        else if (life < 9)
        {
            Destroy(vidas[8].gameObject);
        }
        else if (life < 10)
        {
            Destroy(vidas[9].gameObject);
        }
    }

    public void PlayerDamaged()
    {
        life--;
        CheckLife();
    }

}
