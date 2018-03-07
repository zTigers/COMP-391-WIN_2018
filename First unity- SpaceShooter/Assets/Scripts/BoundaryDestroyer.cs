using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour {
    /*
    // Use this for initialization
    // runs once
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    // runs whenever an object is inside a collider
    // Runs every frame
    private void OnTriggerStay2D(Collider2D other)
    {
        
    }
    */
    // runs whenever an object exits the collider zone.
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
