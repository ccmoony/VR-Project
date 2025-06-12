using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class PianoKey : PushKey
{
    [SerializeField]
    KeySequenceControl controller;
    
    public Renderer renderer;

    public int key_id;
    public void Start(){
        controller = GetComponentInParent<KeySequenceControl>();
    }
    public void Push(){
        base.Push();
        controller.Push(key_id);
    }

    public void Release(){
        base.Release();
    }
}
