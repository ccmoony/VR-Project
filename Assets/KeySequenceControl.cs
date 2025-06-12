using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class KeySequenceControl : MonoBehaviour
{
    private bool activated = false;
    private Dictionary<int, PianoKey> pianoKeys = new  Dictionary<int, PianoKey>();
    public int[] sequence;
    private int target = -1;
    private Color originalColor;
    public void Start(){
        var keys = GetComponentsInChildren<PianoKey>();
        foreach (PianoKey key in keys)
            pianoKeys.Add(key.key_id, key);
        originalColor = pianoKeys[0].renderer.material.GetColor("_Color");
    }
    public void TurnOn(){
        if (activated){
            RevertTargetColor();
            target = -1;
            activated = false;
        }
        else
        {
            activated = true;
            target = 0;
            SetTargetColor();
        }
    }
    public void Push(int i){
        if (activated && i==sequence[target]){
            RevertTargetColor();
            target += 1;
            if(target >= sequence.Length){
                activated = false;
                return;
            }
            SetTargetColor();
        }
    }
    private void RevertTargetColor(){
        pianoKeys[sequence[target]].renderer.materials[0].color = originalColor;
    }
    private void SetTargetColor(){
        pianoKeys[sequence[target]].renderer.materials[0].color = Color.blue;
    }
}
