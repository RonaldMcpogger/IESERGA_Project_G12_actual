using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using JetBrains.Annotations;
using UnityEditor;
using static UnityEngine.GridBrushBase;
using Unity.VisualScripting;
using System.Numerics;
using System;

public class Scene2Dialog : MonoBehaviour
{
    [System.Serializable]
    public class DLines
    {

        [TextArea(3, 10)]
        public string text;
    }
    [System.Serializable]
    public class Dialogue
    {
        public List<string> Characters;

        public List<DLines> lines = new List<DLines>();


    }
    // These are the script variables.
    // For more character images / buttons, copy & renumber the variables:
    public int primeInt = 0;        // This integer drives game progress!

    public Dialogue char1Dia;


    

    public TMP_Text Char1name;
    public TMP_Text Char1speech;
    public TMP_Text Char2name;
    public TMP_Text Char2speech;

    //public TMP_Text Char3name;
    //public TMP_Text Char3speech;

    public GameObject DialogueDisplay;
    public GameObject ArtChar1a;

    //public GameObject ArtChar1b;
    //public GameObject ArtChar1c;
    //public GameObject ArtChar2;


    public GameObject ArtBG1;
    //choices
    //set of choicces
    public GameObject choiceSelect1;//first choice
    public GameObject choiceSelect2;//second choice
    public GameObject choiceSelect3;//third choice

    public GameObject NextScene1Button;
    public GameObject NextScene2Button;

    public GameObject nextButton;

    [SerializeField]
    private GameObject Synopsis;
    //public AudioSource audioSource1;
    private bool allowSpace = true;


  

    // Set initial visibility. Added images or buttons need to also be SetActive(false);



    void Start()
    {
    
        DialogueDisplay.SetActive(false);
        ArtChar1a.SetActive(false);
        ArtBG1.SetActive(true);
       
        NextScene1Button.SetActive(false);
        NextScene2Button.SetActive(false);
        nextButton.SetActive(true);

        choiceSelect1.SetActive(false);
        choiceSelect2.SetActive(false);
        choiceSelect3.SetActive(false);

        char1Dia.Characters[0]=GameHandler.playerName;
        Next();
    }

    // Use the spacebar as a faster "Next" button:
    void Update()
    {
        if (allowSpace == true)
        {
            if (Input.GetKeyDown("space"))
            {
                Next();
            }

            // secret debug code: go back 1 Story Unit, if NEXT is visible
            if (Input.GetKeyDown("p"))
            {
                if (primeInt > 1)
                    primeInt -= 2;
                Debug.Log(primeInt);
                Next();
            }
        }
    }

