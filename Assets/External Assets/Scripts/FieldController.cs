using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Quelle: Knut Hartmann Labor Spieleprogrammierung

public class FieldController : MonoBehaviour {

    private Text textComp;

    // SetValue is called in the Start-Method of the GameController.
    // The order of execution of the Start methods of game objects is unknown.
    // The Awake method is called before the Start methods of all game objects.
    void Awake()
    {
        // the handle to the Component 'Text' must be initialized 
        // before the Star-Method of the GameController
        textComp = GetComponent<Text>();
    }

    // there should be more setter functions for various data types

    public void SetValue(int value)
    {
        textComp.text = value.ToString();
    }
    public void SetTime(float value)
    {
        textComp.text = value.ToString();
    }
}
