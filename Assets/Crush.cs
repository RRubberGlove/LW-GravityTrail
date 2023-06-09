using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    public float yForce;
    public float xForce;
    public float xDirection;
    private Rigidbody2D enemyRigidBody;
    public int maxX;
    public int minX;
    public GameObject Portal;
    private Teleport TpScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        TpScript = Portal.GetComponent <Teleport>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
        enemyRigidBody.AddForce(jumpForce);
        if(collision.gameObject.tag == "ThrowingObject")
        {
            TpScript.subtract();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= minX)
        {
            xDirection = 1;
            enemyRigidBody.AddForce(Vector2.right * xForce);
        }
        if (transform.position.x >= maxX)
        {
            xDirection = -1;
            enemyRigidBody.AddForce(Vector2.left * xForce);
        }
    }
}
