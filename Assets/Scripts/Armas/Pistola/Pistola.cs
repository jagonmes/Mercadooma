using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public float Damage;
    public float Range;
    private Transform PlayerCamera;

    public ParticleSystem Flash;
    public GameObject ImpactEffect;

    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

   public void Shoot()
    {
        Flash.Play();

        Ray bulletRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        Debug.DrawRay(bulletRay.origin, bulletRay.direction * Range, Color.red, 5);
        if (Physics.Raycast(bulletRay, out RaycastHit hitInfo, Range))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy)) 
            {
                enemy.Health -= Damage;
            }

            GameObject impactGO = Instantiate(ImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactGO, 1f);
        }
    }
}
