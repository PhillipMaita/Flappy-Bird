using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{

    public Sprite fly;
    public Sprite flap;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fly;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            spriteRenderer.sprite = flap;

        }
        if (Input.GetButtonUp("Fire1"))
        {
            spriteRenderer.sprite = fly;

        }
    }
}
