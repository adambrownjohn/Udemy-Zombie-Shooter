using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
  
    [SerializeField] Camera fpCamera; // field for declaring origin (player camera)
    [SerializeField] float range = 100f; //range variable for raycasting



    void Update()
    {
        if(Input.GetButtonDown("Fire1")) // Bind for shooting
        {
            ShootGun(); // method for shooting
        }
    }

    private void ShootGun() // method uses raycasting
    {
        RaycastHit hit; //new raycast variable 
        Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range); //raycast code, delcaring origin with fpCamera variable
                                                                                                //then moving froward from fpCamera, then "out", then raycast "hit" variable, then "range" variable
        Debug.Log("I hit: " + hit.transform.name); // test code for printing name of object on raycast hit
    }
}
