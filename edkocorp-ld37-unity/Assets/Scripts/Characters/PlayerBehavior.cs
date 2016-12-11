using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : CharacterBehavior {

    public GameObject weapon;

    private Animator animator;

	// Use this for initialization
	protected override void Start ()
    {
        animator = GetComponent<Animator>();

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
            
            if (weapon != null)
            {
                WeaponBehavior weaponScript = weapon.GetComponent<WeaponBehavior>();
                //TODO ajouter controls manager pour switch clavier/sourie (lastInput = clavier OU stick)
                Vector2 position = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction;
                if (Input.GetMouseButton(0)) //PRESSED
                {
                    //Debug.Log("Pressed left.");
                    direction = mousePos - position;
                    weaponScript.Fire(this.gameObject, direction);
                }
                else
                {
                    direction = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));
                    if(direction.magnitude > 0)
                        weaponScript.Fire(this.gameObject, direction);
                }
            }            

            if (Input.GetMouseButtonDown(1)) //CLICK
                Debug.Log("Clicked right. ROULAAAAAADE");

            /*if (Input.GetMouseButtonDown(2))
                Debug.Log("Clicked middle.");*/
        }
    }

    protected override void LookAt(float xPos, float yPos)
    {
        //base.LookAt(xPos, yPos);
        Vector3 direction = new Vector3(xPos, yPos) - transform.position;
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x >= 0)
            {
                //LookAt right
                animator.SetBool("LookUp", false);
                animator.SetBool("LookLeft", false);
                animator.SetBool("LookRight", true);
            }
            else
            {
                //LookAt left
                animator.SetBool("LookUp", false);
                animator.SetBool("LookLeft", true);
                animator.SetBool("LookRight", false);
            }
        }
        else
        {
            if (direction.y >= 0)
            {
                //LookAt top
                animator.SetBool("LookUp", true);
                animator.SetBool("LookLeft", false);
                animator.SetBool("LookRight", false);
            }
            else
            {
                //LookAt bottom
                animator.SetBool("LookUp", false);
                animator.SetBool("LookLeft", false);
                animator.SetBool("LookRight", false);
            }
        }
    }
}
