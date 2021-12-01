using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float interpolationSpeed;

    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, playerTransform.position.x, interpolationSpeed * Time.deltaTime), 
        Mathf.Lerp(transform.position.y, playerTransform.position.y, interpolationSpeed * Time.deltaTime), 
        transform.position.z);
    }
}
