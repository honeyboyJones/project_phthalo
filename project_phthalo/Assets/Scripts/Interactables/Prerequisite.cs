using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerequisite : MonoBehaviour
{
    //if true, check for item instead
    //better as an enum that has a switcher option and an item option
    public bool requireItem;
    //if requireItem is true, check this collector
    public Collector checkCollector;
    //watch this switcher
    public Switcher watchSwitcher;
    //if true, then block access to this altogether
    public bool nodeAccess;

    public bool Complete
    {
        get
        {
            if (!requireItem)
            {
                return watchSwitcher.state;
            }
            else
            {
                return GameManager.instance.itemHeld.itemName == checkCollector.myItem.itemName;
            }
        }
        //more robust version:
        //get{return watchSwitcher.state == watchSwitcher.stateWanted}
    }
}
