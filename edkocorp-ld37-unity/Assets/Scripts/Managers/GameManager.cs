using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public BoardManager boardManager { get; private set; }

    public static GameManager instance = null;

    //TODO changer la gestion du loading pour etre sur tout s'initialise bien (tester boardHolder ou autre avant chargement niveau)

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
        //Init();
    }

    private void Init()
    {
        boardManager.SetupScene();
    }

    public void OnLevelClear()
    {
        SceneManager.LoadScene(0);
    }

    
    //This is called each time a scene is loaded.
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("GameManager - OnLevelFinishedLoading");
        //Setup a new board
        boardManager.SetupScene();
    }

    void OnEnable()
    {
        //Tell our ‘OnLevelFinishedLoading’ function to start listening for a scene change event as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our ‘OnLevelFinishedLoading’ function to stop listening for a scene change event as soon as this script is disabled. 
        //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
}
