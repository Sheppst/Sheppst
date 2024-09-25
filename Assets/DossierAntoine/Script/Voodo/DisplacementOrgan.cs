using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementOrgan : MonoBehaviour
{
    [SerializeField] private List<GameObject> Organs;
    [SerializeField] private List<Transform> Emplacement;
    [SerializeField] private Transform Mid;
    [SerializeField] private float Distance;

    private void OnEnable()
    {
        for (int i = 0; i < Organs.Count; i++)
        {
            if (Mid.position.z > Emplacement[i].position.z)
                continue;
            GameObject InstOrg = Instantiate(Organs[i], (Emplacement[i].position - Mid.position).normalized * Distance, Quaternion.identity);
            InstOrg.transform.LookAt(Mid.position);
        }
        //RotateDollStart();
        for (int i = 0; i < Organs.Count; i++)
        {
            if (Mid.position.z < Emplacement[i].position.z)
                continue;
            GameObject InstOrg = Instantiate(Organs[i], (Emplacement[i].position - Mid.position).normalized * Distance, Quaternion.identity);
            InstOrg.transform.LookAt(Mid.position);
        }
        enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
