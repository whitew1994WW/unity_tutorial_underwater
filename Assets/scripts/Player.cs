using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms-1")] [SerializeField] float moveScaling = 2;
    [SerializeField] float maxXRange = 5f;
    [SerializeField] float minYRange = -5f;
    [SerializeField] float maxYRange = 5f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlYawFactor = -30f;
    Vector3 moveThrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = positionPitchFactor*transform.localPosition.y + (controlPitchFactor*moveThrow.y);
        float yaw = positionYawFactor*transform.localPosition.x;
        float roll = controlYawFactor * moveThrow.x;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        moveThrow = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),
                                        CrossPlatformInputManager.GetAxis("Vertical"), 0);

        Vector3 moveOffset = Time.deltaTime * moveThrow * moveScaling;

        Vector3 newPos = transform.localPosition + moveOffset;
        newPos.x = Mathf.Clamp(newPos.x, -maxXRange, maxXRange);
        newPos.y = Mathf.Clamp(newPos.y, minYRange, maxYRange);
        transform.localPosition = newPos;
    }
}
