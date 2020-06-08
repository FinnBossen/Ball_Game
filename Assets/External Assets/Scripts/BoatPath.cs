using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quelle: quill18creates https://www.youtube.com/watch?v=b7DZo4jA3Jo 01.07.2018
public class BoatPath : MonoBehaviour {

    GameObject pathGO;
    public Renderer rend;

    Transform targetPathNode;
    int pathNodeIndex = 0;

    float speed = 5f;
   public GameObject leftTrigger;
    public GameObject rightTrigger;
    boatfloatleft leftTriggerCtrl;
    boatfloatright rightTriggerCtrl;
    public bool rotates = true;
    public bool wall = false;

  

    void Start()
    {
        rend = gameObject.GetComponentInChildren<Renderer>();
        rend.enabled = false;
        pathGO = GameObject.Find(gameObject.transform.name + " Path");
    }

    void GetNextPathNode()
    {
        if (pathNodeIndex < pathGO.transform.childCount)
        {
           
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            targetPathNode = null;
            ReachedGoal();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPathNode == null)
        {
            rend.enabled = true;
            GetNextPathNode();
            if (targetPathNode == null)
            {
                // We've run out of path!
                ReachedGoal();
                return;
            }
        }

        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            // We reached the node
            targetPathNode = null;
        }
        else
        {
            // TODO: Consider ways to smooth this motion.

            // Move towards node
            transform.Translate(dir.normalized * distThisFrame, Space.World);


            if (rotates)
            {
                Quaternion targetRotation = Quaternion.LookRotation(dir);

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);
                 }
   


        }

    }

    void ReachedGoal()
    {
        Destroy(this);
        Destroy(leftTrigger);
        Destroy(rightTrigger);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "invisiblewall")
        {
            wall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "invisiblewall")
        {
            wall = false;
        }
    }



}
