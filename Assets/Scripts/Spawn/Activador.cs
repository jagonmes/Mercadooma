using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Activador : MonoBehaviour
{
    static public int enemiesKilled;
    private int enemyGoal;
    // Start is called before the first frame update
    void Start()
    {
        Spawn.EnemyCount = 0;
        enemiesKilled = 0;
        Spawn.On = true;

        switch (Spawn.Difficulty)
        {
            case 0:
                enemyGoal = 12;
                break;
            case 1:
                enemyGoal = 24;
                break;
            case 2:
                enemyGoal = 48;
                break;
            case 3:
                enemyGoal = 96;
                break;
            default:
                break;
        }
    }

    void Update() 
    {
        if(enemiesKilled >= enemyGoal)
            SceneManager.LoadScene(1);
    }
}
