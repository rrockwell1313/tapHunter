using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaunchObject : MonoBehaviour
{
    public float chargeRate = 10f;
    public float maxCharge = 100f;

    private Rigidbody2D rb;
    private float currentCharge = 0f;
    private Vector2 launchDirection;
    private bool launched = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        
    }

    void HandleInput()
    {
        
        if(Input.GetMouseButton(0))
        {
             Debug.Log("Handling input"); 
            CalculateLaunchDirection();
            IncreaseCharge();
        }

        //Check for screen release or mouse release
        if(Input.GetMouseButtonUp(0)){
            Launch();
            ResetCharge();
        }
    }

    void CalculateLaunchDirection()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        launchDirection = (touchPos - (Vector2)transform.position).normalized;
    }

 void IncreaseCharge()
{
    currentCharge += chargeRate * Time.deltaTime;
    currentCharge = Mathf.Clamp(currentCharge, 0, maxCharge);

    Debug.Log("Current Charge: " + currentCharge);

}


    void ResetCharge()
    {
        currentCharge = 0f;
    }

    void Launch()
    {
        rb.AddForce(launchDirection * currentCharge, ForceMode2D.Impulse);
    }

    public float GetCurrentCharge()
    {
        return currentCharge;
    }

}
