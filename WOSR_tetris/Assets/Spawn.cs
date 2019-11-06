using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<ElementPositioning> elements;

    public void OnReset()
    {
        foreach(ElementPositioning element in elements)
        {
            element.ResetPosition();
        }
    }

}
