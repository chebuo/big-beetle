using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    //playercontroller PlayerController;
    beetlecontroller BeetleController;
    //public GameObject tomatobomb;


    // Start is called before the first frame update
    void Start()
    {
        //tomatobomb = GameObject.Find("");
        //GameObject tomatobomb = GameObject.Find("tomatobomb_0");
        GameObject beetle = GameObject.Find("beetle");
        BeetleController = beetle.GetComponent<beetlecontroller>();
        //PlayerController = tomatobomb.GetComponent<playercontroller>();
    }
    void OnParticleCollision(GameObject obj)
    {
        if (obj.gameObject.CompareTag("beetle"))
        {
            BeetleController.HP = BeetleController.HP - 1f;
            Debug.Log(BeetleController.HP);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
