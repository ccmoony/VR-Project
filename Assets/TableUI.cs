using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text UIPanel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Interactable Kinematic Torus")
            UIPanel.text = "Student ID: 522030910208";
    }
}
