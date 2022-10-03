using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : Interactable
{
    public bool state;
    
    //event setup
    //delegate is a variable that takes a function, defines what the function is going to be
    //i.e. defines what the bool is going to be
    public delegate void OnStateChange();
    public event OnStateChange Change;

    public override void Interact()
    {
        state = !state;
        if (Change != null)
        {
            Change();
        }
    }
}
