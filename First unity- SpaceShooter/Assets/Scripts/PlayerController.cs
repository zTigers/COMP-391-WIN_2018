using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //used when preforming physics calculations
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Returns value between -1 and 1 whenever left,right, a, d is pushed.
        float moveVertical = Input.GetAxis("Vertical"); // Returns value between -1 and 1 whenever up, down, w, s is pushed.\

        //Debug.Log("H= " + moveHorizontal + "V= " + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        Rigidbody2D rBody = this.gameObject.GetComponent<Rigidbody2D>(); // this = whole structure of program. gameObject = menu. GetCompontent<> = specific in menu. This line establish connection of movement to Rigidbody2D
        rBody.velocity = movement * speed;
        
        
    }
}
