using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Interactable
{
    public Item myItem;
    
    public override void Interact()
    {
        print("ADDING ITEM TO INVENTORY");
        GameManager.instance.itemHeld = myItem;
        GameManager.instance.inventoryDisplay.UpdateDisplay();
    }
}
