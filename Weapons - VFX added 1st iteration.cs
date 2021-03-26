using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
  
    [SerializeField] Camera fpCamera; 
    [SerializeField] float range = 100f; 
    [SerializeField] float damage = 35f; // Damage variable is defined here
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;



    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            ShootGun(); 
            PlayMuzzleFlash();
        }
    }

    private void PlayMuzzleFlash()
    {
       muzzleFlash.Play();
    }

    private void ShootGun()
    {
        ProcessRaycast();

    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            // TODO: add some effects for more visual spectacle
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            // call a method on EnemyHealth that decreases the enemy health
            if (target == null) return;
            target.TakeDamage(damage); //calls on the public "TakeDamage" method in EnemyHealth script, works as a property of the target hit by raycasting, parses in "damage" variable 
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
