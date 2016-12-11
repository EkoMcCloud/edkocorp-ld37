using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject target;
    public bool followTarget = true;

    private float dampTime = 0.3f; //offset from the viewport center to fix damping
    private Vector3 velocity = Vector3.zero;

    public static CameraManager instance;

	// Use this for initialization
	private void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        followTarget = true;
    }
	
	// Update is called once per frame
	private void LateUpdate ()
    {
        if (target != null && followTarget)
        {
            //Vector2 targetPosition = target.transform.position;
            //transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);

            //rajouter move "smooth" pour deplacement lissé
            Vector3 point  = Camera.main.WorldToViewportPoint(target.transform.position);
            Vector3 delta  = target.transform.position -
                            Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination  = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	}
}
