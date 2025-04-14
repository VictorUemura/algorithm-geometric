namespace ProcessamentoImagens
{
    partial class frmPoligonosTransformacoes
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
            this.panelDesenho = new System.Windows.Forms.Panel();
            this.panelControles = new System.Windows.Forms.Panel();
            this.btnLimparTudo = new System.Windows.Forms.Button();
            this.btnRemoverSelecionados = new System.Windows.Forms.Button();
            this.gbPreenchimento = new System.Windows.Forms.GroupBox();
            this.btnScanline = new System.Windows.Forms.Button();
            this.btnFloodFill = new System.Windows.Forms.Button();
            this.gbTransformacoes = new System.Windows.Forms.GroupBox();
            this.btnReflexaoCentroOrigem = new System.Windows.Forms.Button();
            this.btnReflexaoCentroHorizontal = new System.Windows.Forms.Button();
            this.btnReflexaoCentroVertical = new System.Windows.Forms.Button();
            this.lblReflexaoCentro = new System.Windows.Forms.Label();
            this.numRotacaoCentro = new System.Windows.Forms.NumericUpDown();
            this.lblRotacaoCentro = new System.Windows.Forms.Label();
            this.btnReflexaoConjunto = new System.Windows.Forms.Button();
            this.btnReflexaoHorizontal = new System.Windows.Forms.Button();
            this.btnReflexaoVertical = new System.Windows.Forms.Button();
            this.lblReflexaoEixo = new System.Windows.Forms.Label();
            this.numCisalhamentoY = new System.Windows.Forms.NumericUpDown();
            this.numCisalhamentoX = new System.Windows.Forms.NumericUpDown();
            this.lblCisalhamento = new System.Windows.Forms.Label();
            this.numRotacaoEixo = new System.Windows.Forms.NumericUpDown();
            this.lblRotacaoEixo = new System.Windows.Forms.Label();
            this.numEscalaY = new System.Windows.Forms.NumericUpDown();
            this.numEscalaX = new System.Windows.Forms.NumericUpDown();
            this.lblEscala = new System.Windows.Forms.Label();
            this.numTranslacaoY = new System.Windows.Forms.NumericUpDown();
            this.numTranslacaoX = new System.Windows.Forms.NumericUpDown();
            this.lblTranslacao = new System.Windows.Forms.Label();
            this.flowLayoutPanelPoligonos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFinalizarConexoes = new System.Windows.Forms.Button();
            this.panelControles.SuspendLayout();
            this.gbPreenchimento.SuspendLayout();
            this.gbTransformacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotacaoCentro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCisalhamentoY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCisalhamentoX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotacaoEixo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEscalaY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEscalaX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslacaoY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslacaoX)).BeginInit();
            this.SuspendLayout();
            //
            // panelDesenho
            //
            this.panelDesenho.BackColor = System.Drawing.Color.White;
            this.panelDesenho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDesenho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesenho.Location = new System.Drawing.Point(0, 0);
            this.panelDesenho.Margin = new System.Windows.Forms.Padding(4);
            this.panelDesenho.Name = "panelDesenho";
            this.panelDesenho.Size = new System.Drawing.Size(582, 713);
            this.panelDesenho.TabIndex = 0;
            //
            // panelControles
            //
            this.panelControles.Controls.Add(this.btnLimparTudo);
            this.panelControles.Controls.Add(this.btnRemoverSelecionados);
            this.panelControles.Controls.Add(this.gbPreenchimento);
            this.panelControles.Controls.Add(this.gbTransformacoes);
            this.panelControles.Controls.Add(this.flowLayoutPanelPoligonos);
            this.panelControles.Controls.Add(this.btnFinalizarConexoes);
            this.panelControles.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControles.Location = new System.Drawing.Point(582, 0);
            this.panelControles.Margin = new System.Windows.Forms.Padding(4);
            this.panelControles.Name = "panelControles";
            this.panelControles.Padding = new System.Windows.Forms.Padding(10);
            this.panelControles.Size = new System.Drawing.Size(200, 713);
            this.panelControles.TabIndex = 1;
            //
            // btnLimparTudo
            //
            this.btnLimparTudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimparTudo.Location = new System.Drawing.Point(14, 673);
            this.btnLimparTudo.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimparTudo.Name = "btnLimparTudo";
            this.btnLimparTudo.Size = new System.Drawing.Size(172, 28);
            this.btnLimparTudo.TabIndex = 6;
            this.btnLimparTudo.Text = "Limpar Tudo";
            this.btnLimparTudo.UseVisualStyleBackColor = true;
            //
            // btnRemoverSelecionados
            //
            this.btnRemoverSelecionados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverSelecionados.Location = new System.Drawing.Point(14, 637); 
            this.btnRemoverSelecionados.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoverSelecionados.Name = "btnRemoverSelecionados";
            this.btnRemoverSelecionados.Size = new System.Drawing.Size(172, 28);
            this.btnRemoverSelecionados.TabIndex = 5; 
            this.btnRemoverSelecionados.Text = "Remover Selecionados";
            this.btnRemoverSelecionados.UseVisualStyleBackColor = true;
            //
            // gbPreenchimento
            //
            this.gbPreenchimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPreenchimento.Controls.Add(this.btnScanline);
            this.gbPreenchimento.Controls.Add(this.btnFloodFill);
            this.gbPreenchimento.Location = new System.Drawing.Point(14, 527);
            this.gbPreenchimento.Margin = new System.Windows.Forms.Padding(4);
            this.gbPreenchimento.Name = "gbPreenchimento";
            this.gbPreenchimento.Padding = new System.Windows.Forms.Padding(4);
            this.gbPreenchimento.Size = new System.Drawing.Size(172, 100);
            this.gbPreenchimento.TabIndex = 3;
            this.gbPreenchimento.TabStop = false;
            this.gbPreenchimento.Text = "Preenchimento";
            //
            // btnScanline
            //
            this.btnScanline.Location = new System.Drawing.Point(10, 59);
            this.btnScanline.Margin = new System.Windows.Forms.Padding(4);
            this.btnScanline.Name = "btnScanline";
            this.btnScanline.Size = new System.Drawing.Size(150, 28);
            this.btnScanline.TabIndex = 1;
            this.btnScanline.Text = "Scanline";
            this.btnScanline.UseVisualStyleBackColor = true;
            //
            // btnFloodFill
            //
            this.btnFloodFill.Location = new System.Drawing.Point(10, 23);
            this.btnFloodFill.Margin = new System.Windows.Forms.Padding(4);
            this.btnFloodFill.Name = "btnFloodFill";
            this.btnFloodFill.Size = new System.Drawing.Size(150, 28);
            this.btnFloodFill.TabIndex = 0;
            this.btnFloodFill.Text = "Flood Fill";
            this.btnFloodFill.UseVisualStyleBackColor = true;
            //
            // gbTransformacoes
            //
            this.gbTransformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTransformacoes.Controls.Add(this.btnReflexaoCentroOrigem);
            this.gbTransformacoes.Controls.Add(this.btnReflexaoCentroHorizontal);
            this.gbTransformacoes.Controls.Add(this.btnReflexaoCentroVertical);
            this.gbTransformacoes.Controls.Add(this.lblReflexaoCentro);
            this.gbTransformacoes.Controls.Add(this.numRotacaoCentro);
            this.gbTransformacoes.Controls.Add(this.lblRotacaoCentro);
            this.gbTransformacoes.Controls.Add(this.btnReflexaoConjunto);
            this.gbTransformacoes.Controls.Add(this.btnReflexaoHorizontal);
            this.gbTransformacoes.Controls.Add(this.btnReflexaoVertical);
            this.gbTransformacoes.Controls.Add(this.lblReflexaoEixo);
            this.gbTransformacoes.Controls.Add(this.numCisalhamentoY);
            this.gbTransformacoes.Controls.Add(this.numCisalhamentoX);
            this.gbTransformacoes.Controls.Add(this.lblCisalhamento);
            this.gbTransformacoes.Controls.Add(this.numRotacaoEixo);
            this.gbTransformacoes.Controls.Add(this.lblRotacaoEixo);
            this.gbTransformacoes.Controls.Add(this.numEscalaY);
            this.gbTransformacoes.Controls.Add(this.numEscalaX);
            this.gbTransformacoes.Controls.Add(this.lblEscala);
            this.gbTransformacoes.Controls.Add(this.numTranslacaoY);
            this.gbTransformacoes.Controls.Add(this.numTranslacaoX);
            this.gbTransformacoes.Controls.Add(this.lblTranslacao);
            this.gbTransformacoes.Location = new System.Drawing.Point(14, 160);
            this.gbTransformacoes.Margin = new System.Windows.Forms.Padding(4);
            this.gbTransformacoes.Name = "gbTransformacoes";
            this.gbTransformacoes.Padding = new System.Windows.Forms.Padding(4);
            this.gbTransformacoes.Size = new System.Drawing.Size(172, 359);
            this.gbTransformacoes.TabIndex = 2;
            this.gbTransformacoes.TabStop = false;
            this.gbTransformacoes.Text = "Transformações";
            //
            // btnReflexaoCentroOrigem
            //
            this.btnReflexaoCentroOrigem.Location = new System.Drawing.Point(90, 320);
            this.btnReflexaoCentroOrigem.Margin = new System.Windows.Forms.Padding(2);
            this.btnReflexaoCentroOrigem.Name = "btnReflexaoCentroOrigem";
            this.btnReflexaoCentroOrigem.Size = new System.Drawing.Size(70, 25);
            this.btnReflexaoCentroOrigem.TabIndex = 20;
            this.btnReflexaoCentroOrigem.Text = "Origem";
            this.btnReflexaoCentroOrigem.UseVisualStyleBackColor = true;
            //
            // btnReflexaoCentroHorizontal
            //
            this.btnReflexaoCentroHorizontal.Location = new System.Drawing.Point(90, 291);
            this.btnReflexaoCentroHorizontal.Margin = new System.Windows.Forms.Padding(2);
            this.btnReflexaoCentroHorizontal.Name = "btnReflexaoCentroHorizontal";
            this.btnReflexaoCentroHorizontal.Size = new System.Drawing.Size(70, 25);
            this.btnReflexaoCentroHorizontal.TabIndex = 19;
            this.btnReflexaoCentroHorizontal.Text = "Horizontal";
            this.btnReflexaoCentroHorizontal.UseVisualStyleBackColor = true;
            //
            // btnReflexaoCentroVertical
            //
            this.btnReflexaoCentroVertical.Location = new System.Drawing.Point(10, 291);
            this.btnReflexaoCentroVertical.Margin = new System.Windows.Forms.Padding(2);
            this.btnReflexaoCentroVertical.Name = "btnReflexaoCentroVertical";
            this.btnReflexaoCentroVertical.Size = new System.Drawing.Size(70, 25);
            this.btnReflexaoCentroVertical.TabIndex = 18;
            this.btnReflexaoCentroVertical.Text = "Vertical";
            this.btnReflexaoCentroVertical.UseVisualStyleBackColor = true;
            //
            // lblReflexaoCentro
            //
            this.lblReflexaoCentro.AutoSize = true;
            this.lblReflexaoCentro.Location = new System.Drawing.Point(7, 273);
            this.lblReflexaoCentro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReflexaoCentro.Name = "lblReflexaoCentro";
            this.lblReflexaoCentro.Size = new System.Drawing.Size(108, 16);
            this.lblReflexaoCentro.TabIndex = 17;
            this.lblReflexaoCentro.Text = "Reflexão Centro:";
            //
            // numRotacaoCentro
            //
            this.numRotacaoCentro.Location = new System.Drawing.Point(105, 130);
            this.numRotacaoCentro.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            this.numRotacaoCentro.Minimum = new decimal(new int[] { 360, 0, 0, -2147483648 });
            this.numRotacaoCentro.Name = "numRotacaoCentro";
            this.numRotacaoCentro.Size = new System.Drawing.Size(55, 22);
            this.numRotacaoCentro.TabIndex = 9;
            this.numRotacaoCentro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblRotacaoCentro
            //
            this.lblRotacaoCentro.AutoSize = true;
            this.lblRotacaoCentro.Location = new System.Drawing.Point(7, 132);
            this.lblRotacaoCentro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRotacaoCentro.Name = "lblRotacaoCentro";
            this.lblRotacaoCentro.Size = new System.Drawing.Size(100, 16);
            this.lblRotacaoCentro.TabIndex = 8;
            this.lblRotacaoCentro.Text = "Rotação Centro:";
            //
            // btnReflexaoConjunto
            //
            this.btnReflexaoConjunto.Location = new System.Drawing.Point(90, 250);
            this.btnReflexaoConjunto.Margin = new System.Windows.Forms.Padding(2);
            this.btnReflexaoConjunto.Name = "btnReflexaoConjunto";
            this.btnReflexaoConjunto.Size = new System.Drawing.Size(70, 25);
            this.btnReflexaoConjunto.TabIndex = 16;
            this.btnReflexaoConjunto.Text = "Origem";
            this.btnReflexaoConjunto.UseVisualStyleBackColor = true;
            //
            // btnReflexaoHorizontal
            //
            this.btnReflexaoHorizontal.Location = new System.Drawing.Point(90, 221);
            this.btnReflexaoHorizontal.Margin = new System.Windows.Forms.Padding(2);
            this.btnReflexaoHorizontal.Name = "btnReflexaoHorizontal";
            this.btnReflexaoHorizontal.Size = new System.Drawing.Size(70, 25);
            this.btnReflexaoHorizontal.TabIndex = 15;
            this.btnReflexaoHorizontal.Text = "Horizontal";
            this.btnReflexaoHorizontal.UseVisualStyleBackColor = true;
            //
            // btnReflexaoVertical
            //
            this.btnReflexaoVertical.Location = new System.Drawing.Point(10, 221);
            this.btnReflexaoVertical.Margin = new System.Windows.Forms.Padding(2);
            this.btnReflexaoVertical.Name = "btnReflexaoVertical";
            this.btnReflexaoVertical.Size = new System.Drawing.Size(70, 25);
            this.btnReflexaoVertical.TabIndex = 14;
            this.btnReflexaoVertical.Text = "Vertical";
            this.btnReflexaoVertical.UseVisualStyleBackColor = true;
            //
            // lblReflexaoEixo
            //
            this.lblReflexaoEixo.AutoSize = true;
            this.lblReflexaoEixo.Location = new System.Drawing.Point(7, 203);
            this.lblReflexaoEixo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReflexaoEixo.Name = "lblReflexaoEixo";
            this.lblReflexaoEixo.Size = new System.Drawing.Size(93, 16);
            this.lblReflexaoEixo.TabIndex = 13;
            this.lblReflexaoEixo.Text = "Reflexão Eixo:";
            //
            // numCisalhamentoY
            //
            this.numCisalhamentoY.DecimalPlaces = 2;
            this.numCisalhamentoY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numCisalhamentoY.Location = new System.Drawing.Point(105, 178);
            this.numCisalhamentoY.Margin = new System.Windows.Forms.Padding(4);
            this.numCisalhamentoY.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numCisalhamentoY.Minimum = new decimal(new int[] { 5, 0, 0, -2147483648 });
            this.numCisalhamentoY.Name = "numCisalhamentoY";
            this.numCisalhamentoY.Size = new System.Drawing.Size(55, 22);
            this.numCisalhamentoY.TabIndex = 12;
            this.numCisalhamentoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // numCisalhamentoX
            //
            this.numCisalhamentoX.DecimalPlaces = 2;
            this.numCisalhamentoX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numCisalhamentoX.Location = new System.Drawing.Point(35, 178);
            this.numCisalhamentoX.Margin = new System.Windows.Forms.Padding(4);
            this.numCisalhamentoX.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numCisalhamentoX.Minimum = new decimal(new int[] { 5, 0, 0, -2147483648 });
            this.numCisalhamentoX.Name = "numCisalhamentoX";
            this.numCisalhamentoX.Size = new System.Drawing.Size(55, 22);
            this.numCisalhamentoX.TabIndex = 11;
            this.numCisalhamentoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblCisalhamento
            //
            this.lblCisalhamento.AutoSize = true;
            this.lblCisalhamento.Location = new System.Drawing.Point(7, 160);
            this.lblCisalhamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCisalhamento.Name = "lblCisalhamento";
            this.lblCisalhamento.Size = new System.Drawing.Size(91, 16);
            this.lblCisalhamento.TabIndex = 10;
            this.lblCisalhamento.Text = "Cisalhamento:";
            //
            // numRotacaoEixo
            //
            this.numRotacaoEixo.Location = new System.Drawing.Point(105, 100);
            this.numRotacaoEixo.Margin = new System.Windows.Forms.Padding(4);
            this.numRotacaoEixo.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            this.numRotacaoEixo.Minimum = new decimal(new int[] { 360, 0, 0, -2147483648 });
            this.numRotacaoEixo.Name = "numRotacaoEixo";
            this.numRotacaoEixo.Size = new System.Drawing.Size(55, 22);
            this.numRotacaoEixo.TabIndex = 7;
            this.numRotacaoEixo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblRotacaoEixo
            //
            this.lblRotacaoEixo.AutoSize = true;
            this.lblRotacaoEixo.Location = new System.Drawing.Point(7, 102);
            this.lblRotacaoEixo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRotacaoEixo.Name = "lblRotacaoEixo";
            this.lblRotacaoEixo.Size = new System.Drawing.Size(88, 16);
            this.lblRotacaoEixo.TabIndex = 6;
            this.lblRotacaoEixo.Text = "Rotação Eixo:";
            //
            // numEscalaY
            //
            this.numEscalaY.DecimalPlaces = 2; this.numEscalaY.Increment = new decimal(new int[] { 1, 0, 0, 65536 }); this.numEscalaY.Location = new System.Drawing.Point(105, 68); this.numEscalaY.Margin = new System.Windows.Forms.Padding(4); this.numEscalaY.Maximum = new decimal(new int[] { 10, 0, 0, 0 }); this.numEscalaY.Minimum = new decimal(new int[] { 1, 0, 0, 65536 }); this.numEscalaY.Name = "numEscalaY"; this.numEscalaY.Size = new System.Drawing.Size(55, 22); this.numEscalaY.TabIndex = 5; this.numEscalaY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right; this.numEscalaY.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // numEscalaX
            //
            this.numEscalaX.DecimalPlaces = 2; this.numEscalaX.Increment = new decimal(new int[] { 1, 0, 0, 65536 }); this.numEscalaX.Location = new System.Drawing.Point(35, 68); this.numEscalaX.Margin = new System.Windows.Forms.Padding(4); this.numEscalaX.Maximum = new decimal(new int[] { 10, 0, 0, 0 }); this.numEscalaX.Minimum = new decimal(new int[] { 1, 0, 0, 65536 }); this.numEscalaX.Name = "numEscalaX"; this.numEscalaX.Size = new System.Drawing.Size(55, 22); this.numEscalaX.TabIndex = 4; this.numEscalaX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right; this.numEscalaX.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblEscala
            //
            this.lblEscala.AutoSize = true; this.lblEscala.Location = new System.Drawing.Point(7, 50); this.lblEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0); this.lblEscala.Name = "lblEscala"; this.lblEscala.Size = new System.Drawing.Size(51, 16); this.lblEscala.TabIndex = 3; this.lblEscala.Text = "Escala:";
            //
            // numTranslacaoY
            //
            this.numTranslacaoY.Location = new System.Drawing.Point(105, 23); this.numTranslacaoY.Margin = new System.Windows.Forms.Padding(4); this.numTranslacaoY.Maximum = new decimal(new int[] { 1000, 0, 0, 0 }); this.numTranslacaoY.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 }); this.numTranslacaoY.Name = "numTranslacaoY"; this.numTranslacaoY.Size = new System.Drawing.Size(55, 22); this.numTranslacaoY.TabIndex = 2; this.numTranslacaoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // numTranslacaoX
            //
            this.numTranslacaoX.Location = new System.Drawing.Point(35, 23); this.numTranslacaoX.Margin = new System.Windows.Forms.Padding(4); this.numTranslacaoX.Maximum = new decimal(new int[] { 1000, 0, 0, 0 }); this.numTranslacaoX.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 }); this.numTranslacaoX.Name = "numTranslacaoX"; this.numTranslacaoX.Size = new System.Drawing.Size(55, 22); this.numTranslacaoX.TabIndex = 1; this.numTranslacaoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblTranslacao
            //
            this.lblTranslacao.AutoSize = true; this.lblTranslacao.Location = new System.Drawing.Point(7, 25); this.lblTranslacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0); this.lblTranslacao.Name = "lblTranslacao"; this.lblTranslacao.Size = new System.Drawing.Size(21, 16); this.lblTranslacao.TabIndex = 0; this.lblTranslacao.Text = "T:";
            //
            // flowLayoutPanelPoligonos
            //
            this.flowLayoutPanelPoligonos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelPoligonos.AutoScroll = true;
            this.flowLayoutPanelPoligonos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelPoligonos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelPoligonos.Location = new System.Drawing.Point(14, 55);
            this.flowLayoutPanelPoligonos.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelPoligonos.Name = "flowLayoutPanelPoligonos";
            this.flowLayoutPanelPoligonos.Size = new System.Drawing.Size(172, 95);
            this.flowLayoutPanelPoligonos.TabIndex = 1;
            this.flowLayoutPanelPoligonos.WrapContents = false;
            //
            // btnFinalizarConexoes
            //
            this.btnFinalizarConexoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizarConexoes.Location = new System.Drawing.Point(14, 14);
            this.btnFinalizarConexoes.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinalizarConexoes.Name = "btnFinalizarConexoes";
            this.btnFinalizarConexoes.Size = new System.Drawing.Size(172, 28);
            this.btnFinalizarConexoes.TabIndex = 0;
            this.btnFinalizarConexoes.Text = "Finalizar Conexões";
            this.btnFinalizarConexoes.UseVisualStyleBackColor = true;
            //
            // frmPoligonosTransformacoes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 713);
            this.Controls.Add(this.panelDesenho);
            this.Controls.Add(this.panelControles);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 760);
            this.Name = "frmPoligonosTransformacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Polígonos, Transformações e Preenchimento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPoligonosTransformacoes_FormClosing);
            this.Load += new System.EventHandler(this.frmPoligonosTransformacoes_Load);
            this.panelControles.ResumeLayout(false);
            this.gbPreenchimento.ResumeLayout(false);
            this.gbTransformacoes.ResumeLayout(false);
            this.gbTransformacoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotacaoCentro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCisalhamentoY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCisalhamentoX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotacaoEixo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEscalaY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEscalaX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslacaoY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslacaoX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesenho;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Button btnFinalizarConexoes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPoligonos;
        private System.Windows.Forms.GroupBox gbTransformacoes;
        private System.Windows.Forms.NumericUpDown numTranslacaoY;
        private System.Windows.Forms.NumericUpDown numTranslacaoX;
        private System.Windows.Forms.Label lblTranslacao;
        private System.Windows.Forms.NumericUpDown numEscalaY;
        private System.Windows.Forms.NumericUpDown numEscalaX;
        private System.Windows.Forms.Label lblEscala;
        private System.Windows.Forms.NumericUpDown numRotacaoEixo;
        private System.Windows.Forms.Label lblRotacaoEixo;
        private System.Windows.Forms.NumericUpDown numCisalhamentoY;
        private System.Windows.Forms.NumericUpDown numCisalhamentoX;
        private System.Windows.Forms.Label lblCisalhamento;
        private System.Windows.Forms.Button btnReflexaoConjunto;
        private System.Windows.Forms.Button btnReflexaoHorizontal;
        private System.Windows.Forms.Button btnReflexaoVertical;
        private System.Windows.Forms.Label lblReflexaoEixo;
        private System.Windows.Forms.GroupBox gbPreenchimento;
        private System.Windows.Forms.Button btnScanline;
        private System.Windows.Forms.Button btnFloodFill;
        private System.Windows.Forms.NumericUpDown numRotacaoCentro;
        private System.Windows.Forms.Label lblRotacaoCentro;
        private System.Windows.Forms.Button btnLimparTudo;
        private System.Windows.Forms.Button btnRemoverSelecionados;
        private System.Windows.Forms.Button btnReflexaoCentroOrigem;
        private System.Windows.Forms.Button btnReflexaoCentroHorizontal;
        private System.Windows.Forms.Button btnReflexaoCentroVertical;
        private System.Windows.Forms.Label lblReflexaoCentro;
    }
}