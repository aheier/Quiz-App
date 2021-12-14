
namespace Quiz_App
{
    partial class View
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.answersBox = new System.Windows.Forms.ListBox();
            this.labelSelected = new System.Windows.Forms.Label();
            this.questionBox = new System.Windows.Forms.RichTextBox();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelQuestionNumber = new System.Windows.Forms.Label();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(460, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(312, 23);
            this.progressBar.TabIndex = 0;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevious.Location = new System.Drawing.Point(220, 383);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(120, 40);
            this.buttonPrevious.TabIndex = 1;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(460, 383);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(120, 40);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // answersBox
            // 
            this.answersBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.answersBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answersBox.FormattingEnabled = true;
            this.answersBox.ItemHeight = 23;
            this.answersBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.answersBox.Location = new System.Drawing.Point(12, 215);
            this.answersBox.Name = "answersBox";
            this.answersBox.Size = new System.Drawing.Size(760, 142);
            this.answersBox.TabIndex = 7;
            this.answersBox.SelectedIndexChanged += new System.EventHandler(this.answersBox_SelectedIndexChanged);
            // 
            // labelSelected
            // 
            this.labelSelected.AutoSize = true;
            this.labelSelected.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelected.Location = new System.Drawing.Point(12, 189);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(190, 23);
            this.labelSelected.TabIndex = 8;
            this.labelSelected.Text = "You selected answer: ";
            // 
            // questionBox
            // 
            this.questionBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.questionBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionBox.Location = new System.Drawing.Point(12, 53);
            this.questionBox.Name = "questionBox";
            this.questionBox.Size = new System.Drawing.Size(760, 124);
            this.questionBox.TabIndex = 9;
            this.questionBox.Text = "";
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(12, 27);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(102, 23);
            this.labelQuestion.TabIndex = 10;
            this.labelQuestion.Text = "Question : ";
            // 
            // labelQuestionNumber
            // 
            this.labelQuestionNumber.AutoSize = true;
            this.labelQuestionNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestionNumber.Location = new System.Drawing.Point(124, 27);
            this.labelQuestionNumber.Name = "labelQuestion";
            this.labelQuestionNumber.Size = new System.Drawing.Size(40, 23);
            this.labelQuestionNumber.TabIndex = 16;
            this.labelQuestionNumber.Text = "1";
            // 
            // buttonFinish
            // 
            this.buttonFinish.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinish.Location = new System.Drawing.Point(652, 383);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(120, 40);
            this.buttonFinish.TabIndex = 11;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(304, 13);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(89, 13);
            this.labelTimer.TabIndex = 12;
            this.labelTimer.Text = "Time Remaining: ";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.labelSelected);
            this.Controls.Add(this.answersBox);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelQuestionNumber);
            this.Name = "View";
            this.Text = "Quiz App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Button buttonPrevious;
        public System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.ListBox answersBox;
        public System.Windows.Forms.Label labelSelected;
        public System.Windows.Forms.RichTextBox questionBox;
        public System.Windows.Forms.Label labelQuestion;
        public System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label   labelQuestionNumber;

        private System.Windows.Forms.Label labelTimer;

    }
}

