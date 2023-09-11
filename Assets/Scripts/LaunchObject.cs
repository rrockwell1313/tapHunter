using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    //charge rate is multiplied by time.delta time so its not actually 10 a second.
    public float chargeRate = 10f;
    public float maxCharge = 100f;

    private Rigidbody2D rb;
    private Vector2 launchDirection;
    private Vector2 currentDirection;
    
    private CapsuleCollider2D col;
    private AmmoManager ammoManager;
    private bool isLaunched = false;
    private float currentCharge = 0f;
    private float previousYPosition;

    private float rotationSpeed = 3f;
    private bool isRotating = false;
    private Quaternion targetRotation;


    // Start is called before the first frame update
    void Start()
{
    // Assign rb before using it.
    rb = GetComponentInChildren<Rigidbody2D>();
    ammoManager = FindObjectOfType<AmmoManager>();
    isLaunched = false;
    rb.isKinematic = true;

    // Assign and set the collider's isTrigger property
    col = GetComponentInChildren<CapsuleCollider2D>();
    col.isTrigger = true;
    
}


    // Update is called once per frame
    void Update()
    {
        HandleInput();
        DestructionCalls();
        RotateArrowDown();
        currentDirection = new Vector2(transform.position.x, transform.position.y).normalized;
    }

void HandleInput()
    {
        // Check if the object has not been launched yet
        if (!isLaunched)
        {
            // Check for screen touch or mouse button held down
            if (Input.GetMouseButton(0))
            {
                CalculateLaunchDirection();
                IncreaseCharge();
            }

            // Check for screen release or mouse button release
                if (Input.GetMouseButtonUp(0))
            {
                rb.isKinematic = false;
                isLaunched = true;

                Launch();
                ResetCharge();
                ammoManager.LoadNextAmmo();
            }

        }
    }

void CalculateLaunchDirection()
{
    Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    launchDirection = (touchPos - (Vector2)transform.position).normalized;

    // Calculate the angle between the launch direction and the up vector
    float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg;

    // Adjust the angle by 90 degrees to account for the arrow's default orientation along the Y-axis
    angle -= 90f;

    // Set the rotation of the projectile to face the launch direction
    transform.rotation = Quaternion.Euler(0, 0, angle);
}



    void IncreaseCharge()
{
    if (currentCharge >= maxCharge)
    {
        return;
    }

    currentCharge += chargeRate * Time.deltaTime;
    currentCharge = Mathf.Clamp(currentCharge, 0, maxCharge);

}



    void ResetCharge()
    {
        currentCharge = 0f;
    }

    void Launch()
    {
        rb.AddForce(launchDirection * currentCharge, ForceMode2D.Impulse);
        col.isTrigger = false;
    }

    void RotateArrowDown()
    {
        if (currentDirection.y < previousYPosition && isLaunched && !isRotating)
        {
            targetRotation = Quaternion.Euler(0, 0, 180);
            isRotating = true;
            StartCoroutine(RotateToTarget());
        }

        previousYPosition = currentDirection.y;
    }


    public float GetCurrentCharge()
    {
        return currentCharge;
    }

    void DestructionCalls(){
        if(rb.transform.position.y < -6f)
        {
        Debug.Log("Load Next Ammo");
        Destroy(gameObject);
        }
    }

    IEnumerator RotateToTarget()
{
    while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        yield return null;
    }

    transform.rotation = targetRotation;
    isRotating = false;
}

}
