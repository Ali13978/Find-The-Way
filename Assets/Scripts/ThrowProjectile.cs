using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    public Vector2 direction;
    [SerializeField] GameObject PointPrefab;
    [SerializeField] GameObject[] Points;
    [SerializeField] int NoOfPoints;

    [SerializeField] int ThrowForce;
    [SerializeField] float force;
    [SerializeField] GameObject Projectile;
    // Start is called before the first frame update
    void Start()
    {
        Points = new GameObject[NoOfPoints];
        for (int i = 0; i < NoOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position , Quaternion.identity);
            Points[i].transform.SetParent(this.gameObject.transform);
        }
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
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i].transform.position = PointPosition( i *0.1f);
        }
    }

    private void Shoot()
    {
        GameObject insProjectile = Instantiate(Projectile,transform.position,transform.rotation);
        insProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * ThrowForce;
    }

    private void FaceMouse()
    {
        transform.right = direction;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 CurrentPointPos = (Vector2)transform.position + (direction.normalized * force * t) + 0.5f*Physics2D.gravity*(t*t);
        return CurrentPointPos;
    }
}
