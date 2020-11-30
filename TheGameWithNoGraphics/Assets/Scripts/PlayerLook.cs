using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;


    //XAxisClamp is part of a code in where we prevent the camera from rotating back onto itself in First Person.
    private float xAxisClamp;
    
    private void Awake()
    {
        //Center and Lock the Curosor into the middle of     eeee``the screen to make sure the mouse doens't escape from the game field
        LockCursor();
        
        //This will start off as 0, but will get a value during CameraRotation()
        xAxisClamp = 0;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        CameraRotation();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        //xAxisClamp will now get a value from where our Mouse is moving on the Y axis.
        xAxisClamp += mouseY;

        //If we are looking up...
        if (xAxisClamp > 90.0F)
        {
            xAxisClamp = 90.0F;
            mouseY = 0.0f;
            
            //This is a function that will clamp the X Axis Rotation
            //To the provided Value.
            //According to the tutorial, looking up means the camera is at a 270 degree angle rotation.
            ClampXAxisRotationToValue(270.0f);
        }
        
        //If we are looking down..
        else if (xAxisClamp < -90.0F)
        {
            xAxisClamp = -90.0F;
            mouseY = 0.0f;
            //Ditto to the explanation of this method.
            ClampXAxisRotationToValue(90.0f);
        }

        //This is the code that actually rotates the camera.
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
