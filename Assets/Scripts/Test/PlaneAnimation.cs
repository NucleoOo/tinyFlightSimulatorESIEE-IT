using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAnimation : MonoBehaviour {

    public Transform propeller;
    public float propSpeed = 100;

    public float smoothTime = .5f;
    [Header ("Aileron (Roll)")]
    public Transform aileronLeft;
    public Transform aileronRight;
    public Transform aileronLeft1StP;
    public Transform aileronRight1StP;
    public float aileronMax = 20;
    [Header ("Elevator (Pitch)")]
    public Transform elevator;
    public Transform elevatorLeft1StP;
    public Transform elevatorRight1StP;
    public float elevatorMax = 20;
    [Header ("Rudder (Yaw)")]
    public Transform rudder;
    public Transform rudder1stP;
    public float rudderMax = 20;

    // Smoothing vars
    float smoothedRoll;
    float smoothRollV;
    float smoothedPitch;
    float smoothPitchV;
    float smoothedYaw;
    float smoothYawV;

    MFlight.Demo.Plane plane;

    void Start () {
        plane = GetComponent<MFlight.Demo.Plane> ();
    }

    void Update () {
        // https://en.wikipedia.org/wiki/Aircraft_principal_axes
        propeller.Rotate (Vector3.forward * (propSpeed * Time.deltaTime));

        // Roll
        float targetRoll = plane.Roll;
        smoothedRoll = Mathf.SmoothDamp (smoothedRoll, targetRoll, ref smoothRollV, Time.deltaTime * smoothTime);
        aileronLeft.localEulerAngles = new Vector3 (-smoothedRoll * aileronMax, aileronLeft.localEulerAngles.y, aileronLeft.localEulerAngles.z);
        aileronLeft1StP.localEulerAngles = new Vector3 (-smoothedRoll * aileronMax, aileronLeft1StP.localEulerAngles.y, aileronLeft1StP.localEulerAngles.z);
        aileronRight.localEulerAngles = new Vector3 (smoothedRoll * aileronMax, aileronRight.localEulerAngles.y, aileronRight.localEulerAngles.z);
        aileronRight1StP.localEulerAngles = new Vector3 (smoothedRoll * aileronMax, aileronRight1StP.localEulerAngles.y, aileronRight1StP.localEulerAngles.z);

        // Pitch
        float targetPitch = plane.Pitch;
        smoothedPitch = Mathf.SmoothDamp (smoothedPitch, targetPitch, ref smoothPitchV, Time.deltaTime * smoothTime);
        elevator.localEulerAngles = new Vector3 (-smoothedPitch * elevatorMax, elevator.localEulerAngles.y, elevator.localEulerAngles.z);
        elevatorLeft1StP.localEulerAngles = new Vector3 (-smoothedPitch * elevatorMax, elevator.localEulerAngles.y, elevator.localEulerAngles.z);
        elevatorRight1StP.localEulerAngles = new Vector3 (-smoothedPitch * elevatorMax, elevator.localEulerAngles.y, elevator.localEulerAngles.z);

        // Yaw
        float targetYaw = plane.Yaw;
        smoothedYaw = Mathf.SmoothDamp (smoothedYaw, targetYaw, ref smoothYawV, Time.deltaTime * smoothTime);
        rudder.localEulerAngles = new Vector3 (rudder.localEulerAngles.x, -smoothedYaw * rudderMax, rudder.localEulerAngles.z);
        rudder1stP.localEulerAngles = new Vector3 (rudder.localEulerAngles.x, -smoothedYaw * rudderMax, rudder.localEulerAngles.z);
    }
}