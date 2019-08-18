using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject enemyAtas;
    public GameObject enemyBawah;
    public GameObject enemyKanan;
    public GameObject enemyKiri;


    private float randX;
    public Vector2 spawnPos;    //atas
    public Vector2 spawnPos1; //bawah
    public Vector2 spawnPos2;    //kanan
    public Vector2 spawnPos3; //kiri

    public float spawnRate;
    float nextSpawn = 0.0f;

    private Rigidbody2D myRigid;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();         // biar konsisten
        //myRigid.velocity = Vector2.down * speed;         // Vector2.up sama aja kaya Vector2(0,1) enemy=down
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            //kebawah
            nextSpawn = Time.time + spawnRate;
            Vector3 pos = new Vector3(Random.Range(-spawnPos.x, spawnPos.x), spawnPos.y, 0);
            Instantiate(enemyAtas, pos, Quaternion.identity);
            
            //keatas
            Vector3 pos1 = new Vector3(Random.Range(-spawnPos1.x, spawnPos1.x), spawnPos1.y, 0);
            Instantiate(enemyBawah, pos1, Quaternion.identity);

            //kiri
            Vector3 pos2 = new Vector3(-spawnPos2.x, Random.Range(-spawnPos2.y, spawnPos2.y), 0);
            Instantiate(enemyKanan, pos2, Quaternion.identity);

            //kanan
            Vector3 pos3 = new Vector3(spawnPos3.x, Random.Range(-spawnPos3.y, spawnPos3.y), 0);
            Instantiate(enemyKiri, pos3, Quaternion.identity);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GameArea")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);


        }
    }
}
