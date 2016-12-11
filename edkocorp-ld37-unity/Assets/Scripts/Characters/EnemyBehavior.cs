using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : CharacterBehavior {

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            int horizontal = player.transform.position.x > transform.position.x ? 1 : -1;
            int vertical = player.transform.position.y > transform.position.y ? 1 : -1;

            Move(horizontal, vertical);
            LookAt(player.transform.position.x, player.transform.position.y);
        }
	}
}
