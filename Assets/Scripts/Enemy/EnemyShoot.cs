using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet; //prefab bala

    public Transform spawnBulletPoint; //posición desde la que sale la bala

    private Transform playerPosition;

    public float bulletvelocity; 
    void Start()
    {
        playerPosition = GameObject.Find("Jugador").transform;


        Invoke("ShootPlayer", 3);
    }

    
    void Update()
    {
        
    }

    void ShootPlayer()
    {
        Vector3 playerDirection = playerPosition.position - new Vector3(0,1.0f,0)- transform.position;
        GameObject newBullet;
        Debug.Log(playerDirection);
        newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection*bulletvelocity,ForceMode.Force);
        Invoke("ShootPlayer", 3);
    }
}
