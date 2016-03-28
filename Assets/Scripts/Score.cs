using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text resultsTxt;
    public Text moneyTxt;
	// Use this for initialization
	void Start () {


        resultsTxt.text = "Score: " + levelCreation.score.ToString(); 
        moneyTxt.text = "Money: " + player.money.ToString();
	}
	
	// Update is called once per frame
	void Update () {
       
        
        
	}
}
