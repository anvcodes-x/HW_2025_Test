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

    public int Score = 0;
    private List<Pulpit> activePulpits = new List<Pulpit>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(StartGameLoop());
    }

    IEnumerator StartGameLoop()
    {
        // Load config first
        yield return configLoader.LoadConfig();

        if (ConfigLoader.Config == null)
        {
            Debug.LogError("CRITICAL ERROR: Config not loaded.");
            yield break;
        }

        // Spawn 1st pulpit
        SpawnPulpitAt(Vector3.zero);

        // Reset score
        Score = 0;
        if (uiManager) uiManager.UpdateScoreUI(Score);

        Debug.Log("Game Started! Score reset.");
    }

    public void AddScore()
    {
        Score++;
        if (uiManager) uiManager.UpdateScoreUI(Score);
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER! Final Score: " + Score);

        // Save score for End Scene
        PlayerPrefs.SetInt("FinalScore", Score);

        // Load End Scene
        SceneManager.LoadScene("EndScene");
    }

    public void SpawnNextPulpit(Vector3 originPos)
    {
        if (activePulpits.Count >= 2) return;

        float size = 9f;
        Vector3[] dirs = {
            new Vector3(size, 0, 0),
            new Vector3(-size, 0, 0),
            new Vector3(0, 0, size),
            new Vector3(0, 0, -size)
        };

        Vector3 spawnPos = dirs[Random.Range(0, dirs.Length)] + originPos;

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
