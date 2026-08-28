namespace MacroApp
{
    partial class Form1
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
            this.TitleLB = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DelayLB = new System.Windows.Forms.Label();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.RepeatCB = new System.Windows.Forms.CheckBox();
            this.ActionsGB = new System.Windows.Forms.GroupBox();
            this.ActionList = new System.Windows.Forms.ListView();
            this.AddKeyBTN = new System.Windows.Forms.Button();
            this.AddClickBTN = new System.Windows.Forms.Button();
            this.AddMoveBTN = new System.Windows.Forms.Button();
            this.RemoveBTN = new System.Windows.Forms.Button();
            this.RecordBTN = new System.Windows.Forms.Button();
            this.StopRecordBTN = new System.Windows.Forms.Button();
            this.StartBTN = new System.Windows.Forms.Button();
            this.StopBTN = new System.Windows.Forms.Button();
            this.StatusTitleLB = new System.Windows.Forms.Label();
            this.StatusLB = new System.Windows.Forms.Label();
            this.HotkeyLB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MacroTimer = new System.Windows.Forms.Timer(this.components);
            this.RecordTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.ActionsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLB
            // 
            this.TitleLB.AutoSize = true;
            this.TitleLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLB.Location = new System.Drawing.Point(267, 9);
            this.TitleLB.Name = "TitleLB";
            this.TitleLB.Size = new System.Drawing.Size(110, 25);
            this.TitleLB.TabIndex = 0;
            this.TitleLB.Text = "MacroApp";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.TitleLB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 46);
            this.panel1.TabIndex = 1;
            // 
            // DelayLB
            // 
            this.DelayLB.AutoSize = true;
            this.DelayLB.Location = new System.Drawing.Point(13, 72);
            this.DelayLB.Name = "DelayLB";
            this.DelayLB.Size = new System.Drawing.Size(40, 13);
            this.DelayLB.TabIndex = 2;
            this.DelayLB.Text = "Delay :";
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(16, 89);
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(190, 20);
            this.numDelay.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "ms";
            // 
            // RepeatCB
            // 
            this.RepeatCB.AutoSize = true;
            this.RepeatCB.Location = new System.Drawing.Point(272, 89);
            this.RepeatCB.Name = "RepeatCB";
            this.RepeatCB.Size = new System.Drawing.Size(61, 17);
            this.RepeatCB.TabIndex = 6;
            this.RepeatCB.Text = "Repeat";
            this.RepeatCB.UseVisualStyleBackColor = true;
            // 
            // ActionsGB
            // 
            this.ActionsGB.Controls.Add(this.ActionList);
            this.ActionsGB.Location = new System.Drawing.Point(16, 153);
            this.ActionsGB.Name = "ActionsGB";
            this.ActionsGB.Size = new System.Drawing.Size(628, 166);
            this.ActionsGB.TabIndex = 7;
            this.ActionsGB.TabStop = false;
            this.ActionsGB.Text = "Actions";
            // 
            // ActionList
            // 
            this.ActionList.HideSelection = false;
            this.ActionList.Location = new System.Drawing.Point(7, 20);
            this.ActionList.Name = "ActionList";
            this.ActionList.Size = new System.Drawing.Size(615, 140);
            this.ActionList.TabIndex = 0;
            this.ActionList.UseCompatibleStateImageBehavior = false;
            // 
            // AddKeyBTN
            // 
            this.AddKeyBTN.Location = new System.Drawing.Point(16, 326);
            this.AddKeyBTN.Name = "AddKeyBTN";
            this.AddKeyBTN.Size = new System.Drawing.Size(75, 23);
            this.AddKeyBTN.TabIndex = 8;
            this.AddKeyBTN.Text = "Add Key";
            this.AddKeyBTN.UseVisualStyleBackColor = true;
            this.AddKeyBTN.Click += new System.EventHandler(this.AddKeyBTN_Click);
            // 
            // AddClickBTN
            // 
            this.AddClickBTN.Location = new System.Drawing.Point(116, 326);
            this.AddClickBTN.Name = "AddClickBTN";
            this.AddClickBTN.Size = new System.Drawing.Size(75, 23);
            this.AddClickBTN.TabIndex = 9;
            this.AddClickBTN.Text = "Add Click";
            this.AddClickBTN.UseVisualStyleBackColor = true;
            this.AddClickBTN.Click += new System.EventHandler(this.AddClickBTN_Click);
            // 
            // AddMoveBTN
            // 
            this.AddMoveBTN.Location = new System.Drawing.Point(215, 326);
            this.AddMoveBTN.Name = "AddMoveBTN";
            this.AddMoveBTN.Size = new System.Drawing.Size(75, 23);
            this.AddMoveBTN.TabIndex = 10;
            this.AddMoveBTN.Text = "Add Move";
            this.AddMoveBTN.UseVisualStyleBackColor = true;
            this.AddMoveBTN.Click += new System.EventHandler(this.AddMoveBTN_Click);
            // 
            // RemoveBTN
            // 
            this.RemoveBTN.Location = new System.Drawing.Point(314, 325);
            this.RemoveBTN.Name = "RemoveBTN";
            this.RemoveBTN.Size = new System.Drawing.Size(75, 23);
            this.RemoveBTN.TabIndex = 11;
            this.RemoveBTN.Text = "Remove";
            this.RemoveBTN.UseVisualStyleBackColor = true;
            this.RemoveBTN.Click += new System.EventHandler(this.RemoveBTN_Click);
            // 
            // RecordBTN
            // 
            this.RecordBTN.Location = new System.Drawing.Point(16, 378);
            this.RecordBTN.Name = "RecordBTN";
            this.RecordBTN.Size = new System.Drawing.Size(75, 23);
            this.RecordBTN.TabIndex = 12;
            this.RecordBTN.Text = "Record";
            this.RecordBTN.UseVisualStyleBackColor = true;
            this.RecordBTN.Click += new System.EventHandler(this.RecordBTN_Click);
            // 
            // StopRecordBTN
            // 
            this.StopRecordBTN.Location = new System.Drawing.Point(314, 378);
            this.StopRecordBTN.Name = "StopRecordBTN";
            this.StopRecordBTN.Size = new System.Drawing.Size(75, 23);
            this.StopRecordBTN.TabIndex = 13;
            this.StopRecordBTN.Text = "Stop Record";
            this.StopRecordBTN.UseVisualStyleBackColor = true;
            this.StopRecordBTN.Click += new System.EventHandler(this.StopRecordBTN_Click);
            // 
            // StartBTN
            // 
            this.StartBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBTN.Location = new System.Drawing.Point(419, 325);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(94, 76);
            this.StartBTN.TabIndex = 14;
            this.StartBTN.Text = "START";
            this.StartBTN.UseVisualStyleBackColor = true;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // StopBTN
            // 
            this.StopBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopBTN.Location = new System.Drawing.Point(544, 325);
            this.StopBTN.Name = "StopBTN";
            this.StopBTN.Size = new System.Drawing.Size(94, 76);
            this.StopBTN.TabIndex = 15;
            this.StopBTN.Text = "STOP";
            this.StopBTN.UseVisualStyleBackColor = true;
            this.StopBTN.Click += new System.EventHandler(this.StopBTN_Click);
            // 
            // StatusTitleLB
            // 
            this.StatusTitleLB.AutoSize = true;
            this.StatusTitleLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTitleLB.Location = new System.Drawing.Point(12, 500);
            this.StatusTitleLB.Name = "StatusTitleLB";
            this.StatusTitleLB.Size = new System.Drawing.Size(64, 20);
            this.StatusTitleLB.TabIndex = 16;
            this.StatusTitleLB.Text = "Status :";
            // 
            // StatusLB
            // 
            this.StatusLB.AutoSize = true;
            this.StatusLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLB.Location = new System.Drawing.Point(82, 500);
            this.StatusLB.Name = "StatusLB";
            this.StatusLB.Size = new System.Drawing.Size(70, 20);
            this.StatusLB.TabIndex = 17;
            this.StatusLB.Text = "Stopped";
            // 
            // HotkeyLB
            // 
            this.HotkeyLB.AutoSize = true;
            this.HotkeyLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HotkeyLB.Location = new System.Drawing.Point(435, 404);
            this.HotkeyLB.Name = "HotkeyLB";
            this.HotkeyLB.Size = new System.Drawing.Size(59, 15);
            this.HotkeyLB.TabIndex = 18;
            this.HotkeyLB.Text = "F6 = Play";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(563, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "F7 = Stop Play";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "F10 = Record";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "F11 = Stop Rec";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 529);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HotkeyLB);
            this.Controls.Add(this.StatusLB);
            this.Controls.Add(this.StatusTitleLB);
            this.Controls.Add(this.StopBTN);
            this.Controls.Add(this.StartBTN);
            this.Controls.Add(this.StopRecordBTN);
            this.Controls.Add(this.RecordBTN);
            this.Controls.Add(this.RemoveBTN);
            this.Controls.Add(this.AddMoveBTN);
            this.Controls.Add(this.AddClickBTN);
            this.Controls.Add(this.AddKeyBTN);
            this.Controls.Add(this.ActionsGB);
            this.Controls.Add(this.RepeatCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.DelayLB);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.ActionsGB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DelayLB;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RepeatCB;
        private System.Windows.Forms.GroupBox ActionsGB;
        private System.Windows.Forms.ListView ActionList;
        private System.Windows.Forms.Button AddKeyBTN;
        private System.Windows.Forms.Button AddClickBTN;
        private System.Windows.Forms.Button AddMoveBTN;
        private System.Windows.Forms.Button RemoveBTN;
        private System.Windows.Forms.Button RecordBTN;
        private System.Windows.Forms.Button StopRecordBTN;
        private System.Windows.Forms.Button StartBTN;
        private System.Windows.Forms.Button StopBTN;
        private System.Windows.Forms.Label StatusTitleLB;
        private System.Windows.Forms.Label StatusLB;
        private System.Windows.Forms.Label HotkeyLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer MacroTimer;
        private System.Windows.Forms.Timer RecordTimer;
    }
}

