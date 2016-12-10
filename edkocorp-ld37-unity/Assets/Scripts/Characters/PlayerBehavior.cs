using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : CharacterBehavior {

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();

        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);

        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left click.");

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right click.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        LookAt(mousePos.x, mousePos.y);
    }
}
