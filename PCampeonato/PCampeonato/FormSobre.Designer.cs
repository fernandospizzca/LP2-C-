namespace PCampeonato
{
    partial class FormSobre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSobre));
            this.grpSobre = new System.Windows.Forms.GroupBox();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.grpSobre.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSobre
            // 
            this.grpSobre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpSobre.Controls.Add(this.labelDescricao);
            this.grpSobre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grpSobre.Location = new System.Drawing.Point(62, 48);
            this.grpSobre.Name = "grpSobre";
            this.grpSobre.Size = new System.Drawing.Size(377, 209);
            this.grpSobre.TabIndex = 0;
            this.grpSobre.TabStop = false;
            this.grpSobre.Text = "Criado Por:";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelDescricao.Location = new System.Drawing.Point(16, 33);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(0, 13);
            this.labelDescricao.TabIndex = 0;
            // 
            // FormSobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(523, 305);
            this.Controls.Add(this.grpSobre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSobre";
            this.Text = "Sobre Nós";
            this.Load += new System.EventHandler(this.FormSobre_Load);
            this.grpSobre.ResumeLayout(false);
            this.grpSobre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSobre;
        private System.Windows.Forms.Label labelDescricao;
    }
}