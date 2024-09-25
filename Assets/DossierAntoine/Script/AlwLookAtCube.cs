using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwLookAtCube : MonoBehaviour
{
    [SerializeField] private Transform Cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Cube);
        transform.eulerAngles.Set(transform.eulerAngles.x, 0, 0);
    }
}
