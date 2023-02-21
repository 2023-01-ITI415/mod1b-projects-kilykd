using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    public Text winText;
    

    void Start()
    {
        winText = GetComponent<Text>();
        winText.enabled = false;
    }
}
