using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomatocontroller : MonoBehaviour
{
    public GameObject tomato;
    public float tomatospeed_x = 0f;
    public float tomatospeed_y= 0f;
    public float damage=0f;
    public GameObject bomb;
    Rigidbody2D rb2d;
    beetlecontroller BeetleController;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject beetle = GameObject.Find("beetle");
        
        BeetleController = beetle.GetComponent<beetlecontroller>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("beetle"))
        {          
            GameObject explosion = Instantiate(bomb,transform.position,Quaternion.identity);
            Destroy(explosion,0.4f);
            Destroy(this.gameObject);
            BeetleController.HP -= damage;
            Debug.Log(BeetleController.HP);
        }
        if(col.gameObject.CompareTag("ground"))
        {
            GameObject explosion = Instantiate(bomb, transform.position, Quaternion.identity);
            Destroy(explosion, 0.4f);
            Destroy(this.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (this.rb2d.velocity.magnitude < 0.1)
        {
            rb2d.AddForce(new Vector3(tomatospeed_x, tomatospeed_y, 0f));
        }
    }
}
