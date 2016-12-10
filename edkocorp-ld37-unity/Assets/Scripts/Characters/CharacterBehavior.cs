using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour {

    public float speed = 1f;
    public int hp = 1;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

	// Use this for initialization
	protected virtual void Start ()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
	}

    protected virtual void Update()
    {
        if (hp <= 0)
            OnDie();
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
