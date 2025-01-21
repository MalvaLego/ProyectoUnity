using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    public float healthEnemy=100;
    public Image healthBar;
    

    public void RestarVida(int value){
        if (healthEnemy>0){
            healthEnemy = healthEnemy-value;
        }

        if (healthEnemy==0){
            Debug.Log("HAS GANADO");
            Time.timeScale=0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        healthEnemy= Mathf.Clamp(healthEnemy,0,100);
        healthBar.fillAmount=healthEnemy/100;
    }
}
