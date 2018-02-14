using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLaser : MonoBehaviour {
    public float speed;
    private Rigidbody2D rBody;
    public Boundary boundary;



	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
        rBody.velocity = this.transform.right * speed; // Set velocity = (1,0)


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
