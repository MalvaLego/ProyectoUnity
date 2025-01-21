using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public List<Image> hearts;
    // Start is called before the first frame update
    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }
}
