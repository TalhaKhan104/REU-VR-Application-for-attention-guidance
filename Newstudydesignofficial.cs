//PLEASE READ THIS IF YOU ARE TRYING TO UNDERSTAND AND MODIFY MY CODE..

//To whoever opens this code if any. Most of the variable declarations have been made in order, If you need to get to a variable thats in update, the variables are delared in the order they're used in update.
//biggest problem with the code: so first im gonna explain the code alittle. first, the participant sees the stroop test a number of times, that number can be changed by the variables "letterstoappear" so if you set it to 2,
//the participant will see 2 stroop tests. After those two, the filter will enter based on the Between timer variable, after between timer is defined, things such as data collection, turn cases, and cases where the participant doesnt turn
// are handled. The function that makes the filter move is always active. I put it in the first few lines of update its called move towards. There are also control cases where there will be a break between stroop tests and no filter will appear
// If the participant movs either left or right the amount of degrees defined by the variable "Input angle" and "Input angle Left" then another stroop test will appear in that area. So, During variable declaration, i made anything that moved to the left labeled explicitly with left at the end
// Anything moving right doesnt have a label and is just the name of the variable, as you have seen with input angle. The code as of now runs the stroop variant, then the filter enters on the RIGHT side but MOVES left. the stroop test will appear again after the filter is out of the screen and
//the control case will appear after letterstoappear2 has been surpassed. Then, the same concept will happen except the filter on the LEFT side will MOVE right. After that there will be a control, another filter MOVING right
//another control, filter moving left, and then one more control and the study is over. If you're making modifications, here is the problem i mentioned earlier. When i got to "activatenextset2"The numbering of the variable got messed up
// essentially, 3 and 4 are for one filter setting, 5 and 6 are also together, and then after 5 and 6, everything got fixed, so everything pertaining to the 7th filter test is labelled with 7 and that stays true until the end. Final notes, i initialized most of the noturn variables because i wanted
//that portion of the code to only work for one frame, this was usually done to write data only once. "Timeletterisactive" is user controlled and is essentially the amount of time that the participant sees the stroop test
//Finally when you play the scene, clicking the button "a" will activate the study, from there, you shouldn't need to do anything else. Some changes that i recommend, make the stroop test that appears if the participant moves
//away from the filter something different. Make it something special, otherwise participants dont feel motivated to move, they just keep seeing the boring stroop test over and over again. That being said, im sorry if you cant understand my code:( goodluck!!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Newstudydesignofficial : MonoBehaviour
{    int[] Randomtimearray;public float speed, coverage = .16f, t = 5;float eulerAngY;    public GameObject Geometry, Geometryleft, LetterObject;  public Transform[] waypointsmovingright, waypointsmovingleft;
    public GameObject[]  letters;    private int RandomLetter,Randomtimeforbreakindex, Randomtimeforbreak = 50;    float Threshold, Threshold2, Thresholdleft, Thresholdleft2;
    private string appendpath,appendpath2;public int current, currentleft;  
      float currentangle, Desiredangle, currentangleleft, Desiredangleleft ;
    public float Inputangle, Inputangleleft;
    public string ParticipantIDturndata, ParticipantIDtime;
    StreamWriter sWriter, sWriter2; 
    
    
    
   
    public float timer, timerbreak = 0, Betweentimer,timerfordata,specialtimer, timerrbreak;
     public float  timer2,timerbreak2,     Betweentimer2,timerfordata2, specialtimer2, timerrbreak2;
     public float timer3, timerbreak3,Betweentimer4,timerfordata4,specialtimer4,timerrbreak4; 

      
      public float timer5,timerbreak5;
    public float Betweentimer6,timerfordata6,specialtimer6,timerrbreak6 ; 
   
    
   
   
    


     public float timer7, timerbreak7 = 0, Betweentimer7,timerfordata7,specialtimer7, timerrbreak7;
     public float  timer8,timerbreak8,     Betweentimer8,timerfordata8, specialtimer8, timerrbreak8;
     public float timer9, timerbreak9,Betweentimer9,timerfordata9,specialtimer9,timerrbreak9; 

      
      public float timer10,timerbreak10;
    public float Betweentimer10,timerfordata10,specialtimer10,timerrbreak10 ; 
   
    



    

bool activatenextset,timeractivate2,timerbreakactivate2 = false,activatefilterbreak2 = false,filterinitialize2 = true ,   writedataright2,writedataleft2, activatetimerfordata2 = true,Activatespecial2, activatespecialtimer2,  activatenextsetbreak2;      int Count2  = 1;
   bool  begin,timeractivate = false,timerbreakactivate= false, activatefilterbreak, filterinitialize = true,writedata, activatetimerfordata = true,noturn = true,Activatespecial= false, activatespecialtimer= false,activatenextsetbreak; int Count = 1;
    
bool activatenextset2,timeractivate3, timerbreakactivate3,  activatefilterbreak4,filterinitialize4 = true, writedata4, activatetimerfordata4,  noturn4 = true,  Activatespecial4, activatespecialtimer4, activatenextsetbreak4;int Count3 = 1; 

 
 bool activatenextset5,timeractivate5,timerbreakactivate5,activatefilterbreak6,filterinitialize6 = true,writedataright6, writedataleft6, activatetimerfordata6,Activatespecial6,activatespecialtimer6, activatenextsetbreak6; int Count5 = 1; 
 bool  activatenextset7,timeractivate7 = false,timerbreakactivate7= false, activatefilterbreak7, filterinitialize7 = true,writedata7, activatetimerfordata7 = true,noturn7 = true,Activatespecial7= false, activatespecialtimer7= false,activatenextsetbreak7; int Count7 = 1;
bool activatenextset8,timeractivate8,timerbreakactivate8 = false,activatefilterbreak8 = false,filterinitialize8 = true ,   writedataright8,writedataleft8, activatetimerfordata8 = true,Activatespecial8, activatespecialtimer8,  activatenextsetbreak8;      int Count8  = 1;

    bool activatenextset9,timeractivate9, timerbreakactivate9,  activatefilterbreak9,filterinitialize9 = true, writedata9, activatetimerfordata9,  noturn9 = true,  Activatespecial9, activatespecialtimer9, activatenextsetbreak9;int Count9 = 1; 

 
 bool activatenextset10,timeractivate10,timerbreakactivate10,activatefilterbreak10,filterinitialize10 = true,writedataright10, writedataleft10, activatetimerfordata10,Activatespecial10,activatespecialtimer10, activatenextsetbreak10; int Count10 = 1; 


    bool noturn2 = true, noturn6 = true, noturn8 = true, noturn10 = true;

   

    public int  timeletterisactive1, timeletterisactive2, letterstoappear2, letterstoappear, letterstoappear4,letterstoappear6,  timeletterisactive4, timeletterisactive6;
 public int  timeletterisactive7, timeletterisactive8, letterstoappear8, letterstoappear7, letterstoappear9,letterstoappear10,  timeletterisactive10, timeletterisactive9;





    
   
   
    

    



    

    // Start is called before the first frame update
    void Start()
    {   
        appendpath = Application.dataPath + ParticipantIDturndata;
        appendpath2 = Application.dataPath + ParticipantIDtime;
        speed = coverage/t;
        Randomtimearray = new int[]{1,2,3};

        begin = false;
        current = 1;
        currentleft = 1;
        sWriter2 = new StreamWriter(appendpath2, append:true);
        sWriter = new StreamWriter(appendpath,append:true); 
        sWriter2.Write("Control Left,,15%left,,25%left,,Control Right,,15%Right,,25%Right,,Control no turn\n");
        sWriter2.Close();
        sWriter.Write("Control Left,,15%left,,25%left,,Control Right,,15%Right,,25%Right,,Control no turn\n");
        sWriter.Close();
    }

    // Update is called once per frame
    void Update()
    {    float step =  speed * Time.deltaTime; // calculate distance to move
        Geometryleft.transform.position = Vector3.MoveTowards(Geometryleft.transform.position, waypointsmovingleft[currentleft].position, step);
        Geometry.transform.position = Vector3.MoveTowards(Geometry.transform.position, waypointsmovingright[current].position, step);
        eulerAngY = transform.localEulerAngles.y;

         if (Input.GetButtonDown("a")){
             begin = true;
         }
        //Left return button this pushes the filter on the right side back to the right position
        if(begin){ 
            timeractivate = true; 
            RandomLetter = Random.Range(0,letters.Length);
            Randomtimeforbreakindex = Random.Range(0,Randomtimearray.Length);
            Randomtimeforbreak = Randomtimearray[Randomtimeforbreakindex];
            LetterObject = letters[RandomLetter];
            LetterObject.SetActive(true);
            begin = false;
        }
        if(timeractivate){
            timer = timer+=Time.deltaTime;
        }
        if(timer>=timeletterisactive1){
            LetterObject.SetActive(false);
            timer = 0;
            timeractivate = false;
            timerbreakactivate = true;
        }
        if(timerbreakactivate){
            timerbreak = timerbreak+=Time.deltaTime;
        }
        if(timerbreak>=Randomtimeforbreak){
            Count++;
            
            timerbreak = 0;
            timerbreakactivate = false;
            if(Count<=letterstoappear){
                begin = true;
            }
            if(Count>letterstoappear){
                activatefilterbreak = true;
                Count = 0;
            }
        }
        if(activatefilterbreak){
            Betweentimer = Betweentimer+=Time.deltaTime;
            if((Betweentimer>=3) && filterinitialize){
                currentleft = 0;
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
                filterinitialize = false;  
                writedata = true;
            }
            if((Betweentimer>=3) && (!filterinitialize)){
                
                if(activatetimerfordata){
                    timerfordata = timerfordata +=Time.deltaTime;
                }

                if((Betweentimer>=11) && (!((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2)))){
                    currentleft = 1;
                    activatetimerfordata = false;
                    Thresholdleft = 400f;
                    Thresholdleft2 = 400f;
                    if(noturn){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,");
                        sWriter2.Write(timerfordata + "\n" );
                        sWriter2.Close();
                        sWriter.Write(",,,,0\n");
                        sWriter.Close();
                        noturn = false;
                        activatefilterbreak = false;
                        activatenextset = true;
                        Betweentimer = 0;
                        timerfordata = 0;
                
                    }
                  

                }  
                if((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2)){
                   
                    if((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2) && (writedata)){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,");
                        sWriter2.Write(timerfordata +"\n");
                        sWriter2.Close();
                        sWriter.Write(",,,,1\n");
                        sWriter.Close();
                        timerfordata = 0;
                        currentleft = 1;
                        writedata = false;
                        activatetimerfordata = false;
                        Activatespecial = true;
                        noturn = false;
                    }
                }    
                if(Activatespecial){
                    RandomLetter = Random.Range(0,letters.Length);
                    LetterObject = letters[RandomLetter];
                    LetterObject.SetActive(true);
                    Activatespecial = false;
                    activatespecialtimer = true;
                }
                if(activatespecialtimer){
                    specialtimer = specialtimer+=Time.deltaTime;
                }
                if(specialtimer>=timeletterisactive1){
                    LetterObject.SetActive(false);
                    specialtimer = 0;
                    activatespecialtimer = false;
                    activatefilterbreak = false;
                    Betweentimer = 0;
                    activatenextsetbreak = true;

                }
                    

                
                

            

         }
         

             


             
         }
        if(activatenextsetbreak){
            timerrbreak = timerrbreak += Time.deltaTime;
        }
        if(timerrbreak>Randomtimeforbreak){
            timerrbreak = 0;
            activatenextsetbreak = false;
            activatenextset = true;
        }
        if(activatenextset){
            RandomLetter = Random.Range(0,letters.Length);
            Randomtimeforbreakindex = Random.Range(0,Randomtimearray.Length);
            Randomtimeforbreak = Randomtimearray[Randomtimeforbreakindex];
            LetterObject = letters[RandomLetter];
            LetterObject.SetActive(true);
            timeractivate2 = true;
            activatenextset = false;
        }
        if(timeractivate2){
            timer2 = timer2+=Time.deltaTime;
        }
        
        if(timer2>=timeletterisactive2){
            LetterObject.SetActive(false);
            timer2 = 0;
            timeractivate2 = false;
            timerbreakactivate2 = true;
        }
        if(timerbreakactivate2){
            timerbreak2 = timerbreak2+=Time.deltaTime;
        }
        if(timerbreak2>=Randomtimeforbreak){
            Count2++;
            
            timerbreak2 = 0;
            timerbreakactivate2 = false;
            if(Count2<=letterstoappear2){
                activatenextset = true;
            }
            if(Count2>letterstoappear2){
                activatefilterbreak2 = true;
                Count2 = 0;

            }
        }
        if(activatefilterbreak2){
            Betweentimer2 = Betweentimer2+=Time.deltaTime;
            if((Betweentimer2>=3) && filterinitialize2){
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
        
                filterinitialize2 = false;  
                writedataright2 = true;
                writedataleft2 = true;

            }
            
            if((Betweentimer2>=3) && (!filterinitialize2)){
                
                if(activatetimerfordata2){
                    timerfordata2 = timerfordata2 +=Time.deltaTime;
                }

                if((Betweentimer2>=8) && (!((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2))) && (!((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)))){
                    if(noturn2){
                        activatetimerfordata2 = false;
                        Thresholdleft = 400f;
                        Thresholdleft2 = 400f;
                        Threshold = 400f;
                        Threshold2 = 400f;
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,,,,,,," + timerfordata2 + "\n" );
                        sWriter2.Close();
                        sWriter.Write(",,,,,,,,,,,,0\n");
                        sWriter.Close();
                    
                    
                    
                        activatefilterbreak2 = false;
                        activatenextset2 = true;
                        Betweentimer2 = 0;
                        timerfordata2 = 0;
                    }
                }
                  
                if((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2)){
                   
                    if(writedataleft2){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(timerfordata2 +"\n");
                        sWriter2.Close();
                        sWriter.Write("1\n");
                        sWriter.Close();
                        timerfordata2 = 0;
                        writedataleft2 = false;
                        activatetimerfordata2 = false;
                        Activatespecial2 = true;
                        noturn2 = false;
               

            
                    }
                }
                if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)){
                  
                    if(writedataright2){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,");
                        sWriter2.Write(timerfordata2 +"\n");
                        sWriter2.Close();
                        sWriter.Write(",,,,,,1\n");
                        sWriter.Close();
                        timerfordata2 = 0;
                        writedataright2 = false;
                        activatetimerfordata2 = false;
                        Activatespecial2 = true;
                        noturn2 = false;
                    } 
                }   
                if(Activatespecial2){
                    RandomLetter = Random.Range(0,letters.Length);
                    LetterObject = letters[RandomLetter];
                    LetterObject.SetActive(true);
                    Activatespecial2 = false;
                    activatespecialtimer2 = true;
                }
                if(activatespecialtimer2){
                    specialtimer2 = specialtimer2+=Time.deltaTime;
                }
                if(specialtimer2>=timeletterisactive2){
                    LetterObject.SetActive(false);
                    specialtimer2 = 0;
                    activatespecialtimer2 = false;
                    activatefilterbreak2 = false;
                    Betweentimer2 = 0;
                    activatenextsetbreak2 = true;

                }
                    

                
                

            

        
        }
        }
        if(activatenextsetbreak2){
            timerrbreak2 = timerrbreak2 += Time.deltaTime;
        }
        if(timerrbreak2>2){
            timerrbreak2 = 0;
            activatenextsetbreak2 = false;
            activatenextset2 = true;
        } 
        if(activatenextset2){
            RandomLetter = Random.Range(0,letters.Length);
            Randomtimeforbreakindex = Random.Range(0,Randomtimearray.Length);
            Randomtimeforbreak = Randomtimearray[Randomtimeforbreakindex];
            LetterObject = letters[RandomLetter];
            LetterObject.SetActive(true);
            timeractivate3 = true;
            activatenextset2 = false;
        }
        if(timeractivate3){
            timer3 = timer3+=Time.deltaTime;
        }
        
        if(timer3>=timeletterisactive4){
            LetterObject.SetActive(false);
            timer3 = 0;
            timeractivate3 = false;
            timerbreakactivate3 = true;
        }
        if(timerbreakactivate3){
            timerbreak3 = timerbreak3+=Time.deltaTime;
        }
        if(timerbreak3>=Randomtimeforbreak){
            Count3++;
            
            timerbreak3 = 0;
            timerbreakactivate3 = false;
            if(Count3<=letterstoappear4){
                activatenextset2 = true;
            }
            if(Count3>letterstoappear4){
                activatefilterbreak4 = true;
                Count3 = 0;

            }
        }
        if(activatefilterbreak4){
            Betweentimer4 = Betweentimer4+=Time.deltaTime; 
            if((Betweentimer4>=3) && filterinitialize4){
                current = 0;
                currentangle = eulerAngY;
                Debug.Log(currentangle);
                Desiredangle = currentangle + Inputangle;
                Debug.Log(Desiredangle);      
         
                if(Desiredangle>360){
                    Desiredangle = Desiredangle -360;
                }
                
                Threshold = Desiredangle-15;
                Debug.Log("Threshold = " +Threshold);

                Threshold2 = Desiredangle+15;

                Debug.Log("Threshold2 = " +Threshold2);   
                filterinitialize4 = false;  
                writedata4 = true;
                activatetimerfordata4 = true;
            }
            if((Betweentimer4>=3) && (!filterinitialize4)){
                
                if(activatetimerfordata4){
                    timerfordata4 = timerfordata4 +=Time.deltaTime;
                }

                if((Betweentimer4>=11) && (!((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)))){
                    current = 1;
                    activatetimerfordata4 = false;
                    Threshold = 400f;
                    Threshold2 = 400f;
                    if(noturn4){ 
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,,,,,");
                        sWriter2.Write(timerfordata4 + "\n" );
                        sWriter2.Close();
                        sWriter.Write(",,,,,,,,,,0\n");
                        sWriter.Close();
                        noturn4 = false;   
                        activatefilterbreak4 = false;
                        activatenextset5 = true;
                        Betweentimer4 = 0;
                        timerfordata4 = 0;
                    }
                    
                    
                
                }  
                if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)){
                   
                    if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2) && (writedata4)){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,,,,,");
                        sWriter2.Write(timerfordata4 +"\n");
                        sWriter2.Close();
                        sWriter.Write(",,,,,,,,,,1\n");
                        sWriter.Close();
                        timerfordata4 = 0;
                        current = 1;
                        writedata4 = false;
                        activatetimerfordata4 = false;
                        Activatespecial4 = true;
                        noturn4 = false;
                    }
                }
                if(Activatespecial4){
                    RandomLetter = Random.Range(0,letters.Length);
                    LetterObject = letters[RandomLetter];
                    LetterObject.SetActive(true);
                    Activatespecial4 = false;
                    activatespecialtimer4 = true;
                }
                if(activatespecialtimer4){
                    specialtimer4 = specialtimer4+=Time.deltaTime;
                }
                if(specialtimer4>=timeletterisactive4){
                    LetterObject.SetActive(false);
                    specialtimer4 = 0;
                    activatespecialtimer4 = false;
                    activatefilterbreak4 = false;
                    Betweentimer4 = 0;
                    activatenextsetbreak4 = true;

                }
                    

                
                

            

        }
         

             


             
         }
        if(activatenextsetbreak4){
            timerrbreak4 = timerrbreak4 += Time.deltaTime;
        }
        if(timerrbreak4>Randomtimeforbreak){
            timerrbreak4 = 0;
            activatenextsetbreak4 = false;
            activatenextset5 = true;
        }

        if(activatenextset5){
            RandomLetter = Random.Range(0,letters.Length);
            Randomtimeforbreakindex = Random.Range(0,Randomtimearray.Length);
            Randomtimeforbreak = Randomtimearray[Randomtimeforbreakindex];
            LetterObject = letters[RandomLetter];
            LetterObject.SetActive(true);
            timeractivate5 = true;
            activatenextset5 = false;
        }
        if(timeractivate5){
            timer5 = timer5+=Time.deltaTime;
        }
        
        if(timer5>=timeletterisactive6){
            LetterObject.SetActive(false);
            timer5 = 0;
            timeractivate5 = false;
            timerbreakactivate5 = true;
        }
        if(timerbreakactivate5){
            timerbreak5 = timerbreak5+=Time.deltaTime;
        }
        if(timerbreak5>=Randomtimeforbreak){
            Count5++;
            
            timerbreak5 = 0;
            timerbreakactivate5 = false;
            if(Count5<=letterstoappear6){
                activatenextset5 = true;
            }
            if(Count5>letterstoappear6){
                activatefilterbreak6 = true;
                Count5 = 0;

            }
        } 
        if(activatefilterbreak6){
            Betweentimer6 = Betweentimer6+=Time.deltaTime;
            if((Betweentimer6>=3) && filterinitialize6){
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
        
                filterinitialize6 = false;  
                writedataright6 = true;
                writedataleft6 = true;
                activatetimerfordata6 = true;

            }
            
            if((Betweentimer6>=3) && (!filterinitialize6)){
                
                if(activatetimerfordata6){
                    timerfordata6 = timerfordata6 +=Time.deltaTime;
                }

                if((Betweentimer6>=8) && (!((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2))) && (!((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)))){
                    activatetimerfordata6 = false;
                    Thresholdleft = 400f;
                    Thresholdleft2 = 400f;
                    Threshold = 400f;
                    Threshold2 = 400f;
                    if(noturn6){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,,,,,,," + timerfordata6 + "\n" );
                        sWriter2.Close();
                        sWriter.Write(",,,,,,,,,,,,0\n");
                        sWriter.Close();
                    
                    
                    
                        activatefilterbreak6 = false;
                        activatenextset7 = true;
                        Betweentimer6 = 0;
                        timerfordata6 = 0;
                    }
                }
                  
                if((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2)){
                    if(writedataleft6){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(timerfordata6 +"\n");
                        sWriter2.Close();
                        sWriter.Write("1\n");
                        sWriter.Close();
                        timerfordata6 = 0;
                        writedataleft6 = false;
                        activatetimerfordata6 = false;
                        Activatespecial6 = true;
                        noturn6 = false;
                    }
           
                }                
            

                
                if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)){
                  
                    if(writedataright6){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,");
                        sWriter2.Write(timerfordata6 +"\n");
                        sWriter2.Close();
                        sWriter.Write(",,,,,,1\n");
                        sWriter.Close();
                        timerfordata6 = 0;
                        writedataright6 = false;
                        activatetimerfordata6 = false;
                        Activatespecial6 = true;
                        noturn6 = false;
                    }
                }
                if(Activatespecial6){
                    RandomLetter = Random.Range(0,letters.Length);
                    LetterObject = letters[RandomLetter];
                    LetterObject.SetActive(true);
                    Activatespecial6 = false;
                    activatespecialtimer6 = true;
                }
                if(activatespecialtimer6){
                    specialtimer6 = specialtimer6+=Time.deltaTime;
                }
                if(specialtimer6>=timeletterisactive6){
                    LetterObject.SetActive(false);
                    specialtimer6 = 0;
                    activatespecialtimer6 = false;
                    activatefilterbreak6 = false;
                    Betweentimer6 = 0;
                    activatenextsetbreak6 = true;
                }
            }
                    

               
                

            

        
        
        }
        if(activatenextsetbreak6){
            timerrbreak6 = timerrbreak6 += Time.deltaTime;
        }
        if(timerrbreak6>2){
            timerrbreak6 = 0;
            activatenextsetbreak6 = false;
            activatenextset7 = true;
        } 
        if(activatenextset7){ 
            timeractivate7 = true; 
            RandomLetter = Random.Range(0,letters.Length);
            Randomtimeforbreakindex = Random.Range(0,Randomtimearray.Length);
            Randomtimeforbreak = Randomtimearray[Randomtimeforbreakindex];
            LetterObject = letters[RandomLetter];
            LetterObject.SetActive(true);
            activatenextset7 = false;
        }
        if(timeractivate7){
            timer7 = timer7+=Time.deltaTime;
        }
        if(timer7>=timeletterisactive7){
            LetterObject.SetActive(false);
            timer7 = 0;
            timeractivate7 = false;
            timerbreakactivate7 = true;
        }
        if(timerbreakactivate7){
            timerbreak7 = timerbreak7+=Time.deltaTime;
        }
        if(timerbreak7>=Randomtimeforbreak){
            Count7++;
            
            timerbreak7 = 0;
            timerbreakactivate7 = false;
            if(Count7<=letterstoappear7){
                activatenextset7 = true;
            }
            if(Count7>letterstoappear7){
                activatefilterbreak7 = true;
                Count7 = 0;
            }
        }
        if(activatefilterbreak7){
            Betweentimer7 = Betweentimer7+=Time.deltaTime;
            if((Betweentimer7>=3) && filterinitialize7){
                current = 0;
                currentangle = eulerAngY;
                Debug.Log(currentangle);
                Desiredangle = currentangle + Inputangle;
                Debug.Log(Desiredangle);      
         
                if(Desiredangle>360){
                    Desiredangle = Desiredangle-360;
                }
                
                Threshold = Desiredangle-15;
                Debug.Log("Threshold = " +Threshold);

                Threshold2 = Desiredangle+15;

                Debug.Log("Threshold2 = " +Threshold2);   
                filterinitialize7 = false;  
                writedata7 = true;
            }
            if((Betweentimer7>=3) && (!filterinitialize7)){
                
                if(activatetimerfordata7){
                    timerfordata7 = timerfordata7 +=Time.deltaTime;
                }

                if((Betweentimer7>=11) && (!((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)))){
                    current = 1;
                    activatetimerfordata7 = false;
                    Threshold = 400f;
                    Threshold2 = 400f;
                    if(noturn7){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,,,,,");
                        sWriter2.Write(timerfordata7 + "\n" );
                        sWriter2.Close();
                        sWriter.Write(",,,,,,,,,,0\n");
                        sWriter.Close();
                        noturn7 = false;
                        activatefilterbreak7 = false;
                        activatenextset8 = true;
                        Betweentimer7 = 0;
                        timerfordata7 = 0;
            
                    }
                  
                }  
                if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)){
                   
                    if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2) && (writedata7)){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,,,,,");
                        sWriter2.Write(timerfordata7 +"\n");
                        sWriter2.Close();
                        sWriter.Write(",,,,,,,,,,1\n");
                        sWriter.Close();
                        timerfordata7 = 0;
                        current = 1;
                        writedata7 = false;
                        activatetimerfordata7 = false;
                        noturn7 = false;
                        Activatespecial7 = true;
                    }
                }
                    
                if(Activatespecial7){
                    RandomLetter = Random.Range(0,letters.Length);
                    LetterObject = letters[RandomLetter];
                    LetterObject.SetActive(true);
                    Activatespecial7 = false;
                    activatespecialtimer7 = true;
                }
                if(activatespecialtimer7){
                    specialtimer7 = specialtimer7+=Time.deltaTime;
                }
                if(specialtimer7>=timeletterisactive7){
                    LetterObject.SetActive(false);
                    specialtimer7 = 0;
                    activatespecialtimer7 = false;
                    activatefilterbreak7 = false;
                    Betweentimer7 = 0;
                    activatenextsetbreak7 = true;

                }
                    

                
                

            

         }
         

             


             
         }
        if(activatenextsetbreak7){
            timerrbreak7 = timerrbreak7 += Time.deltaTime;
        }
        if(timerrbreak7>Randomtimeforbreak){
            timerrbreak7 = 0;
            activatenextsetbreak7 = false;
            activatenextset8 = true;
        }
        if(activatenextset8){
            RandomLetter = Random.Range(0,letters.Length);
            Randomtimeforbreakindex = Random.Range(0,Randomtimearray.Length);
            Randomtimeforbreak = Randomtimearray[Randomtimeforbreakindex];
            LetterObject = letters[RandomLetter];
            LetterObject.SetActive(true);
            timeractivate8 = true;
            activatenextset8 = false;
        }
        if(timeractivate8){
            timer8 = timer8+=Time.deltaTime;
        }
        
        if(timer8>=timeletterisactive8){
            LetterObject.SetActive(false);
            timer8 = 0;
            timeractivate8 = false;
            timerbreakactivate8 = true;
        }
        if(timerbreakactivate8){
            timerbreak8 = timerbreak8+=Time.deltaTime;
        }
        if(timerbreak8>=Randomtimeforbreak){
            Count8++;
            
            timerbreak8 = 0;
            timerbreakactivate8 = false;
            if(Count8<=letterstoappear8){
                activatenextset8 = true;
            }
            if(Count8>letterstoappear8){
                activatefilterbreak8 = true;
                Count8 = 0;

            }
        }
        if(activatefilterbreak8){
            Betweentimer8 = Betweentimer8+=Time.deltaTime;
            if((Betweentimer8>=3) && filterinitialize8){
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
        
                filterinitialize8 = false;  
                writedataright2 = true;
                writedataleft8 = true;

            }
            
            if((Betweentimer8>=3) && (!filterinitialize8)){
                
                if(activatetimerfordata8){
                    timerfordata8 = timerfordata8 +=Time.deltaTime;
                }

                if((Betweentimer8>=8) && (!((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2))) && (!((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)))){
                    if(noturn8){
                        activatetimerfordata8 = false;
                        Thresholdleft = 400f;
                        Thresholdleft2 = 400f;
                        Threshold = 400f;
                        Threshold2 = 400f;
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,,,,,,," + timerfordata8 + "\n" );
                        sWriter2.Close();
                        sWriter.Write(",,,,,,,,,,,,0\n");
                        sWriter.Close();
                    
                    
                        noturn8 = false;
                        activatefilterbreak8 = false;
                        activatenextset9 = true;
                        Betweentimer8 = 0;
                        timerfordata8 = 0;
                    }
                }
                  
                if((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2)){
                   
                    if(writedataleft8){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(timerfordata8 +"\n");
                        sWriter2.Close();
                        sWriter.Write("1\n");
                        sWriter.Close();
                        timerfordata8 = 0;
                        writedataleft8 = false;
                        activatetimerfordata8 = false;
                        Activatespecial8 = true;
                        noturn8 = false;
                    }
                }
                    

                
                

            

                
                if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)){
                  
                    if(writedataright2){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,");
                        sWriter2.Write(timerfordata8 +"\n");
                        sWriter2.Close();
                        sWriter.Write(",,,,,,1\n");
                        sWriter.Close();
                        timerfordata8 = 0;
                        writedataright2 = false;
                        activatetimerfordata8 = false;
                        Activatespecial8 = true;
                        noturn8 = false;
                    }
                }
                if(Activatespecial8){
                    RandomLetter = Random.Range(0,letters.Length);
                    LetterObject = letters[RandomLetter];
                    LetterObject.SetActive(true);
                    Activatespecial8 = false;
                    activatespecialtimer8 = true;
                }
                if(activatespecialtimer8){
                    specialtimer8 = specialtimer8+=Time.deltaTime;
                }
                if(specialtimer8>=timeletterisactive8){
                    LetterObject.SetActive(false);
                    specialtimer8 = 0;
                    activatespecialtimer8 = false;
                    activatefilterbreak8 = false;
                    Betweentimer8 = 0;
                    activatenextsetbreak8 = true;

                }
                    

                
                

            

        
        }
        }
        if(activatenextsetbreak8){
            timerrbreak8 = timerrbreak8 += Time.deltaTime;
        }
        if(timerrbreak8>2){
            timerrbreak8 = 0;
            activatenextsetbreak8 = false;
            activatenextset9 = true;
        } 
        if(activatenextset9){
            RandomLetter = Random.Range(0,letters.Length);
            Randomtimeforbreakindex = Random.Range(0,Randomtimearray.Length);
            Randomtimeforbreak = Randomtimearray[Randomtimeforbreakindex];
            LetterObject = letters[RandomLetter];
            LetterObject.SetActive(true);
            timeractivate9 = true;
            activatenextset9 = false;
        }
        if(timeractivate9){
            timer9 = timer9+=Time.deltaTime;
        }
        
        if(timer9>=timeletterisactive9){
            LetterObject.SetActive(false);
            timer9 = 0;
            timeractivate9 = false;
            timerbreakactivate9 = true;
        }
        if(timerbreakactivate9){
            timerbreak9 = timerbreak9+=Time.deltaTime;
        }
        if(timerbreak9>=Randomtimeforbreak){
            Count9++;
            
            timerbreak9 = 0;
            timerbreakactivate9 = false;
            if(Count9<=letterstoappear9){
                activatenextset9 = true;
            }
            if(Count9>letterstoappear9){
                activatefilterbreak9 = true;
                Count9 = 0;

            }
        }
        if(activatefilterbreak9){
            Betweentimer9 = Betweentimer9+=Time.deltaTime; 
            if((Betweentimer9>=3) && filterinitialize9){
                currentleft = 0;
                currentangleleft = eulerAngY;
                Debug.Log(currentangleleft);
                Desiredangleleft = currentangleleft - Inputangleleft;
                Debug.Log(Desiredangleleft);      
         
                if(Desiredangleleft<0){
                    Desiredangleleft = Desiredangleleft +360;
                }
                
                Thresholdleft = Desiredangleleft-15;
                Debug.Log("Threshold = " +Thresholdleft);

                Thresholdleft2 = Desiredangleleft+15;

                Debug.Log("Threshold2 = " +Thresholdleft2);   
                filterinitialize9 = false;  
                writedata9 = true;
                activatetimerfordata9 = true;
            }
            if((Betweentimer9>=3) && (!filterinitialize9)){
                
                if(activatetimerfordata9){
                    timerfordata9 = timerfordata9 +=Time.deltaTime;
                }

                if((Betweentimer9>=11) && (!((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2)))){
                    currentleft = 1;
                    activatetimerfordata9 = false;
                    Thresholdleft = 400f;
                    Thresholdleft2 = 400f;
                    if(noturn9){ 
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,");
                        sWriter2.Write(timerfordata9 + "\n" );
                        sWriter2.Close();
                        sWriter.Write(",,,,0\n");
                        sWriter.Close();
                        noturn9 = false;
                        activatefilterbreak9 = false;
                        activatenextset10 = true;
                        Betweentimer9 = 0;
                        timerfordata9 = 0;
                    }
                  
           
                
                }  
                if((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2)){
                   
                    if((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2) && (writedata9)){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,");
                        sWriter2.Write(timerfordata9 +"\n");
                        sWriter2.Close();
                        sWriter.Write(",,,,1\n");
                        sWriter.Close();
                        timerfordata9 = 0;
                        currentleft = 1;
                        writedata9 = false;
                        activatetimerfordata9 = false;
                        Activatespecial9 = true;
                        noturn9 = false;
                    }
                }
                if(Activatespecial9){
                    RandomLetter = Random.Range(0,letters.Length);
                    LetterObject = letters[RandomLetter];
                    LetterObject.SetActive(true);
                    Activatespecial9 = false;
                    activatespecialtimer9 = true;
                }
                if(activatespecialtimer9){
                    specialtimer9 = specialtimer9+=Time.deltaTime;
                }
                if(specialtimer9>=timeletterisactive9){
                    LetterObject.SetActive(false);
                    specialtimer9 = 0;
                    activatespecialtimer9 = false;
                    activatefilterbreak9 = false;
                    Betweentimer9 = 0;
                    activatenextsetbreak9 = true;

                }
                    

                  
                

            

         }
         

             


             
         }
        if(activatenextsetbreak9){
            timerrbreak9 = timerrbreak9 += Time.deltaTime;
        }
        if(timerrbreak9>Randomtimeforbreak){
            timerrbreak9 = 0;
            activatenextsetbreak9 = false;
            activatenextset10 = true;
        }

        if(activatenextset10){
            RandomLetter = Random.Range(0,letters.Length);
            Randomtimeforbreakindex = Random.Range(0,Randomtimearray.Length);
            Randomtimeforbreak = Randomtimearray[Randomtimeforbreakindex];
            LetterObject = letters[RandomLetter];
            LetterObject.SetActive(true);
            timeractivate10 = true;
            activatenextset10 = false;
        }
        if(timeractivate10){
            timer10 = timer10+=Time.deltaTime;
        }
        
        if(timer10>=timeletterisactive10){
            LetterObject.SetActive(false);
            timer10 = 0;
            timeractivate10 = false;
            timerbreakactivate10 = true;
        }
        if(timerbreakactivate10){
            timerbreak10 = timerbreak10+=Time.deltaTime;
        }
        if(timerbreak10>=Randomtimeforbreak){
            Count10++;
            
            timerbreak10 = 0;
            timerbreakactivate10 = false;
            if(Count10<=letterstoappear10){
                activatenextset10 = true;
            }
            if(Count10>letterstoappear10){
                activatefilterbreak10 = true;
                Count10 = 0;

            }
        } 
        if(activatefilterbreak10){
            Betweentimer10 = Betweentimer10+=Time.deltaTime;
            if((Betweentimer10>=3) && filterinitialize10){
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
        
                filterinitialize10 = false;  
                writedataright10 = true;
                writedataleft10 = true;
                activatetimerfordata10 = true;

            }
            
            if((Betweentimer10>=3) && (!filterinitialize10)){
                
                if(activatetimerfordata10){
                    timerfordata10 = timerfordata10 +=Time.deltaTime;
                }

                if((Betweentimer10>=8) && (!((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2))) && (!((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)))){
                    if(noturn10){
                        activatetimerfordata10 = false;
                        Thresholdleft = 400f;
                        Thresholdleft2 = 400f;
                        Threshold = 400f;
                        Threshold2 = 400f; 
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,,,,,,," + timerfordata10 + "\n" );
                        sWriter2.Close();
                        sWriter.Write(",,,,,,,,,,,,0\n");
                        sWriter.Close();
                    
                    
                    
                        activatefilterbreak10 = false;
                        Betweentimer10 = 0;
                        timerfordata10 = 0;
                    }
                }
                  
                if((eulerAngY>=Thresholdleft) && (eulerAngY <= Thresholdleft2)){
                    if(writedataleft10){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(timerfordata10 +"\n");
                        sWriter2.Close();
                        sWriter.Write("1\n");
                        sWriter.Close();
                        timerfordata10 = 0;
                        writedataleft10 = false;
                        activatetimerfordata10 = false;
                        Activatespecial10 = true;
                        noturn10 = false;
                    }
                   
                }

                
                if((eulerAngY>=Threshold) && (eulerAngY <= Threshold2)){
                  
                    if(writedataright10){
                        sWriter2 = new StreamWriter(appendpath2, append:true);
                        sWriter = new StreamWriter(appendpath,append:true); 
                        sWriter2.Write(",,,,,,");
                        sWriter2.Write(timerfordata10 +"\n");
                        sWriter2.Close();
                        sWriter.Write(",,,,,,1\n");
                        sWriter.Close();
                        timerfordata10 = 0;
                        writedataright10 = false;
                        activatetimerfordata10 = false;
                        Activatespecial10 = true;
                        noturn10 = false;
                    }
                }
                if(Activatespecial10){
                    RandomLetter = Random.Range(0,letters.Length);
                    LetterObject = letters[RandomLetter];
                    LetterObject.SetActive(true);
                    Activatespecial10 = false;
                    activatespecialtimer10 = true;
                }
                if(activatespecialtimer10){
                    specialtimer10 = specialtimer10+=Time.deltaTime;
                }
                if(specialtimer10>=timeletterisactive10){
                    LetterObject.SetActive(false);
                    specialtimer10 = 0;
                    activatespecialtimer10 = false;
                    activatefilterbreak10 = false;
                    Betweentimer10 = 0;
                    activatenextsetbreak10 = true;

                }
                    

               
                

            

        
        }
        }
        if(activatenextsetbreak10){
            timerrbreak10 = timerrbreak10 += Time.deltaTime;
        }
        if(timerrbreak10>2){
            timerrbreak10 = 0;
            activatenextsetbreak10 = false;
        } 
        }
}

        

        

    

    
    

         
         

             


             
    
    


