using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woorden_teller
{
    public partial class Form1 : Form
    {
        string defaultText = @"LaadLos is een verhuisbedrijf, dat zich heeft gespecialiseerd in het verhuizen van bedrijven. 
In 2007 is LaadLos als eenmanszaak met 1 verhuiswagen begonnen en is uitgegroeid tot een middelgroot bedrijf met 9 verhuiswagens en 27 mensen in vaste dienst. De administratie is meegegroeid van een zakagenda met verhuizingen tot een ingewikkelde wirwar van spreadsheets. Tijdens de ziekte van de secretaresse gingen een aantal zaken mis en daardoor is nu de vraag ontstaan om hier een systeem voor te ontwikkelen.
In het te ontwikkelen systeem moeten de diverse administraties (personeel, verhuisafspraken, klanten, inkoop, offertes, facturen en verhuisbestekken (overzicht van de te verhuizen goederen)) bijgehouden kunnen worden.
Een bedrijfsverhuizing kan behoorlijk ingewikkeld worden. Zo zijn er verschillende soorten inpak- en verhuismaterialen, denk hierbij aan verhuisdozen in allerlei maten, maar ook aan speciale kisten voor computers en servers, speciale kisten voor servies, rollende leggers (voor bijvoorbeeld bureaus, kasten en machines) en een speciaal systeem voor het verhuizen van archieven. Er zijn ook verschillende typen rijdend verhuismaterieel beschikbaar, variërend van een elektrische palletwagen tot een vrachtwagen met aanhanger. Indien noodzakelijk worden speciale voertuigen ingehuurd (bijvoorbeeld voor een internationale verhuizing of verhuizing van complete machineparken).
Het verhuispersoneel is opgeleid in het omgaan met verschillende soorten apparatuur en materialen en weet hier ook veilig mee om moeten gaan. Alle personeelsleden hebben een autorijbewijs (categorie B (vaak ook E achter B)), de meesten beschikken ook over een heftruckrijbewijs en een aantal over een vrachtwagenrijbewijs (categorie C). Slechts 2 personeelsleden mogen met een aanhangwagen achter de vrachtwagen rijden (rijbewijs E achter C). Voor het afbreken en inrichten van technische installaties zijn, vanwege wettelijke eisen, een aantal gecertificeerde bedrijven gecontracteerd.
Een verhuizing kost een klant veel geld. Niet alleen het inhuren van een verhuisbedrijf, maar vooral de stilstand van het bedrijf kan behoorlijk oplopen. Daarom wordt een dergelijke verhuizing altijd ruim van tevoren helemaal uitgepland. Zodat de verhuizing een zo klein mogelijke onderbreking van de bedrijfsprocessen betekent.
Bij het opstellen van een offerte gaat een adviseur van het bedrijf bij de klant kijken welke goederen verhuisd zullen worden. Ook wordt in overleg met de klant een globaal plan opgesteld, waarmee een schatting van de duur van de verhuizing en aanvullende kosten gemaakt kan worden, dit ter indicatie van de prijs. Vervolgens bekijkt de planner welke materialen, voertuigen en mensen nodig zijn. Op basis van de planning stelt de financieel expert een officiële offerte op. Deze is standaard 2 maanden geldig. LaadLos werkt met vaste prijzen, dus in de offerte prijs wordt een post voor risico’s en een post voor onvoorziene zaken opgenomen. Uiteraard wil Laadlos ook nog winst maken (ong. 6 tot 8 procent, afhankelijk van de grootte van de klus). Bovenop de gecalculeerde prijs moet bovendien BTW worden gerekend (op dit moment 21 %).
Wanneer de klant akkoord gaat met de offerte, wordt samen met de klant een actieplan opgesteld, waarin zowel de activiteiten van LaadLos als die van de klant worden opgenomen. Dit plan wordt over het algemeen een aantal keren aangepast, voordat het definitief gemaakt wordt. Wanneer het definitief is, wordt het als draaiboek verstuurd naar de klant, de werkvoorbereider, de planner, de inkoper en een kopie voor het papieren archief. Het zou prettig zijn wanneer de digitale versie ook aan het digitale dossier in het systeem gekoppeld kan worden.
Klanten hebben aangegeven het prettig te vinden als via een app kunnen zien hoe het staat met hun verhuizing. Daarom wordt de mogelijkheid tot het volgen van verhuisgoederen geïntroduceerd. In het vervolg kunnen bepaalde goederen (bijvoorbeeld servers of machines) bij de inventarisatie worden voorzien van een barcode of RFID chip, zodat deze bij het in-, over- en uitladen ingescand kan worden. Zo weet de klant waar deze zich ongeveer bevinden.
De verhuizers krijgen de beschikking over een smartphone met barcode scanner app of met RFID lezer (hierover wordt nog onderhandeld met leveranciers). Bij het inscannen van een artikel wordt meteen voor klanten zichtbaar welke status (ontkoppeld, klaar voor transport, op transport, etc.) het artikel heeft en op welke locatie deze zich bevindt (bijv. in opslag, op transport, op nieuwe locatie, etc.). Bij het inscannen wordt tevens voor de verhuizer zichtbaar waar het artikel heen moet (loodsnummer, kamernummer, verdieping, etc.). Tevens staat aangegeven of het artikel breekbaar of gevaarlijk is en eventuele aanvullende informatie en/of instructies.
Na afronding van de verhuizing wordt samen met de klant gekeken of alles naar wens is verlopen. Eventuele fouten worden opgelost en van veroorzaakte schade worden foto’s gemaakt en doorgestuurd naar de verzekering. In een aantal gevallen zal de acceptatie resulteren in een aanpassing van de factuurprijs.
Ten slotte wordt de factuur naar de klant gestuurd. Wanneer de klant te laat is met betalen wordt een herinnering gestuurd. Wordt na de herinnering niet tijdig betaald, ontvangt de klant een aanmaning met extra administratiekosten. Mocht de factuur hierna nog steeds niet voldaan worden, wordt een incasso bureau ingeschakeld. De exacte betalingstermijnen moeten nog worden vastgesteld.
";
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }

        void Form1_Shown(object sender, EventArgs e)
        {
            T_input.Text = defaultText;
            btn_convert_Click(null, null);
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            T_output.Clear();
            string input = T_input.Text;
            string[] woorden = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dic_geteldewoorden = new Dictionary<string, int>();
            foreach(string s in woorden)
            {
                if(dic_geteldewoorden.ContainsKey(s))
                    dic_geteldewoorden[s] += 1;
                else
                    dic_geteldewoorden.Add(s, 1);
            }
            List<KeyValuePair<string, int>> myList = dic_geteldewoorden.ToList();

            myList.Sort((firstPair, nextPair) =>
            {
                return firstPair.Value.CompareTo(nextPair.Value);
            }
            );
            for (int i = 0; i < myList.Count;i++)
            {
                if (myList[i].Key.Length <= 3)
                {
                    myList.RemoveAt(i);
                    i--;
                }
            }
            myList.Reverse();
            /*myList.Reverse();
            myList.Sort((firstPair, nextPair) =>
            {
                return firstPair.Key.Length.CompareTo(nextPair.Key.Length);
            }
            );
            myList.Reverse();
             * */
            string output = "";
            foreach(KeyValuePair<string,int> s in myList)
            {
                if(s.Key.Length > 3)
                {
                    output += s.Key + ":" + s.Value.ToString()  + Environment.NewLine;
                }
            }
            T_output.Text = output;
        }
    }
}
