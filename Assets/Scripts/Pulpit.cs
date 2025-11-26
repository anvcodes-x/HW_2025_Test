
using UnityEngine;

public class Pulpit : MonoBehaviour
{
    public float destroyTime;
    private float age;
    private bool spawnTriggered = false;
    private Renderer rend;

    public void Initialize(float lifeSpan)
    {
        destroyTime = lifeSpan;
        age = 0;
        spawnTriggered = false;
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float dt = Time.deltaTime;
        age += dt;

        
        if (rend)
        {
            if (destroyTime - age < 1.5f)
            {
                rend.material.color = Color.Lerp(Color.green, Color.red, Mathf.PingPong(Time.time * 5, 1));
            }
        }

        
        if (!spawnTriggered && age >= ConfigLoader.Config.pulpit_data.pulpit_spawn_time)
        {
            spawnTriggered = true;
            GameManager.Instance.SpawnNextPulpit(transform.position);
        }

        
        if (age >= destroyTime)
        {
            GameManager.Instance.RemovePulpit(this);
            Destroy(gameObject);
        }
    }
}
