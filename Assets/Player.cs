using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("ms^-1")][SerializeField] float xSpeed = 20f;
    [Tooltip("ms^-1")] [SerializeField] float ySpeed = 20f;

    [Tooltip("m")] [SerializeField] float xRange = 8f;
    [Tooltip("m")] [SerializeField] float yMinRange = -6f;
    [Tooltip("m")] [SerializeField] float yMaxRange = 7f;

    [SerializeField] float positionPitchFactor = 1.5f;
    [SerializeField] float controlPitchFactor = -2f;

    [SerializeField] float positionYawFactor = 3f;

    [SerializeField] float controlRollFactor = -25f;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
    }

    private void ProcessMovement()
    {
        //x movement
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffSet = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffSet;
        float xPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);

        //y movement
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffSet = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffSet;
        float yPos = Mathf.Clamp(rawYPos, yMinRange, yMaxRange);
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToContolThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToContolThrow;    //x rotation called pitch

        float yaw = transform.localPosition.x * positionYawFactor;    //y rotation called yaw

        float roll = xThrow * controlRollFactor;    //z rotation called roll
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
