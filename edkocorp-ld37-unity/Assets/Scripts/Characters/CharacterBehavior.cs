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

    protected void Update()
    {
        if (hp <= 0)
            OnDie();
    }

    protected void OnDie()
    {
        gameObject.SetActive(false);
    }

    protected void Move(int xDir, int yDir)
    {
        //rb2D.transform.position += new Vector3(xDir * speed, yDir * speed);
        rb2D.velocity = new Vector2(xDir * speed, yDir * speed);
    }
	
}
