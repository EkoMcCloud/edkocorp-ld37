using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : CharacterBehavior {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {

        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Move(horizontal, vertical);
        }
    }
}
