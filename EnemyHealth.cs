using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f; // variable for HP

    // create a public method which reduces hitpoints by the amount of damage
    public void TakeDamage(float damage) // method for health loss that can be called in other scripts, method parses in the float variable "damage" 
    {
        hitPoints -= damage; // hitpoints that are lost are parsed in as damage
        
       
        if(hitPoints <= 0) //if HP reaches 0, destroy object
        {
            Destroy(gameObject);
        }
    }
}
