using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const string PLAYER_SPAWN_TAG = "Spawn Point";
    public const string MAIN_CAMERA = "MainCamera";

    public GameOverScreen GameOverScreen;

    //This is a enum to represent the scenes in the game
    //NOTE: the enum values must appear in the same order as
    //there corresponding scenes appear in the build setting 
    //windows. If this order is maintained, then the default 
    //int values for enum (0, 1, 2, ...) for each scene be 
    //the same as the build index for the corresponding scene
    //To recove this build index simple cast the emun into
    //an int
    private enum scenes
    {
        MAIN_MENU_SCENE,
        GAME_SCENE
    };
    scenes currentScene; //A variable to keep track of the current loaded scene


    [SerializeField] private Player playerPrefab;

    //Camera set up
    [SerializeField] private Vector3 cameraPositionInPlayerSpace;
    [SerializeField] private Quaternion cameraRotationInPlayerSpace;

    //GameManager is a singleton
    public GameManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        //set the Instance property so that GameManager is a singleton
        Instance = this;

        //Don't destroy the GameManager when loading a new scene
        //enforces the singleton property
        DontDestroyOnLoad(this);

        //subscribe to scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void StartGame()
    {
        //load game scene
        LoadNewScene(scenes.GAME_SCENE);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //switch on the scenes for scene specific processing
        switch (currentScene)
        {
            case scenes.MAIN_MENU_SCENE : //fill in code here later
                                          break;

            case scenes.GAME_SCENE : //spawn the player
                                     spawnPlayer();
                                     break;

            default : Debug.LogError("Game Manager current scene is invalid");
                      break;
        }
    }

    private void spawnPlayer()
    {
        Debug.Log("Spawning player");
        //instantiate the player
        GameObject spawnPoint = GameObject.FindWithTag(PLAYER_SPAWN_TAG); //find spawn point in scene
        Debug.Log($"Location {spawnPoint.transform.position}");
        if (spawnPoint == null)
        {
            //no spawn point
            Debug.LogError("No player spawn point in current scene. Please make an empty game object to be the spawn point and tag it apporiately.");
            return; //return to avoid null deference
        }
        Player player = Instantiate(playerPrefab, spawnPoint.transform.position, playerPrefab.transform.rotation);

        //Set first person camera
        GameObject camera = GameObject.FindWithTag(MAIN_CAMERA); //get reference to the camera's transform
        camera.transform.SetParent(player.transform); //set the player as the parent so the camera follows them
        //set camera position and rotations in player space
        camera.transform.localPosition = cameraPositionInPlayerSpace;
        camera.transform.localRotation = cameraRotationInPlayerSpace;
        //inform the player about the camera
        player.GetComponent<MovementScript>().SetCameraTransform(camera.transform);
        
    }

    private void LoadNewScene(scenes sceneToLoad)
    {
        //keep track of the current scene
        currentScene = sceneToLoad;

        //Actaully load the new current scene
        SceneManager.LoadScene((int)currentScene);
    }

    private void Start()
    {
        EventManager.Instance.Subscribe(EventTypes.Events.PLAYER_DEATH, death);
    }

    //this is a temp. function to be deleted later
    void death()
    {
        GameOverScreen.SetScreen();
    }


    private void OnDestroy()
    {
        EventManager.Instance.Unsubscribe(EventTypes.Events.PLAYER_DEATH, death);
    }
}
