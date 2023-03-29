using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificultad : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            Spawn.Difficulty = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            Spawn.Difficulty = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            Spawn.Difficulty = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            Spawn.Difficulty = 3;
        }
    }
}
