using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mondo : MonoBehaviour
{
    public Vector3 coords, offset, terrapos;
[System.Serializable]
    public struct Regio
    {
        public Regione[] riga;  //riga means row
    }
    public Regio[] colonna; //colonna means column
    public Regione center;
    public Camera cam;
    int ind = 0;
    Vector3 poss;
    // Start is called before the first frame update
    void Start()
    {
        //change 8 to your number of rows
        for(int r=0;r<8; r++)
        foreach (Regione rrr in colonna[r].riga)
        {
            rrr.camm = cam;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //fai apparire i terreni in base alla tua posizione nel mondo di gioco che è coords
        //32000 is the total size of the world in units
        coords.x = Mathf.Repeat(coords.x, 32000);
        coords.z = Mathf.Repeat(coords.z, 32000);
        for (int a = 0; a < 8; a++)
            for (int b = 0; b < 8; b++)
            {
                if (Vector3.Distance(coords, new Vector3(colonna[a].riga[b].coordin.x+2000, coords.y, colonna[a].riga[b].coordin.z+2000)) < 3000) //2000 is an adjustment, feel free to change it
                {
                    center = colonna[a].riga[b];
                    for (int e = -2; e < 2; e++) //spawns 2 terrains in every direction, change to necessity
                        for (int j = -2; j < 2; j++)
                        {
                            poss = new Vector3(center.coordin.x - coords.x - (4000 * j), -500, center.coordin.z - coords.z + (4000 * e)); //4000 is the size of the terrains
                            if(GameObject.Find(colonna[(int)Mathf.Repeat(a + e, 8)].riga[(int)Mathf.Repeat(b + j, 8)].name)==null) //8 is the size of the rows and columns
                                Instantiate(colonna[(int)Mathf.Repeat(a + e, 8)].riga[(int)Mathf.Repeat(b + j, 8)], poss, Quaternion.identity).name = colonna[(int)Mathf.Repeat(a + e, 8)].riga[(int)Mathf.Repeat(b + j, 8)].name;
                        }
                }
            }
        //limit the camera position to the center by moving everything back
        if (Mathf.Abs(cam.transform.position.x) > 100 || Mathf.Abs(cam.transform.position.z) > 100) //everything snaps back when the camera is distance 100 from the center, change to necessity
        {
            Vector3 dir = new Vector3(cam.transform.position.x, 0, cam.transform.position.z);
            foreach (Transform tr in FindObjectsOfType<Transform>())
                if (tr.parent == null)
                    tr.position -= dir;
            transform.position += dir;
            coords += dir;           
        }
    }
}