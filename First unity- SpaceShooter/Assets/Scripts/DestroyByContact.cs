using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosionAsteroid;
    public GameObject PlayerExplosion;

    private GameController gameControllerScript;
    public int scoreValue = 10;

	// Use this for initialization
	void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if(gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerScript == null)
        {
            Debug.Log("Cannot find game controller script on object");
        }
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boundary")
        {
            return;
            //Debug.Log("DestroyByContact");
        }
        if (other.tag == "Player")
        {
            Vector3 deltaP = (this.transform.position + other.transform.position) / 2; // finds half way point between two objects

            // Create our explosion animation
            Instantiate(PlayerExplosion, deltaP, other.transform.rotation);

            //GameOver!
            gameControllerScript.GameOver();
        }
        else
        {
            Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);
            gameControllerScript.AddScore(scoreValue);
        }


        Destroy(other.gameObject); // destroy other game object
        Destroy(this.gameObject); // Destroying thus thing (the asteroid 
	}
}
