using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

    public float speed = 1f;

	// Use this for initialization
	protected void Start ()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
	}

    protected void Move(int xDir, int yDir)
    {
        Debug.Log("@@" + rb2D.ToString());
        rb2D.transform.position += new Vector3(xDir * speed, yDir * speed);
    }
	
}
