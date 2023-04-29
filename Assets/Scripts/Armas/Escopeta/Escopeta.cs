using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : MonoBehaviour
{
    public float Damage;
    public float Range;
    public float RangoDispersion;
    public int numeroDeBalas;
    private Transform PlayerCamera;

    private Animator animator;

    public ParticleSystem Flash;
    public ParticleSystem Flash2;
    public GameObject ImpactEffect;

    void Start()
    {
        PlayerCamera = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

   public void Shoot()
    {
        Flash.Play();
        Flash2.Play();
        animator.SetTrigger("Disparo");
        Vector3 destino = PlayerCamera.position + PlayerCamera.forward * Range;
        for (int i = 0; i < numeroDeBalas; i++) {
            // Genera dos angulos aleatorios en radianes
            float angulo1 = Random.Range(0.0f, 1.0f) * 2 * Mathf.PI;
            float angulo2 = Random.Range(0.0f, 1.0f) * 2 * Mathf.PI;
            // Genera una distancia aleatoria desde el centro de la esfera hasta el punto
            float distancia = Mathf.Pow(Random.Range(0.0f, 1.0f), 1.0f/3.0f) * RangoDispersion;
            float x = distancia * Mathf.Cos(angulo1) * Mathf.Sin(angulo2);
            float y = distancia * Mathf.Sin(angulo1) * Mathf.Cos(angulo2);
            float z = distancia * Mathf.Sin(angulo2);
            Vector3 direccion = Vector3.Normalize(destino + new Vector3(x,y,z) - PlayerCamera.position);
            Ray bulletRay = new Ray(PlayerCamera.position + PlayerCamera.forward, direccion);
            Debug.DrawRay(bulletRay.origin, bulletRay.direction * Range, Color.red, 2);

            if (Physics.Raycast(bulletRay, out RaycastHit hitInfo, Range))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
                {
                    enemy.Health -= Damage/numeroDeBalas;
                }

                GameObject impactGO = Instantiate(ImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(impactGO, 1f);
            }
        }
    }
}
