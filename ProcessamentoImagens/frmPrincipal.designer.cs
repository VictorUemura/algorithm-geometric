// Make sure this namespace matches your project's namespace in frmPrincipal.cs
namespace ProcessamentoImagens // Or change to CG_Trab if that's your actual project namespace
{
    partial class frmPrincipal // Ensure this matches the class name in frmPrincipal.cs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            // Remember to dispose your Bitmap and Graphics objects in frmPrincipal.cs (e.g., in FormClosing event)
            // bitmapGraphics?.Dispose();
            // drawingBitmap?.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Use Panel instead of PictureBox if preferred, named drawingPanel
            // If using PictureBox, keep the name pictBoxImg1 as in your example
            this.drawingPanel = new System.Windows.Forms.Panel(); // Or PictureBox pictBoxImg1;

            this.groupBoxShape = new System.Windows.Forms.GroupBox();
            this.chkElipse = new System.Windows.Forms.CheckBox();
            this.chkCircunferencia = new System.Windows.Forms.CheckBox();
            this.chkLinha = new System.Windows.Forms.CheckBox();
            this.groupBoxLinhaAlg = new System.Windows.Forms.GroupBox();
            this.rbLinhaPontoMedio = new System.Windows.Forms.RadioButton();
            this.rbLinhaDDA = new System.Windows.Forms.RadioButton();
            this.rbLinhaEqReal = new System.Windows.Forms.RadioButton();
            this.groupBoxCirculoAlg = new System.Windows.Forms.GroupBox();
            this.rbCirculoPontoMedio = new System.Windows.Forms.RadioButton();
            this.rbCirculoTrigonometria = new System.Windows.Forms.RadioButton();
            this.rbCirculoEqReal = new System.Windows.Forms.RadioButton();
            this.groupBoxElipseAlg = new System.Windows.Forms.GroupBox();
            this.rbElipsePontoMedio = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel(); // Optional status label
            this.btnAbrirPoligonos = new System.Windows.Forms.Button();

            // If using PictureBox pictBoxImg1 from your example:
            // ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).BeginInit();

