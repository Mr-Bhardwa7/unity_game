using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public Sprite bombWithFire;
    public Sprite bombWithoutFire;
    private SpriteRenderer bombSpriteRenderer;
    public bool readyToExplode;

    // Start is called before the first frame update
    void Start()
    {
        bombSpriteRenderer = GetComponent<SpriteRenderer>();
        bombSpriteRenderer.sprite = bombWithoutFire;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            bombSpriteRenderer.sprite = bombWithFire;
            readyToExplode = true;
        }
    }
}
