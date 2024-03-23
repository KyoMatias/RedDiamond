using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCinematic : MonoBehaviour
{
    [SerializeField] private GameObject modelkey;
    public void InsertKey()
    {
        modelkey.SetActive(true);
    }
}
