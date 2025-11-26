using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DoofusController player;
    public ConfigLoader configLoader;
    public GameObject pulpitPrefab;
    
    // Added UI Reference back
    public UIManager uiManager;

    // Scoring
    public int Score = 0;
    private List<Pulpit> activePulpits = new List<Pulpit>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Start the game immediately!
        StartCoroutine(StartGameLoop());
    }

    IEnumerator StartGameLoop()
    {
        // 1. Load Data
        yield return configLoader.LoadConfig();

        if (ConfigLoader.Config == null) 
        {
            Debug.LogError("CRITICAL ERROR: Config not loaded.");
            yield break; 
        }

        // 2. Spawn First Pulpit
        SpawnPulpitAt(Vector3.zero);
        
        // 3. Reset Score & Update UI
        Score = 0;
        if(uiManager != null) uiManager.UpdateScoreUI(Score);
        
        Debug.Log("Game Started! Score: " + Score);
    }

    public void AddScore()
    {
        Score++;
        // Update UI when score changes
        if(uiManager != null) uiManager.UpdateScoreUI(Score);
    }

    // --- PULPIT SPAWNING LOGIC ---

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