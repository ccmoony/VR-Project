using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class PushKey : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    public void Push(){
        animator.SetInteger("Push",1);
    }

    public void Release(){
        animator.SetInteger("Push",0);
    }
}
