using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidbody : MonoBehaviour
{
    public float pushPower=2.0f;
    private float targetMass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        Rigidbody body= hit.collider.attachedRigidbody;

        if (body==null || body.isKinematic){// si no choca nada o está asociado ese objeto para que se ignore
            return;
        }

        if (hit.moveDirection.y < -0.3){// si está arriba del objeto
            return;
        }

        targetMass=body.mass;
        Vector3 pushDir= new Vector3(hit.moveDirection.x,0,hit.moveDirection.z);

        body.velocity= pushDir*pushPower/targetMass;
    }

}
