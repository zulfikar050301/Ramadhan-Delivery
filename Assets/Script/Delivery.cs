using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    // [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    // [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    public Sprite sprite1;
    public Sprite sprite2;
    SpriteRenderer spriteRenderer;
    bool hasPackage;


    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("ouch"); 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked Up");
            // spriteRenderer.color = hasPackageColor;
            spriteRenderer.sprite = sprite2;
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.sprite = sprite1;
            // spriteRenderer.sprite = sprite1;
            // spriteRenderer.color = noPackageColor;
        }
    }
}
