namespace ProcessamentoImagens
{
    partial class frmPrincipal
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
            this.pictBoxImg1 = new System.Windows.Forms.PictureBox();
            this.btnAbrirImagem = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AddBrightness = new System.Windows.Forms.Button();
            this.RemoveBrightness = new System.Windows.Forms.Button();
            this.pictureBoxH = new System.Windows.Forms.PictureBox();
            this.pictureBoxS = new System.Windows.Forms.PictureBox();
            this.pictureBoxI = new System.Windows.Forms.PictureBox();
            this.pictureBoxB = new System.Windows.Forms.PictureBox();
            this.pictureBoxG = new System.Windows.Forms.PictureBox();
            this.pictureBoxR = new System.Windows.Forms.PictureBox();
            this.RGBLabel = new System.Windows.Forms.Label();
            this.HSILabel = new System.Windows.Forms.Label();
            this.operationLabel = new System.Windows.Forms.Label();
            this.valuesOfChannelLabel = new System.Windows.Forms.Label();
            this.pictureBoxLuminancia = new System.Windows.Forms.PictureBox();
            this.LuminanciaLabel = new System.Windows.Forms.Label();
            this.textBoxFaixa1 = new System.Windows.Forms.TextBox();
            this.textBoxFaixa2 = new System.Windows.Forms.TextBox();
            this.IsolarFaixaButton = new System.Windows.Forms.Button();
            this.pictureBoxHistograma = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addHue = new System.Windows.Forms.Button();
            this.removeHue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLuminancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistograma)).BeginInit();
            this.SuspendLayout();
            // 
            // pictBoxImg1
            // 
            this.pictBoxImg1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictBoxImg1.Location = new System.Drawing.Point(7, 7);
            this.pictBoxImg1.Margin = new System.Windows.Forms.Padding(4);
            this.pictBoxImg1.Name = "pictBoxImg1";
            this.pictBoxImg1.Size = new System.Drawing.Size(800, 615);
            this.pictBoxImg1.TabIndex = 102;
            this.pictBoxImg1.TabStop = false;
            this.pictBoxImg1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DetectMouseMoviment);
            // 
            // btnAbrirImagem
            // 
            this.btnAbrirImagem.Location = new System.Drawing.Point(7, 630);
            this.btnAbrirImagem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrirImagem.Name = "btnAbrirImagem";
            this.btnAbrirImagem.Size = new System.Drawing.Size(135, 28);
            this.btnAbrirImagem.TabIndex = 106;
            this.btnAbrirImagem.Text = "Abrir Imagem";
            this.btnAbrirImagem.UseVisualStyleBackColor = true;
            this.btnAbrirImagem.Click += new System.EventHandler(this.OpenImage);
            // 
            // AddBrightness
            // 
            this.AddBrightness.Location = new System.Drawing.Point(815, 15);
            this.AddBrightness.Margin = new System.Windows.Forms.Padding(4);
            this.AddBrightness.Name = "AddBrightness";
            this.AddBrightness.Size = new System.Drawing.Size(100, 28);
            this.AddBrightness.TabIndex = 107;
            this.AddBrightness.Text = "+ Brightness";
            this.AddBrightness.UseVisualStyleBackColor = true;
            this.AddBrightness.Click += new System.EventHandler(this.AddBrightnessButton);
            // 
            // RemoveBrightness
            // 
            this.RemoveBrightness.Location = new System.Drawing.Point(815, 50);
            this.RemoveBrightness.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveBrightness.Name = "RemoveBrightness";
            this.RemoveBrightness.Size = new System.Drawing.Size(100, 28);
            this.RemoveBrightness.TabIndex = 108;
            this.RemoveBrightness.Text = "- Brightness";
            this.RemoveBrightness.UseVisualStyleBackColor = true;
            this.RemoveBrightness.Click += new System.EventHandler(this.RemoveBrightnessButton);
            // 
            // pictureBoxH
            // 
            this.pictureBoxH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxH.Location = new System.Drawing.Point(1383, 50);
            this.pictureBoxH.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxH.Name = "pictureBoxH";
            this.pictureBoxH.Size = new System.Drawing.Size(228, 154);
            this.pictureBoxH.TabIndex = 109;
            this.pictureBoxH.TabStop = false;
            // 
            // pictureBoxS
            // 
            this.pictureBoxS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxS.Location = new System.Drawing.Point(1383, 225);
            this.pictureBoxS.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxS.Name = "pictureBoxS";
            this.pictureBoxS.Size = new System.Drawing.Size(228, 154);
            this.pictureBoxS.TabIndex = 110;
            this.pictureBoxS.TabStop = false;
            // 
            // pictureBoxI
            // 
            this.pictureBoxI.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxI.Location = new System.Drawing.Point(1383, 404);
            this.pictureBoxI.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxI.Name = "pictureBoxI";
            this.pictureBoxI.Size = new System.Drawing.Size(228, 154);
            this.pictureBoxI.TabIndex = 111;
            this.pictureBoxI.TabStop = false;
            // 
            // pictureBoxB
            // 
            this.pictureBoxB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxB.Location = new System.Drawing.Point(1131, 404);
            this.pictureBoxB.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxB.Name = "pictureBoxB";
            this.pictureBoxB.Size = new System.Drawing.Size(228, 154);
            this.pictureBoxB.TabIndex = 114;
            this.pictureBoxB.TabStop = false;
            // 
            // pictureBoxG
            // 
            this.pictureBoxG.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxG.Location = new System.Drawing.Point(1131, 225);
            this.pictureBoxG.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxG.Name = "pictureBoxG";
            this.pictureBoxG.Size = new System.Drawing.Size(228, 154);
            this.pictureBoxG.TabIndex = 113;
            this.pictureBoxG.TabStop = false;
            // 
            // pictureBoxR
            // 
            this.pictureBoxR.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxR.Location = new System.Drawing.Point(1131, 50);
            this.pictureBoxR.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxR.Name = "pictureBoxR";
            this.pictureBoxR.Size = new System.Drawing.Size(228, 154);
            this.pictureBoxR.TabIndex = 112;
            this.pictureBoxR.TabStop = false;
            // 
            // RGBLabel
            // 
            this.RGBLabel.AutoSize = true;
            this.RGBLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.RGBLabel.Location = new System.Drawing.Point(1127, 21);
            this.RGBLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RGBLabel.Name = "RGBLabel";
            this.RGBLabel.Size = new System.Drawing.Size(38, 17);
            this.RGBLabel.TabIndex = 115;
            this.RGBLabel.Text = "RGB";
            this.RGBLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // HSILabel
            // 
            this.HSILabel.AutoSize = true;
            this.HSILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.HSILabel.Location = new System.Drawing.Point(1379, 21);
            this.HSILabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HSILabel.Name = "HSILabel";
            this.HSILabel.Size = new System.Drawing.Size(30, 17);
            this.HSILabel.TabIndex = 116;
            this.HSILabel.Text = "HSI";
            this.HSILabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // operationLabel
            // 
            this.operationLabel.AutoSize = true;
            this.operationLabel.Location = new System.Drawing.Point(149, 636);
            this.operationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(0, 16);
            this.operationLabel.TabIndex = 117;
            // 
            // valuesOfChannelLabel
            // 
            this.valuesOfChannelLabel.AutoSize = true;
            this.valuesOfChannelLabel.Location = new System.Drawing.Point(16, 721);
            this.valuesOfChannelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valuesOfChannelLabel.Name = "valuesOfChannelLabel";
            this.valuesOfChannelLabel.Size = new System.Drawing.Size(0, 16);
            this.valuesOfChannelLabel.TabIndex = 118;
            // 
            // pictureBoxLuminancia
            // 
            this.pictureBoxLuminancia.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxLuminancia.Location = new System.Drawing.Point(1251, 630);
            this.pictureBoxLuminancia.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxLuminancia.Name = "pictureBoxLuminancia";
            this.pictureBoxLuminancia.Size = new System.Drawing.Size(228, 154);
            this.pictureBoxLuminancia.TabIndex = 119;
            this.pictureBoxLuminancia.TabStop = false;
            // 
            // LuminanciaLabel
            // 
            this.LuminanciaLabel.AutoSize = true;
            this.LuminanciaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.LuminanciaLabel.Location = new System.Drawing.Point(1247, 608);
            this.LuminanciaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LuminanciaLabel.Name = "LuminanciaLabel";
            this.LuminanciaLabel.Size = new System.Drawing.Size(80, 17);
            this.LuminanciaLabel.TabIndex = 120;
            this.LuminanciaLabel.Text = "Luminância";
            this.LuminanciaLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBoxFaixa1
            // 
            this.textBoxFaixa1.Location = new System.Drawing.Point(244, 633);
            this.textBoxFaixa1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFaixa1.Name = "textBoxFaixa1";
            this.textBoxFaixa1.Size = new System.Drawing.Size(132, 22);
            this.textBoxFaixa1.TabIndex = 121;
            // 
            // textBoxFaixa2
            // 
            this.textBoxFaixa2.Location = new System.Drawing.Point(400, 634);
            this.textBoxFaixa2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFaixa2.Name = "textBoxFaixa2";
            this.textBoxFaixa2.Size = new System.Drawing.Size(132, 22);
            this.textBoxFaixa2.TabIndex = 122;
            // 
            // IsolarFaixaButton
            // 
            this.IsolarFaixaButton.Location = new System.Drawing.Point(541, 631);
            this.IsolarFaixaButton.Margin = new System.Windows.Forms.Padding(4);
            this.IsolarFaixaButton.Name = "IsolarFaixaButton";
            this.IsolarFaixaButton.Size = new System.Drawing.Size(173, 28);
            this.IsolarFaixaButton.TabIndex = 123;
            this.IsolarFaixaButton.Text = "Isolar faixa de valor";
            this.IsolarFaixaButton.UseVisualStyleBackColor = true;
            this.IsolarFaixaButton.Click += new System.EventHandler(this.IsolarFaixaHue);
            // 
            // pictureBoxHistograma
            // 
            this.pictureBoxHistograma.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxHistograma.Location = new System.Drawing.Point(838, 630);
            this.pictureBoxHistograma.Name = "pictureBoxHistograma";
            this.pictureBoxHistograma.Size = new System.Drawing.Size(392, 154);
            this.pictureBoxHistograma.TabIndex = 124;
            this.pictureBoxHistograma.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(838, 609);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 125;
            this.label1.Text = "Histograma";
            // 
            // addHue
            // 
            this.addHue.Location = new System.Drawing.Point(815, 86);
            this.addHue.Name = "addHue";
            this.addHue.Size = new System.Drawing.Size(100, 23);
            this.addHue.TabIndex = 126;
            this.addHue.Text = "Aumentar Hue";
            this.addHue.UseVisualStyleBackColor = true;
            this.addHue.Click += new System.EventHandler(this.addHue_Click);
            // 
            // removeHue
            // 
            this.removeHue.Location = new System.Drawing.Point(815, 116);
            this.removeHue.Name = "removeHue";
            this.removeHue.Size = new System.Drawing.Size(100, 23);
            this.removeHue.TabIndex = 127;
            this.removeHue.Text = "Diminuir Hue";
            this.removeHue.UseVisualStyleBackColor = true;
            this.removeHue.Click += new System.EventHandler(this.removeHue_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 794);
            this.Controls.Add(this.removeHue);
            this.Controls.Add(this.addHue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxHistograma);
            this.Controls.Add(this.IsolarFaixaButton);
            this.Controls.Add(this.textBoxFaixa2);
            this.Controls.Add(this.textBoxFaixa1);
            this.Controls.Add(this.LuminanciaLabel);
            this.Controls.Add(this.pictureBoxLuminancia);
            this.Controls.Add(this.valuesOfChannelLabel);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.HSILabel);
            this.Controls.Add(this.RGBLabel);
            this.Controls.Add(this.pictureBoxB);
            this.Controls.Add(this.pictureBoxG);
            this.Controls.Add(this.pictureBoxR);
            this.Controls.Add(this.pictureBoxI);
            this.Controls.Add(this.pictureBoxS);
            this.Controls.Add(this.pictureBoxH);
            this.Controls.Add(this.RemoveBrightness);
            this.Controls.Add(this.AddBrightness);
            this.Controls.Add(this.btnAbrirImagem);
            this.Controls.Add(this.pictBoxImg1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLuminancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistograma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBoxImg1;
        private System.Windows.Forms.Button btnAbrirImagem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button AddBrightness;
        private System.Windows.Forms.Button RemoveBrightness;
        private System.Windows.Forms.PictureBox pictureBoxH;
        private System.Windows.Forms.PictureBox pictureBoxS;
        private System.Windows.Forms.PictureBox pictureBoxI;
        private System.Windows.Forms.PictureBox pictureBoxB;
        private System.Windows.Forms.PictureBox pictureBoxG;
        private System.Windows.Forms.PictureBox pictureBoxR;
        private System.Windows.Forms.Label RGBLabel;
        private System.Windows.Forms.Label HSILabel;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.Label valuesOfChannelLabel;
        private System.Windows.Forms.PictureBox pictureBoxLuminancia;
        private System.Windows.Forms.Label LuminanciaLabel;
        private System.Windows.Forms.TextBox textBoxFaixa1;
        private System.Windows.Forms.TextBox textBoxFaixa2;
        private System.Windows.Forms.Button IsolarFaixaButton;
        private System.Windows.Forms.PictureBox pictureBoxHistograma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addHue;
        private System.Windows.Forms.Button removeHue;
    }
}

