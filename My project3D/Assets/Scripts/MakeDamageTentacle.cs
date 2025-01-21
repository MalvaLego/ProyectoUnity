using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageTentacle : MonoBehaviour
{
    public int value=1;

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player"){
            other.GetComponent<HealthAndDamage>().RestarVida(value);
        }    
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag=="Player"){
            other.GetComponent<HealthAndDamage>().RestarVida(value);
        }    
    }

    
}
