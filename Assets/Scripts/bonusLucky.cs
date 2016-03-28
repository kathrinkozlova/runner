using UnityEngine;
using System.Collections;

public class bonusLucky : MonoBehaviour {

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
            GameObject.Find("Main Camera").GetComponent<levelCreation>().gameSpeed -= 0.5f;
            Debug.Log("Loooooooooooooooow");
           // AudioSource.PlayClipAtPoint(Audio, transform.position);
        }
       
        Destroy(gameObject);
    }
}