            this.groupBoxShape.SuspendLayout();
            this.groupBoxLinhaAlg.SuspendLayout();
            this.groupBoxCirculoAlg.SuspendLayout();
            this.groupBoxElipseAlg.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            //
            // drawingPanel (or pictBoxImg1) - Adjust properties as needed
            //
            this.drawingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingPanel.Location = new System.Drawing.Point(12, 12); // Position next to controls
            this.drawingPanel.Margin = new System.Windows.Forms.Padding(4); // Use appropriate margins
            this.drawingPanel.Name = "drawingPanel"; // Or pictBoxImg1
            this.drawingPanel.Size = new System.Drawing.Size(750, 550); // Adjust size
            this.drawingPanel.TabIndex = 5; // Set tab index
                                            // Logo após a linha this.drawingPanel.TabIndex = 5;
            this.drawingPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseClick); // <-- ADICIONE ESTA LINHA                               // Add MouseClick handler - RENAME the handler method if needed in your frmPrincipal.cs
                                                                                                                      // If using PictureBox:
                                                                                                                      // this.pictBoxImg1.TabStop = false;

            //
            // groupBoxShape
            //
            this.groupBoxShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); // Anchor to the right
            this.groupBoxShape.Controls.Add(this.chkElipse);
            this.groupBoxShape.Controls.Add(this.chkCircunferencia);
            this.groupBoxShape.Controls.Add(this.chkLinha);
            this.groupBoxShape.Location = new System.Drawing.Point(770, 12); // Position to the right of panel
            this.groupBoxShape.Name = "groupBoxShape";
            this.groupBoxShape.Size = new System.Drawing.Size(180, 105); // Adjust size
            this.groupBoxShape.TabIndex = 0;
            this.groupBoxShape.TabStop = false;
            this.groupBoxShape.Text = "Forma";
            //
            // chkElipse
            //
            this.chkElipse.AutoSize = true;
            this.chkElipse.Location = new System.Drawing.Point(15, 75); // Adjust position within groupbox
            this.chkElipse.Name = "chkElipse";
            this.chkElipse.Size = new System.Drawing.Size(68, 20); // Adjust size/text
            this.chkElipse.TabIndex = 2;
            this.chkElipse.Text = "Elipse";
            this.chkElipse.UseVisualStyleBackColor = true;
            this.chkElipse.CheckedChanged += new System.EventHandler(this.chkElipse_CheckedChanged);
            // Add CheckChanged handler - RENAME the handler method if needed in your frmPrincipal.cs
            //
            // chkCircunferencia
            //
            this.chkCircunferencia.AutoSize = true;
            this.chkCircunferencia.Location = new System.Drawing.Point(15, 50);
            this.chkCircunferencia.Name = "chkCircunferencia";
            this.chkCircunferencia.Size = new System.Drawing.Size(118, 20);
            this.chkCircunferencia.TabIndex = 1;
            this.chkCircunferencia.Text = "Circunferência";
            this.chkCircunferencia.UseVisualStyleBackColor = true;
            this.chkCircunferencia.CheckedChanged += new System.EventHandler(this.chkCircunferencia_CheckedChanged); 
            // Add CheckChanged handler - RENAME the handler method if needed in your frmPrincipal.cs
            //
            // chkLinha
            //
            this.chkLinha.AutoSize = true;
            this.chkLinha.Location = new System.Drawing.Point(15, 25);
            this.chkLinha.Name = "chkLinha";
            this.chkLinha.Size = new System.Drawing.Size(60, 20);
            this.chkLinha.TabIndex = 0;
            this.chkLinha.Text = "Linha";
            this.chkLinha.UseVisualStyleBackColor = true;
            this.chkLinha.CheckedChanged += new System.EventHandler(this.chkLinha_CheckedChanged); // <
            // Add CheckChanged handler - RENAME the handler method if needed in your frmPrincipal.cs
            //
            // groupBoxLinhaAlg
            //
            this.groupBoxLinhaAlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLinhaAlg.Controls.Add(this.rbLinhaPontoMedio);
            this.groupBoxLinhaAlg.Controls.Add(this.rbLinhaDDA);
            this.groupBoxLinhaAlg.Controls.Add(this.rbLinhaEqReal);
            this.groupBoxLinhaAlg.Enabled = false; // Start disabled
            this.groupBoxLinhaAlg.Location = new System.Drawing.Point(770, 123); // Position below shape group
            this.groupBoxLinhaAlg.Name = "groupBoxLinhaAlg";
            this.groupBoxLinhaAlg.Size = new System.Drawing.Size(180, 105);
            this.groupBoxLinhaAlg.TabIndex = 1;
            this.groupBoxLinhaAlg.TabStop = false;
            this.groupBoxLinhaAlg.Text = "Algoritmo Reta";
            //
            // rbLinhaPontoMedio
            //
            this.rbLinhaPontoMedio.AutoSize = true;
            this.rbLinhaPontoMedio.Location = new System.Drawing.Point(15, 75);
            this.rbLinhaPontoMedio.Name = "rbLinhaPontoMedio";
            this.rbLinhaPontoMedio.Size = new System.Drawing.Size(104, 20);
            this.rbLinhaPontoMedio.TabIndex = 2;
            this.rbLinhaPontoMedio.Text = "Ponto Médio";
            this.rbLinhaPontoMedio.UseVisualStyleBackColor = true;
            //
            // rbLinhaDDA
            //
            this.rbLinhaDDA.AutoSize = true;
            this.rbLinhaDDA.Location = new System.Drawing.Point(15, 50);
            this.rbLinhaDDA.Name = "rbLinhaDDA";
            this.rbLinhaDDA.Size = new System.Drawing.Size(56, 20);
            this.rbLinhaDDA.TabIndex = 1;
            this.rbLinhaDDA.Text = "DDA";
            this.rbLinhaDDA.UseVisualStyleBackColor = true;
            //
            // rbLinhaEqReal
            //
            this.rbLinhaEqReal.AutoSize = true;
            this.rbLinhaEqReal.Checked = true; // Default for line
            this.rbLinhaEqReal.Location = new System.Drawing.Point(15, 25);
            this.rbLinhaEqReal.Name = "rbLinhaEqReal";
            this.rbLinhaEqReal.Size = new System.Drawing.Size(78, 20);
            this.rbLinhaEqReal.TabIndex = 0;
            this.rbLinhaEqReal.TabStop = true;
            this.rbLinhaEqReal.Text = "Eq. Real";
            this.rbLinhaEqReal.UseVisualStyleBackColor = true;
            //
            // groupBoxCirculoAlg
            //
            this.groupBoxCirculoAlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCirculoAlg.Controls.Add(this.rbCirculoPontoMedio);
            this.groupBoxCirculoAlg.Controls.Add(this.rbCirculoTrigonometria);
            this.groupBoxCirculoAlg.Controls.Add(this.rbCirculoEqReal);
            this.groupBoxCirculoAlg.Enabled = false; // Start disabled
            this.groupBoxCirculoAlg.Location = new System.Drawing.Point(770, 234); // Position below line group
            this.groupBoxCirculoAlg.Name = "groupBoxCirculoAlg";
            this.groupBoxCirculoAlg.Size = new System.Drawing.Size(180, 105);
            this.groupBoxCirculoAlg.TabIndex = 2;
            this.groupBoxCirculoAlg.TabStop = false;
            this.groupBoxCirculoAlg.Text = "Algoritmo Circunferência";
            //
            // rbCirculoPontoMedio
            //
            this.rbCirculoPontoMedio.AutoSize = true;
            this.rbCirculoPontoMedio.Location = new System.Drawing.Point(15, 75);
            this.rbCirculoPontoMedio.Name = "rbCirculoPontoMedio";
            this.rbCirculoPontoMedio.Size = new System.Drawing.Size(104, 20);
            this.rbCirculoPontoMedio.TabIndex = 2;
            this.rbCirculoPontoMedio.Text = "Ponto Médio";
            this.rbCirculoPontoMedio.UseVisualStyleBackColor = true;
            //
            // rbCirculoTrigonometria
            //
            this.rbCirculoTrigonometria.AutoSize = true;
            this.rbCirculoTrigonometria.Location = new System.Drawing.Point(15, 50);
            this.rbCirculoTrigonometria.Name = "rbCirculoTrigonometria";
            this.rbCirculoTrigonometria.Size = new System.Drawing.Size(111, 20);
            this.rbCirculoTrigonometria.TabIndex = 1;
            this.rbCirculoTrigonometria.Text = "Trigonometria";
            this.rbCirculoTrigonometria.UseVisualStyleBackColor = true;
            //
            // rbCirculoEqReal
            //
            this.rbCirculoEqReal.AutoSize = true;
            this.rbCirculoEqReal.Checked = true; // Default for circle
            this.rbCirculoEqReal.Location = new System.Drawing.Point(15, 25);
            this.rbCirculoEqReal.Name = "rbCirculoEqReal";
            this.rbCirculoEqReal.Size = new System.Drawing.Size(103, 20);
            this.rbCirculoEqReal.TabIndex = 0;
            this.rbCirculoEqReal.TabStop = true;
            this.rbCirculoEqReal.Text = "Eq. Explícita"; // Or "Eq. Real"
            this.rbCirculoEqReal.UseVisualStyleBackColor = true;
            //
            // groupBoxElipseAlg
            //
            this.groupBoxElipseAlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxElipseAlg.Controls.Add(this.rbElipsePontoMedio);
            this.groupBoxElipseAlg.Enabled = false; // Start disabled
            this.groupBoxElipseAlg.Location = new System.Drawing.Point(770, 345); // Position below circle group
            this.groupBoxElipseAlg.Name = "groupBoxElipseAlg";
            this.groupBoxElipseAlg.Size = new System.Drawing.Size(180, 60); // Smaller height
            this.groupBoxElipseAlg.TabIndex = 3;
            this.groupBoxElipseAlg.TabStop = false;
            this.groupBoxElipseAlg.Text = "Algoritmo Elipse";
            //
            // rbElipsePontoMedio
            //
            this.rbElipsePontoMedio.AutoSize = true;
            this.rbElipsePontoMedio.Checked = true; // Only option for ellipse
            this.rbElipsePontoMedio.Location = new System.Drawing.Point(15, 25);
            this.rbElipsePontoMedio.Name = "rbElipsePontoMedio";
            this.rbElipsePontoMedio.Size = new System.Drawing.Size(104, 20);
            this.rbElipsePontoMedio.TabIndex = 0;
            this.rbElipsePontoMedio.TabStop = true;
            this.rbElipsePontoMedio.Text = "Ponto Médio";
            this.rbElipsePontoMedio.UseVisualStyleBackColor = true;
            //
            // btnClear
            //
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(770, 411); // Position below ellipse group
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 30); // Adjust size
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Limpar Desenho";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click); // <-- AD
            // Add Click handler - RENAME the handler method if needed in your frmPrincipal.cs

            //
            // statusStrip1
            //
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 571); // Adjust based on form height
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(962, 22); // Adjust based on form width
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            //
            // lblStatus
            //
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(165, 16); // Adjust size
            this.lblStatus.Text = "Selecione forma e clique na área"; // Initial status text
                                                                      //
                                                                      // frmPrincipal
                                                                      //
                                                                      // --- Configuração do btnAbrirPoligonos --- << MOVER PARA CÁ
            this.btnAbrirPoligonos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirPoligonos.Location = new System.Drawing.Point(770, 450);
            this.btnAbrirPoligonos.Name = "btnAbrirPoligonos";
            this.btnAbrirPoligonos.Size = new System.Drawing.Size(180, 30);
            this.btnAbrirPoligonos.TabIndex = 7; //INCREMENTAR TabIndex se necessário
            this.btnAbrirPoligonos.Text = "Polígonos e Transformações";
            this.btnAbrirPoligonos.UseVisualStyleBackColor = true;
            this.btnAbrirPoligonos.Click += new System.EventHandler(this.btnAbrirPoligonos_Click);
            // --- Fim da Configuração ---

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); // Match your project settings
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 593); // Adjust overall form size
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBoxElipseAlg);
            this.Controls.Add(this.groupBoxCirculoAlg);
            this.Controls.Add(this.groupBoxLinhaAlg);
            this.Controls.Add(this.groupBoxShape);
            this.Controls.Add(this.drawingPanel); // Or pictBoxImg1
            this.Controls.Add(this.btnAbrirPoligonos); // << ADICIONAR JUNTO COM OS OUTROS

            this.Margin = new System.Windows.Forms.Padding(4); // Match your project settings
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computação Gráfica - Desenho"; // Set appropriate title
                                                        // Add FormClosing handler - RENAME the handler method if needed in your frmPrincipal.cs
                                                        // Add Load handler if you have one - RENAME the handler method if needed in your frmPrincipal.cs
                                                        // this.Load += new System.EventHandler(this.frmPrincipal_Load);

            this.Load += new System.EventHandler(this.frmPrincipal_Load); // <-- ADICIONE ESTA LINHA
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);

            // If using PictureBox pictBoxImg1:
            // ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).EndInit();

            this.groupBoxShape.ResumeLayout(false);
            this.groupBoxShape.PerformLayout();
            this.groupBoxLinhaAlg.ResumeLayout(false);
            this.groupBoxLinhaAlg.PerformLayout();
            this.groupBoxCirculoAlg.ResumeLayout(false);
            this.groupBoxCirculoAlg.PerformLayout();
            this.groupBoxElipseAlg.ResumeLayout(false);
            this.groupBoxElipseAlg.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Use Panel or PictureBox depending on your choice in frmPrincipal.cs
        // private System.Windows.Forms.PictureBox pictBoxImg1;
        private System.Windows.Forms.Panel drawingPanel;

        private System.Windows.Forms.GroupBox groupBoxShape;
        private System.Windows.Forms.CheckBox chkElipse;
        private System.Windows.Forms.CheckBox chkCircunferencia;
        private System.Windows.Forms.CheckBox chkLinha;
        private System.Windows.Forms.GroupBox groupBoxLinhaAlg;
        private System.Windows.Forms.RadioButton rbLinhaPontoMedio;
        private System.Windows.Forms.RadioButton rbLinhaDDA;
        private System.Windows.Forms.RadioButton rbLinhaEqReal;
        private System.Windows.Forms.GroupBox groupBoxCirculoAlg;
        private System.Windows.Forms.RadioButton rbCirculoPontoMedio;
        private System.Windows.Forms.RadioButton rbCirculoTrigonometria;
        private System.Windows.Forms.RadioButton rbCirculoEqReal;
        private System.Windows.Forms.GroupBox groupBoxElipseAlg;
        private System.Windows.Forms.RadioButton rbElipsePontoMedio;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.StatusStrip statusStrip1; // Optional status bar
        private System.Windows.Forms.ToolStripStatusLabel lblStatus; // Optional status label
        private System.Windows.Forms.Button btnAbrirPoligonos;

        // Keep OpenFileDialog if you need it for other purposes, otherwise remove
        // private System.Windows.Forms.OpenFileDialog openFileDialog;
    }

    // Keep OpenFileDialog if you need it for other purposes, otherwise remove
    // private System.Windows.Forms.OpenFileDialog openFileDialog;
}