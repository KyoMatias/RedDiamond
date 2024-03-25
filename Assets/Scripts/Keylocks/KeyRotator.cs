using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotator : MonoBehaviour
{
    
    public void RotateRight()
    {
        this.gameObject.transform.Rotate(0,90,0);
        Debug.Log("Rotating Key");
    }

    public virtual void RotateR()
    {
        this.gameObject.transform.Rotate(0,90,0);
        Debug.Log("Rotating Virtual Key");
    }

    public virtual void RotateL()
    {
        this.gameObject.transform.Rotate(0,-90,0);
    }
}
