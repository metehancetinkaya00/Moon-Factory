using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
public class stacksystem : MonoBehaviour
{
    Transform othertransform;
    [SerializeField]   public Transform otherpos;
    public Animator animator;
  //  public upgradesystem systemupgrade;
//[SerializeField]  public  Transform pickupbar;
[SerializeField] Transform stackposition;
[SerializeField] public List<Transform> Pickuplist;
private Vector3 newpos;
[SerializeField] public AnimationCurve OutBounce;
//public Vector3 droposwood;
//public Vector3 droposoil;
    //  public Transform droppositionwood;
    // public Transform droppositiongold;
    public joysticksystem controllerjoystick;
    [SerializeField] public float speed;
[SerializeField] public float delay;
//public upgradesystem upgrader;
    [SerializeField] public AnimationCurve OutBbounce;
    public bool isdrop;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Pickuplist = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown("f"))
        {
            Time.timeScale = 1;
        }
   
        //  updatestacks();
    //    movelistelement();
    }
    private void FixedUpdate()
    {
        movelistelement();
        animationmotions();
    }
    public void animationmotions()
    {
        if (controllerjoystick.isrunning == true)
        {
            animator.SetBool("idle", false);

        }
        if (controllerjoystick.isrunning == false)
        {
            animator.SetBool("idle", true);

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "barrel")
        {

             othertransform = other.transform;

            Rigidbody otherrb = othertransform.GetComponent<Rigidbody>();
            //othertransform.DOJump(stackposition.position, 2f, 2, 2).onComplete(
          
            otherrb.isKinematic = true;
            other.enabled = false;
            othertransform.parent = stackposition;
          //  othertransform.GetComponent<prefabenabled>().isactive=false;
            othertransform.transform.localRotation = Quaternion.Euler(90, 90, 0);
            // othertransform.transform.localScale = new Vector3(1, 0.3f, 0.5f);
            Pickuplist.Add(othertransform);
            
            //  othertransform.DOJump(stackposition.position, 1f, 1, 1).OnComplete(() =>

            othertransform.localPosition = (Pickuplist.Count - 1) * Vector3.up * 0.4f;
            //   updatestack();
            //
       
        }
       

        if (other.gameObject.name == "areabarrel" )
        {
            otherpos = other.transform;
            if (Pickuplist.Count > 0)
            {
                isdrop = true;
                if (isdrop == true)
                {


                    StartCoroutine(barrel());
                }
              
                // droposgold = coinner.objectplace[coinner.objectindex].position;
              
           

            }
            else
            {
                otherpos = null;
               return;
            }

           
        }

        if (other.gameObject.name == "areabrick")
        {
            otherpos = other.transform;
            if (Pickuplist.Count > 0)
            {
                isdrop = true;
                if (isdrop == true)
                {


                    StartCoroutine(brick());
                }

            }
            else
            {
                otherpos = null;
                return;
            }


        }
      


    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "area")
        {
            otherpos = null;
            isdrop = false;


        }
       

    }
    public void movelistelement()
    {

        for (int i = 1; i < Pickuplist.Count; i++)
        {


            for (int j = 0; j < Pickuplist.Count; j++)
            {

                Vector3 pos = Pickuplist[i].transform.localPosition;
                pos.y = Pickuplist[i - 1].transform.localPosition.y;
                Pickuplist[j].transform.localPosition = new Vector3(0, j * 0.4f);

                // Pickuplist[j].transform.localPosition = (Pickuplist.Count - 1)*Vector3.up * 0.4f;
                //  getpickupcoin();


            }

        }

    }
   
    public IEnumerator barrel()
    {

      

      
        for (int i = 0; i < Pickuplist.Count; i++)
        {
       

            foreach (Transform pickupbar in Pickuplist.ToArray())
            {
                if (pickupbar.gameObject.name == "drop")
                {

                  
                    if (isdrop == true)
                    {
                        yield return new WaitForSeconds(delay);
                        pickupbar.GetComponent<prefabenabled>().issactive();
                        //    otherpos.GetComponent<upgradesystem>().oildropper();

                        // pickupbar = pickupbarr;
                        pickupbar.tag = "dropbar";
                        //   pickupbar.GetComponent<stacksystem>().enabled = true;
                        //  StartCoroutine(upgrader.oill());
                        pickupbar.transform.rotation = Quaternion.Euler(0, 270, 0);
                    
                    //if (pickupgold.gameObject.name == "coin")
                    //{
                    pickupbar.transform.DORotate(new Vector3(0, 40, 0), 1, RotateMode.FastBeyond360);
                      //  pickupbar.name = "barrel";
                   Pickuplist.Sort(delegate (Transform a, Transform b)
                    {

                        return Vector3.Distance(pickupbar.transform.position, a.transform.position)
                        .CompareTo(Vector3.Distance(pickupbar.transform.position, b.transform.position));
                    });



                        if (pickupbar == null)
                        {
                            yield return null;

                        }

                        pickupbar.SetParent(null);
                      
                    Pickuplist.Remove(pickupbar);
                    
                
                        pickupbar.GetComponent<prefabenabled>().drop = true;
                       
                   
                    movelistelement();
                     

              

                    }



            }
        }
        }
    }

   
    public IEnumerator brick()
    {

        for (int i = 0; i < Pickuplist.Count; i++)
        {
            // coinner.wood();

            foreach (Transform pickupbrick in Pickuplist.ToArray())
            {

                //if (pickupgold.gameObject.name == "coin(Clone)")
                //{
                if (pickupbrick.gameObject.name == "dropbrick")
                {



                    if (isdrop == true)
                    {
                        yield return new WaitForSeconds(delay);
                        pickupbrick.GetComponent<prefabenabledbrick>().issactive();
                        //    otherpos.GetComponent<upgradesystem>().oildropper();

                        // pickupbar = pickupbarr;
                        pickupbrick.tag = "dropbar";
                        //   pickupbar.GetComponent<stacksystem>().enabled = true;
                        //  StartCoroutine(upgrader.oill());
                        pickupbrick.transform.rotation = Quaternion.Euler(0, 0, 0);

                        //if (pickupgold.gameObject.name == "coin")
                        //{
                        pickupbrick.transform.DORotate(new Vector3(0, 0, 0), 1, RotateMode.FastBeyond360);
                        //  pickupbar.name = "barrel";
                        Pickuplist.Sort(delegate (Transform a, Transform b)
                        {

                            return Vector3.Distance(pickupbrick.transform.position, a.transform.position)
                            .CompareTo(Vector3.Distance(pickupbrick.transform.position, b.transform.position));
                        });



                        if (pickupbrick == null)
                        {
                            yield return null;

                        }

                        pickupbrick.SetParent(null);

                        Pickuplist.Remove(pickupbrick);


                        pickupbrick.GetComponent<prefabenabledbrick>().drop = true;


                        movelistelement();




                    }



                }
            }
                
            }
    }
   
    public void updatestack()
    {
        for (int i = 0; i < Pickuplist.Count; i++)
        {
           
                // coinner.wood();

                foreach (Transform pickupbar in Pickuplist.ToArray())
                {

                    //if (pickupgold.gameObject.name == "coin(Clone)")
                    //{
                    if (pickupbar.gameObject.tag == "barrel")
                    {

                        pickupbar.transform.DOLocalRotate(new Vector3(0, 0, 90), 1, RotateMode.FastBeyond360);

                        Pickuplist.Sort(delegate (Transform a, Transform b)
                        {


                            return Vector3.Distance(pickupbar.transform.position, a.transform.position)
                                .CompareTo(Vector3.Distance(pickupbar.transform.position, b.transform.position));

                        });

                    }
                }
            }
        
       }
    /*
        public void updatestacks()
    {


        for (int i = 1; i < Pickuplist.Count - 1; i++)
        {
            Pickuplist[i] = Pickuplist[i - 1];

        }


    }
    */

}
