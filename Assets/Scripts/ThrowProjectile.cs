using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    public Vector2 direction;

    [SerializeField] int ThrowForce;
    [SerializeField] GameObject Projectile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 ArrowPos = transform.position;
        direction = MousePos - ArrowPos;
        FaceMouse();

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject insProjectile = Instantiate(Projectile,transform.position,transform.rotation);
        insProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * ThrowForce);
    }

    private void FaceMouse()
    {
        transform.right = direction;
    }
}
