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
    private float h;
    private float v;
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

        /*if (isEnableDefaultMovement&grounded)
        {
            direction = Vector3.zero;
            if (Input.GetKey(KeyCode.D))
            {
                direction.x += 1;
            }
            else
            {
                direction.x += 0;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction.x += -1;
            }
            else
            {
                direction.x += 0;
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction.z += 1;
            }
            else
            {
                direction.z += 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction.z += -1;
            }
            else
            {
                direction.z += 0;
            }
            direction = direction.normalized;
            rb.velocity = direction*moveSpeed;
        }*/
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
