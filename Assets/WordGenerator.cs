using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Muista lis�t� t�m�

public class WordGenerator : MonoBehaviour
{
    // TextMesh Pro -komponentit, joihin sanat asetetaan
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;  // Uusi tekstikentt� suomennoksille

    // Englannin yleisimm�t sanat ja niiden suomennokset
    private Dictionary<string, string> wordDictionary = new Dictionary<string, string>
{
    { "Accept", "Hyv�ksy�" },
    { "Agree", "Sopia" },
    { "Answer", "Vastata" },
    { "Arrive", "Saapua" },
    { "Ask", "Kysy�" },
    { "Begin", "Aloittaa" },
    { "Believe", "Uskoa" },
    { "Blend", "Sekoittaa" },
    { "Borrow", "Lainata" },
    { "Bring", "Tuoda" },
    { "Build", "Rakentaa" },
    { "Buy", "Ostaa" },
    { "Call", "Soittaa" },
    { "Cancel", "Peruuttaa" },
    { "Change", "Muuttaa" },
    { "Check", "Tarkistaa" },
    { "Choose", "Valita" },
    { "Clean", "Puhdistaa" },
    { "Compete", "Kilpailla" },
    { "Contact", "Ota yhteytt�" },
    { "Control", "Hallita" },
    { "Convert", "Muuttaa" },
    { "Create", "Luoda" },
    { "Cure", "Parantaa" },
    { "Dance", "Tanssia" },
    { "Decide", "P��t��" },
    { "Deliver", "Toimittaa" },
    { "Describe", "Kuvailla" },
    { "Destroy", "Tuhoaa" },
    { "Discuss", "Keskustella" },
    { "Do", "Tehd�" },
    { "Drink", "Juoda" },
    { "Drive", "Ajaa" },
    { "Eat", "Sy�d�" },
    { "Enjoy", "Nauttia" },
    { "Explain", "Selitt��" },
    { "Feel", "Tuntea" },
    { "Find", "L�yt��" },
    { "Finish", "Lopettaa" },
    { "Fix", "Korjata" },
    { "Follow", "Seurata" },
    { "Forget", "Unohtaa" },
    { "Give", "Antaa" },
    { "Go", "Menn�" },
    { "Guess", "Arvata" },
    { "Hate", "Vihata" },
    { "Hear", "Kuulla" },
    { "Help", "Auttaa" },
    { "Hold", "Pit�� kiinni" },
    { "Hop", "Hyp�t�" },
    { "Hope", "Toivoa" },
    { "Introduce", "Esitell�" },
    { "Join", "Liitty�" },
    { "Jump", "Hyppi�" },
    { "Keep", "Pit��" },
    { "Know", "Tiet��" },
    { "Laugh", "Nauraa" },
    { "Learn", "Oppia" },
    { "Leave", "L�hte�" },
    { "Like", "Pit��" },
    { "Listen", "Kuunnella" },
    { "Look", "Katsoa" },
    { "Lose", "H�vit�" },
    { "Make", "Tehd�" },
    { "Meet", "Tavata" },
    { "Move", "Liikkua" },
    { "Need", "Tarvita" },
    { "Open", "Avaa" },
    { "Play", "Pelata" },
    { "Put", "Laittaa" },
    { "Read", "Lukea" },
    { "Remember", "Muistaa" },
    { "Run", "Juosta" },
    { "Say", "Sanoa" },
    { "See", "N�hd�" },
    { "Send", "L�hett��" },
    { "Shout", "Huuda" },
    { "Show", "N�ytt��" },
    { "Sing", "Laulaa" },
    { "Sit", "Istua" },
    { "Sleep", "Nukkua" },
    { "Speak", "Puhua" },
    { "Start", "Aloittaa" },
    { "Stay", "Pysy�" },
    { "Stop", "Pys�hty�" },
    { "Study", "Opiskella" },
    { "Take", "Ottaa" },
    { "Talk", "Puhua" },
    { "Teach", "Opettaa" },
    { "Tell", "Kertoa" },
    { "Think", "Ajatella" },
    { "Throw", "Heitt��" },
    { "Turn", "K��nty�" },
    { "Understand", "Ymm�rt��" },
    { "Use", "K�ytt��" },
    { "Visit", "Vierailla" },
    { "Wait", "Odottaa" },
    { "Walk", "K�vell�" },
    { "Want", "Haluta" },
    { "Watch", "Katsoa" },
    { "Win", "Voittaa" },
    { "Wonder", "Ihmetell�" },
    { "Yell", "Huutaa" },
    { "Zip", "Vetoketju" },
    { "Account", "Tili" },
    { "Asset", "Asema" },
    { "Balance", "Tasapaino" },
    { "Bank", "Pankki" },
    { "Bond", "Obligaatio" },
    { "Budget", "Budjetti" },
    { "Capital", "P��oma" },
    { "Cash", "K�teinen" },
    { "Cheque", "Shekki" },
    { "Claim", "Vaatimus" },
    { "Client", "Asiakas" },
    { "Collateral", "Vakuus" },
    { "Commission", "Palkkio" },
    { "Company", "Yritys" },
    { "Contract", "Sopimus" },
    { "Credit", "Luotto" },
    { "Debt", "Velka" },
    { "Deposit", "Talletus" },
    { "Dividend", "Osinko" },
    { "Economy", "Talous" },
    { "Equity", "Oma p��oma" },
    { "Exchange", "Vaihto" },
    { "Expense", "Kulutus" },
    { "Financial", "Rahoitus" },
    { "Forecast", "Ennuste" },
    { "Fund", "Rahasto" },
    { "Gross", "Brutto" },
    { "Income", "Tulo" },
    { "Inflation", "Inflaatio" },
    { "Interest", "Korko" },
    { "Investment", "Sijoitus" },
    { "Loan", "Laina" },
    { "Loss", "Tappio" },
    { "Market", "Markkinat" },
    { "Mortgage", "Asuntolaina" },
    { "Net", "Nettotulo" },
    { "Portfolio", "Salkku" },
    { "Profit", "Voitto" },
    { "Rate", "Korko" },
    { "Return", "Tuotto" },
    { "Risk", "Riski" },
    { "Share", "Osake" },
    { "Stock", "Osake" },
    { "Tax", "Vero" },
    { "Transaction", "Kauppa" },
    { "Trust", "S��ti�" },
    { "Valuation", "Arviointi" },
    { "Withdrawal", "Nosto" },
    { "Yield", "Tuotto" },
    { "Athlete", "Urheilija" },
    { "Ball", "Pallo" },
    { "Basketball", "Koripallo" },
    { "Coach", "Valmentaja" },
    { "Competition", "Kilpailu" },
    { "Contest", "Kilpa" },
    { "Court", "Kentt�" },
    { "Crossfit", "Crossfit" },
    { "Cycling", "Py�r�ily" },
    { "Defend", "Puolustaa" },
    { "Defense", "Puolustus" },
    { "Diamond", "Kentt�" },
    { "Draw", "Tasapeli" },
    { "Dunk", "Dunkata" },
    { "Goal", "Maali" },
    { "Goalkeeper", "Maalitykki" },
    { "Golf", "Golf" },
    { "Gymnastics", "Voimistelu" },
    { "Hockey", "J��kiekko" },
    { "Home Run", "Kotijuoksu" },
    { "League", "Liiga" },
    { "Match", "Ottelu" },
    { "Offside", "Paitsio" },
    { "Penalty", "Rangaistus" },
    { "Player", "Pelaaja" },
    { "Race", "Kilpailu" },
    { "Referee", "Tuomari" },
    { "Score", "Pisteet" },
    { "Team", "Joukkue" },
    { "Tournament", "Turnaus" }
};

