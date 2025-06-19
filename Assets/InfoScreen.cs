using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tmp;
    string defaultText = " ";
    Color defaultColor = Color.black;
    public void ErrorMsg()
    {
        StartCoroutine(Error_());
    }
    private IEnumerator Error_()
    {

        tmp.text = "Error";
        tmp.color = Color.red;
        yield return new WaitForSecondsRealtime(0.5f);
        tmp.text = defaultText;
        tmp.color = defaultColor;
    }
    public void CompleteMsg()
    {
        tmp.text = "Finish";
        tmp.color = Color.green;
    }
    public void SongMsg(string song)
    {
        tmp.text = "Now Playing:\n" + song;
        tmp.color = Color.black;
        defaultText = tmp.text;
        defaultColor = tmp.color;
    }
}
