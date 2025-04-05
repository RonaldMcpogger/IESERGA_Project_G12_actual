using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene4Dialogue : MonoBehaviour
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
    public GameObject ArtBG2;
    public GameObject ArtBG3;
    public GameObject ArtBG4;

    public GameObject nextButton;

    //public AudioSource audioSource1;
    private bool allowSpace = true;
    
    // Set initial visibility. Added images or buttons need to also be SetActive(false);



    void Start()
    {
        DialogueDisplay.SetActive(true);
        ArtChar1a.SetActive(false);
        nextButton.SetActive(true);

        Char1name.text = "";
        Char1speech.text = "";
        Char2name.text = "";
        Char2speech.text = "";

        ArtBG1.SetActive(false);
        ArtBG2.SetActive(false);
        ArtBG3.SetActive(false);
        ArtBG4.SetActive(false);
        if(GameHandler.playerScore >= 4)
        {
            ArtBG1.SetActive(true);
        }
        else if (GameHandler.playerScore >= 0 && GameHandler.playerScore < 4)
        {
            ArtBG2.SetActive(true);
            primeInt = 5;
        }
        else if (GameHandler.playerScore >= -4 && GameHandler.playerScore < 0)
        {
            ArtBG3.SetActive(true);
            primeInt = 9;
        }
        else if (GameHandler.playerScore < -4)
        {
            ArtBG4.SetActive(true);
            primeInt = 14;
        }
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
        }
    }

    //Story Units! The main story function.
    //Players hit [NEXT] to progress to the next primeInt:
    public void Next()
    {
        primeInt += 1;
        if (primeInt == 1)
        {
            DialogueDisplay.SetActive(true);
            Next();
        }
        else if (primeInt == 2)
        {
            Char1name.text = "";
            Char1speech.text = "You have upheld justice, protected the innocent, and maintained unwavering integrity.";
            Char2name.text = "";
            Char2speech.text = "";

        }
        else if (primeInt == 3)
        {
            Char1speech.text = " Your actions inspire hope, creating a better future for the world. Society thrives under your influence, and you are remembered as a legend, a hero amongst those who experienced a terrible regime.";
        }
        else if (primeInt == 4)
        {
            Char1speech.text = "Ending A: \"A Hero\"";
        }
        else if (primeInt == 5)
        {
            SceneManager.LoadScene("Credits");
        }
        else if (primeInt == 6)
        {
            Char1name.text = "";
            Char1speech.text = "You help where you can but avoid outright defiance. You protect others in secret but never directly challenge the system.";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 7)
        {
            Char1speech.text = "You survive, but the weight of your choices stays with you.";
        }
        else if (primeInt == 8)
        {
            Char1speech.text = "Ending B: \"Light in the Dark\"";
        }
        else if (primeInt == 9)
        {
            SceneManager.LoadScene("Credits");
        }
        else if (primeInt == 10)
        {
            Char1name.text = "";
            Char1speech.text = "You choose survival over resistance, doing what is required but avoiding direct atrocities.";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 11)
        {
            Char1speech.text = "You justify your inaction as a necessity, but history will judge you differently.";
        }
        else if (primeInt == 12)
        {
            Char1speech.text = "When the Reich falls, you are left wondering whether you did the right thing.";
        }
        else if (primeInt == 13)
        {
            Char1speech.text = "Ending C: \"Just Doing my Job\"";
        }
        else if (primeInt == 14)
        {
            SceneManager.LoadScene("Credits");
        }
        else if (primeInt == 15)
        {
            Char1name.text = "";
            Char1speech.text = "You fully embrace the unjust and cruel ideology of your leader and actively participate in its horrors.";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 16)
        {
            Char1speech.text = "You commit atrocities in the name of the regime, believing in its cause or simply following orders.";
        }
        else if (primeInt == 17)
        {
            Char1speech.text = "When the war ends, justice comes for you in the trials to be upheld.";

        }
        else if (primeInt == 18)
        {
            Char1speech.text = "There is no escape.";
        }
        else if (primeInt == 19)
        {
            Char1speech.text = "Ending D: \"A Participant of Evil\"";
        }
        else if (primeInt == 20)
        {
            SceneManager.LoadScene("Credits");
        }
        
        //Please do NOT delete this final bracket that ends the Next() function:
    }

    public void readName()
    {
       
        char1Dia.Characters[0] = GameHandler.playerName;
        Debug.Log(char1Dia.Characters[0].ToString());
        allowSpace = true;
        nextButton.SetActive(true);
        DialogueDisplay.SetActive(true);
        Next();


    }
}