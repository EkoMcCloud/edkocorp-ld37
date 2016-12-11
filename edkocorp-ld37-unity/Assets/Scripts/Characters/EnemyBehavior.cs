using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : CharacterBehavior {

    public int damage = 1;

	// Use this for initialization
	protected override void Start ()
    {
        bloodColor = new Color(0.0f, 0.0f, 0.0f, 0.3f);
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();

        if (IsAlive())
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 move = new Vector3();

            if (player != null)
            {
                move = player.transform.position - transform.position;
                LookAt(player.transform.position.x, player.transform.position.y);
            }

            Move(move.x, move.y);
        }
        else Move(0, 0); //empecher slide (a faire autrement)
	}

    protected override void OnDie()
    {
        //TODO utiliser getter pour recup temps d'anim
        float time = (damageCooldown != 0.0f) ? damageCooldown : 0.1f;

        Invoke("ProcessDie", time);
        //prevent + StartCoroutine("FadeOut") then Destroy;
    }

    protected void ProcessDie()
    {
        base.OnDie();
    }

    /*protected IEnumerator FadeOut()
    {
        //timer
        float progress = 0;
        float increment = smoothness / duration;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        while (progress < 1)
        {
            //lerp colour
            renderer.color = Color.Lerp(A, B, progress);
            //move time forward
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }

        yield return true;
    }*/

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //TODO ADD DAMAGE ON TRIGGER STAY sinon immune
        {
            PlayerBehavior player = collision.gameObject.GetComponent<PlayerBehavior>();
            //hpLoss
            if (player != null)
                player.Damage(damage);
        }
    }
}
