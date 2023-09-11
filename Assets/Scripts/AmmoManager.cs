using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public int maxAmmo = 10;

    private int currentAmmo;

void Start()
{
    currentAmmo = maxAmmo;

    // Find the parent object first
    GameObject spawners = GameObject.Find("Spawners");

    if (spawners != null)
    {
        // Find the child object named "Spawn_Reload" under the parent
        Transform reloadSpawn = spawners.transform.Find("Spawn_Reload");

        if (reloadSpawn != null)
        {
            // Assign its Transform to your spawnPoint
            spawnPoint = reloadSpawn;
        }
        else
        {
            Debug.LogError("Child object 'Spawn_Reload' not found");
        }
    }
    else
    {
        Debug.LogError("Parent object 'Spawners' not found");
    }
}

    public void LoadNextAmmo()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn Point not set!");
            return;
        }

        if (currentAmmo > 0)
        {
            Debug.Log("Location: " + spawnPoint.position);
            Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            currentAmmo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
            // You can add a timer logic here to reload ammo after a certain time
        }
    }


}
