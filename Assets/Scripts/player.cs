using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

   public static bool isJump;
    
    private Animator anim;
    static public int money;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
      }

    public void jump()
    {
        transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3350);
        anim.SetBool("isRun", false);
        anim.SetBool("isJump", true);
        isJump = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
         {
             isJump = false;
             anim.SetBool("isJump", false);
             anim.SetBool("isRun", true);
            
         }
    }

}
