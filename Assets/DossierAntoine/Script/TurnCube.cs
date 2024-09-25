using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interface;
using static UnityEngine.GraphicsBuffer;

public class TurnCube : MonoBehaviour, Rotate
{
    public bool IsMoving;
    private Vector3 ActRota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMoving) 
        {
            ActRota = transform.eulerAngles;
        }
    }

    public void Right()
    {
        if (IsMoving)
            return;
        if (transform.eulerAngles.y == ActRota.y * 90)
            transform.Rotate(transform.eulerAngles + Vector3.up * 90);
    }
    public void Left()
    {
        if (IsMoving)
            return;
        transform.Rotate(transform.eulerAngles + Vector3.up * 90);
    }
    public void Up()
    {
        if (IsMoving)
            return;
        transform.Rotate(transform.eulerAngles + Vector3.up * 90);
    }
    public void Down()
    {
        if (IsMoving)
            return;
        transform.Rotate(transform.eulerAngles + Vector3.up * 90);
    }
}
