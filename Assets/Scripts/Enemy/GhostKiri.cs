using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostKiri : MonoBehaviour
{
    public float speed;
    Animator myAnimator;
    private Rigidbody2D myRigid;
    public Transform player;
    

    public GameObject myGhost; //ghost prefab
    private Vector2 movement;
    private bool isAngry;


    // Start is called before the first frame update

    void Start()
    {
      
         myRigid = GetComponent<Rigidbody2D>();         // biar konsisten
                                                        //  myRigid.velocity = Vector2.down * speed;         // Vector2.up sama aja kaya Vector2(0,1) enemy=down
        //Vector3 direction = player.position;
        //Debug.Log("dir" + direction);
        //Debug.Log("transform" + transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 direction = player.position;
        Vector3 direction = new Vector3(-0.1f, 0, 0);
        //Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // myRigid.rotation = angle;
        movement = direction;

    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {

        myRigid.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GameArea")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            
        }
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            print("exit");
            myAnimator.SetBool("isAngry", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            print("stay");
            myAnimator.SetBool("isAngry", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            print("enter");
            myAnimator.SetBool("isAngry", true);
        }
    }
}

  
