using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageFromEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health.Instance.PlayerDamaged();
            Debug.Log("Jugador dañado por el enemigo");
        }
    }
}
