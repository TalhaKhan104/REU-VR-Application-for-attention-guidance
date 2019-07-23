using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.IO;
public class FOVApplication : MonoBehaviour
{      
float eulerAngY;
float currentangle, Desiredangle, currentangleleft, Desiredangleleft ;
public float Inputangle, Inputangleleft;
float Threshold, Threshold2, Thresholdleft, Thresholdleft2;
bool triggeractivate, manualreturn, manualreturnleft, triggeractivateleft, AttentionGrabbercreator;
public GameObject Geometry, Geometryleft;
 public float speed = .03f, timer = 0, waittime = .25f, timerleft = 0, timer2 = 0, timerleft2 = 0;
 public Transform[] waypoints, waypointsleft;
 public int current, currentleft;
 public GameObject Attentiongrabberright,  clone, AttentionGrabberleft;
 public List<float> writelist = new List<float>();
 private string appendpath,appendpath2;
 public string ParticipantIDangle, ParticipantIDtime;
 StreamWriter sWriter, sWriter2;
    // Start is called before the first frame update
    void Start()
    {
        appendpath = Application.dataPath + ParticipantIDangle;
        appendpath2 = Application.dataPath + ParticipantIDtime;
        Attentiongrabberright.SetActive(false);
        AttentionGrabberleft.SetActive(false);
    }
    

    void Update () {
        eulerAngY = transform.localEulerAngles.y;
        //Left return button this pushes the filter on the right side back to the right position
        if( Input.GetButtonDown("Fire1")){
            Destroy(clone);

           currentleft = 1;
           manualreturnleft =true;
           Thresholdleft = 400f;
            Thresholdleft2 = 400f; 
            AttentionGrabbercreator = false;
            sWriter2 = new StreamWriter(appendpath2, append:true);
            sWriter = new StreamWriter(appendpath,append:true); 
            sWriter2.Write(",,Filter Moving Left Manually Returned MEDIUM\n,,");
             sWriter2.Write(timerleft2+"\n");
            
            sWriter2.Close();
             sWriter.Write(",,Filter Moving Left Manually Returned MEDIUM \n,,");
             for(int k=0; k< writelist.Count;k++ ){
                    sWriter.Write(writelist[k]+"\n,,");
                     }
            sWriter.Write("\n");
            sWriter.Close();
            writelist.Clear();
            timerleft2 = 0;
            timerleft = 0;
        }
            if( Input.GetButtonDown("Speedhalf")){
            speed = .015f;

        }
                if( Input.GetButtonDown("Speed1")){
            speed = .03f;

        }
                if( Input.GetButtonDown("Speeddouble")){
            speed = .06f;

        }
        //left filterstarter pushes the right side to the left
          if (Input.GetButtonDown("a"))
        {
            currentleft = 0;

            AttentionGrabbercreator = true;

            triggeractivateleft = true;
             manualreturnleft = false;
             currentangleleft = eulerAngY;
            Debug.Log(currentangleleft);
            Desiredangleleft = currentangleleft - Inputangleleft;
            Debug.Log(Desiredangleleft);      
         
            if(Desiredangleleft<0){
            Desiredangleleft = 360 + Desiredangleleft;
            }
          Thresholdleft = Desiredangleleft-15;
           Debug.Log("Threshold = " +Thresholdleft);
           Thresholdleft2 = Desiredangleleft+15;
           Debug.Log("Threshold2 = " +Thresholdleft2);     
        }


        //Right filter return pushes the left side filter back home
        if( Input.GetButtonDown("Fire2")){
            Destroy(clone);

          current = 1;
          manualreturn =true;
          AttentionGrabbercreator = false;
            Threshold = 400f;
            Threshold2 = 400f;   
            sWriter2 = new StreamWriter(appendpath2, append:true);
            sWriter = new StreamWriter(appendpath,append:true); 
             sWriter2.Write(",,,,,,,,Filter Moving Right Manually Returned MEDIUM\n,,,,,,,,");
            sWriter2.Write(timer2+"\n");
            sWriter.Write(",,,,,,,,Filter Moving Right Manually Returned MEDIUM\n,,,,,,,,");
            for(int k=0; k< writelist.Count;k++ ){
                    sWriter.Write(writelist[k]+"\n,,,,,,,,");
                     }
            sWriter.Write("\n");         
            writelist.Clear();
            sWriter.Close();
            sWriter2.Close();
            timer2 = 0;      
            timer =0;  
  
        }
        

        //right filter start pushed left side filter towards the right
          if (Input.GetButtonDown("Fire3"))
        {
            current = 0;
            AttentionGrabbercreator = true;
            triggeractivate = true;
            manualreturn = false;
            currentangle = eulerAngY;
            Debug.Log(currentangle);
            Desiredangle = currentangle + Inputangle;
            Debug.Log(Desiredangle);      
            if(Desiredangle>360){
                Desiredangle = Desiredangle-360 ;
       

        }      
        Threshold = Desiredangle-15;
        Debug.Log("Threshold = " +Threshold);
        Threshold2 = Desiredangle+15;
        Debug.Log("Threshold2 = " +Threshold2);
        }
    
    
        if(triggeractivate){
            //Left side filter is being pushed to the right
            float step =  speed * Time.deltaTime; // calculate distance to move

           if(!manualreturn){
           timer = timer+=Time.deltaTime;
           timer2 = timer2+=Time.deltaTime;
           }
           if(timer>= waittime){
               
                writelist.Add(item:eulerAngY);
                
               timer = timer-waittime;
           }
        Geometry.transform.position = Vector3.MoveTowards(Geometry.transform.position, waypoints[current].position, step);
        

        if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)){
            current = 1;
            timer2 = timer2-=Time.deltaTime;
            if(AttentionGrabbercreator){
            Attentiongrabberright.SetActive(true);
            clone = Instantiate(Attentiongrabberright, Attentiongrabberright.transform.position, Attentiongrabberright.transform.rotation);
            AttentionGrabbercreator = false;
            Attentiongrabberright.SetActive(false);
            }
            
            if(Vector3.Distance(Geometry.transform.position, waypoints[current].position) < 0.001f){
                triggeractivate = false;
                manualreturn = false;
                sWriter2 = new StreamWriter(appendpath2, append:true);
                sWriter = new StreamWriter(appendpath,append:true); 
                sWriter.Write(",,,,,,,,Righttrigger MEDIUM \n,,,,,,,,");
                for(int k=0; k< writelist.Count;k++ ){
                    sWriter.Write(writelist[k]+"\n,,,,,,,,");
                     }
                sWriter.Write("\n");
                
                sWriter2.Write(",,,,,,,,Time taken for user to turn right MEDIUM \n,,,,,,,,");

                sWriter2.Write(timer2+"\n");
                sWriter.Close();
                sWriter2.Close();
                writelist.Clear();
                timer2 = 0;
                timer = 0;
                
                Destroy(clone);
                }
      

           }
        
