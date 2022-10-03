using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorReactor : StateReactor
{
    public Color active;
    public Color inactive;

    MeshRenderer mesh;

    protected override void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        base.Awake();
        React();
    }

    public override void React()
    {
        //if switcher = true
        if (switcher.state)
        {
            mesh.material.color = active;
        }
        else
        {
            mesh.material.color = inactive;
        }
    }
}
