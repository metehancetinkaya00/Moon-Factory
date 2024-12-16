using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class rocketmove : MonoBehaviour
{
    [SerializeField] public AnimationCurve finish;
    [SerializeField] public AnimationCurve start;
    public ParticleSystem particle;
    public bool ismovve;
   public camerascript camscpt;
    public Transform startpos,finalpos;
    public GameObject systemjoy;
    public GameObject finishimg;

    // Start is called before the first frame update
    void Start()
    {
        particle.Play();
        transform.DOMove(new Vector3(startpos.position.x, startpos.position.y, startpos.position.z), 1.5f).SetEase(start).OnComplete(() =>
        {
            particle.Pause();
        });
    
    }
    private void FixedUpdate()
    {
        if (ismovve == true)
        {
            systemjoy.SetActive(false);
            finishimg.SetActive(true);
            camscpt.target.gameObject.SetActive(false);

            camscpt.roty = 30;
            camscpt.offset.y = 10f;
            camscpt.offset.z = -15f;
            particle.Play();
            enabled = false;
            transform.DOMove(new Vector3(finalpos.position.x, finalpos.position.y, finalpos.position.z), 3f).SetEase(start);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ismovve = true;
        }
    }
 
}
