using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peak : MonoBehaviour
{
    [SerializeField] private GameObject mainHUD;

    private bool isPeaking;
    private Animator ObjMain;
    
    private void Awake() {
        isPeaking = false;
        ObjMain = GetComponent<Animator>();
    }



}
