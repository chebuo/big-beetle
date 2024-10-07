using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beetlecontroller : MonoBehaviour
{
    public GameObject fly;
    public GameObject deadbeetle;
    public float HP = 500f;
    float beetlespeed=-1;
    Vector3 fpos;
    Vector3 bpos;
    Rigidbody2D rb2d;
    playercontroller PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = fly.GetComponent<playercontroller>();
        rb2d = GetComponent<Rigidbody2D>();
        fly = GameObject.Find("fly");
        deadbeetle = GameObject.Find("deadbeetle");
        deadbeetle.gameObject.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("turnip"))
        {
            PlayerController.isBattle = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        bpos = this.transform.position;
        fpos = fly.transform.position;
        float fposx = fpos.x;
        float bposx = bpos.x;
        if(HP<=0)
        {          
            PlayerController.isBattle=false;
            deadbeetle.gameObject.SetActive(true);
            int i = 0;
            if(i == 0)
            {           
                
                //‚â‚ç‚ê‚½‚Æ‚«‚Ìeffect
                Debug.Log("ˆê‰ñŽÀs");
                i++;
            }
            this.gameObject.SetActive(false);
            PlayerController.Win = true;
        }
        beetlespeed = (fposx - bposx)/10f;
        rb2d.velocity = new Vector3(beetlespeed,0,0);
    }
}
