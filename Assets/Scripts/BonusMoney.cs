using UnityEngine;
using System.Collections;

public class BonusMoney : MonoBehaviour {

    private AudioClip Audio;


	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.money += 50;
            Debug.Log("babloooooooo");
           // AudioSource.PlayClipAtPoint(Audio, transform.position);
        }
        
        Destroy(gameObject);
    }
}
