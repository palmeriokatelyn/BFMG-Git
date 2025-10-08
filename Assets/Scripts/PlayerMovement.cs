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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
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
    }
}
