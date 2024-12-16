using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class brickspawn : MonoBehaviour
{
    [SerializeField] public Transform[] objectplace;
    public int cost, decraese, objectindex;
    [SerializeField] private TextMeshPro costtext;
    public stacksystem systemstack;
    // [SerializeField] public Transform objpos;
    [SerializeField] public AnimationCurve OutBbounce;
    private GameObject newspawn;
    [SerializeField] public List<Transform> lisst;
    [SerializeField] private GameObject objectt;
    public float waittime;
    public BoxCollider colder;
    public stacksystem stck;
    //  Transform othertransform;
    private void Start()
    {
        for (int i = 0; i < objectplace.Length; i++)
        {
            objectplace[i] = transform.GetChild(0).GetChild(i);



        }

    }

    void Update()
    {
       
        if(lisst.Count<5)
        {
          //  colder.enabled = true;
            if (cost==0)
            {
                StartCoroutine(spawntime());
                cost = 5;
            }
        }
        if (lisst.Count == 4)
        {
         
          //  colder.enabled = false;
        }
        if (lisst.Count ==4)
        {
            stck.isdrop = false;
            costtext.text = "FULL";
            gameObject.tag = "Untagged";
            gameObject.name = "empty";
        }
        else
        {
            stck.isdrop = true;
            costtext.text = "" + cost;
            gameObject.tag = "area";
            gameObject.name = "areabarrel";
        }

    }
    public IEnumerator spawntime()
    {
      

            
                //  objectindex = queue;



               


                    yield return new WaitForSeconds(waittime);

                    newspawn = Instantiate(objectt, new Vector3(transform.position.x, -3, transform.position.z), Quaternion.identity, transform.parent);
                    newspawn.transform.DOJump(new Vector3(objectplace[objectindex].position.x, objectplace[objectindex].position.y,
                        objectplace[objectindex].position.z), 2f, 1, 1f).SetEase(Ease.OutBounce);
                    newspawn.transform.parent = objectplace[objectindex];
        newspawn.transform.localRotation = Quaternion.Euler(0, 0, 90);
        //  objectplace[objectindex].name = "spawnbar";
        // newspawn.transform.parent = objectplace[objectindex];
        lisst.Add(newspawn.transform);
             

            objectindex++;
        
   
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="dropbar")
        {
            cost--;
        }



    }

       


    
}
