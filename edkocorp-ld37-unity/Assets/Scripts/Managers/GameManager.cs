using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BoardManager boardManager { get; private set; }

    public static GameManager instance = null;

    // Use this for initialization
    private void Awake ()
    {
        Debug.Log("GameManager - Awake");

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
        boardManager = GetComponent<BoardManager>();
        Init();
    }

    private void Init()
    {
        boardManager.SetupScene();
    }
}
