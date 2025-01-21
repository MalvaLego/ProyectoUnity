using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int Gems=0;
    // Start is called before the first frame update
    public void GetGem(){
        Gems += 1;
    }


}
