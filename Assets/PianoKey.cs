using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class PianoKey : PushKey
{
    [SerializeField]
    SongManager songManager;

    [SerializeField]
    public Note note;

    public Renderer renderer;

    // public int key_id;
    public void Start()
    {
        songManager = GetComponentInParent<SongManager>();
        // initialLocalPosition = transform.localPosition;
    }
    public void Push()
    {
        base.Push();
        // controller.Push(key_id);
        // transform.localPosition = initialLocalPosition + new Vector3(0, 0, -pressDistance);

        songManager.PlayNote(this.note);
    }

    public void Release()
    {
        base.Release();
        // transform.localPosition = initialLocalPosition;
    }
}

