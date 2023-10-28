using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public bool isEntered = false;
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       isEntered = true;
    }
    private void OnTriggerExit(Collider other)
    {
       isEntered= false;
    }
}
