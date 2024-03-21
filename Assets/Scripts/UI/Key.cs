using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
[SerializeField] private GameObject Prompt;

[Header("Key")]
[SerializeField] private GameObject SA_Message; 



public event Action<bool> ShowPrompt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
