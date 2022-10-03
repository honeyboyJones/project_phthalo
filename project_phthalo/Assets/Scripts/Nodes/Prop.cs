using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Node
{
    public Location location;
    Interactable interactable;

    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    public override void Arrive()
    {
        if (interactable != null && interactable.enabled)
        {
            interactable.Interact();
            return;
        }
        
        base.Arrive();
        
        //make this object interactable, if prerequisite is met
        if (interactable != null)
        {
            if (GetComponent<Prerequisite>() && !GetComponent<Prerequisite>().Complete)
            {
                return;
            }
            collider.enabled = true;
            interactable.enabled = true;
        }
    }

    public override void Leave()
    {
        base.Leave();

        if (interactable != null)
        {
            interactable.enabled = false;
        }
    }
}
