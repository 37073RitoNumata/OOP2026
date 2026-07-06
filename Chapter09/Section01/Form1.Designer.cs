namespace Section01 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btGet = new Button();
            tbAgeOut = new TextBox();
            dtpDate = new DateTimePicker();
            nudDay = new NumericUpDown();
            dtpBirth = new DateTimePicker();
            btBirthCalc = new Button();
            label1 = new Label();
            label2 = new Label();
            tbDateOut = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // btGet
            // 
            btGet.Location = new Point(415, 53);
            btGet.Name = "btGet";
            btGet.Size = new Size(92, 39);
            btGet.TabIndex = 1;
            btGet.Text = "計算";
            btGet.UseVisualStyleBackColor = true;
            btGet.Click += btGet_Click;
            // 
            // tbAgeOut
            // 
            tbAgeOut.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbAgeOut.Location = new Point(118, 360);
            tbAgeOut.Name = "tbAgeOut";
            tbAgeOut.Size = new Size(389, 39);
            tbAgeOut.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(118, 53);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 39);
            dtpDate.TabIndex = 3;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(258, 145);
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(94, 39);
            nudDay.TabIndex = 4;
            nudDay.Tag = "";
            // 
            // dtpBirth
            // 
            dtpBirth.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpBirth.Location = new Point(118, 256);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(201, 39);
            dtpBirth.TabIndex = 5;
            dtpBirth.ValueChanged += dtpBirth_ValueChanged;
            // 
            // btBirthCalc
            // 
            btBirthCalc.Location = new Point(415, 256);
            btBirthCalc.Name = "btBirthCalc";
            btBirthCalc.Size = new Size(92, 39);
            btBirthCalc.TabIndex = 6;
            btBirthCalc.Text = "計算";
            btBirthCalc.UseVisualStyleBackColor = true;
            btBirthCalc.Click += btBirthCalc_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(358, 147);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 7;
            label1.Text = "日後";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 238);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 8;
            label2.Text = "生年月日";
            label2.Click += label2_Click;
            // 
            // tbDateOut
            // 
            tbDateOut.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDateOut.Location = new Point(118, 405);
            tbDateOut.Name = "tbDateOut";
            tbDateOut.Size = new Size(389, 39);
            tbDateOut.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 377);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 10;
            label3.Text = "年齢";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 422);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 11;
            label4.Text = "経過日数";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 592);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tbDateOut);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btBirthCalc);
            Controls.Add(dtpBirth);
            Controls.Add(nudDay);
            Controls.Add(dtpDate);
            Controls.Add(tbAgeOut);
            Controls.Add(btGet);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btGet;
        private TextBox tbAgeOut;
        private DateTimePicker dtpDate;
        private NumericUpDown nudDay;
        private DateTimePicker dtpBirth;
        private Button btBirthCalc;
        private Label label1;
        private Label label2;
        private TextBox tbDateOut;
        private Label label3;
        private Label label4;
    }
}