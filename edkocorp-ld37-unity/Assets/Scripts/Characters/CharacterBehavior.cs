using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour {

    public float speed = 1f;
    public int maxHP = 1; //uniquement sur enemie & player ? pnj ?
    public float damageCooldown = 0f; //a mettre uniquement sur player ?

    protected int currentHP;
    protected bool vulnerable = true; //a mettre uniquement sur player ?

    protected BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

	// Use this for initialization
	protected virtual void Start ()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        currentHP = maxHP;

    }

    protected virtual void Update()
    {
        if (currentHP <= 0)
            OnDie();
    }

    public bool Damage(int damage)
    {
        bool damaged = false;
        if(vulnerable && currentHP > 0)
        {
            currentHP -= damage;
            damaged = true;
        }

        return damaged;
    }

    public bool Heal(int heal)
    {
        bool healed = false;
        if(currentHP < maxHP)
        {
            if(currentHP + heal > maxHP)
                currentHP = maxHP;
            else
                maxHP += heal;

            healed = true;
        }

        return healed;
    }

    protected void OnDie()
    {
        gameObject.SetActive(false);
    }

    protected void LookAt(float xPos, float yPos)
    {

        /*Debug.Log("x: " + xPos);
        Debug.Log("y: " + yPos);

        Debug.Log("pos x: " + transform.position.x);
        Debug.Log("pos y: " + transform.position.y);*/

        float angleRad = Mathf.Atan2(yPos - transform.position.y, xPos - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;

        angleDeg += -90;

        this.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
    }

    protected void Move(int xDir, int yDir)
    {
        //rb2D.transform.position += new Vector3(xDir * speed, yDir * speed);
        rb2D.velocity = new Vector2(xDir * speed, yDir * speed);
    }
	
}
