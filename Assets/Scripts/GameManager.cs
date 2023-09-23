using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject easyEnemyPrefab;
    public GameObject hardEnemyPrefab;
    public static GameManager instance;
    public GameObject player;
    public int playerLives;
    public int enemyLives;
    public GameObject enemy;
    public List<Controller> players;
    public List<Controller> enemies;
    public Transform playerSpawn;
    public Transform enemySpawn;
    public Transform centerPoint;
    public bool hardModeActive;
    public GameObject titleObject;
    public GameObject mainMenuObject;
    public GameObject controlsObject;
    public GameObject optionsObject;
    public GameObject gameplayObject;
    public GameObject gameOverObject;
    public TextMeshProUGUI gameOverText;
    public AudioMixer mixer;
    public AudioSource sfxSource;
    private void Awake()
    {
        if (instance == null)//prevents more than one game manager from existing at once
        {   
            instance = this;
        }
        else
        {   
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject); 
    }

    private void Start()
    {
        DeactivateAllStates();
        ActivateTitleState();
    }
    public void SpawnPlayer()
    {
        GameObject newPawnObj = Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
        player = newPawnObj;
    }

    public void SpawnEasyEnemy()
    {
        GameObject newPawnObj = Instantiate(easyEnemyPrefab, enemySpawn.position, enemySpawn.rotation);
        enemy = newPawnObj;
    }

    public void SpawnHardEnemy()
    {
        GameObject newPawnObj = Instantiate(hardEnemyPrefab, enemySpawn.position, enemySpawn.rotation);
        enemy = newPawnObj;
    }

    public void SpawnEnemy() //determines what enemy to spawn
    {
        if (hardModeActive == true)
        {
            SpawnHardEnemy();
        }
        else
        {
            SpawnEasyEnemy();
        }
    }

    public void DeactivateAllStates()
    {
        if (titleObject != null)
        {
            titleObject.SetActive(false);
        }
        if (mainMenuObject != null)
        {
            mainMenuObject.SetActive(false);
        }
        if (optionsObject != null)
        {
            optionsObject.SetActive(false);
        }
        if (controlsObject != null)
        {
            controlsObject.SetActive(false);
        }
        if (gameplayObject != null)
        {
            gameplayObject.SetActive(false);
        }
        if (gameOverObject != null)
        {
            gameOverObject.SetActive(false);
        }
    }
    public void ActivateTitleState()
    {
        DeactivateAllStates();
        titleObject.SetActive(true);
    }

    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        mainMenuObject.SetActive(true);
    }

    public void ActivateOptionsState()
    {
        DeactivateAllStates();
        optionsObject.SetActive(true);
    }

    public void ActivateControlsState()
    {
        DeactivateAllStates();
        controlsObject.SetActive(true);
    }

    public void ActivateGameplayState()
    {
        DeactivateAllStates();
        gameplayObject.SetActive(true);
        SpawnPlayer();
        SpawnEnemy();
    }

    public void ActivateGameOverState(bool victory) 
    {
        DeactivateAllStates();
        if (player != null) //destroys unnecessary pawns
        {
            Destroy(player);
        }
        if (enemy != null)
        {
            Destroy(enemy);
        }
        gameOverObject.SetActive(true);
        if (victory == true)
        {
            gameOverText.text = "You win!";
        }
        else
        {
            gameOverText.text = "You lost...";
        }

    }

    public void TryGameOver() //checks whether either player object is null and awards victory accordingly
    {
        if (player == null)
        {
            ActivateGameOverState(false);
        }
        else if (enemy == null)
        {
            ActivateGameOverState(true);
        }
        else
        {
            Debug.Log("No Game Over!");
        }
    }
}
