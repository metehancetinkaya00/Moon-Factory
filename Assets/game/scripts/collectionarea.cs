using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class collectionarea : MonoBehaviour
{

    [SerializeField] public Transform[] objectplace;
    // public oblist[] TestWithArray = new oblist[20];
    [SerializeField] private GameObject objectt;
    private GameObject newspawn;
    [SerializeField] public float yaxis, spawnlimit;
    public int objectindex = 0;
    public int spawncount = 0;
    [SerializeField] public List<Transform> lisadd;
    public float waittime;
    public int allobj, queue;
    public bool trfls;
    // public List<Transform[]> placelist=new List<Transform[]>();


    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < objectplace.Length; i++)
        {
            objectplace[i] = transform.GetChild(0).GetChild(i);



        }

        // 
    }
    
    private void LateUpdate()
    {

    }
    private void Update()
    {

        if (trfls == true)
        {
            StartCoroutine(barrel());
        }

        if (objectindex < objectplace.Length)
        {
            trfls = true;
        }
        else
        {
            objectindex = 0;
            trfls = false;
        }






        // Update is called once per frame

        // if (allobj < 20)


    }
    public IEnumerator barrel()
    {



        // for (queue = 0; queue < objectplace.Length; queue++)

        //    wt = waittime;
        if (objectindex < objectplace.Length)
        {

            if (objectplace[objectindex].childCount == 0)
            {
                //  objectindex = queue;



                if (objectindex < objectplace.Length)
                {

                    newspawn = Instantiate(objectt, new Vector3(transform.position.x, -3, transform.position.z), Quaternion.identity, transform.parent);
                    newspawn.transform.DOJump(new Vector3(objectplace[objectindex].position.x, objectplace[objectindex].position.y + yaxis,
                        objectplace[objectindex].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);
                    newspawn.transform.parent = objectplace[objectindex];
                    //  objectplace[objectindex].name = "spawnbar";
                    // newspawn.transform.parent = objectplace[objectindex];
                    lisadd.Add(newspawn.transform);
                }


            }
            else
            {
                objectindex++;

            }
            //





        }

        yield return new WaitForSeconds(waittime);
        //    movelistelement();


    }

  
    }

        



    


    
    

        
      
        




   

   



