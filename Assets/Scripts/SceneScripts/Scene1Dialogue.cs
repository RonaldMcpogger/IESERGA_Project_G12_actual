using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene1Dialogue : MonoBehaviour
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
    public GameObject Choice1a;
    public GameObject Choice1b;
    public GameObject NextScene1Button;
    public GameObject NextScene2Button;
    public GameObject nextButton;

    [SerializeField]
    private GameObject Synopsis;
    //public AudioSource audioSource1;
    private bool allowSpace = true;


    public GameObject inputField;
    // Set initial visibility. Added images or buttons need to also be SetActive(false);



    void Start()
    {
        inputField.SetActive(false);
        DialogueDisplay.SetActive(false);
        ArtChar1a.SetActive(false);
        ArtBG1.SetActive(true);
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        NextScene1Button.SetActive(false);
        NextScene2Button.SetActive(false);
        nextButton.SetActive(true);
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
        }
        else if (primeInt == 2)
        {
            //ArtChar1a.SetActive(true);

            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "The Convention for the Amelioration of the Condition of the Wounded and Sick in Armed Forces in the Field";
            temColor.a = 0.97f;
            tem.color = temColor;

        }
        else if (primeInt == 3)
        {
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "The Convention for the Amelioration of the Condition of the Wounded, Sick, and Shipwrecked Members of Armed Forces at Sea";
            temColor.a = 0.80f;
            tem.color = temColor;

            //gameHandler.AddPlayerStat(1);
        }
        else if (primeInt == 4)
        {
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "The Convention Relative to the Treatment of Prisoners of War";
            temColor.a = 0.70f;
            tem.color = temColor;
        }
        else if (primeInt == 5)
        {
            Synopsis.transform.Find("synText").GetComponent<TMP_Text>().text = "The Convention Relative to the Protection of Civilian Persons in Time of War.";

            temColor.a = 0.50f;
            tem.color = temColor;
        }
        else if (primeInt == 6)
        {
            Synopsis.SetActive(false);
            DialogueDisplay.SetActive(true);
            Char1name.text = char1Dia.Characters[0];
            Char1speech.text = char1Dia.lines[0].text;
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 7)
        {
            Char1name.text = char1Dia.Characters[0];
            Char1speech.text = char1Dia.lines[1].text;
            //Char2name.text = "";
            //Char2speech.text = "";
        }
        else if (primeInt == 8)
        {
            Char1name.text = char1Dia.Characters[2];
            Char1speech.text = " you wake up, confused, greeted with an unfamiliar place. The place is dark, dated, and seems to be a bit run-down";

            // Turn off the "Next" button, turn on "Choice" buttons

        }
        else if (primeInt == 9)
        {
            Char1name.text = char1Dia.Characters[0];
            Char1speech.text = "I remember going to bedÅc but when I woke up, I was here. In the uniform of a German officer. This isnÅft a dream, is it?";


        }
        else if (primeInt == 10)
        {
            Char1name.text = "";

            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[1];
            Char2speech.text = "Ah, our newest officer has arrived. I am Commandant Richter. You will be trained to lead, to command, and most importantly, to enforce discipline.";
            // Turn off the "Next" button, turn on "Choice" buttons


        }
        else if (primeInt == 11)
        {
            Char1name.text = "";

            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[1];
            Char2speech.text = "Your decisions will shape the war. Remember this well, OfficerÅc. For now, sign here to officially start your training.";
            // Turn off the "Next" button, turn on "Choice" buttons


        }
        else if (primeInt == 12)
        {
            Char1name.text = "";

            Char1speech.text = "";
            Char2name.text = char1Dia.Characters[2];
            Char2speech.text = "Commandant Richter approaches you with a piece of paper.";
            // Turn off the "Next" button, turn on "Choice" buttons


        }
        else if (primeInt == 13)
        {
            Char1name.text = "";

            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
            // Turn off the "Next" button, turn on "Choice" buttons
            nextButton.SetActive(false);
            allowSpace = false;
            inputField.SetActive(true);
            DialogueDisplay.SetActive(false);


        }

        else if (primeInt == 16)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
            // Turn off the "Next" button, turn on "Choice" buttons
            nextButton.SetActive(false);
            allowSpace = false;
            Choice1a.SetActive(true); // function Choice1aFunct()
            Choice1b.SetActive(true); // function Choice1bFunct()
        }

        else if (primeInt == 17)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
            // Turn off the "Next" button, turn on "Choice" buttons
            nextButton.SetActive(false);
            allowSpace = false;
            Choice1a.SetActive(true); // function Choice1aFunct()
            Choice1b.SetActive(true); // function Choice1bFunct()
        }



        // after choice 1a
        else if (primeInt == 20)
        {
            //gameHandler.AddPlayerStat(1);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Jeda";
            Char2speech.text = "Then you are no use to me, and must be silenced.";
        }
        else if (primeInt == 21)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Jeda";
            Char2speech.text = "Come back here! Do not think you can hide from me!";
            // Turn off the "Next" button, turn on "Scene" button/s
            nextButton.SetActive(false);
            allowSpace = false;
            NextScene1Button.SetActive(true);
        }

        // after choice 1b
        else if (primeInt == 30)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Jeda";
            Char2speech.text = "Do not think you can fool me, human. Where will we find him?";
        }
        else if (primeInt == 31)
        {
            Char1name.text = "YOU";
            Char1speech.text = "Ragu hangs out in a rough part of town. I'll take you now.";
            Char2name.text = "";
            Char2speech.text = "";
            // Turn off the "Next" button, turn on "Scene" button/s
            nextButton.SetActive(false);
            allowSpace = false;
            NextScene2Button.SetActive(true);
        }

        //Please do NOT delete this final bracket that ends the Next() function:
    }

    // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
    public void Choice1aFunct()
    {
        Char1name.text = "YOU";
        Char1speech.text = "I don't know what you're talking about!";
        Char2name.text = "";
        Char2speech.text = "";
        primeInt = 19; // so hitting "NEXT" goes to primeInt==20!
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }
    public void Choice1bFunct()
    {
        Char1name.text = "YOU";
        Char1speech.text = "Sure, anything you want... just lay off the club.";
        Char2name.text = "";
        Char2speech.text = "";
        primeInt = 29; // so hitting "NEXT" goes to primeInt==30!
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }


    public void SceneChange1()
    {
        SceneManager.LoadScene("Scene2a");
    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("Scene2b");
    }

    public void readName(string s)
    {
        char1Dia.Characters[0] = s;
        allowSpace = true;
        nextButton.SetActive(true);
        inputField.SetActive(false);
        DialogueDisplay.SetActive(true);
        Next();


    }
}