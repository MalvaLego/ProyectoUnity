using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenInfo : MonoBehaviour
{
    public TMP_Text healthText;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Vida: " +player.GetComponent<HealthAndDamage>().GetHealth();
    }
}
