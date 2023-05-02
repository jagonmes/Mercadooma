using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageFromEnemy : MonoBehaviour
{

    [SerializeField] private float setCoolDown;
    private float coolDown = 0f;
    [SerializeField] private float impactForce;

    public Movimiento movimiento;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (coolDown <= 0)
            {
                Debug.Log("Normal of the first point: " + other.gameObject.transform.position);
                Health.Instance.PlayerDamaged();
                coolDown = setCoolDown;
            }
            movimiento.PhysicalHit(other.gameObject.transform.forward * impactForce);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Enemy"))
        {
            if (coolDown <= 0)
            {
                Health.Instance.PlayerDamaged();
                coolDown = setCoolDown;
            }
            movimiento.PhysicalHit(other.gameObject.transform.forward * impactForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Health.Instance.PlayerDamaged();
        }
    }

    void Update() {
        if (!MenuPausa.juegoPausado)
        {
            coolDown -= Time.deltaTime;
        }
    }

     
}
