using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public int health=4;
    public bool invencible= false;
    public float invencibilityTime=2f;

    public HeartSystem heartSystem;

    void Start(){
        heartSystem.UpdateHearts(health);
    }

    public void RestarVida(int value){
        if (!invencible && health>0){
            health = health-value;
            heartSystem.UpdateHearts(health);
            StartCoroutine(NoDamage());
        }

        if (health==0){
            Debug.Log("HAS MUERTO");
            Time.timeScale=0;
        }

    }

    IEnumerator NoDamage(){
        invencible=true;
        yield return new WaitForSeconds(invencibilityTime);
        invencible=false;
    }

    public int GetHealth(){
        return health;
    } 
    
}
