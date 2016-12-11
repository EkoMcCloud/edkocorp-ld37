using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemies;
    public float minDelay = 5f;
    public float maxDelay = 10f;
    //TODO Rajouter quantité max de mob, decrementer iterateur a chaque pop jusqu'a 0 puis autodestruction

    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        InvokeNextSpawn();
	}

    protected void InvokeNextSpawn()
    {
        float delay = Random.Range(minDelay, maxDelay);
        Invoke("Spawn", delay);
    }

    protected void Spawn()
    {
        GameObject toInstantiate = RandomEnemy();
        GameObject instance = Instantiate(toInstantiate, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;

        instance.transform.SetParent(GameManager.instance.boardManager.boardHolder);
        animator.SetTrigger("Pop");
        InvokeNextSpawn();
    }

    protected GameObject RandomEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }
}
