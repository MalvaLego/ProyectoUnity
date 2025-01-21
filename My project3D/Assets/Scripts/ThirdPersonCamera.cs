using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Vector3 offset;
    private Transform target;
    [Range (0,1)] public float lerpValue;
    public float sensibilidad;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        target= GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(1)){
            float mouseX=Input.GetAxis("Mouse X")*sensibilidad;
            offset= Quaternion.AngleAxis(mouseX* sensibilidad,Vector3.up)* offset;
        }
        transform.position= Vector3.Lerp(transform.position, target.position +offset, lerpValue);
        
        
        transform.LookAt(target);
    }
}
