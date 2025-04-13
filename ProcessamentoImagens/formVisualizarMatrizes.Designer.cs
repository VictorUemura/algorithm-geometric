namespace ProcessamentoImagens
{
    partial class frmVisualizarMatrizes
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
            this.richTextBoxMatrizes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            //
            // richTextBoxMatrizes
            //
            this.richTextBoxMatrizes.BackColor = System.Drawing.SystemColors.Window; // Fundo branco
            this.richTextBoxMatrizes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMatrizes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMatrizes.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Fonte monoespaçada
            this.richTextBoxMatrizes.Location = new System.Drawing.Point(10, 10); // Adiciona uma margem interna
            this.richTextBoxMatrizes.Name = "richTextBoxMatrizes";
            this.richTextBoxMatrizes.ReadOnly = true;
            this.richTextBoxMatrizes.Size = new System.Drawing.Size(462, 433); // Tamanho inicial ajustado
            this.richTextBoxMatrizes.TabIndex = 0;
            this.richTextBoxMatrizes.Text = "";
            this.richTextBoxMatrizes.WordWrap = false; // Desativa quebra de linha automática
            //
            // frmVisualizarMatrizes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453); // Tamanho inicial ajustado
            this.Controls.Add(this.richTextBoxMatrizes);
            this.MinimumSize = new System.Drawing.Size(350, 200); // Define um tamanho mínimo
            this.Name = "frmVisualizarMatrizes";
            this.Padding = new System.Windows.Forms.Padding(10); // Margem geral
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Matrizes Acumuladas";
            this.Load += new System.EventHandler(this.frmVisualizarMatrizes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMatrizes;
    }
}