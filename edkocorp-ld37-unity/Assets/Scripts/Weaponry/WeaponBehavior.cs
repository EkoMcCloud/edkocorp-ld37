using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour {

    public float cooldownDelay = 0.3f;
    protected bool cooldownRunning = false;
    public GameObject bullet;

    //opt
    //- ammoPerLoader:int = -1;
    //- reloadDelay:int = 0;
    //super opt
    //- magazineCurrent:int => sur perso ?
    //- magazineMax:int => sur perso ?

    public void Fire(GameObject shooter, Vector2 direction)
    {
        if(!cooldownRunning)
        {
            Vector2 startingPos = new Vector2(shooter.transform.position.x, shooter.transform.position.y);
            GameObject shot = Instantiate(bullet, startingPos, Quaternion.identity) as GameObject;
            
            //create GameObject bullet and throw lol
            BulletBehavior behavior = shot.GetComponent<BulletBehavior>();
            behavior.Init(shooter, direction); //pass startingPos pour affiner le depart ?
            shot.transform.SetParent(shooter.transform.parent);
            
            startCooldown();
        }
    }

    protected void startCooldown()
    {
        cooldownRunning = true;
        Invoke("ResetCooldown", cooldownDelay);
    }

    protected void ResetCooldown()
    {
        cooldownRunning = false;
    }
}
