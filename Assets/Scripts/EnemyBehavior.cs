using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float movementSpeed = 3f;
    private float movementDirection = 1f;

    void Update()
    {
        // Move the enemy horizontally
        transform.Translate(Vector3.right * movementDirection * movementSpeed * Time.deltaTime);

        // Check if the enemy has reached the maximum limit
        if (transform.position.x >= 3f)
        {
            // Change the movement direction to go back to the left
            movementDirection = -1f;
        }
        // Check if the enemy has reached the minimum limit
        else if (transform.position.x <= -3f)
        {
            // Change the movement direction to go back to the right
            movementDirection = 1f;
        }
    }
}
