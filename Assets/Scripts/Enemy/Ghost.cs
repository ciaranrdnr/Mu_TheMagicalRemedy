using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
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
       

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, -0.1f, 0);
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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            print("bisa");
            myAnimator.SetBool("isAngry", true);
        }
    }

}
