using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : CharacterBehavior {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            LookAt(player.transform.position.x, player.transform.position.y);
        }	
	}
}
