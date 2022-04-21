using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireManager : MonoBehaviour
{
    [SerializeField] float Power = 10f;
    [SerializeField] float MaxDrag = 5f;
    [SerializeField] int NoOfApples;
    [SerializeField] TextMeshProUGUI NoOfApplesText;
    [SerializeField] GameObject Projectile;
    
    Rigidbody2D ProjectileRigidBody;
    LineRenderer lr;
    Vector3 DragStartPos;
    Touch touch;
    bool TouchingUiElement = true;
    // Start is called before the first frame update
    void Start()
    {
        NoOfApplesText.text = "X " + NoOfApples.ToString();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(NoOfApples<=0)
        {return;}
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if(touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if(touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }

    private void CheckIfTouchIsOverUIElement()
    {
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(id))
            {
                TouchingUiElement = true;
                Debug.Log("TouchingUiElement UI Element");
            }
            else
            {
                TouchingUiElement = false;
                Debug.Log("Not Touching UI Element");
            }
        }
    }

    void DragStart()
    {
        DragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        DragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0,DragStartPos);
    }

    void Dragging()
    {
        Vector3 Draggingpos = Camera.main.ScreenToWorldPoint(touch.position);
        Draggingpos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1,Draggingpos);
    }

    void DragRelease()
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        DragStartPos.z = 0f;

        Vector3 force = DragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, MaxDrag) * Power;
        GameObject Apple = Instantiate(Projectile,transform.position,Quaternion.identity);
        NoOfApples -- ;
        NoOfApplesText.text ="X " + NoOfApples.ToString();
        Apple.GetComponent<Rigidbody2D>().AddForce(clampedForce, ForceMode2D.Impulse);
    }
}
