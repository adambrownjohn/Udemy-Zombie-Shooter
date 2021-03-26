using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
  
    [SerializeField] Camera fpCamera; 
    [SerializeField] float range = 100f; 
    [SerializeField] float damage = 35f; // Damage variable is defined here



    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            ShootGun(); 
        }
    }

    private void ShootGun() 
    {
        
        RaycastHit hit; 
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit: " + hit.transform.name); 
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
}
