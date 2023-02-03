using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrackingCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;

    //[SerializeField] public Vector3 locationOffset;
    private Vector3 _locationOffset;
    
    public float smoothSpeed = 0.125f;

    private void Awake()
    {
        _locationOffset =  transform.position - target.transform.position;
    }
    
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position + target.transform.rotation * _locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target.transform);


    }
}
