using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard; // what are we spawning
    public Vector2 spawnValue; // where do we spawn Hazards
    public int hazardCount; // how many hazards per wave
    public float startWait; // how long until hazard wave starts
    public float spawnWait; // how long between each hazard in each wave
    public float waveWait; // how long between each wave of enemies

    private bool gameOver;
    private bool restart;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;

        StartCoroutine(SpawnWaves());
    }
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); // pause Wait time before game first wave
        while(true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y,spawnValue.y));
                //                                      12                         -3.5          3.5

                Quaternion spawnRotation = Quaternion.identity; // default rotation
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); //Wait time between spawning each asteroid
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        // score = score + newScoreValue
        Debug.Log("Score is " + score);
    }

    public void GameOver()
    {
        Debug.Log("Game is Over");
        gameOver = true;
    }
}
