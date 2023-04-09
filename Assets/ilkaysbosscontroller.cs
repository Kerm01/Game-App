using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ilkaysbosscontroller : MonoBehaviour
{
    GameObject player;
    int distance;
    Animator animator;
    NavMeshAgent navigation;


    // Start is called before the first frame update
    void Start()
    {
        navigation = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        distance =(int)Vector3.Distance(this.transform.position, player.transform.position);
        animator.SetInteger("distance", distance);
        if (distance<=20)
        {
            navigation.destination = player.transform.position;

            if (distance <= 3)
            {
            //this.transform.LookAt(player.transform.position);
                animator.SetBool("attack", true);

            }
            else
            {
                animator.SetBool("attack", false);

            }
        }
      
    }
}
