using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public GameObject tomatobomb;
    public GameObject pumpkinbomb;
    public float speedup=5f;
    public float speeddown = -5f;
    public float bombcharge = 0f;
    public float maxbombcharge = 40f;
    public bool isBattle = true;
    public bool Win = true;
    bool isMove = false;
    bool isParticle = false;
    bool isBombCharge = false;
    Rigidbody2D rb2d;
    Renderer rder;
    [SerializeField] private ParticleSystem seed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rder = GetComponent<Renderer>();       
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("beetle"))
        {
            this.gameObject.SetActive(false);
            isBattle = false;
            Win = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {      
        if (!isParticle && isBattle && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float speed_y = 0;
            float speed_x = 0;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector3(0, speedup, 0);
                isMove = true;
                speed_y = speedup;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector3(speedup, speed_y, 0);
                isMove = true;
                speed_x = speedup;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.velocity = new Vector3(speeddown, speed_y, 0);
                isMove = true;
                speed_x = speeddown;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = new Vector3(speed_x, speeddown, 0);
                isMove = true;
                speed_y = speeddown;
            }
        }
        else
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            isMove = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            isMove = false;
        }
        if (!isBattle)
        {
            rb2d.velocity = new Vector3(0, 0, 0);
            isMove = false;
        }
        if (Input.GetKey(KeyCode.W) && maxbombcharge >= bombcharge)
        {
            bombcharge++;
            isBombCharge = true;
        }
    }
    IEnumerator ChargeColor()
    {
        while (maxbombcharge>bombcharge&&maxbombcharge / 2 <= bombcharge)
        {
            rder.material.color = new Color32(255, 255, 255, 140);
            yield return new WaitForSeconds(0.1f);
            rder.material.color = new Color32(250, 250, 250, 255);
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            speedup /= 2;
            speeddown /= 2;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            speedup *= 2;
            speeddown *= 2;
        }
        if (!isMove && isBattle)
        {

            if (Input.GetKey(KeyCode.Space)&&!Input.GetKey(KeyCode.W))
            {
                if (!isParticle)
                {
                    seed.Play();
                    isParticle = true;
                }
            }
            else
            {
                seed.Stop();
                isParticle = false;
            }
           
            

            if (Input.GetKeyUp(KeyCode.W))
            {
                if (!isParticle&&maxbombcharge<=bombcharge)
                {
                    Instantiate(pumpkinbomb, transform.position, Quaternion.identity);
                    //rder.material.color = new Color32(0,0,0,0);
                }
                else if (!isParticle&&maxbombcharge/2<=bombcharge)
                {
                    Instantiate(tomatobomb, transform.position, Quaternion.identity);                 
                }
                Debug.Log(bombcharge);                         
            }
            else if (!Input.GetKey(KeyCode.Space))
            {
                seed.Stop();
                isParticle = false;
            }
        }
        else
        {
            seed.Stop();
            isParticle = false;
        }
        if(isBombCharge)
        {
            this.rb2d.velocity = new Vector3(0,0,0);
        }
        if (Input.GetKey(KeyCode.W)&&isBattle)
        {
            if (maxbombcharge <= bombcharge)
            {
                rder.material.color = new Color32(255, 255, 255, 180);
            }
            else if (maxbombcharge / 2 <= bombcharge)
            {
                StartCoroutine("ChargeColor");
            }
            else if (0 < bombcharge)
            {
                rder.material.color = new Color32(150,150,150,255);
            }
        }
        else
        {
            rder.material.color = new Color32(255, 255, 255, 255);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            bombcharge = 0f;
        }
        if(!isBattle)
        {
            if (Win)
            {
                Debug.Log("konittiwa"); 
            }
            else
            {
                Debug.Log("make");
            }
        }
    } 
}
