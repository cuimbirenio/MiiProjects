namespace HangmanGameEduvos2024
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_word = new Label();
            textBox_guess = new TextBox();
            button_next = new Button();
            button_start = new Button();
            label_result = new Label();
            label_score = new Label();
            button_quit = new Button();
            Scoreboard = new ListBox();
            SuspendLayout();
            // 
            // label_word
            // 
            label_word.BackColor = SystemColors.InactiveCaption;
            label_word.Font = new Font("Algerian", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_word.ForeColor = SystemColors.WindowText;
            label_word.Location = new Point(259, 9);
            label_word.Name = "label_word";
            label_word.Size = new Size(202, 58);
            label_word.TabIndex = 0;
            label_word.Text = "Word";
            label_word.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_guess
            // 
            textBox_guess.Location = new Point(259, 85);
            textBox_guess.Multiline = true;
            textBox_guess.Name = "textBox_guess";
            textBox_guess.Size = new Size(202, 41);
            textBox_guess.TabIndex = 1;
            textBox_guess.TextAlign = HorizontalAlignment.Center;
            // 
            // button_next
            // 
            button_next.BackColor = Color.LightSeaGreen;
            button_next.Enabled = false;
            button_next.Location = new Point(295, 132);
            button_next.Name = "button_next";
            button_next.Size = new Size(132, 47);
            button_next.TabIndex = 2;
            button_next.Text = "[Next Word]";
            button_next.UseVisualStyleBackColor = false;
            button_next.Click += button_next_Click;
            // 
            // button_start
            // 
            button_start.BackColor = Color.Aquamarine;
            button_start.Font = new Font("Arial", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button_start.Location = new Point(259, 225);
            button_start.Name = "button_start";
            button_start.Size = new Size(202, 53);
            button_start.TabIndex = 3;
            button_start.Text = "Start New Game";
            button_start.UseVisualStyleBackColor = false;
            button_start.Click += button_start_Click;
            // 
            // label_result
            // 
            label_result.BackColor = SystemColors.InactiveCaption;
            label_result.Location = new Point(660, 22);
            label_result.Name = "label_result";
            label_result.Size = new Size(132, 45);
            label_result.TabIndex = 4;
            label_result.Text = "Result";
            label_result.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_score
            // 
            label_score.AutoSize = true;
            label_score.Location = new Point(688, 106);
            label_score.Name = "label_score";
            label_score.Size = new Size(0, 20);
            label_score.TabIndex = 5;
            // 
            // button_quit
            // 
            button_quit.BackColor = Color.LightSeaGreen;
            button_quit.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_quit.Location = new Point(316, 368);
            button_quit.Name = "button_quit";
            button_quit.Size = new Size(92, 41);
            button_quit.TabIndex = 6;
            button_quit.Text = "Quit";
            button_quit.UseVisualStyleBackColor = false;
            button_quit.Click += button_quit_Click;
            // 
            // Scoreboard
            // 
            Scoreboard.BackColor = SystemColors.InactiveCaption;
            Scoreboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Scoreboard.FormattingEnabled = true;
            Scoreboard.Location = new Point(530, 145);
            Scoreboard.Name = "Scoreboard";
            Scoreboard.Size = new Size(338, 264);
            Scoreboard.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(894, 450);
            Controls.Add(Scoreboard);
            Controls.Add(button_quit);
            Controls.Add(label_score);
            Controls.Add(label_result);
            Controls.Add(button_start);
            Controls.Add(button_next);
            Controls.Add(textBox_guess);
            Controls.Add(label_word);
            Name = "Form1";
            Text = "Hangman Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_word;
        private TextBox textBox_guess;
        private Button button_next;
        private Button button_start;
        private Label label_result;
        private Label label_score;
        private Button button_quit;
        private ListBox Scoreboard;
    }
}
