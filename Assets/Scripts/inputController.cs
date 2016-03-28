using UnityEngine;
using System.Collections;

public class inputController : MonoBehaviour
{

   
    public player _player;
    public static bool isPlayerJump;
    private bool isMobail = true;
   


    // Use this for initialization
    void Start() {
        if (Application.isEditor)
            isMobail = false;
        _player = GameObject.Find("Player").GetComponent<player>();
 
	}

    // Update is called once per frame
    void Update()
    {

        if (isMobail)
        {
            int tmpC = Input.touchCount;
            tmpC--;

            if (Input.GetTouch(tmpC).phase == TouchPhase.Began)
            {
                handleInteraction(true);
            }
            if (Input.GetTouch(tmpC).phase == TouchPhase.Ended)
            {
                handleInteraction(false);
            }
        }
        else

                           if ((player.isJump == false) & (Input.GetKeyDown(KeyCode.Space)))
                {
                    handleInteraction(true);

                }

                else
                {
                    handleInteraction(false);

                }
            }

        

    void handleInteraction(bool starting)
    {
        if (starting)
        {
            _player.jump();
        }
    }
}
