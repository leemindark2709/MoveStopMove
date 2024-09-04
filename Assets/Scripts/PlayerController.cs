using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator anim;

    // Start is called before the first frame update
    void Start()
    {   
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.instance.isMoving)
        {

            //anim.SetFloat("attack", 0);
            if (anim.GetFloat("attack") == 1)
            {
                anim.SetFloat("attack", 0);
            }
            if (anim.GetFloat("attackMoving") == 1)
            {
                anim.SetFloat("attackMoving", 0.1f);
            }

            anim.SetFloat("moving", 1);
            //anim.SetFloat("attackMoving", 1);

        }
        else
        {
            //anim.SetFloat("attack", 0);
            anim.SetFloat("moving", 0);
        }
    }
}
