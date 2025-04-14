namespace ProcessamentoImagens
{
    partial class frmVisualizarMatrizes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.richTextBoxMatrizes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            //
            // richTextBoxMatrizes
            //
            this.richTextBoxMatrizes.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxMatrizes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMatrizes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMatrizes.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMatrizes.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxMatrizes.Name = "richTextBoxMatrizes";
            this.richTextBoxMatrizes.ReadOnly = true;
            this.richTextBoxMatrizes.Size = new System.Drawing.Size(462, 433); 
            this.richTextBoxMatrizes.TabIndex = 0;
            this.richTextBoxMatrizes.Text = "";
            this.richTextBoxMatrizes.WordWrap = false;
            //
            // frmVisualizarMatrizes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.richTextBoxMatrizes);
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "frmVisualizarMatrizes";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Matrizes Acumuladas";
            this.Load += new System.EventHandler(this.frmVisualizarMatrizes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMatrizes;
    }
}