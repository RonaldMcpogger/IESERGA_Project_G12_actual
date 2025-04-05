using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene3Dialogue : MonoBehaviour
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
    public GameObject ArtChar1b;
    public GameObject ArtChar1c;
    public GameObject ArtChar2a;
    public GameObject ArtChar2b;
    public GameObject ArtSoldier;


    public GameObject ArtBG1;
    public GameObject ArtCG;
    public GameObject ArtBlack;
    public GameObject Choice1a;
    public GameObject Choice1b;
    public GameObject Choice2a;
    public GameObject Choice2b;
    public GameObject Choice2c;
    public GameObject nextButton;

    //public AudioSource audioSource1;
    private bool allowSpace = true;
    
    // Set initial visibility. Added images or buttons need to also be SetActive(false);



    void Start()
    {
        DialogueDisplay.SetActive(false);

        ArtChar1a.SetActive(false);
        ArtChar1b.SetActive(false);
        ArtChar1c.SetActive(false);
        ArtChar2a.SetActive(false);
        ArtChar2b.SetActive(false);
        ArtSoldier.SetActive(false);

        ArtBG1.SetActive(true);
        ArtCG.SetActive(false);
        ArtBlack.SetActive(false);

        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        Choice2a.SetActive(false);
        Choice2b.SetActive(false);
        Choice2c.SetActive(false);
        nextButton.SetActive(true);

        Char1name.text = "";
        Char1speech.text = "";
        Char2name.text = "";
        Char2speech.text = "";
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
            ArtSoldier.SetActive(true);
            Char1name.text = "Soldier";
            Char1speech.text = "Herr Kommandant, our unit has captured several suspicious figures.";
            Char2name.text = "";
            Char2speech.text = "";

        }
        else if (primeInt == 3)
        {
            Char1speech.text = "That said, we are not sure if all of these prisoners are even connected to the enemy. We suspect that some may simply be civilians caught up in the war.";
        }
        else if (primeInt == 4)
        {
            ArtSoldier.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "You see the prisoners that your unit has captured and the Hauptmann Schwarz has tasked you to order your unit to interrogate these prisoners and get any information as well as their involvement with the enemy forces";
        }
        else if (primeInt == 5)
        {
            ArtChar2a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Hauptmann Schwarz";
            Char2speech.text = "Our unit needs to extract information from these prisoners as quickly as possible.";
        }
        else if (primeInt == 6)
        {
            Char2speech.text = "We donít have time to play nice, so torture them to loosen their lips. They'll be begging to tell us what we want in no time.";
        }
        else if (primeInt == 7)
        {
            Char2speech.text = "Aggressive tactics are just what we need here, soldier. So I expect you to do what needs to be done.";
        }
        else if (primeInt == 8)
        {
            ArtChar2a.SetActive(false);
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
        else if (primeInt == 9)
        {
            //ArtChar1a.SetActive(false);
            ArtChar1a.SetActive(false);
            ArtChar2a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Hauptmann Schwarz";
            Char2speech.text = " Good. You have become the ideal soldier, always obedient and willing to do whatever it takes for your country!";

        }
        else if (primeInt == 10)
        {
            ArtBG1.SetActive(false);
            ArtBlack.SetActive(true);
            ArtChar2a.SetActive(false);
            Char2name.text = "";
            Char2speech.text = "The unit moves forward. But later that night, as you try to sleep, the sounds of the groans and screams from the prisoners getting tortured echo in your head";
            // Turn off the "Next" button, turn on "Choice" buttons
        }
        else if (primeInt == 11)
        {
            Char2speech.text = "...and the faces of the dead and brutally beaten up prisoners linger, burned forever into your memory. The cries of suffering haunt you, preventing you from getting even a wink of rest...";
        }
        else if (primeInt == 12)
        {
            Char2speech.text = "Article 17: No physical or mental torture, nor any form of coercion, may be inflicted on prisoners of war to secure information from them...";
        }
        else if (primeInt == 13)
        {
            Char2speech.text = "Article 130: Torture and inhumane treatment are considered grave breaches of the Convention.";
        }
        else if (primeInt == 14)
        {
            SceneManager.LoadScene("Scene4");
        }
        else if (primeInt == 23)
        {
            ArtChar1a.SetActive(false);
            ArtChar2b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Hauptmann Schwarz";
            Char2speech.text = "Are you questioning my tactics!? Do you think they will tell us everything just because you chose to be kind and merciful!?";
            // Turn off the "Next" button, turn on "inputs" buttons
        }
        else if (primeInt == 24)
        {
            Char2name.text = "";
            Char2speech.text = "He steps forward, slams you to the wall, and shouts loudly so that the rest of your unit can hear what he is saying.";
        }
        else if (primeInt == 25)
        {
            Char2name.text = "Hauptmann Schwarz";
            Char2speech.text = "Iíll remind you that we cannot afford to follow the international law if we want to win. We are fighting for our countryís cause! If you keep on refusing to follow my orders, I will have you executed for treason!";

        }
        else if (primeInt == 26)
        {
            Char2name.text = "";
            Char2speech.text = "Article 13: Prisoners of war must at all times be humanely treated. Any unlawful act or omission causing death or serious endangerment is prohibited.";
        }
        else if (primeInt == 27)
        {
            Char2speech.text = "Article 14: Prisoners of war are entitled to respect for their persons and their honor.";
        }
        else if (primeInt == 28)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "(Now then... what to do?)";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 29)
        {
            Char1name.text = "";
            Char1speech.text = "";
            // Turn off the "Next" button, turn on "Choice" buttons
            nextButton.SetActive(false);
            allowSpace = false;
            Choice2a.SetActive(true); // function Choice2aFunct()
            Choice2b.SetActive(true); // function Choice2bFunct()
            Choice2c.SetActive(true); // function Choice2cFunct()
        }
        else if (primeInt == 30)
        {
            ArtChar1a.SetActive(false);
            ArtChar2b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Hauptmann Schwarz";
            Char2speech.text = "Fool. Such insubordination cannot be tolerated. If you cannot do what needs to be done, then I will do what you cannot!";
        }
        else if (primeInt == 31)
        {
            Char2name.text = "";
            Char2speech.text = "Hauptmann Schwarz orders your troops to detain you and teach you a lesson by beating you up until you learn your lesson.";
        }
        else if (primeInt == 32)
        {
            Char2speech.text = "The prisoners are still tortured, and you are forced to watch them suffer and slowly die.";
        }
        else if (primeInt == 33)
        {
            ArtBG1.SetActive(false);
            ArtBlack.SetActive(true);
            Char2speech.text = "Though you tried to uphold international law, your actions still weren't enough.";
        }
        else if (primeInt == 34)
        {
            ArtChar2b.SetActive(false);
            Char2speech.text = "Article 3: Inhumane treatment and torture are prohibited in all circumstances, including in internal conflicts.";
        }
        else if (primeInt == 35)
        {
            Char2speech.text = "Article 99: No prisoner may be punished without a fair trial and due process.";
        }
        else if (primeInt == 36)
        {
            SceneManager.LoadScene("Scene4");
        }
        else if (primeInt == 37)
        {
            ArtChar1a.SetActive(false);
            ArtChar2b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Hauptmann Schwarz";
            Char2speech.text = "If you cannot do what needs to be done, then I will do it for you. Out of my way!";
        }
        else if (primeInt == 38)
        {
            Char2name.text = "";
            Char2speech.text = "Hauptmann Schwarz throws you on the floor and gives the order himself.";
        }
        else if (primeInt == 39)
        {
            Char2speech.text = "Under his command, the soldiers mercilessly interrogate the prisoners for information by any means necessary.";
        }
        else if (primeInt == 40)
        {
            Char2speech.text = "You do not directly commit the war crime, but your inaction allows it to happen.";
        }
        else if (primeInt == 41)
        {
            ArtChar2b.SetActive(false);
            Char2speech.text = "Later, some soldiers whisper about your failure to act and start to think that there is a possibility that you are a traitor.";
        }
        else if (primeInt == 42)
        {
            Char2speech.text = "At the very least though, there some still respect you for trying to uphold International Law.";
        }
        else if (primeInt == 43)
        {
            Char2speech.text = "Article 7 (Additional Protocol I): No superior order may justify the commission of war crimes.";
        }
        else if (primeInt == 44)
        {
            Char2speech.text = "Nuremberg Trials: Superior orders, also known as just following orders or the Nuremberg defense. The trials determined that the defense of superior orders was no longer enough to escape punishment.";
        }
        else if (primeInt == 45)
        {
            Char2speech.text = "Article 99: Prisoners may not be punished for refusing to give information.";
        }
        else if (primeInt == 46)
        {
            SceneManager.LoadScene("Scene4");
        }
        else if (primeInt == 47)
        {
            ArtChar1a.SetActive(false);
            ArtChar2b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Hauptmann Schwarz";
            Char2speech.text = "Then hurry up and torture them! You've tried my patience long enough.";
        }
        else if (primeInt == 48)
        {
            ArtChar2b.SetActive(false);
            Char2name.text = "";
            Char2speech.text = "You are a little tense but keep your composure so the Hauptmann Schwarz wonít notice what youíre planning to do.";
        }
        else if (primeInt == 49)
        {
            Char2speech.text = "You sign the order, but before your subordinates interrogate the prisoners, you stop and tell them to treat the prisoners properly during the interrogation.";
        }
        else if (primeInt == 50)
        {
            ArtBG1.SetActive(false);
            ArtCG.SetActive(true);
            Char2speech.text = "Afterwards, you ordered them that when night falls, they are to release the prisoners, explaining that they all either died or commited suicide during the interrogation.";
        }
        else if (primeInt == 51)
        {
            ArtCG.SetActive(false);
            ArtBlack.SetActive(true);
            Char2speech.text = "Sometime later...";
        }
        else if (primeInt == 52)
        {
            ArtBG1.SetActive(true);
            ArtBlack.SetActive(false);
            ArtSoldier.SetActive(true);
            Char2speech.text = "";
            Char1name.text = "Soldier";
            Char1speech.text = "Kommandant, why did you disobey orders? Why are you risking your life for these prisoners?";
        }
        else if (primeInt == 53)
        {
            ArtSoldier.SetActive(false);
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Allow me to ask you this question: Are we just psychopaths that solely rely on violent tactics?";
        }
        else if (primeInt == 54)
        {
            Char1speech.text = "Even if we trampled over the rights of our prisoners, it would not be enough to guarantee their confessions.";
        }
        else if (primeInt == 55)
        {
            Char1speech.text = "War has stipped us enough of our humanity. At the very least, I refuse to be responsible for propagating such excessive bloodshed.";
        }
        else if (primeInt == 56)
        {
            ArtChar1a.SetActive(true);
            Char1speech.text = "I choose to follow my heart, and abide by the International Laws made to help us maintain our humanity during these inhumane times.";
        }
        else if (primeInt == 57)
        {
            Char1speech.text = "To that end, I will do what I believe needs to be done, and I impore you to do the same.";
        }
        else if (primeInt == 58)
        {
            ArtChar1a.SetActive(false);
            ArtSoldier.SetActive(true);
            Char1name.text = "Soldier";
            Char1speech.text = "Sir yes sir!";
        }
        else if (primeInt == 59)
        {
            ArtBG1.SetActive(false);
            ArtBlack.SetActive(true);
            ArtSoldier.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2speech.text = "After the interrogation, some prisoners confessed and gave up, spilling valuable information, but a few committed suicide by biting on a cyanide pills hidden in their mouths.";
        }
        else if (primeInt == 60)
        {
            Char2speech.text = "Hauptmann Schwarz didnít hear any sounds of the prisonerís pain.";
        }
        else if (primeInt == 61)
        {
            ArtBG1.SetActive(true);
            ArtBlack.SetActive(false);
            ArtChar2b.SetActive(true);
            Char2name.text = "Hauptmann Schwarz";
            Char2speech.text = "Why were there no screams or any sounds from the prisoners? Did you disobey my orders!?";
        }
        else if (primeInt == 62)
        {
            Char2speech.text = "I'll have you court martialed for this! " + GameHandler.playerName + "! You hear me!?";
        }
        else if (primeInt == 63)
        {
            ArtChar2b.SetActive(false);
            Char2name.text = "";
            Char2speech.text = "";
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "...";
        }
        else if (primeInt == 64)
        {
            Char1speech.text = "(I've made my decision, and I won't go back. I'll live with the weight of my choices from now, until the moment of my death.)";
        }
        else if (primeInt == 65)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2speech.text = "Article 17: No physical or mental torture, nor any form of coercion, may be inflicted on prisoners of war to secure information from them.";
        }
        else if (primeInt == 66)
        {
            Char2speech.text = "Article 13: Prisoners of war must not be killed, mistreated, or subjected to violence or intimidation.";
        }
        else if (primeInt == 67)
        {
            Char2speech.text = "Article 14: Respect for PrisonersÅEHonor and Rights";
        }
        else if (primeInt == 68)
        {
            SceneManager.LoadScene("Scene4");
        }
        //Please do NOT delete this final bracket that ends the Next() function:
    }

    // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
    public void Choice1aFunct()
    {
        ArtChar1a.SetActive(true);
        GameHandler.playerScore -= 2;
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "On your command, Herr Hauptmann.";
        Char2name.text = "";
        Char2speech.text = "";
        primeInt = 8; // so hitting "NEXT" goes to primeInt==9!
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }
    public void Choice1bFunct()
    {
        ArtChar1a.SetActive(true);
        GameHandler.playerScore += 1;
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Iím afraid I cannot comply. These prisoners wonít cooperate with us and give us useful information if we torture them to death";
        Char2name.text = "";
        Char2speech.text = "";
        primeInt = 22; // so hitting "NEXT" goes to primeInt==23!
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }


    public void Choice2aFunct()
    {
        ArtChar2b.SetActive(false);
        ArtChar1a.SetActive(true);
        GameHandler.playerScore += 1;
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "If you refuse to stop these brutal tactics, then I will have you reported to the higher ups!";
        Char2name.text = "";
        Char2speech.text = "";
        primeInt = 29; // so hitting "NEXT" goes to primeInt==9!
        Choice2a.SetActive(false);
        Choice2b.SetActive(false);
        Choice2c.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }
    public void Choice2bFunct()
    {
        ArtChar2b.SetActive(false);
        ArtChar1b.SetActive(true);
        GameHandler.playerScore -= 1;
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "I...";
        Char2name.text = "";
        Char2speech.text = "";
        primeInt = 36; // so hitting "NEXT" goes to primeInt==37!
        Choice2a.SetActive(false);
        Choice2b.SetActive(false);
        Choice2c.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
    }

    public void Choice2cFunct()
    {
        ArtChar2b.SetActive(false);
        ArtChar1a.SetActive(true);
        GameHandler.playerScore += 2;
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Very well. I will do as you say.";
        Char2name.text = "";
        Char2speech.text = "";
        primeInt = 46; // so hitting "NEXT" goes to primeInt==37!
        Choice2a.SetActive(false);
        Choice2b.SetActive(false);
        Choice2c.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
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