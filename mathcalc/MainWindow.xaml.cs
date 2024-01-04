using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace CalcMath2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int gameKind;
        private int correctcount = 0;
        private int questionCounter = 0;
        private string userInput = string.Empty;
        private GameLogic currentGame;





        public MainWindow()
        {
            InitializeComponent();
            nameAnswer.TextChanged += nameAnswer_TextChanged;
        }

        private void ActivateGameForGrade(int grade)
        {
            Buttons.Visibility = Visibility.Collapsed;
            gameTitle.Visibility = Visibility.Collapsed;
            enterName.Visibility = Visibility.Collapsed;
            nameAnswer.Visibility = Visibility.Collapsed;
            exercises.Visibility = Visibility.Visible;
            checking.Visibility = Visibility.Visible;
            heyuser.Visibility = Visibility.Visible;
            nextQuestion.Visibility = Visibility.Visible;

            gameKind = grade;

            // Call the checking_Click method directly to activate the game
            checking_Click(this, new RoutedEventArgs());
        }
        private void grade1_Click(object sender, RoutedEventArgs e)
        {
            ActivateGameForGrade(1);

        }

        private void grade2_Click(object sender, RoutedEventArgs e)
        {
            ActivateGameForGrade(2);

        }

        private void grade3_Click(object sender, RoutedEventArgs e)
        {
            ActivateGameForGrade(3);

        }

        private void grade4_Click(object sender, RoutedEventArgs e)
        {
            ActivateGameForGrade(4);
        }

        private void GetNameFromText(string text, out string name)
        {
            name = text;
        }

        private void nameAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetNameFromText(nameAnswer.Text, out string name); // Extract the name using the out parameter
            heyuser.Text = "hey " + name + "!";

        }

        private void checking_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
        }

        private void answeruser_TextInput(object sender, TextCompositionEventArgs e)
        {
            userInput = answeruser.Text; // Store user input in the variable
        }

        private void nextQuestion_Click(object sender, RoutedEventArgs e)
        {
            MoveToNextQuestion();
        }
        private void MoveToNextQuestion()
        {
            // Clear the answer user input
            questionCounter++;

            if (questionCounter <= 10)
            {
                if (gameKind == 1)
                {
                    gameKind = 1;
                    currentGame = new GameLogic(gameKind, '+');
                    num1.Text = currentGame.GetNumber1().ToString();
                    num2.Text = currentGame.GetNumber2().ToString();
                    operation.Text = "+";
                }
                else if (gameKind == 2)
                {
                    gameKind = 2;
                    currentGame = new GameLogic(gameKind, '-');
                    num1.Text = currentGame.GetNumber1().ToString();
                    num2.Text = currentGame.GetNumber2().ToString();
                    operation.Text = "-";
                }
                else if (gameKind == 3)
                {
                    gameKind = 3;
                    currentGame = new GameLogic(gameKind, '*');
                    num1.Text = currentGame.GetNumber1().ToString();
                    num2.Text = currentGame.GetNumber2().ToString();
                    operation.Text = "*";
                }
                else if (gameKind == 4)
                {
                    gameKind = 4;
                    currentGame = new GameLogic(gameKind, '/');
                    num1.Text = currentGame.GetNumber1().ToString();
                    num2.Text = currentGame.GetNumber2().ToString();
                    operation.Text = "/";
                }

                answeruser.Text = string.Empty;

                // Show the "Next Question" button after displaying the new question
            }
            else
            {
                // Handle the case when all questions are answered
                if (correctcount != 0)
                {
                    double final_grade = (correctcount / 10.0) * 100;
                    MessageBox.Show($"All questions answered! Your final grade is {final_grade}");
                }
                else
                {
                    MessageBox.Show("All questions answered! Your final grade is 0, try again!");
                }
            }
        }

        private void CheckAnswer()
        {
            if (currentGame != null)
            {
                int rightAnswer = currentGame.GetRightAnswer();

                if (int.TryParse(answeruser.Text, out int usersAnswer))
                {
                    if (rightAnswer == usersAnswer)
                    {
                        MessageBox.Show("Correct! Good job!");
                        correctcount++;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect :( Try again!");
                    }
                }

                // Hide the "Next Question" button until the user checks the answer
            }

            if (questionCounter >= 10)
            {
                // Handle the case when all questions are answered
                if (correctcount != 0)
                {
                    double final_grade = (correctcount / 10.0) * 100;
                    MessageBox.Show($"All questions answered! Your final grade is {final_grade}");
                }
                else
                {
                    MessageBox.Show("All questions answered! Your final grade is 0, try again!");
                }
            }
        }
    }
}

