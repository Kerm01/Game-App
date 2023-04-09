using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherenemycontroller : MonoBehaviour
{
    GameObject player;
    int distance;
    Animator bowanimasyon;
    [SerializeField]GameObject projectile;
    [SerializeField] GameObject shotpoint;
    bool alreadyattcaked = false;
        
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bowanimasyon = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        distance = (int)Vector3.Distance(this.transform.position, player.transform.position);
        if (distance<=30)
        {
            transform.LookAt(player.transform.position);
            bowanimasyon.SetBool("attack", true);
            invokemethod();
            






        }
        else
        {
            bowanimasyon.SetBool("attack", false);
        }
    }
    private void attackmethod()
    {
        Rigidbody rb = Instantiate(projectile, shotpoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
        rb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }
   private void invokemethod()
    {
        if (!alreadyattcaked)
        {
            attackmethod();
            alreadyattcaked = true;
            Invoke("Resetattack", 4f);
        }
    }
    private void Resetattack()
    {
        alreadyattcaked = false;
    }









}
