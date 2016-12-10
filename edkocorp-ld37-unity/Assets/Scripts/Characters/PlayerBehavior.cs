using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : CharacterBehavior {

	// Use this for initialization
	protected void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	private void Update () {

        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
    }
}