    // Manually assign the cubes (GameObjects)  
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    void Start()
    {
        // Valitse kolme uniikkia sanaa listasta
        List<string> selectedWords = GetUniqueRandomWords(3);

        // Aseta sanat TextMesh Pro -komponentteihin
        text1.text = selectedWords[0];
        text2.text = selectedWords[1];
        text3.text = selectedWords[2];

        // Lis�� suomennos viimeiseen text elementtiin
        string selectedWordForTranslation = selectedWords[Random.Range(0,3)];
        text4.text = wordDictionary[selectedWordForTranslation]; // N�ytet��n sana ja sen suomennos

        // Change tags based on the correct answer
        ChangeTagsBasedOnCorrectAnswer(selectedWords, selectedWordForTranslation);
    }

    // Funktio, joka valitsee uniikit sanat
    private List<string> GetUniqueRandomWords(int count)
    {
        List<string> copyList = new List<string>(wordDictionary.Keys);  // Ota sanat sanakirjasta
        List<string> selectedWords = new List<string>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, copyList.Count);
            selectedWords.Add(copyList[randomIndex]);
            copyList.RemoveAt(randomIndex); // Poista valittu sana, jotta se ei toistu
        }

        return selectedWords;
    }

    // Funktio, joka vaihtaa tagit oikean vastauksen mukaan
    private void ChangeTagsBasedOnCorrectAnswer(List<string> selectedWords, string translation)
    {

        // Check the translations and assign the correct tag
        if (selectedWords[0] == translation)
        {
            SetTagToCorrect(cube1);
            SetTagToIncorrect(cube2);
            SetTagToIncorrect(cube3);
            Debug.Log("Cube 1 set to correct tag");
        }
        else if (selectedWords[1] == translation)
        {
            SetTagToCorrect(cube2);
            SetTagToIncorrect(cube1);
            SetTagToIncorrect(cube3);
            Debug.Log("Cube 2 set to correct tag");
        }
        else if (selectedWords[2] == translation)
        {
            SetTagToCorrect(cube3);
            SetTagToIncorrect(cube1);
            SetTagToIncorrect(cube2);
            Debug.Log("Cube 3 set to correct tag");
        }
    }

    // Helper function to set the tag to "correct" for the Cube GameObject
    private void SetTagToCorrect(GameObject cube)
    {
        Debug.Log("Setting tag to correct for: " + cube.name);
        cube.tag = "correct";
    }

    // Helper function to set the tag to "incorrect" for the Cube GameObject
    private void SetTagToIncorrect(GameObject cube)
    {
        Debug.Log("Setting tag to incorrect for: " + cube.name);
        cube.tag = "incorrect";
    }
}
