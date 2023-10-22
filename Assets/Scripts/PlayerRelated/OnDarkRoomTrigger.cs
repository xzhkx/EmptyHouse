using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDarkRoomTrigger : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    private Material litMaterial;

    private void Awake()
    {
        litMaterial = gameObject.GetComponent<SpriteRenderer>().material;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().material = litMaterial;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().material = defaultMaterial;
        }    
    }
}
