using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class KeySequenceControl : MonoBehaviour
{
    private bool activated = false;
    public Renderer[] renderers;
    public int[] sequence;
    private int target = -1;
    private Color originalColor;
    public void Start(){
        originalColor = renderers[0].material.GetColor("_Color");
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
        renderers[sequence[target]].materials[0].color = originalColor;
    }
    private void SetTargetColor(){
        renderers[sequence[target]].materials[0].color = Color.blue;
    }
}
