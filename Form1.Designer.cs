namespace ProyectoFinal_ExpresionGenetica
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.buttonGenerateGraph = new System.Windows.Forms.Button();
            this.buttonCluster = new System.Windows.Forms.Button();
            this.labelGraph = new System.Windows.Forms.Label();
            this.treeViewGraph = new System.Windows.Forms.TreeView();
            this.labelClusters = new System.Windows.Forms.Label();
            this.labelEdgesSelection = new System.Windows.Forms.Label();
            this.listBoxKruskalEdges = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(24, 31);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(967, 567);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.Location = new System.Drawing.Point(24, 616);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(225, 85);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Cargar Datos";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.FileName = "openFileDialog1";
            // 
            // buttonGenerateGraph
            // 
            this.buttonGenerateGraph.Enabled = false;
            this.buttonGenerateGraph.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateGraph.Location = new System.Drawing.Point(407, 616);
            this.buttonGenerateGraph.Name = "buttonGenerateGraph";
            this.buttonGenerateGraph.Size = new System.Drawing.Size(208, 85);
            this.buttonGenerateGraph.TabIndex = 2;
            this.buttonGenerateGraph.Text = "Generar Grafo";
            this.buttonGenerateGraph.UseVisualStyleBackColor = true;
            this.buttonGenerateGraph.Click += new System.EventHandler(this.buttonGenerateGraph_Click);
            // 
            // buttonCluster
            // 
            this.buttonCluster.Enabled = false;
            this.buttonCluster.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCluster.Location = new System.Drawing.Point(754, 616);
            this.buttonCluster.Name = "buttonCluster";
            this.buttonCluster.Size = new System.Drawing.Size(212, 85);
            this.buttonCluster.TabIndex = 3;
            this.buttonCluster.Text = "Agrupar Datos";
            this.buttonCluster.UseVisualStyleBackColor = true;
            this.buttonCluster.Click += new System.EventHandler(this.buttonCluster_Click);
            // 
            // labelGraph
            // 
            this.labelGraph.AutoSize = true;
            this.labelGraph.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGraph.Location = new System.Drawing.Point(1006, 95);
            this.labelGraph.Name = "labelGraph";
            this.labelGraph.Size = new System.Drawing.Size(83, 31);
            this.labelGraph.TabIndex = 4;
            this.labelGraph.Text = "Grafo:";
            // 
            // treeViewGraph
            // 
            this.treeViewGraph.Location = new System.Drawing.Point(1012, 129);
            this.treeViewGraph.Name = "treeViewGraph";
            this.treeViewGraph.Size = new System.Drawing.Size(276, 285);
            this.treeViewGraph.TabIndex = 5;
            // 
            // labelClusters
            // 
            this.labelClusters.AutoSize = true;
            this.labelClusters.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClusters.Location = new System.Drawing.Point(1006, 31);
            this.labelClusters.Name = "labelClusters";
            this.labelClusters.Size = new System.Drawing.Size(0, 36);
            this.labelClusters.TabIndex = 6;
            // 
            // labelEdgesSelection
            // 
            this.labelEdgesSelection.AutoSize = true;
            this.labelEdgesSelection.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEdgesSelection.Location = new System.Drawing.Point(1006, 452);
            this.labelEdgesSelection.Name = "labelEdgesSelection";
            this.labelEdgesSelection.Size = new System.Drawing.Size(247, 31);
            this.labelEdgesSelection.TabIndex = 7;
            this.labelEdgesSelection.Text = "Selección de Aristas:";
            // 
            // listBoxKruskalEdges
            // 
            this.listBoxKruskalEdges.FormattingEnabled = true;
            this.listBoxKruskalEdges.ItemHeight = 16;
            this.listBoxKruskalEdges.Location = new System.Drawing.Point(1012, 486);
            this.listBoxKruskalEdges.Name = "listBoxKruskalEdges";
            this.listBoxKruskalEdges.Size = new System.Drawing.Size(276, 196);
            this.listBoxKruskalEdges.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 725);
            this.Controls.Add(this.listBoxKruskalEdges);
            this.Controls.Add(this.labelEdgesSelection);
            this.Controls.Add(this.labelClusters);
            this.Controls.Add(this.treeViewGraph);
            this.Controls.Add(this.labelGraph);
            this.Controls.Add(this.buttonCluster);
            this.Controls.Add(this.buttonGenerateGraph);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.pictureBoxImage);
            this.Name = "Form1";
            this.Text = "Sanchez Salcedo Andres - Proyecto Final: Agrupación de datos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.Button buttonGenerateGraph;
        private System.Windows.Forms.Button buttonCluster;
        private System.Windows.Forms.Label labelGraph;
        private System.Windows.Forms.TreeView treeViewGraph;
        private System.Windows.Forms.Label labelClusters;
        private System.Windows.Forms.Label labelEdgesSelection;
        private System.Windows.Forms.ListBox listBoxKruskalEdges;
    }
}

