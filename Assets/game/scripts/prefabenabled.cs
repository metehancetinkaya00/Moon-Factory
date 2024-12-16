using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class prefabenabled : MonoBehaviour
{
    public BoxCollider colliderr;
    public bool iswaitactive;
   [SerializeField] public bool isactive,drop,isinmachine;
    public float waittime;
    public float waitforactive;
    public stacksystem stck;
    public bool isplayer;
    public collectionarea colar;
    public bool isstart;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "destroyer")
        {
            Destroy(gameObject);
        }
            if (other.gameObject.tag=="Player")
        {
           

            if(isinmachine==true)
            {
            //    colar.allobj -= 1;
                colar.objectindex = 0;
                gameObject.name = "drop";
                trg();
            }
           if(isstart==true)
            {
                gameObject.name = "drop";
            }
       
        }
        if (other.gameObject.name == "launchunlock")
        {
            // isdrop = false;
            Destroy(gameObject);

        }
        if (other.gameObject.name == "oilunlock")
        {
            // isinarea = true;
            // isdrop = false;
           Destroy(gameObject);
        }
        if (other.gameObject.tag == "area")
        {
            Destroy(gameObject);
        }
        }

    public void issactive()
    {
       // stck.otherpos = transform.position;
        //  rb.isKinematic = false;
        transform.DOMove(new Vector3(stck.otherpos.position.x, stck.otherpos.position.y, stck.otherpos.position.z), 0.4f).SetEase(stck.OutBbounce);
       
        // gameObject.tag = "dropingoil";
       // yield return new WaitForSeconds(waitforactive);
        colliderr.enabled = true;
    
      //  yield return new WaitForSeconds(waitforactive);
      //  Destroy(gameObject);

    }
    public void trg()
    {

        for (int i = 0; i < colar.lisadd.Count; i++)
        {


            foreach (Transform pickupbar in colar.lisadd.ToArray())
            {
                if (pickupbar.gameObject.name == "drop")
                {
                   // colar.objectindex = 0;
                    //  pickupbar.SetParent(null);
                    colar.lisadd.Remove(pickupbar.gameObject.transform);
                    colar.objectindex = colar.lisadd.Count ;
                }
            }
        }
    }
        public IEnumerator spawn()
    {

      //  gameObject.tag = "dropingoil";

        colliderr.enabled = false;
        yield return new WaitForSeconds(waittime);
        colliderr.enabled = true;
        iswaitactive = false;

    }
        

    }
