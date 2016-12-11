using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour {

    public float speed = 1f;
    public int maxHP = 1; //uniquement sur enemie & player ? pnj ?
    public float damageCooldown = 0f; //a mettre uniquement sur player ?

    protected Color bloodColor = new Color(1.0f, 0.0f, 0.0f, 0.3f);

    protected int currentHP;
    protected bool vulnerable = true; //a mettre uniquement sur player ?

    protected BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

	// Use this for initialization
	protected virtual void Start ()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;

        currentHP = maxHP;

    }

    public bool IsAlive()
    {
        return currentHP > 0;
    }

    protected virtual void Update()
    {
        if (!IsAlive())
            OnDie();
    }

    public virtual bool Damage(int damage)
    {
        bool damaged = false;
        if(vulnerable && currentHP > 0)
        {
            currentHP -= damage;
            damaged = true;

            RenderDamage();
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

    protected void RenderDamage()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = bloodColor;
        float time = (damageCooldown != 0.0f) ? damageCooldown : 0.1f;

        Invoke("ResetMaterialColor", time);
    }

    private void ResetMaterialColor()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    protected virtual void OnDie()
    {
        gameObject.SetActive(false);
    }

    protected virtual void LookAt(float xPos, float yPos)
    {

        /*Debug.Log("x: " + xPos);
        Debug.Log("y: " + yPos);

        Debug.Log("pos x: " + transform.position.x);
        Debug.Log("pos y: " + transform.position.y);*/

        /*float angleRad = Mathf.Atan2(yPos - transform.position.y, xPos - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;

        angleDeg += -90;

        this.transform.rotation = Quaternion.Euler(0, 0, angleDeg);*/
    }

    protected void Move(float xDir, float yDir)
    {
        //rb2D.transform.position += new Vector3(xDir * speed, yDir * speed);
        //rb2D.MovePosition(transform.position + direction.normalized * speed * Time.deltaTime);

        Vector3 direction = new Vector3(xDir, yDir);
        if (direction.magnitude > 1)
            direction = direction.normalized; //prevent sliding and normalize max speed

        rb2D.velocity = direction * speed * 60 * Time.deltaTime;
    }
	
}
