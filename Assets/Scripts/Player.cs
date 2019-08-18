using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    Animator myAnimator;
    public float speed;
    public bool isAttack;
    public bool isHurt;

    private ExampleGestureHandler _gestureHandler;
  //  public GestureRecognizer.RecognitionResult result;
    // Start is called before the first frame update
    void Start()
    {

        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        //tambahan
        _gestureHandler = GetComponent<ExampleGestureHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAttacks();
    }
    private void HandleMovement()
    {
        myRigidBody.velocity = Vector2.left; // jalan kekiri x= -1
    }
    public void HandleAttacks()
    {
        //if (attack)
            if (Input.GetMouseButtonDown(0))
            {
                // myAnimator.SetBool(attack,"True");
                myAnimator.SetBool("isAttack", true);
            }
            else
            {
                myAnimator.SetBool("isAttack", false);
            }
      
    }
    void FixedUpdate()                                                      // dipanggil setiap step pyschics
    {
        float moveX = Input.GetAxis("Horizontal");                          // bakal ngeset nilai secara otomatis
        float moveY = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(moveX, moveY);

        myRigidBody.velocity = direction * speed;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bawah kiri
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));  // bagian atas kanan

        min.x += 0.285f;
        //max.x += 0.285f;
        max.x += 0f;
        min.y += 0.250f;
        max.y += 0.250f;

        Vector2 pos = myRigidBody.position;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);                           // dia tidak akan melewati min dan max x nya
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);
            print("enter PLAYER");
            myAnimator.SetBool("isHurt", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);
            print("enter PLAYER");
            myAnimator.SetBool("isHurt", false);
        }
    }
}
