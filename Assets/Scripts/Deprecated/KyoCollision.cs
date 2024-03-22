using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyoCollision : MonoBehaviour
{
    [SerializeField] private GameObject playerRoot;
    [SerializeField] private GameObject targetRoot;
    // Start is called before the first frame update

    public float Range;
    public event Action OnDetectObject;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        CalculateRange();
    }
    
    void CalculateRange()
    {
              
        var seg2 = Vector3.Normalize(targetRoot.transform.position - playerRoot.transform.position ); //Takes the World Position of the Target Turret (Check if This is possible to be replicated via duplicates)
        var seg1 = playerRoot.transform.position; // Tracks player position in world 
        var dotproduct = seg1.x * seg2.x + seg1.y * seg2.y + seg1.z + seg2.z;
        var referencedotX= seg1.x - seg2.x; // This is responsible for calculating the distance of the two segments.
        var referencedotY = seg1.y - seg2.y;//Debug: fucntion is responsible for checking Y axis Coordinates (WILL BE USED FOR TURRET DIRECTION FEEDBACK SYSTEM)

        Debug.Log($"Dot Product | Product: {dotproduct} / X:{referencedotX} / Y: {referencedotY} | Player Position: {seg1}");


        if(dotproduct >= Range)
        {
            OnDetectObject?.Invoke();
        }


    }

}