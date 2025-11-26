using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DoofusController player;
    public ConfigLoader configLoader;
    public GameObject pulpitPrefab;
    public UIManager uiManager;

    public bool isPlaying = false; 
    public int Score = 0;
    private List<Pulpit> activePulpits = new List<Pulpit>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isPlaying = false;
        StartCoroutine(LoadAndSetup());
    }

    IEnumerator LoadAndSetup()
    {
        yield return configLoader.LoadConfig();
        if(uiManager != null) uiManager.ShowStartMenu();
    }

    public void StartGame()
    {
        Score = 0;
        if(uiManager != null) 
        {
            uiManager.ShowHUD();
            uiManager.UpdateScoreUI(Score);
        }

        SpawnPulpitAt(Vector3.zero);
        
        if(player != null) player.Initialize();
        isPlaying = true;
    }

    public void GameOver()
    {
        isPlaying = false;
        if(uiManager != null) uiManager.ShowGameOver(Score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore()
    {
        Score++;
        if(uiManager != null) uiManager.UpdateScoreUI(Score);
    }

    public void SpawnNextPulpit(Vector3 originPos)
    {
        if (activePulpits.Count >= 2) return;

        float size = 9f;
        Vector3[] directions = { 
            new Vector3(size, 0, 0), new Vector3(-size, 0, 0), 
            new Vector3(0, 0, size), new Vector3(0, 0, -size) 
        };

        List<Vector3> validPositions = new List<Vector3>();
        foreach (var dir in directions)
        {
            validPositions.Add(originPos + dir);
        }

        Vector3 spawnPos = validPositions[Random.Range(0, validPositions.Count)];
        SpawnPulpitAt(spawnPos);
    }

    void SpawnPulpitAt(Vector3 pos)
    {
        GameObject go = Instantiate(pulpitPrefab, pos, Quaternion.identity);
        Pulpit p = go.GetComponent<Pulpit>();
        
        float min = ConfigLoader.Config.pulpit_data.min_pulpit_destroy_time;
        float max = ConfigLoader.Config.pulpit_data.max_pulpit_destroy_time;
        
        p.Initialize(Random.Range(min, max));
        activePulpits.Add(p);
    }

    public void RemovePulpit(Pulpit p)
    {
        if (activePulpits.Contains(p)) activePulpits.Remove(p);
    }
}
