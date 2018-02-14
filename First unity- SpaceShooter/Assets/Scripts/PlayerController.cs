using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Boundary class
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour {

    public float speed;
    public float nextFire = 0.25f;
    public Boundary boundary;
    public GameObject Laser;
    public Transform LaserSpawn;
    /*
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;
    */

    //Private Variables
    private Rigidbody2D rBody;
    private float myTime = 0.0f;

    // Use this for initialization
    void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        myTime += Time.deltaTime;

        if(Input.GetButton("Fire1") && myTime > nextFire)
        {
            Instantiate(Laser, LaserSpawn.position, LaserSpawn.rotation);

            myTime = 0.0f;
        }
		
	}
    //used when preforming physics calculations
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Returns value between -1 and 1 whenever left,right, a, d is pushed.
        float moveVertical = Input.GetAxis("Vertical"); // Returns value between -1 and 1 whenever up, down, w, s is pushed.\

        //Debug.Log("H= " + moveHorizontal + "V= " + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Rigidbody2D rBody = this.gameObject.GetComponent<Rigidbody2D>(); // this = whole structure of program. gameObject = menu. GetCompontent<> = specific in menu. This line establish connection of movement to Rigidbody2D
        rBody.velocity = movement * speed;

        //rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, -8.14f, 3.5f), Mathf.Clamp(rBody.position.y, -4.19f, 4.19f));
        //rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, xMin, xMax), Mathf.Clamp(rBody.position.y, yMin, yMax));
        rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax));


    }
}
