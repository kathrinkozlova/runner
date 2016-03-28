using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      
        //anim.SetBool("isRun",true);
        
     /*  if (inputController.isPlayerJump == false)
        {
            anim.SetBool("isRun", true);
            anim.SetBool("isJump", false);
        }
        else 
        { 
            anim.SetBool("isJump", true);
            anim.SetBool("isRun", false);
        } */
    }

    public void jump()
    {
        transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3000);
        anim.SetBool("isRun", false);
        anim.SetBool("isJump", true);
        Debug.Log("juuump");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
         {
             Debug.Log("op");
             anim.SetBool("isJump", false);
             anim.SetBool("isRun", true);
            
         }
        /* else if (col.gameObject.tag != "ground")
         {
             Debug.Log("juuump");
             anim.SetBool("isRun", false);
             anim.SetBool("isJump",true);
         }*/
    }
}
