using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    [SerializeField] float forceMagnitude;
    [SerializeField] float maxVeloicty;
    [SerializeField] float rotationSpeed;
    Camera mainCamera;
    Rigidbody rb;

    Vector3 movementDirection;
   
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update() // called every frame
    {
        ProcessInput();

        KeepPlayerOnScreen();

        RotateToFaceVelocity();

    }
    
    void FixedUpdate() // physics calculation everytime is physics system updates just like Time.Deltatime
    {
         if (movementDirection == Vector3.zero) { return; }

        rb.AddForce(movementDirection * forceMagnitude * Time.deltaTime, ForceMode.Force);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVeloicty); // we clamp to define our max velocity

         
    }

    void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }

    }

    void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition =  mainCamera.WorldToViewportPoint(transform.position);

        if(viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if(viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;

    }

    void RotateToFaceVelocity()
    {
        if (rb.velocity == Vector3.zero) {return;} // we dont want its rotating if our velocity is 0 0 0

        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);

        transform.rotation = Quaternion.Lerp(transform.rotation ,
                                                 targetRotation ,
                                                  rotationSpeed *
                                                Time.deltaTime);
        
    }
}