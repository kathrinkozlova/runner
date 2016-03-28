using UnityEngine;
using System.Collections;

public class enemyOne : MonoBehaviour {

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
            GameObject _player = GameObject.Find("Player");
            Application.LoadLevel("Game over");

        }
        
    }
}
