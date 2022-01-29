using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModePowerUp : MonoBehaviour
{
    public GameObject godPrefab;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dead") || other.CompareTag("Alive"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider Player)
    {
        Instantiate(godPrefab, Player.transform.position, Quaternion.identity);
        Destroy(Player.gameObject);
        Destroy(gameObject);
    }
}
