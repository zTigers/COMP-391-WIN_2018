using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Open up unity for UI changes and For audio changes
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseController : MonoBehaviour {

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    private Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
	}
    private void Pause()
    {
        //short version of an if statement.
        text.enabled = !text.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; //ternary statement
        PlayAudio();
        // Longer version if statement of timeScale
        /*if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        } else
        {
            Time.timeScale = 0;
        }*/

    }
    private void PlayAudio()
    {
        if(Time.timeScale == 0)
        {
            paused.TransitionTo(0.01f);
        }else
        {
            unpaused.TransitionTo(0.01f);
        }
    }
}
