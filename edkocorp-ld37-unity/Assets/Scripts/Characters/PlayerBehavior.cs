using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : CharacterBehavior {

    public GameObject weapon;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();

        if(IsAlive())
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

            Move(horizontal, vertical);
            LookAt(mousePos.x, mousePos.y);

            if (Input.GetMouseButton(0)) //PRESSED
            {
                Debug.Log("Pressed left.");
                if (weapon != null)
                {
                    WeaponBehavior weaponScript = weapon.GetComponent<WeaponBehavior>();
                    Vector2 position = new Vector2(transform.position.x, transform.position.y);
                    Vector2 direction = mousePos - position;
                    weaponScript.Fire(this.gameObject, direction);
                }
            }

            if (Input.GetMouseButtonDown(1)) //CLICK
                Debug.Log("Clicked right. ROULAAAAAADE");

            /*if (Input.GetMouseButtonDown(2))
                Debug.Log("Clicked middle.");*/
        }
    }
}
