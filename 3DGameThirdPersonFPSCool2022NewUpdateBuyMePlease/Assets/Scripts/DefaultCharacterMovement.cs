using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCharacterMovement : MonoBehaviour
{
    private bool isEnableDefaultMovement=true;
    private Vector3 playerVelocity;
    [SerializeField]private Vector3 direction;
    private Rigidbody rb;
    public float moveSpeed;
    public bool grounded;
    private float health;
    private Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;

        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;


        movingVector = Vector3.ClampMagnitude(camF.normalized * Input.GetAxis("Vertical") * moveSpeed + camR.normalized * Input.GetAxis("Horizontal") * moveSpeed, moveSpeed);
        rb.velocity = new Vector3(movingVector.x, rb.velocity.y, movingVector.z);
        rb.angularVelocity = Vector3.zero;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
