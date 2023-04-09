using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Animator zombieAnim;
    private float zombiHP = 100;
    bool zombiOlu;
    GameObject hedefOyuncu;
   public float kovalamaMesafe;
    NavMeshAgent zombieNav;
    public float sald�rmaMesafe;
    float mesafe;
    // Start is called before the first frame update
    void Start()
    {
        zombieAnim= GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("PlayerArmature");
        zombieNav=this.GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
      
        if (zombiHP <= 0) 
        
        {

            zombiOlu = true;
        }
        if (zombiOlu==true)
        {
            zombieAnim.SetBool("oldu", true);
            StartCoroutine(YokOl());
        }
        else
        {

             mesafe=Vector3.Distance(this.transform.position,hedefOyuncu.transform.position);
            if (mesafe<kovalamaMesafe)
            {
                zombieNav.isStopped = false;
                zombieNav.SetDestination(hedefOyuncu.transform.position);
                zombieAnim.SetBool("yuruyor", true);
                zombieAnim.SetBool("sald�r�yor", false);
                this.transform.LookAt(hedefOyuncu.transform.position);
            }
            else
            {
                zombieNav.isStopped= true;
                zombieAnim.SetBool("yuruyor", false);
                zombieAnim.SetBool("sald�r�yor", false);
            }
            if (mesafe<sald�rmaMesafe)
            {
                this.transform.LookAt(hedefOyuncu.transform.position);
                zombieNav.isStopped = true;//vurma anim �al��cak
                zombieAnim.SetBool("yuruyor", false);
                zombieAnim.SetBool("sald�r�yor", true);
            }
        }
    }
    public void HasarVer()
    {

        
    }
    IEnumerator YokOl()
    {

        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);    
    }
    public void HasarA1()
    {
        zombiHP -= Random.Range(15, 25);

    }
}
