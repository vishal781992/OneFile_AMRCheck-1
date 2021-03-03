
namespace OneFile_AMRCheck
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
            this.timer_FileUpload = new System.Windows.Forms.Timer(this.components);
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Server19 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_initials = new System.Windows.Forms.TextBox();
            this.checkBox_StartProcessDB = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // timer_FileUpload
            // 
            this.timer_FileUpload.Enabled = true;
            this.timer_FileUpload.Tick += new System.EventHandler(this.timer_FileUpload_Tick);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.Black;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox2.HideSelection = false;
            this.richTextBox2.Location = new System.Drawing.Point(12, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(437, 252);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Address for OneFile";
            // 
            // textBox_Server19
            // 
            this.textBox_Server19.BackColor = System.Drawing.Color.White;
            this.textBox_Server19.Location = new System.Drawing.Point(22, 283);
            this.textBox_Server19.Name = "textBox_Server19";
            this.textBox_Server19.Size = new System.Drawing.Size(427, 20);
            this.textBox_Server19.TabIndex = 11;
            this.textBox_Server19.Text = "\\\\VISIONSERVER19\\VisionShared\\VisionSharedFiles\\SimAutomationServerFiles";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Initials for the AMR check";
            // 
            // textBox_initials
            // 
            this.textBox_initials.BackColor = System.Drawing.Color.Red;
            this.textBox_initials.Location = new System.Drawing.Point(22, 319);
            this.textBox_initials.Name = "textBox_initials";
            this.textBox_initials.Size = new System.Drawing.Size(196, 20);
            this.textBox_initials.TabIndex = 14;
            this.textBox_initials.Text = "VCauto";
            // 
            // checkBox_StartProcessDB
            // 
            this.checkBox_StartProcessDB.AutoSize = true;
            this.checkBox_StartProcessDB.Location = new System.Drawing.Point(22, 345);
            this.checkBox_StartProcessDB.Name = "checkBox_StartProcessDB";
            this.checkBox_StartProcessDB.Size = new System.Drawing.Size(134, 17);
            this.checkBox_StartProcessDB.TabIndex = 16;
            this.checkBox_StartProcessDB.Text = "Start/Stop the Process";
            this.checkBox_StartProcessDB.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(315, 309);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "stop File check Log";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(461, 369);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox_StartProcessDB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox_initials);
            this.Controls.Add(this.textBox_Server19);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_FileUpload;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Server19;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_initials;
        private System.Windows.Forms.CheckBox checkBox_StartProcessDB;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