    //Story Units! The main story function.
    //Players hit [NEXT] to progress to the next primeInt:
    public void Next()
    {
        Image tem = Synopsis.GetComponent<Image>();
        var temColor = tem.color;
        primeInt += 1;
        if (primeInt == 1)
        {
            DialogueDisplay.SetActive(false);
            Synopsis.SetActive(true);
            // audioSource1.Play();
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = " The sun hangs low over a war-torn village. Smoke drifts from ruined buildings. A dozen bound and kneeling civilians.Men, women, and elderly, are surrounded by German soldiers, rifles at the ready. Your uniform is stiff, and freshly issued. You are the newly assigned Commanding Officer, a stranger in a land already lost to war.";

        }
        else if (primeInt == 2)
        {
            //ArtChar1a.SetActive(true);

            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = " This was a city of a neighboring nation that was taken over and occupied recently by your unit after a successful operation. However, this operation was merely a step to occupying the neighboring country";
            temColor.a = 0.85f;
            tem.color = temColor;

        }
        else if (primeInt == 3)
        {
            Synopsis.SetActive(false);
            DialogueDisplay.SetActive(true);
            Char1name.text = char1Dia.Characters[2];
            Char1speech.text = "Herr Kommandant, our unit has captured 12 civilians from the recently occupied city";
            Char2name.text = "";
            Char2speech.text = "";

            //gameHandler.AddPlayerStat(1);
        }
        else if (primeInt == 4)
        {

            Char1name.text = char1Dia.Characters[3];
            Char1speech.text = "A superior officer from your squad approaches you with a written order. It's Hauptmann Schwarz";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 5)
        {
            Char1name.text = char1Dia.Characters[1];
            Char1speech.text = "Our unit does not have enough resources to detain the prisoners. Keeping them alive will slow down our approach to the capital. Execute them and move forward";

        }
        else if (primeInt == 6)
        {
            nextButton.SetActive(false);
            choiceSelect1.SetActive(true);
            Char1name.text = char1Dia.Characters[3];
            Char1speech.text = "What will you do";
            Char2name.text = "";
            Char2speech.text = "";
        }
        // after choice A
        else if (primeInt == 8)
        {
            GameHandler.playerScore -= 2;
            Char1name.text = char1Dia.Characters[3];
            Char1speech.text = "the sound of rifles echoes behind you as the bodies of the once alive captives fall limp as their blood stains the dirt. The civilians are dead. Some soldiers murmur approvingly, while a few avert their gaze, disturbed.";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 9)
        {

            Char1name.text = char1Dia.Characters[2];
            Char1speech.text = "Hauptmann Schwarz made a slight nod on your decision";

        }
        else if (primeInt == 10)
        {

            Char1name.text = char1Dia.Characters[1];
            Char1speech.text = "Good. You understand how war is fought";

        }
        else if (primeInt == 11)
        {
            Synopsis.SetActive(true);
            DialogueDisplay.SetActive(false);
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "Article 3: Persons not taking part in hostilities must be treated humanely. Summary execution is strictly prohibited.";
            temColor.a = 0.35f;
            tem.color = temColor;
        }
        else if (primeInt == 12)
        {
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "Article 4: Civilians under enemy control must be protected and not treated as combatants.";
            temColor.a = 0.65f;
            tem.color = temColor;
        }
        else if (primeInt == 13)
        {

            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "Article 130: The execution of civilians is a grave breach of the Convention.";
            temColor.a = 0.80f;
            tem.color = temColor;
        }

        else if (primeInt == 14)
        {

            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "The unit moves forward." +
                " But later that night, as you try to sleep, the sounds of the gunfire echo in your head...";
            temColor.a = 0.95f;
            tem.color = temColor;
        }
        else if (primeInt == 15)
        {

            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = " and the blank faces of the executed civilians linger.";
            temColor.a = 1f;
            tem.color = temColor;
        }
        else if (primeInt == 16)
        {
            //SceneManager.LoadScene("Scene3");
        }




        //afterChoice B


        else if (primeInt == 18)
        {
            Char1name.text = char1Dia.Characters[0];
            Char1speech.text = "I’m afraid I cannot comply.Civilians do not deserve to suffer the consequences of war.";

            ;
            Char2name.text = "";
            Char2speech.text = "";
            // Turn off the "Next" button, turn on "Choice" buttons


        }

        else if (primeInt == 19)
        {
            Char1name.text = char1Dia.Characters[1];
            Char1speech.text = "Are you questioning command? You think you have the luxury to play the saint?";


            Char2name.text = "";
            Char2speech.text = "";
            // Turn off the "Next" button, turn on "Choice" buttons


        }

        else if (primeInt == 20)
        {
            Char1name.text = char1Dia.Characters[3];
            Char1speech.text = "He steps forward, lowering his voice so the soldiers cannot hear.";
            // Turn off the "Next" button, turn on "Choice" buttons


        }
        else if (primeInt == 21)
        {
            Char1name.text = char1Dia.Characters[1];
            Char1speech.text = "I’ll remind you that we are here to win a war, not to play jailer to useless mouths." +
                " If you won’t give the order, I will";
            // Turn off the "Next" button, turn on "Choice" buttons

            nextButton.SetActive(false);
            choiceSelect2.SetActive(true);


        }

        //after B.1 choice
        else if (primeInt == 23)
        {
            Synopsis.SetActive(true);
            DialogueDisplay.SetActive(false);
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "Article 5: Persons captured must be presumed as prisoners of war and treated as such until their status is determined.\r\n";
            temColor.a = 0.75f;
            tem.color = temColor;
        }
        else if (primeInt == 24)
        {

            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "Article 13: Prisoners must always be treated humanely, regardless of circumstances.\r\n";
            temColor.a = 0.75f;
            tem.color = temColor;
        }
        else if (primeInt == 23)
        {
            //SceneManager.LoadScene("Scene3");

        }


        //after C choice

        else if (primeInt == 30)
        {
            GameHandler.playerScore += 2;
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[2];
            Char2speech.text = "Herr Kommandant, if we are caught—";

        }
        else if (primeInt == 31)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[0];
            Char2speech.text = "We are not murderers. We are soldiers. Follow my orders.";
        }
        else if (primeInt == 32)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[3];
            Char2speech.text = "That night, the prisoners are led away under the cover of darkness." +
                " In the morning, Schwarz hears no gunshots and eyes you suspiciously";
        }
        else if (primeInt == 33)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[1];
            Char2speech.text = "I didn’t hear any screams from the executions last night.";
            choiceSelect3.SetActive(true);
        }

        else if (primeInt == 36)
        {
            Synopsis.SetActive(true);
            DialogueDisplay.SetActive(false);
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "Article 3: In armed conflict, persons who do not take part in" +
                " hostilities must be protected.";
            temColor.a = 0.75f;
            tem.color = temColor;
        }
        else if (primeInt == 37)
        {
           
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "";
          
        }

        else if (primeInt == 38)
        {
            Synopsis.SetActive(true);
            DialogueDisplay.SetActive(false);
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "Article 5: Persons captured must be presumed as prisoners of war and treated as such until their status is determined.\r\n";
            temColor.a = 0.75f;
            tem.color = temColor;
        }











        //Please do NOT delete this final bracket that ends the Next() function:
    }

    // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
    public void Choice1aFunct()
    {
        nextButton.SetActive(true);
        allowSpace = true;
        if (primeInt == 6)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[0];
            Char2speech.text = " On your command, Herr Hauptmann";
            choiceSelect1.SetActive(false);

            primeInt = 7; // so hitting "NEXT" goes to primeInt==20!
            
        }
        else if (primeInt == 21)//choice b1
        {
            choiceSelect2.SetActive(false);

            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[3];
            Char2speech.text = " You threaten to report Schwarz to the higher command for violating international law." +
                "Schwarz backs down but warns that you are making dangerous enemies. supplies are stretched thin with the detained civillians.";
            primeInt = 22; // so hitting "NEXT" goes to primeInt==20!
        }
        else if (primeInt == 33)
        {
            choiceSelect2.SetActive(false);

            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[0];
            Char2speech.text = " You told Hauptmann Schwarz that the captives seemed like they accepted their fate and were executed without any struggle. " +
                "He seems to accept the answer";
            primeInt = 35; // so hitting "NEXT" goes to primeInt==20!
        }



    }
    public void Choice1bFunct()
    {
        nextButton.SetActive(true);
        choiceSelect1.SetActive(false);
        allowSpace = true;
        Char1name.text = "";
        Char1speech.text = "";
        Char2name.text = char1Dia.Characters[3];
        Char2speech.text = "You shook your head";
        primeInt = 17;
    }

    public void choice1Cfunc()
    {
        nextButton.SetActive(true);
        
        allowSpace = true;

        if (primeInt == 6)
        {
            choiceSelect1.SetActive(false);

            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[3];
            Char2speech.text = " You glance at Schwarz, then at the civilians. " +
                "You sign the paper but quietly instruct your men later to fire into the air and let them flee at night ";
            primeInt = 29;
        }


        else if (primeInt == 21)//choice b2
        {
            choiceSelect2.SetActive(false);

            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[3];
            Char2speech.text = "Hauptmann Schwarz smirked and gave the execution order" +
                ". Soldiers whisper among themselves about your failure to act ";
            primeInt = 22; // so hitting "NEXT" goes to primeInt==20!
        }
        else if (primeInt == 33)
        {
            choiceSelect2.SetActive(false);

            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[3];
            Char2speech.text = " Schwarz watches you, unconvinced, and starts keeping  a closer eye on you in later missions ";
            primeInt = 35; // so hitting "NEXT" goes to primeInt==20!
        }

    }
 
}