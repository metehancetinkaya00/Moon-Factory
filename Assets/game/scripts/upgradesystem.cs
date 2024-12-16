using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class upgradesystem : MonoBehaviour
{
    public int cost, decraese;
    [SerializeField] private TextMeshPro costtext;
    public stacksystem systemstack;
    [SerializeField] public Transform objpos;
    [SerializeField] public AnimationCurve OutBbounce;
    public GameObject[] unlocks;
    [SerializeField] public List<Transform> oillist;
    //  Transform othertransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        costtext.text = "" + cost;

        if (cost <= 0)
        {
            // animator.SetBool("run", true);
            unlocks[0].SetActive(true);
            Destroy(this.gameObject);
            unlocks[1].SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

       


        if (other.gameObject.tag == "dropbar")
        {

            cost --;

        }


       
    }

   
        
    
}
   


    





