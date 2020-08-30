namespace ProyectoFinal_ExpresionGenetica
{
    partial class FormClusterInfo
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
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.labelClusterSelection = new System.Windows.Forms.Label();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.labelK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirm.Location = new System.Drawing.Point(157, 121);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(155, 52);
            this.buttonConfirm.TabIndex = 0;
            this.buttonConfirm.Text = "Confirmar";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // labelClusterSelection
            // 
            this.labelClusterSelection.AutoSize = true;
            this.labelClusterSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClusterSelection.Location = new System.Drawing.Point(12, 18);
            this.labelClusterSelection.Name = "labelClusterSelection";
            this.labelClusterSelection.Size = new System.Drawing.Size(281, 25);
            this.labelClusterSelection.TabIndex = 1;
            this.labelClusterSelection.Text = "Cantidad de Grupos a generar:";
            // 
            // textBoxK
            // 
            this.textBoxK.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxK.Location = new System.Drawing.Point(95, 58);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(144, 33);
            this.textBoxK.TabIndex = 3;
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelK.Location = new System.Drawing.Point(57, 58);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(32, 27);
            this.labelK.TabIndex = 4;
            this.labelK.Text = "K:";
            // 
            // FormClusterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 189);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.labelClusterSelection);
            this.Controls.Add(this.buttonConfirm);
            this.Name = "FormClusterInfo";
            this.Text = "Generar Grupos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labelClusterSelection;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Label labelK;
    }
}