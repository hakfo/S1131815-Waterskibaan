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

        int score0;
        int score1;
        int score2;
        int score3;
        int score4;

        int idscore0;
        int idscore1;
        int idscore2;
        int idscore3;
        int idscore4;

        public MainWindow()
        {
            InitializeComponent();
            game.Initialize();
        }

        // Als er op het start knopje gedrukt wordt voert hij dit uit
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            game.waterskibaan.Start();
            while (game.waterskibaan.isGestart)
            {
                // Zet de genoemde labels op de gegeven waardes. De counter houdt de tijd bij. De rest spreekt voor zichzelf.
                Counter.Content = game.oteCounter;
                WachtrijInstructieNummer.Content = game.wachtrijInstructie.GetAlleSporters().Count;
                InstructieGroepNummer.Content = game.instructieGroep.GetAlleSporters().Count;
                WachtrijStartenNummer.Content = game.wachtrijStarten.GetAlleSporters().Count;
                LijnenvoorraadCounter.Content = game.waterskibaan.lijnenVoorraad.GetAantalLijnen();

                // De code werkt blijkbaar wel met een try-catch blok. Het is niet wenselijk gedrag, maar zorgt er wel voor dat ik kan blijven debuggen.
                // De code gooit momenteel regelmatig een ArgumentOutOfRange exception. Achterhalen waar dit vandaan komt.
                try
                {
                    if (game.oteCounter % 4 == 0)
                    {
                        // Dit blok zorgt ervoor dat de System.Drawing.Color naar een System.Windows.Media.Brush gezet wordt.
                        // Dit wordt gebruikt om de kleur van de cirkels die de positie weergeven op de kabelbaan te veranderen om zo een volgorde te simuleren.
                        // Daarnaast wordt het ID van de speler meegegeven zodat de volgorde ook gevolgd kan worden op nummer.
                        

                        if (game.waterskibaan.kabel._lijnen.Count > 0)
                        {
                            System.Drawing.Color kleur = game.waterskibaan.kabel._lijnen.ElementAt(0).sp.KledingKleur;
                            Brush tempBrush = new SolidColorBrush(Color.FromArgb(kleur.A, kleur.R, kleur.G, kleur.B));
                            Brush wit = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

                            if (game.waterskibaan.kabel._lijnen.ElementAt(0) != null)
                            {
                                colors.AddFirst(tempBrush);
                            }
                            else
                            {
                                colors.AddFirst(wit);
                            }

                            int id = game.waterskibaan.kabel._lijnen.ElementAt(0).sp.ID;
                            IDs.AddFirst(id);

                            int score = game.waterskibaan.kabel._lijnen.ElementAt(0).sp.BehaaldePunten;
                            scores.Add(score);


                            // Was een leuke oplossing geweest maar mag niet.
                            if(!sporterGegevens.ContainsKey(id))
                            {
                                sporterGegevens.Add(id, score);
                            } 
                            else
                            {
                                foreach (KeyValuePair<int, int> sporterGegeven in sporterGegevens)
                                {
                                    if(sporterGegeven.Key == id)
                                    {
                                        int tempScore = sporterGegeven.Value;
                                        score += tempScore;
                                        sporterGegevens.Remove(sporterGegeven.Key);
                                        sporterGegevens.Add(id, score);
                                    }
                                }
                            }
                            
                        }

                        // Selecteert de top 5 scores uit sporterGegevens op een manier die heel erg lijkt op queries. Vast niet effectief, maar het enigste dat leek te werken.

                        var top5SporterScores =                         // Maakt een IEnumerable<KeyValuePair<int, int> aan. De KeyValuePair is een ID + Score van de sporterGegevens.
                            (from sporterScores                         // Een zogenaamde compound from
                            in sporterGegevens                          // Waar de gegevens uit moeten komen
                             orderby sporterScores.Value                // Sorteren op basis van de value (Dus niet de key)
                             descending select sporterScores)           // We willen dat hij hem aflopend sorteert zodat ze hoogste waarde bovenaan komt (Het is immers een topscore)
                            .ToDictionary                               // 
                            (set => set.Key, set => set.Value)          // De Key en de Value refereren hierbij naar zichzelf. We willen immers niks toevoegen, enkel dat de volgorde verandert.
                            .Take(5);                                   // Stopt enkel de hoogste 5 in de var



                        // Zeer lelijke code om de cirkels te blijven vullen. 
                        int count = sporterGegevens.Count();
                        int i = 0;

                        if (count > i)
                        {
                            Positie0.Fill = colors.ElementAt(i);
                            IDSpeler0.Content = IDs.ElementAt(i);
                            LeaderboardScore0.Content = top5SporterScores.ElementAt(i).Value;
                            LeaderboardPlek0.Content = top5SporterScores.ElementAt(i).Key;
                        }

                        i++;

                        if (count > i)
                        {
                            Positie1.Fill = colors.ElementAt(i);
                            IDSpeler1.Content = IDs.ElementAt(i);
                            LeaderboardScore1.Content = top5SporterScores.ElementAt(i).Value;
                            LeaderboardPlek1.Content = top5SporterScores.ElementAt(i).Key;
                        }

                        i++;

                        if (count > i)
                        {
                            Positie2.Fill = colors.ElementAt(i);
                            IDSpeler2.Content = IDs.ElementAt(i);
                            LeaderboardScore2.Content = top5SporterScores.ElementAt(i).Value;
                            LeaderboardPlek2.Content = top5SporterScores.ElementAt(i).Key;
                        }

                        i++;

                        if (count > i)
                        {
                            Positie3.Fill = colors.ElementAt(i);
                            IDSpeler3.Content = IDs.ElementAt(i);
                            LeaderboardScore3.Content = top5SporterScores.ElementAt(i).Value;
                            LeaderboardPlek3.Content = top5SporterScores.ElementAt(i).Key;
                        }

                        i++;

                        if (count > i)
                        {
                            Positie4.Fill = colors.ElementAt(i);
                            IDSpeler4.Content = IDs.ElementAt(i);
                            LeaderboardScore4.Content = top5SporterScores.ElementAt(i).Value;
                            LeaderboardPlek4.Content = top5SporterScores.ElementAt(i).Key;
                        }

                        i++;

                        if (count > i)
                        {
                            Positie5.Fill = colors.ElementAt(i);
                            IDSpeler5.Content = IDs.ElementAt(i);
                        }

                        i++;

                        if (count > i)
                        {
                            Positie6.Fill = colors.ElementAt(i);
                            IDSpeler6.Content = IDs.ElementAt(i);
                        }

                        i++;

                        if (count > i)
                        {
                            Positie7.Fill = colors.ElementAt(i);
                            IDSpeler7.Content = IDs.ElementAt(i);
                        }

                        i++;

                        if (count > i)
                        {
                            Positie8.Fill = colors.ElementAt(i);
                            IDSpeler8.Content = IDs.ElementAt(i);
                        }

                        i++;

                        if (count > i)
                        {
                            Positie9.Fill = colors.ElementAt(i);
                            IDSpeler9.Content = IDs.ElementAt(i);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Test.Content = ex;
                    Console.WriteLine(ex);
                }

                // Zorgt ervoor dat alles labels en cirkels gerefreshed worden zodat de waardes kloppen met hoe ze aangepast zijn.
                Counter.Refresh();
                Thread.Sleep(1000);
            }
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
