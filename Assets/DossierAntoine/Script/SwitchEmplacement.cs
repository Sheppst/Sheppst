using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SwitchEmplacement : MonoBehaviour
{
    [SerializeField] private List<Transform> RotaPoint;
    [SerializeField] private Transform Target;
    [SerializeField] private float Speed;
    private int ActualFace;
    private Vector3 ActualFacePos;
    private bool IsMoving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
    }

    public void Right()
    {
        if (IsMoving)
            return;
        if (ActualFace == 0)
            Target = RotaPoint[2];

    }
    public void Left()
    {
        if (IsMoving)
            return;
    }
    public void Up()
    {
        if (IsMoving)
            return;
    }
    public void Down()
    {
        if (IsMoving)
            return;
    }
}
