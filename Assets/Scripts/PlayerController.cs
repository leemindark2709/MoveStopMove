using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator anim;

    // Start is called before the first frame update
    void Start()
    {   
        anim=gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.instance.isMoving)
        {
            anim.SetFloat("moving", 1);
        }
        else
        {
            anim.SetFloat("moving", 0);
        }
    }
}
