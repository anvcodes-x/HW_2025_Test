using UnityEngine;

public class DoofusController : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody rb;
    private Transform currentPulpit; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. Initialize Speed from Config if loaded
        if (ConfigLoader.Config != null && speed == 3f) 
        {
            speed = ConfigLoader.Config.player_data.speed;
        }

        // 2. Movement
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0, v).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // 3. Scoring Check
        CheckScore();
        
        // 4. Fall Check
        if (transform.position.y < -5f)
        {
            Debug.Log("Game Over! (Fell off)");
        }
    }

    void CheckScore()
    {
        RaycastHit hit;
        // Shoot ray down to see what we are standing on
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        {
            if (hit.transform.GetComponent<Pulpit>() != null)
            {
                if (hit.transform != currentPulpit)
                {
                    currentPulpit = hit.transform;
                    GameManager.Instance.AddScore();
                }
            }
        }
    }
}