        else{
            if(!manualreturn){
            current = 0;
            }
            } 
              
            }
        if(triggeractivateleft){
        //right side filter is moving left
            if(!manualreturnleft){
            timerleft = timerleft+=Time.deltaTime;
            timerleft2 = timerleft2+=Time.deltaTime;
             }
            if(timerleft>= waittime){
               writelist.Add(item:eulerAngY);
               timerleft = timerleft-waittime;
           }
            float step =  speed * Time.deltaTime; // calculate distance to move
            Geometryleft.transform.position = Vector3.MoveTowards(Geometryleft.transform.position, waypointsleft[currentleft].position, step);
        

            if((eulerAngY>=Thresholdleft) && (eulerAngY < Thresholdleft2)){
            currentleft = 1;
            timerleft2 = timerleft2-=Time.deltaTime;

                if(AttentionGrabbercreator){
                AttentionGrabberleft.SetActive(true);
                clone = Instantiate(AttentionGrabberleft, AttentionGrabberleft.transform.position, AttentionGrabberleft.transform.rotation);
                AttentionGrabbercreator = false;
                AttentionGrabberleft.SetActive(false);
                }
                if(Vector3.Distance(Geometryleft.transform.position, waypointsleft[currentleft].position) < 0.001f){
                    triggeractivateleft = false;
                
                    manualreturnleft = false;
                   sWriter2 = new StreamWriter(appendpath2, append:true);
                    sWriter = new StreamWriter(appendpath,append:true); 
                    sWriter.Write(",,Lefttrigger MEDIUM \n,,");
                    for(int k=0; k< writelist.Count;k++ ){
                    sWriter.Write(writelist[k]+"\n,,");
                        }
                    sWriter.Write("\n");
                
                    sWriter2.Write(",,Time taken for user to turn left MEDIUM\n,,");

                    sWriter2.Write(timerleft2+"\n");
                    sWriter.Close();
                    sWriter2.Close();
                    writelist.Clear();
                    timerleft2 = 0;
                    Destroy(clone);
                    }
           }
        
            else{
                if(!manualreturnleft){
                currentleft = 0;
                }
                } 
              
                
         }
        }
}
     

