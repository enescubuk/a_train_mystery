using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastController : MonoBehaviour
{
    private LayerMask targetLayer;
    public List<GameObject> currentHits = new List<GameObject>();
    public GameObject nearestObject;
    public SOInventory playerInventory;
    
    void Start()
    {
        targetLayer = LayerMask.GetMask("Raycastable");
        addingListWithTag();
    }
    void addingListWithTag()
    {
        currentHits.RemoveRange(0,currentHits.Count);
        foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("Collectable")) 
        {
            currentHits.Add(fooObj);
        }
    }
    void Update()
    {
        if (nearestObject != null)
        {
            nearestObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius,targetLayer);
        foreach (Collider hitObject in hitColliders)
        {
            if (nearestObject != null)
            {
                nearestObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            GetClosestObject();
            nearestObject.transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                collectObject();
            }
        }
        
    }

    private void collectObject()
    {
        if (nearestObject.CompareTag("Collectable"))
        {
            playerInventory.addItem(nearestObject.GetComponent<Item>().item);
            currentHits.Remove(nearestObject);
            Destroy(nearestObject);

        }
    }

    void GetClosestObject()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in currentHits)
        {
            float distance = Vector3.Distance(t.transform.position, currentPos);
            if (distance < minDist)
            {
                tMin = t.transform;
                minDist = distance;
            }
        }
        nearestObject = tMin.gameObject;
    }

    void activeSelectMark(Transform hitObject)
    {
        Debug.Log(hitObject.gameObject.name);
        
        hitObject.GetChild(0).gameObject.SetActive(true);
    }
}
