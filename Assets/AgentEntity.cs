using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomRigid))]
public class AgentEntity : MonoBehaviour
{
    CustomRigid custRigid;
    Hitdata hitdata;
    
    void Start()
    {
        custRigid = GetComponent<CustomRigid>();
   
    }
    // Update is called once per frame
    void Update()
    {
        
    }





    void OnHurtEvent(Hitdata hitData)
    {
     
        
    }
}



