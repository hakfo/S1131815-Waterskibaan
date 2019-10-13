using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Waterskibaan;

namespace WaterskibaanGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Game game = new Game();
        LinkedList<Brush> colors = new LinkedList<Brush>();
        Dictionary<int, int> sporterGegevens = new Dictionary<int, int>();
        LinkedList<int> IDs = new LinkedList<int>();
        List<int> scores = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            game.Initialize();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            game.waterskibaan.Start();

            int i = 0;

            Counter.Content = game.oteCounter;
            WachtrijInstructieNummer.Content = game.wachtrijInstructie.GetAlleSporters().Count;
            InstructieGroepNummer.Content = game.instructieGroep.GetAlleSporters().Count;
            WachtrijStartenNummer.Content = game.wachtrijStarten.GetAlleSporters().Count;
            LijnenvoorraadCounter.Content = game.waterskibaan.lijnenVoorraad.GetAantalLijnen();

            i++;

            try
            {
                if (game.oteCounter % 4 == 0)
                {
                    System.Drawing.Color kleur = game.waterskibaan.kabel._lijnen.ElementAt(i).sp.KledingKleur;
                    int id = game.waterskibaan.kabel._lijnen.ElementAt(i).sp.ID;
                    Brush tempBrush = new SolidColorBrush(Color.FromArgb(kleur.A, kleur.R, kleur.G, kleur.B));
                    Brush wit = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    colors.AddFirst(tempBrush);
                    IDs.AddFirst(id);


                    Positie0.Fill = colors.ElementAt(0) ?? wit;
                    IDSpeler0.Content = IDs.ElementAt(0);
                    Positie1.Fill = colors.ElementAt(1) ?? wit;
                    IDSpeler1.Content = IDs.ElementAt(1);
                    Positie2.Fill = colors.ElementAt(2) ?? wit;
                    IDSpeler2.Content = IDs.ElementAt(2);
                    Positie3.Fill = colors.ElementAt(3) ?? wit;
                    IDSpeler3.Content = IDs.ElementAt(3);
                    Positie4.Fill = colors.ElementAt(4) ?? wit;
                    IDSpeler4.Content = IDs.ElementAt(4);
                    Positie5.Fill = colors.ElementAt(5) ?? wit;
                    IDSpeler5.Content = IDs.ElementAt(5);
                    Positie6.Fill = colors.ElementAt(6) ?? wit;
                    IDSpeler6.Content = IDs.ElementAt(6);
                    Positie7.Fill = colors.ElementAt(7) ?? wit;
                    IDSpeler7.Content = IDs.ElementAt(7);
                    Positie8.Fill = colors.ElementAt(8) ?? wit;
                    IDSpeler8.Content = IDs.ElementAt(8);
                    Positie9.Fill = colors.ElementAt(9) ?? wit;
                    IDSpeler9.Content = IDs.ElementAt(9);

                    int score = game.waterskibaan.kabel._lijnen.ElementAt(i).sp.BehaaldePunten;
                    scores.Add(score);

                    scores.Sort();
                    scores.Reverse();
                    LeaderboardScore0.Content = scores[0];
                    LeaderboardScore1.Content = scores[1];
                    LeaderboardScore2.Content = scores[2];
                    LeaderboardScore3.Content = scores[3];
                    LeaderboardScore4.Content = scores[4];

                    ///////////////////////////////////////////////////////////////////////////////////////////////
                    ///                                           T O   D O :                                   ///
                    ///     Op het moment werkt het bovenstaande ongeveer. De kleuren gaan redelijk             ///
                    ///     netjes over naar de volgende. Helaas beginnen de IDs om een of andere reden         ///
                    ///     vanaf 2. Daarnaast is er een soort ritme waarbij elk 5e ID/kleur dubbel geprint     ///
                    ///     wordt en dus niet klopt. Het opvolgende ID/kleur wordt overgeslagen. Het leader-    ///
                    ///     board zoals die hierboven staat werkt in principe ook. De scores worden netjes      ///
                    ///     gesorteerd en gedisplayed. Soms verdwijnen echter scores. Nog onzeker waarom.       ///
                    ///     (garbage collector?) Probeer nu met onderstaande code de LinkedList van IDs en      ///
                    ///     de List van scores om te zetten in een Dictionary zodat ik kan sorteren maar wel    ///
                    ///     de goede ID bij de goede score houdt. Tot nu toe crashed onderstaande code echter   ///
                    ///     en ik kan niet goed gedisplayed krijgen wat de error inhoudt. Ik weet enkel dat     ///
                    ///     het een ArgumentOutOfRange exception betreft. Blijkbaar gooit hij die de hele tijd  ///
                    ///     al maar heeft ie niet voor directe opvallende problemen gezorgd. Met onderstaande   ///
                    ///     code werkt het echter helemaal niet meer.                                           ///
                    ///                                                                                         ///
                    ///     Tevens is de huidige manier van refreshen niet optimaal. Ik kan het programma op    ///
                    ///     het moment niet meer stoppen als het eenmal begonnen is. De buttons lijken te       ///
                    ///     freezen. Nog onzeker hoe ik dit ga fixen.                                           ///
                    ///                                                                                         ///
                    ///////////////////////////////////////////////////////////////////////////////////////////////


                    /*                  System.Drawing.Color kleur = game.waterskibaan.kabel._lijnen.ElementAt(i).sp.KledingKleur;
                                        int id = game.waterskibaan.kabel._lijnen.ElementAt(i).sp.ID;
                                        int score = game.waterskibaan.kabel._lijnen.ElementAt(i).sp.BehaaldePunten;
                                        Brush tempBrush = new SolidColorBrush(Color.FromArgb(kleur.A, kleur.R, kleur.G, kleur.B));
                                        Brush wit = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                                        sporterGegevens.Add(id, score);


                                        Positie0.Fill = colors.ElementAt(0) ?? wit;
                                        IDSpeler0.Content = sporterGegevens.Count;
                                        Positie1.Fill = colors.ElementAt(1) ?? wit;
                                        IDSpeler1.Content = sporterGegevens.Keys.ElementAt(1).ToString();
                                        Positie2.Fill = colors.ElementAt(2) ?? wit;
                                        IDSpeler2.Content = sporterGegevens.Keys.ElementAt(2).ToString();
                                        Positie3.Fill = colors.ElementAt(3) ?? wit;
                                        IDSpeler3.Content = sporterGegevens.Keys.ElementAt(3);
                                        Positie4.Fill = colors.ElementAt(4) ?? wit;
                                        IDSpeler4.Content = sporterGegevens.Keys.ElementAt(4);
                                        Positie5.Fill = colors.ElementAt(5) ?? wit;
                                        IDSpeler5.Content = sporterGegevens.Keys.ElementAt(5);
                                        Positie6.Fill = colors.ElementAt(6) ?? wit;
                                        IDSpeler6.Content = sporterGegevens.Keys.ElementAt(6);
                                        Positie7.Fill = colors.ElementAt(7) ?? wit;
                                        IDSpeler7.Content = sporterGegevens.Keys.ElementAt(7);
                                        Positie8.Fill = colors.ElementAt(8) ?? wit;
                                        IDSpeler8.Content = sporterGegevens.Keys.ElementAt(8);
                                        Positie9.Fill = colors.ElementAt(9) ?? wit;
                                        IDSpeler9.Content = sporterGegevens.Keys.ElementAt(9);				

                                        foreach (KeyValuePair<int, int> sporterGegeven in sporterGegevens.OrderBy(key => key.Value))
                                        {
                                            int gegevenScore = sporterGegeven.Value;
                                            int gegevenID = sporterGegeven.Key;

                                            if (score0 < gegevenScore)
                                            {
                                                score0 = gegevenScore;
                                                idscore0 = gegevenID;
                                            }
                                            else if (score1 < gegevenScore)
                                            {
                                                score1 = gegevenScore;
                                                idscore1 = gegevenID;
                                            }
                                            else if (score2 < gegevenScore)
                                            {
                                                score2 = gegevenScore;
                                                idscore2 = gegevenID;
                                            }
                                            else if (score3 < gegevenScore)
                                            {
                                                score3 = gegevenScore;
                                                idscore3 = gegevenID;
                                            }
                                            else if (score4 < gegevenScore)
                                            {
                                                score4 = gegevenScore;
                                                idscore4 = gegevenID;
                                            }
                                        }

                                        LeaderboardScore0.Content = score0;
                                        LeaderboardScore1.Content = score1;
                                        LeaderboardScore2.Content = score2;
                                        LeaderboardScore3.Content = score3;
                                        LeaderboardScore4.Content = score4;

                                        LeaderboardPlek0.Content = idscore0;
                                        LeaderboardPlek1.Content = idscore1;
                                        LeaderboardPlek2.Content = idscore2;
                                        LeaderboardPlek3.Content = idscore3;
                                        LeaderboardPlek4.Content = idscore4;        */
                }
            }
            catch (Exception ex)
            {
                Test.Content = ex;
            }

            Counter.Refresh();
            Thread.Sleep(1000);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            game.waterskibaan.Stop();
            Test.Content = game.waterskibaan.isGestart;
        }
    }

    // Hoe het werkt, geen idee, maar het zorgt ervoor dat het UIElement waar het op aangeroepen wordt refreshed en daarbij alles met een 'hogere prioriteit'. 
    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
