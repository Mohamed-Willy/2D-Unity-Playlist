using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rigidBody;
    private float direction;
    private int onGround;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        onGround = 2;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal"); // -1 -> 1
        if(direction < 0)
        {
            transform.localScale = Vector3.one;
            animator.SetBool("run", true);
        }
        else if(direction > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
        transform.Translate(new Vector2(direction * speed * Time.deltaTime, 0));
        if (Input.GetKeyDown(KeyCode.Space) && onGround > 1)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
            onGround--;
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround > 0)
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, jumpForce * 10));
            onGround--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = 1;
        }
    }
}
