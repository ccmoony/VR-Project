using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class PianoKey2 : PushKey
{
    [SerializeField]
    KeySequenceControl controller;
    
    [SerializeField]
    Note note;
    
    public Renderer renderer;

    public int key_id;
    private Vector3 initialLocalPosition;
    public float pressDistance = 0.01f;
    public void Start(){
        controller = GetComponentInParent<KeySequenceControl>();
        initialLocalPosition = transform.localPosition;
    }
    public void Push(){
        base.Push();
        controller.Push(key_id);
        transform.localPosition = initialLocalPosition + new Vector3(0, 0, -pressDistance);

        SongManager.instance.PlayNote(this.note);
    }

    public void Release(){
        base.Release();
        transform.localPosition = initialLocalPosition;
    }
}

