using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Variables para controlar el numero de enemigos totales que existen a la vez y si los spawns estan activos
    static public int EnemyCount = 0;
    static public int MaxEnemies = 15;
    static public bool On = false;

    [SerializeField] private int Difficulty = 0;

    //Tipos de enemigos que puede invocar el spawn
    [SerializeField] private GameObject EnemyType1;
    [SerializeField] private GameObject EnemyType2;
    [SerializeField] private GameObject EnemyType3;
    [SerializeField] private GameObject EnemyType4;
    [SerializeField] private GameObject EnemyType5;

    //Probabilidad de que salga ese tipo de enemigos
    [SerializeField] private float EnemyType1Prob;
    [SerializeField] private float EnemyType2Prob;
    [SerializeField] private float EnemyType3Prob;
    [SerializeField] private float EnemyType4Prob;
    [SerializeField] private float EnemyType5Prob;

    //En Segundos
    [SerializeField] private float SpawnRate;

    //Tiempo desde el ultimo spawn
    private float LastSpawnTime = 0f;


    void Start()
    {
        //Se normaliza la probabilidad de aparición de cada tipo de enemigo
        float aux = EnemyType1Prob + EnemyType2Prob + EnemyType3Prob + EnemyType4Prob + EnemyType5Prob;
        EnemyType1Prob = EnemyType1Prob / aux * 100;
        EnemyType2Prob = EnemyType2Prob / aux * 100 + EnemyType1Prob;
        EnemyType3Prob = EnemyType3Prob / aux * 100 + EnemyType2Prob;
        EnemyType4Prob = EnemyType4Prob / aux * 100 + EnemyType3Prob;
        EnemyType5Prob = EnemyType5Prob / aux * 100 + EnemyType4Prob;

        //Segun la dificultad se ajusta el número máximo de enemigos activos
        switch (Difficulty) {
            case 0:
                break;
            case 1:
                MaxEnemies = 15;
                break;
            case 2:
                MaxEnemies = 30;
                break;
            case 3:
                MaxEnemies = 50;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        //Si el spawn esta activo y esta dentro de una ventana de tiempo valida
        if (On && Time.time > (LastSpawnTime + SpawnRate)) {

            LastSpawnTime = Time.time;

            //Si hay menos enemigos que el máximo de enemigos
            if (EnemyCount < MaxEnemies) {

                //Se genera un número aleatorio
                float rnd = Random.Range(0f, 99f);

                GameObject aux;

                //Se elige el tipo de enemigo a invocar
                if (rnd < EnemyType1Prob) {
                    aux = EnemyType1;
                } else if (rnd < EnemyType2Prob) {
                    aux = EnemyType2;
                } else if (rnd < EnemyType3Prob) {
                    aux = EnemyType3;
                } else if (rnd < EnemyType4Prob) {
                    aux = EnemyType4;
                }else {
                    aux = EnemyType5;
                }

                Instantiate(aux, transform.position, Quaternion.identity);

                EnemyCount++;
            }
        }

    }
}
