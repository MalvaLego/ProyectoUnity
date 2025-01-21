using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollect : MonoBehaviour
{
    public float rotationSpeed=2f;

	public AudioClip collectSound;

	public GameObject collectEffect;
    // Start is called before the first frame update
    void Update () {
		transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			 if(collectSound)
			    AudioSource.PlayClipAtPoint(collectSound, transform.position);
		    if(collectEffect)
			    Instantiate(collectEffect, transform.position, Quaternion.identity);

            other.GetComponent<Collectables>().GetGem();
            Destroy (gameObject);  
		}
	}

    
}
