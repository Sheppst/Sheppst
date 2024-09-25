using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGen : MonoBehaviour
{
    [SerializeField] private int Colon;
    [SerializeField] private int Lign;
    [SerializeField] private GameObject Ground;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject PressurePlate;

    private int InvertFactor = 1;
    private Vector3 Begining;
    private Vector3 End;
    private GameObject ActParent;
    // Start is called before the first frame update
    void Start()
    {
        Begining = Vector3.zero;
        for (int i = 0; i < Colon; i++)
        {
            for (int j = 0; j < Lign; j++)
            {
                GameObject GroundLvl = Instantiate(Ground, Vector3.right * i + Vector3.back * j, Ground.transform.rotation);
            }
        }
        End = Vector3.right * (Colon - 1) + Vector3.back * (Lign - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int Randomizer(Vector3 ActGround, int XorZ)
    {
        int add = 1;
        int rand = Random.Range(0, 15);
        if (rand % 5 == 0) 
        {
            add = -1;
        }
        return add;
    }

    private List<Vector3> PathMader()
    {
        Vector3 ActGround = Vector3.zero; 
        List<Vector3> path = new List<Vector3>();
        for (int i = 0; i < Colon; i++) 
        {
            for (int j = 0; j < Lign; j++)
            {
                if (i == 0 && j == 0)
                { 
                    path.Add(Begining);
                    ActGround = Begining;
                }

                if (i == Colon - 1 && j == Lign - 1)
                { 
                    path.Add(End);
                    ActGround = End;
                }
                else
                {
                    path.Add(Vector3.right * Randomizer(ActGround, 0) + Vector3.back * Randomizer(ActGround, 1));
                }
            }
        }
        return path;

        
    }
    private Vector3 PathFinder(int i, int j, Vector3 Actground)
    {
        Vector3 Ground = Vector3.zero;
        float x = 0;
        float z = 0;
        Ground.x = Randomizer(Actground, 0);
        Ground.z = Randomizer(Actground, 1);
        if (Actground.x == i)
            x = i;
        if (Actground.y == j)
            z = j;
        return Ground;
    }
}
