using UnityEngine;

public class DoofusController : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody rb;
    private Transform currentPulpit; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // 1. FREEZE PHYSICS COMPLETELY
        // This makes Doofus ignore gravity and collisions until we say otherwise
        rb.isKinematic = true; 
    }

    public void Initialize()
    {
        // 2. RESET POSITION
        transform.position = new Vector3(0, 1, 0);
        transform.rotation = Quaternion.identity;
        
        // 3. UNFREEZE PHYSICS
        rb.isKinematic = false;
        
        // Unity 6 check: Use linearVelocity if available, otherwise velocity
        // rb.linearVelocity = Vector3.zero; 
        
        currentPulpit = null;
        
        if (ConfigLoader.Config != null)
        {
            speed = ConfigLoader.Config.player_data.speed;
        }
    }

    void Update()
    {
        if (!GameManager.Instance.isPlaying) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0, v).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (transform.position.y < -3f)
        {
            GameManager.Instance.GameOver();
        }

        CheckScore();
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
