using System; //Namespace declaration
using System.Collections; //Namespace declaration
using System.Collections.Generic; //Namespace declaration
using System.Drawing; //Namespace declaration
using System.Linq; //Namespace declaration
using System.Windows.Forms; //Namespace declaration

namespace HangmanGameEduvos2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Enables form to capture key events
            this.KeyDown += Form1_KeyDown; // Subscribing to KeyDown event
            textBox_guess.Enabled = false; // Disable TextBox initially
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            // Ensure the game has started before processing key events
            if (!textBox_guess.Enabled) return;

            // Allow specific keys for editing and navigation
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
            {
                e.SuppressKeyPress = false; // Let the TextBox handle these keys
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // Validate and process the word when Enter is pressed
                if (ValidateInput(textBox_guess.Text))
                {
                    attempts++;
                    checkWord();

                    // Check for draw condition
                    if (score == 5 && wrongGuesses == 5)
                    {
                        MessageBox.Show("It's a draw!", "Game Drawn");
                        EndGame();
                        return;
                    }

                    if (attempts >= 10)
                    {
                        EndGame();
                    }
                    else
                    {
                        SelectRandomWord();
                        displayWord();
                    }
                }

                e.SuppressKeyPress = true; // Prevent default behavior for Enter
            }
            else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                e.SuppressKeyPress = false; // Allow letters
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button_quit.PerformClick(); // Quit the game
                e.SuppressKeyPress = true;
            }
            else
            {
                e.SuppressKeyPress = true; // Suppress other keys
            }
        }

        string[] words = new[] { "eduvos", "student", "playstation", "life", "bursary", "scholarship", "lecturer", "black", "friday", "enterprise", "candle", "promotion", "rotate", "turismo", "computer" };
        ArrayList scores = new ArrayList();
        SortedList<int, string> highScores = new SortedList<int, string>();

        int score = 0, wrongGuesses = 0, attempts = 0;
        string currentWord = "";
        Random random = new Random();

        private void button_start_Click(object sender, EventArgs e)
        {
            ResetGame();
            textBox_guess.Enabled = true; // Enable TextBox when the game starts
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (ValidateInput(textBox_guess.Text))
            {
                attempts++;
                checkWord();

                // Check for draw condition
                if (score == 5 && wrongGuesses == 5)
                {
                    MessageBox.Show("It's a draw!", "Game Drawn");
                    EndGame();
                    return;
                }

                if (attempts >= 10)
                {
                    EndGame();
                }
                else
                {
                    SelectRandomWord();
                    displayWord();
                }
            }
        }

        private void ResetGame()
        {
            score = 0;
            wrongGuesses = 0;
            attempts = 0;
            label_result.Text = "Result";
            label_result.BackColor = Color.LightBlue;
            label_score.Text = "00";
            Scoreboard.Items.Clear();
            SelectRandomWord();
            displayWord();
            textBox_guess.Text = ""; // Clear TextBox content
            button_next.Enabled = true;
            button_start.Enabled = false;
        }

        private void SelectRandomWord()
        {
            // Choose a random word different from the current one
            string newWord;
            do
            {
                newWord = words[random.Next(words.Length)];
            } while (newWord == currentWord);
            currentWord = newWord;
        }

        public void displayWord()
        {
            int pos1 = random.Next(currentWord.Length);
            int pos2 = random.Next(currentWord.Length);
            int pos3 = random.Next(currentWord.Length);

            string word = currentWord;
            word = word.Remove(pos1, 1).Insert(pos1, "_");
            word = word.Remove(pos2, 1).Insert(pos2, "_");
            word = word.Remove(pos3, 1).Insert(pos3, "_");

            label_word.Text = word;
        }

        public void checkWord()
        {
            string guess = textBox_guess.Text.ToLower();
            if (guess.Equals(currentWord))
            {
                label_result.Text = "Correct";
                label_result.BackColor = Color.Green;
                score++;
                Scoreboard.Items.Add($"Correct: {guess}");
            }
            else
            {
                label_result.Text = "Wrong";
                label_result.BackColor = Color.Red;
                wrongGuesses++;
                Scoreboard.Items.Add($"Wrong: {guess} (Expected: {currentWord})");

                // End the game if wrong guesses reach 10
                if (wrongGuesses >= 10)
                {
                    EndGame();
                    return;
                }
            }

            textBox_guess.Text = "";
            label_score.Text = $"Score: {score} / 10";
        }

        private void EndGame()
        {
            button_start.Enabled = true;
            button_next.Enabled = false;
            textBox_guess.Enabled = false; // Disable TextBox when the game ends

            scores.Add(score);
            if (!highScores.ContainsKey(score))
            {
                highScores.Add(score, DateTime.Now.ToString("G"));
            }

            string resultMessage;

            // Check for draw
            if (score == 5 && wrongGuesses == 5)
            {
                resultMessage = "It's a draw! Both correct and wrong guesses reached 5.";
            }
            // Check for losing condition
            else if (wrongGuesses > 5)
            {
                resultMessage = "You lost! More than 5 wrong guesses.";
            }
            // Check for win
            else if (score > 5)
            {
                resultMessage = $"You won! Your best score is: {highScores.Keys.Max()}!";
            }
            // General loss if none of the above conditions are met
            else
            {
                resultMessage = $"Game Over! Your best score is: {highScores.Keys.Max()}!";
            }

            MessageBox.Show(resultMessage, "Game Over");
        }

        private bool ValidateInput(string input)
        {
            try
            {
                // Check if input is null, empty, or contains non-letter characters
                if (string.IsNullOrWhiteSpace(input) || !input.All(char.IsLetter))
                {
                    MessageBox.Show("Invalid character! Please enter only letters.", "Invalid Input");
                    textBox_guess.Text = "";  // Clear the input
                    return false;
                }
            }
            catch (Exception ex)
            {
                // If any exception occurs, show an error message and return false
                MessageBox.Show($"An error occurred while validating input: {ex.Message}", "Error");
                textBox_guess.Text = "";  // Clear the input
                return false;
            }

            return true;
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
