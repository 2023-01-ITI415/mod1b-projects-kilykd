using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BumperCounter : MonoBehaviour
{
    public int bumpersLeft = 0;
    public Text remaniningBumpers; 
    void Start()
    {
        remaniningBumpers = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        remaniningBumpers.text = bumpersLeft.ToString();
    }
}
