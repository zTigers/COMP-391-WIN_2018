﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	// Use this for initialization
public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
