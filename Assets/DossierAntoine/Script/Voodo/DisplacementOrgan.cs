using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementOrgan : MonoBehaviour
{
    [SerializeField] private List<GameObject> Organs;
    [SerializeField] private List<Transform> Emplacement;
    [SerializeField] private Transform Mid;
    [SerializeField] private float Distance;
    [SerializeField] private float WaitTime;
    [SerializeField] private float SpeedDisplace;

    private bool Rotate;
    private bool Placement;
    private float Moved;
    private Vector3 RotateTo;
    private List<GameObject> OrgansList;
    private List<Transform> EmplacementList;

    private void OnEnable()
    {
        OrgansList = new List<GameObject>();
        EmplacementList = new List<Transform>();
        for (int i = 0; i < Organs.Count; i++) // Place les organes d'un coté
        {
            if (Mid.position.z > Emplacement[i].position.z)
                continue;
            GameObject InstOrg = Instantiate(Organs[i], (Emplacement[i].position - Mid.position).normalized * Distance, Quaternion.identity);
            InstOrg.transform.LookAt(Mid.position);
            OrgansList.Add(InstOrg);
            EmplacementList.Add(Emplacement[i]);
        }
        StartCoroutine(WaitForOrgPlacement()); // Autorise les organes à se placer et attend leur placement
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Rotate)
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(RotateTo), 180);
        if (Placement) // Quand activé déplace les organes vers les emplacement dans le corps 
        {
            for (int i = 0; i < OrgansList.Count; i++)
            {
                OrgansList[i].transform.position = Vector3.MoveTowards(OrgansList[i].transform.position, EmplacementList[i].position, SpeedDisplace * Time.deltaTime);
            }
        }
        if (Rotate) // Quand activé déplace les organes vers les emplacement dans le corps // Rotate est le booléen pour le coté inverse
        {
            for (int i = 0; i < OrgansList.Count; i++)
            {
                OrgansList[i].transform.position = Vector3.MoveTowards(OrgansList[i].transform.position, EmplacementList[i].position, SpeedDisplace * Time.deltaTime);
                if (Vector3.Distance(OrgansList[i].transform.position, EmplacementList[i].position) <= 0.1) // Si l'organe à la position i dans la liste est placé le retire et retire l'emplacement dans la liste
                {
                    OrgansList.Remove(OrgansList[i]);
                    EmplacementList.Remove(EmplacementList[i]);
                }
            }
            if (OrgansList.Count == 0 && EmplacementList.Count == 0) // Si les deux listes sont vide on arrête tous et on réinitialise pour la prochaine activation
            {
                Rotate = false;
                enabled = false;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Abs(transform.eulerAngles.y) - 180, transform.eulerAngles.z); // Retourne la poupée dans le sens inverse sur l'axe Y
            }
        }
    }
    
    private void OtherSidePlacement()
    {
        OrgansList = new List<GameObject>();
        EmplacementList = new List<Transform>();
        for (int i = 0; i < Organs.Count; i++)
        {
            if (Mid.position.z < Emplacement[i].position.z)
                continue;
            GameObject InstOrg = Instantiate(Organs[i], (Emplacement[i].position - Mid.position).normalized * Distance, Quaternion.identity);
            InstOrg.transform.LookAt(Mid.position);
            OrgansList.Add(InstOrg);
            EmplacementList.Add(Emplacement[i]);
        }
    }

    void RotateDollStart()
    {
        Placement = false; //Bloque le déplacement des objets
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Abs(transform.eulerAngles.y) - 180, transform.eulerAngles.z); // Retourne la poupée dans le sens inverse sur l'axe Y
        OtherSidePlacement(); // Réeffectue le placement des organes mais de l'autre cotée cette fois-ci
        Rotate = true; // Autorise le déplacement dans l'update
    }

    private IEnumerator WaitForOrgPlacement()
    {
        Placement = true; // Lance la procédure de placement dans l'update
        yield return new WaitForSeconds(WaitTime); // Quand leur placement est final   
        RotateDollStart(); // Fais en sort de retourner la poupée 
    }
}
