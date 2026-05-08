using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 5f;

    private Vector2 movementInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        
    }

    private void FixedUpdate()
    {
        Vector3 moveDirecao = 
            new Vector3(movementInput.x, 0, movementInput.y) * speed;

        if (rb.linearVelocity.magnitude < maxSpeed)
        {

            rb.linearVelocity = new Vector3(
                moveDirecao.x, rb.linearVelocity.y, moveDirecao.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
