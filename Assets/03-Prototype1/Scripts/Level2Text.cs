using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Text : MonoBehaviour
{
    public Text lvl2Text;
    public BumperMachine bumperMachine;

    void Start()
    {
        lvl2Text = GetComponent<Text>();
        lvl2Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bumperMachine.bumpersLaunched == 10)
        {
            Invoke("textEnable", 3f);
        }
    }

    void textEnable()
    {
        lvl2Text.enabled = true;
        Invoke("textDisable", 4f);
    }

    void textDisable()
    {
        lvl2Text.enabled = false;
    }
}
