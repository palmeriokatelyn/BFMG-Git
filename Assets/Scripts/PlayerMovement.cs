using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    public float speed = 6f;
    private Vector3 moveDirection;
    public float jump;
    public Rigidbody rb;
    private bool isGrounded = true;

    public float maxPower = 1f;
    private float currentPower;
    public float powerForce = 0.5f;
    private int bubbleCount = 0;

    public GameObject spawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        currentPower = maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (isGrounded)
        {
            if (currentPower < maxPower)
            {
                currentPower += Time.deltaTime;
            }
        }
        

        Debug.Log("Current power is: " + currentPower);


    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Jump") > 0f && currentPower > 0f)
        {
            Debug.Log("She bubble on my floatie till i Mcgee");
            currentPower -= Time.deltaTime;
            rb.AddForce(rb.transform.up * powerForce, ForceMode.Impulse);
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == ("Bubble"))
        {
            bubbleCount++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == ("GameOver"))
        {
            rb.transform.position = spawnPoint.transform.position;
        }
    }
}
