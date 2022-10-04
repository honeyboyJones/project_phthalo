using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    TMP_Text displayText;

    void Start()
    {
        displayText = GetComponent<TMP_Text>();
        //displayText.text = "Item Held: none";
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        string displayName = "NONE";

        if (GameManager.instance.itemHeld.itemName != "")
        {
            displayName = GameManager.instance.itemHeld.itemName;
        }
        // else
        // {
        //     displayName = "NONE";
        // }
        displayText.text = "ITEM HELD: " + displayName;
    }
}
