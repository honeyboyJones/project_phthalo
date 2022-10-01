using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Prop))]
public abstract class Interactable : MonoBehaviour
{
    //called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    public virtual void Interact()
    {
        print("INTERACTING WITH " + name);
    }
}
