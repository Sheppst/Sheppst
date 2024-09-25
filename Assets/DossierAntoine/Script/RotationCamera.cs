using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interface;

public class RotationCamera : MonoBehaviour, Rotate
{
    [SerializeField] private List<Transform> RotaPoint;
    [SerializeField] private Transform Target;
    [SerializeField] private Transform CamTrans;
    [SerializeField] private float Speed;

    private bool IsMoving;
    private int ActualFace;
    private Vector3 ActualFacePos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < RotaPoint.Count; i++)
        {
            RotaPoint[i].SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Target.position;

        //if (Vector3.Distance(CamTrans.position, targetPosition) <= 0.5f)
        //{
        //    ActualFace = RotaPoint.IndexOf(Target);
        //    IsMoving = false;
        //}
        //else
        //    IsMoving = true;
            

        // Là ça crée un vecteur de direction entre un point A et B, par contre j'ai pas saisi pk il marchait pas en B - A :/
        Vector3 direction = transform.position - targetPosition;

        // On utilise le vecteur de déplacement pour obtenir un quaternion de rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Puis on l'applique dans un slerp pour permettre un transition douce 

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Speed * Time.deltaTime);
        ActualFacePos = RotaPoint[ActualFace].position;
    }

    /* -Z : 0, -X : 1, -Y : 2, Z : 3, X : 4, Y : 5 */

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
