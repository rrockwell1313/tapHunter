using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public int maxAmmo = 10;

    private int currentAmmo;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;    
    }
     void Update()
    {
        
    }

    // Update is called once per frame
    public void LoadNextAmmo()
    {
        //basically if the ammo is not zero, we are able to create a new projectil.
        //if we are at 0 then we need to actually reset the function of ammo.
        if (currentAmmo >  0)
        {
            Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            currentAmmo--;
        }else {
            //we need to reset the ammo to 0, but with a timer.
            Debug.Log("Out of ammo!");
            return;
        }
    }


}
