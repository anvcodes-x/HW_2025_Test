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
        // Load player speed from config
        if (ConfigLoader.Config != null && speed == 3f)
        {
            speed = ConfigLoader.Config.player_data.speed;
        }

        // Movement
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0, v).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Scoring
        CheckScore();

        // Fall detection → Game Over
        if (transform.position.y < -5f)
        {
            GameManager.Instance.GameOver();
        }
    }

    void CheckScore()
    {
        RaycastHit hit;

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
