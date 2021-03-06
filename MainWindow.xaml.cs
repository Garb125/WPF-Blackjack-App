using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blackjack_App_v._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //static List<Card> gameDeck = new Deck().DeckBuilder();
        static Deck gameDeck = new Deck();
        static Chips playerStack = new Chips();
        //List<Card> cardStack = gameDeck.deck;
        static Hand playerHand = new Hand();
        static Hand dealerHand = new Hand();
        static bool playing = false;

        public MainWindow()
        {
            InitializeComponent();

            StartUp();

            //StartGame();

            /*
            Card testCard = new Card("Spades", 2);
            Console.WriteLine(testCard);
            //image1.Source = (ImageSource)(object)testCard.Source;

            image1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(testCard.Source);
            GamePrompt.Content = testCard;
            */

            //Deck gameDeck = new Deck();


            //List<Card> cardStack = gameDeck.DeckBuilder();
            Console.WriteLine(gameDeck.deck.Count());
            
            //Console.WriteLine(cardStack[20]);
            //Console.WriteLine(rand.Next(0,cardStack.Count()));

            //Console.WriteLine(gameDeck.drawCard());
            //Console.WriteLine(cardStack.Count());

            

            Console.WriteLine(playerHand.HandValue);
            Console.WriteLine(playerHand.HandComp);
            Console.WriteLine(gameDeck.deck.Count());
            Console.WriteLine(playerStack.CurrentBet);

            //Console.WriteLine(gameDeck.DeckBuilder().Count);
            //Console.WriteLine(gameDeck.DeckBuilder()[5]);            


        }
        //Random rand = new Random();

        public void StartUp()
        {
            PopulateBet();
            GamePrompt.Content = "Select Your Bet";
            

            PlayAgainButton.Visibility = Visibility.Hidden;
            ExitButton.Visibility = Visibility.Hidden;
            HitButton.Visibility = Visibility.Hidden;
            StayButton.Visibility = Visibility.Hidden;

            PlayerValue.Content = playerHand.HandValue;
            DealerValue.Content = dealerHand.HandValue;

            pc_0.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\GG-Code\\Pictures\\cardimages\\back-blue.gif");
            pc_1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\GG-Code\\Pictures\\cardimages\\back-blue.gif");
            dc_0.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\GG-Code\\Pictures\\cardimages\\back-blue.gif");
            dc_1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\GG-Code\\Pictures\\cardimages\\back-blue.gif");

            pc_2.Visibility = Visibility.Hidden;
            pc_3.Visibility = Visibility.Hidden;
            dc_2.Visibility = Visibility.Hidden;
            dc_3.Visibility = Visibility.Hidden;
        }
        
        public void StartGame()
        {
            //PopulateBet();
            //GamePrompt.Content = "Select Your Bet";

            //HitButton.IsEnabled = true;
            //StayButton.IsEnabled = true;

            Playing();

            playerStack.Bet((int)cbBet.SelectedValue);
            ChipStack.Content = playerStack.Total; 

            playerHand.AddCard(gameDeck.drawCard());
            Thread.Sleep(2000);
            playerHand.AddCard(gameDeck.drawCard());
            Thread.Sleep(2000);            
            dealerHand.AddCard(gameDeck.drawCard());
            pc_0.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(playerHand.HandComp[0].Source);
            pc_1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(playerHand.HandComp[1].Source);
            dc_0.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(dealerHand.HandComp[0].Source);

            PlayerValue.Content = playerHand.HandValue;
            DealerValue.Content = dealerHand.HandValue;
            playerHand.BustCheck();

        }

        public void Playing()
        {
            if(!playing)
            {
                HitButton.Visibility = Visibility.Hidden;
                StayButton.Visibility = Visibility.Hidden; 

                PlayAgainButton.Visibility = Visibility.Visible;
                ExitButton.Visibility = Visibility.Visible;
            }
            else
            {
                HitButton.Visibility = Visibility.Visible;
                StayButton.Visibility = Visibility.Visible;

                PlayAgainButton.Visibility = Visibility.Hidden;
                ExitButton.Visibility = Visibility.Hidden;
            }
        }

        public void PlayAgain()
        {
            //*** Remake gamedeck ***//
            //playing = true;
            Playing();

            
            gameDeck = new Deck();
            playerHand = new Hand();
            dealerHand = new Hand();
            playerStack.CurrentBet = 0;
            //GamePrompt.Content = gameDeck.deck.Count;

            //*** Redo setup ***//

            //playerHand.HandComp.Clear();
            //dealerHand.HandComp.Clear();
            

            //dc_1.Visibility = Visibility.Hidden;
            

            StartUp();

        }

        public void PopulateBet()
        {
            int[] betList = new int[] { 0,5, 10, 25, 50, 100 };
            cbBet.ItemsSource = betList;
            cbBet.SelectedIndex = 0;
            playing = true;
        }

        public void DealCard()
        {
            playerHand.AddCard(gameDeck.drawCard());
            PlayerValue.Content = playerHand.HandValue;
        }

        public void WinCheck()
        {
            if (dealerHand.HandValue > 21)
            {
                playerStack.AddFunds();
                GamePrompt.Content = $"You Win! Play Again? {playerStack.Total}";                
                ChipStack.Content = playerStack.Total;
                playing = false;
                Playing();
            }
            else if (dealerHand.HandValue > playerHand.HandValue && dealerHand.HandValue <= 21)
            {                
                GamePrompt.Content = $"You Lose! Play Again? {playerStack.Total}";
                playing = false;
                Playing();
            }
            else if (dealerHand.HandValue < playerHand.HandValue)
            {
                playerStack.AddFunds();
                GamePrompt.Content = $"You Win! Play Again? {playerStack.Total}";                
                ChipStack.Content = playerStack.Total;
                playing = false;
                Playing();
            }
            else if (dealerHand.HandValue == playerHand.HandValue)
            {
                GamePrompt.Content = $"Draw! Play Again? {playerStack.Total}";
                playing = false;
                Playing();                
            }
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            //string picture = $"pc_{playerHand.HandComp.Count}";
            
            DealCard();

            switch (playerHand.HandComp.Count)
            {
                case 3:
                    pc_2.Visibility = Visibility.Visible;
                    pc_2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(playerHand.HandComp[2].Source);
                    GamePrompt.Content = $"{playerStack.Total} - {playerStack.CurrentBet}";
                    break;
                case 4:
                    pc_3.Visibility = Visibility.Visible;
                    pc_3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(playerHand.HandComp[3].Source);
                    GamePrompt.Content = $"{playerStack.Total} - {playerStack.CurrentBet}";
                    break;
                default:
                    break;
            }
            switch (playerHand.BustCheck())
            {
                case "Blackjack":
                    playing = false;
                    Playing();
                    GamePrompt.Content = $"Blackjack! You Win! Play Again? {playerStack.Total}";
                    playerStack.AddFunds();
                    ChipStack.Content = playerStack.Total;
                    break;
                case "Bust":
                    playing = false;
                    Playing();
                    GamePrompt.Content = $"Bust! Play Again? {playerStack.Total}";                    
                    break;
                default:
                    break;
            }            



        }

        private void StayButton_Click(object sender, RoutedEventArgs e)
        {
            while (dealerHand.HandValue < 17)
            {
                dealerHand.AddCard(gameDeck.drawCard());
                switch (dealerHand.HandComp.Count)
                {
                    case 2:
                        dc_1.Visibility = Visibility.Visible;
                        dc_1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(dealerHand.HandComp[1].Source);
                        DealerValue.Content = dealerHand.HandValue;
                        break;
                    case 3:
                        dc_2.Visibility = Visibility.Visible;
                        dc_2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(dealerHand.HandComp[2].Source);
                        DealerValue.Content = dealerHand.HandValue;
                        break;
                    case 4:
                        dc_3.Visibility = Visibility.Visible;
                        dc_3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(dealerHand.HandComp[3].Source);
                        DealerValue.Content = dealerHand.HandValue;
                        break;

                    default:
                        break;
                }
                DealerValue.Content = dealerHand.HandValue;                               
            }
            WinCheck();
        }

        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            PlayAgain();
            //StartUp();

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbBet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (playing)
            {                
                StartGame();
            }
            
        }
    }
}
