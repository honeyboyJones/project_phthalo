using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateReactor : MonoBehaviour
{
    public Switcher switcher;

    protected virtual void Awake()
    {
        switcher.Change += React;
    }

    public virtual void React()
    {
        print(name + "'S STATE IS " + switcher.state);
    }
}
