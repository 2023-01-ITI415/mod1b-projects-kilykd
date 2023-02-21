using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level3Text : MonoBehaviour
{
    public Text lvl3Text;
    public BumperMachine bumperMachine;

    void Start()
    {
        lvl3Text = GetComponent<Text>();
        lvl3Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bumperMachine.bumpersLaunched == 30)
        {
            Invoke("textEnable", 3f);
        }
    }

    void textEnable()
    {
        lvl3Text.enabled = true;
        Invoke("textDisable", 4f);
    }

    void textDisable()
    {
        lvl3Text.enabled = false;
    }
}
