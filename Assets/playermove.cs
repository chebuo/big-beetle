using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour
{
    public GameObject turnip;
    public float speedup = 5f;
    public float speeddown = -5f;
    public bool isScenechange= false;
    Vector3 localScale;
    Rigidbody2D rb2d;
    SpriteRenderer sird;
    // Start is called before the first frame update
    void Start()
    {
        ///scenechange = GameObject.Find("scenechange");
        rb2d = GetComponent<Rigidbody2D>();
        sird = GetComponent<SpriteRenderer>();
        //image = scenechange.GetComponent<Image>();
    }
    public void OnCollisionStay2D(Collision2D col)
    { 
        if(col.gameObject.CompareTag("return"))
        { 
            isScenechange = true;
        }
        if (col.gameObject.CompareTag("fight"))
        {
            Debug.Log("n");
            isScenechange = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float speed_y = 0;
            float speed_x = 0;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector3(0, speedup, 0);              
                speed_y = speedup;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector3(speedup, speed_y, 0);            
                speed_x = speedup;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.velocity = new Vector3(speeddown, speed_y, 0);
                speed_x = speeddown;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = new Vector3(speed_x, speeddown, 0);
                speed_y = speeddown;
            }
        }
        else
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
        }
    }
    void Update()
    {
        localScale = transform.localScale;      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.localScale.x = 1f;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.localScale.x = -1f;
        }
        transform.localScale = localScale;
    }
}