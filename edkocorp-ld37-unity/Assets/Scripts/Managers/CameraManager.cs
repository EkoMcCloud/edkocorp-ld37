using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    //TODO rajouter public GameObject target et virer l'accès direct à player + remplacer followPlayer par followTarget
    public bool followPlayer = true;

    public static CameraManager instance;

	// Use this for initialization
	private void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	private void LateUpdate () {

        if(followPlayer)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                //TODO rajouter move "smooth" pour deplacement lissé
                Vector2 playerPosition = player.transform.position;
                transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
            }
        }
	}
}
