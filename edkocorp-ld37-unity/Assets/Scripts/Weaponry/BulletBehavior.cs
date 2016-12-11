using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO rename Projectile
public class BulletBehavior : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    protected GameObject shooter;
    protected Vector2 direction;

    protected static int BUFF = 1;

    //rajouter time to live pour auto destruction ?
    
	// Use this for initialization
	public void Init (GameObject shooter, Vector2 direction)
    {
        this.shooter = shooter;
        this.direction = direction;

        transform.localScale = new Vector2(transform.localScale.x*BUFF, transform.localScale.y*BUFF);
        //transform.rotation = Quaternion.LookRotation(direction);
        float angleRad = Mathf.Atan2(direction.y, direction.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;

        //angleDeg += -90;

        this.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
    }
	
	// Update is called once per frame
	protected void Update ()
    {
        //move toward direction
        //on normalize le vecteur de direction
        Vector2 move = direction.normalized * speed * Time.deltaTime;
        transform.position += new Vector3(move.x, move.y, 0.0f);

        
        //Rotate transform pour direction de balle
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            SelfDestruct();
        }
        else if (collision.tag == "Enemy" || collision.tag == "Player") //pour friendly fire
        {
            //immune owner
            if(shooter == null || collision.gameObject.GetInstanceID() != shooter.GetInstanceID())
            {
                CharacterBehavior character = collision.gameObject.GetComponent<CharacterBehavior>();
                //hpLoss + self destroy
                if (character != null && character.Damage(damage * BUFF))
                    SelfDestruct();
            }
        }
    }

    protected void SelfDestruct()
    {
        //gameObject.SetActive(false); //+self destroy
        Destroy(this.gameObject); 
    }
}
