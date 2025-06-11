using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class PushKey : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    [SerializeField]
    KeySequenceControl controller;
    
    public int key_id;
    public void Push(){
        animator.SetInteger("Push",1);
        controller.Push(key_id);
    }

    public void Release(){
        animator.SetInteger("Push",0);
    }
}
