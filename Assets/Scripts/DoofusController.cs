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

    public void Initialize()
    {
        transform.position = new Vector3(0, 1, 0);
        
        if (ConfigLoader.Config != null)
        {
            speed = ConfigLoader.Config.player_data.speed;
        }
    }

    void Update()
    {
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0, v).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        
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
