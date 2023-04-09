using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform tp;
    [SerializeField] GameObject player;
    private bool canTeleport = true; // boolean variable to check if teleportation is allowed
    private float cooldownTime = 10f; // the duration of the cooldown

    private void OnTriggerEnter(Collider other)
    {
        if (canTeleport) // check if teleportation is allowed
        {
            StartCoroutine(Telep());
            canTeleport = false; // set canTeleport to false to start the cooldown
            StartCoroutine(Cooldown()); // start the cooldown coroutine
        }
    }

    IEnumerator Telep()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(
          tp.transform.position.x,
          tp.transform.position.y,
          tp.transform.position.z
        );
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canTeleport = true; // set canTeleport to true to allow teleportation again
    }
}

