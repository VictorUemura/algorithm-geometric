using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

namespace ProcessamentoImagens
{
    public partial class frmPoligonosTransformacoes : Form
    {
        // --- Estrutura Auxiliar para Scanline ---
        private class EdgeInfoScanline // Renomeado para evitar conflito se tiver outro EdgeInfo
        {
            public int YMax { get; set; }
            public float XCurrent { get; set; } // X na interseção com a scanline atual
            public float InverseSlope { get; set; } // 1/m = dx/dy

            public EdgeInfoScanline(int yMax, float xStart, float invSlope)
            {
                YMax = yMax;
                XCurrent = xStart;
                InverseSlope = invSlope;
            }
        }

        // --- Variáveis de Estado ---
        private List<Poligono> listaPoligonos = new List<Poligono>();
        private List<Point> currentPolygonPoints = new List<Point>();
        private Bitmap drawingBitmap;
        private Graphics bitmapGraphics;
        private PointF centroDoPainel;

        private bool isDrawingPolygon = false;
        private bool needsRedraw = true;

        // Configurações
        private Color polygonDrawColor = Color.DarkSlateBlue;
        private Color currentPolygonDrawColor = Color.Crimson;
        private Color selectionHighlightColor = Color.LimeGreen;
        private Color fillColor = Color.MediumAquamarine; // Cor de preenchimento padrão

        // --- Construtor e Ciclo de Vida ---
        public frmPoligonosTransformacoes()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeDrawingArea();
            AttachEventHandlers();
            ResetTransformationControls();
        }

        private void frmPoligonosTransformacoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            bitmapGraphics?.Dispose(); drawingBitmap?.Dispose();
        }

        // --- Configuração Inicial e Redimensionamento ---
        private void InitializeDrawingArea()
        {
            if (panelDesenho.Width <= 0 || panelDesenho.Height <= 0) return;
            centroDoPainel = new PointF(panelDesenho.Width / 2f, panelDesenho.Height / 2f);
            Bitmap oldBitmap = drawingBitmap; Graphics oldGraphics = bitmapGraphics;
            drawingBitmap = new Bitmap(panelDesenho.Width, panelDesenho.Height, PixelFormat.Format32bppArgb); // Usa 32bpp para LockBits fácil
            bitmapGraphics = Graphics.FromImage(drawingBitmap);
            bitmapGraphics.SmoothingMode = SmoothingMode.AntiAlias; bitmapGraphics.Clear(Color.White);
            oldGraphics?.Dispose(); oldBitmap?.Dispose();
            needsRedraw = true; panelDesenho.Invalidate();
        }

        private void panelDesenho_Resize(object sender, EventArgs e)
        {
            InitializeDrawingArea();
            needsRedraw = true; panelDesenho.Invalidate();
            RebuildAndUpdateSelectedPolygons();
        }

        private void AttachEventHandlers()
        {
            this.panelDesenho.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesenho_Paint);
            this.panelDesenho.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDesenho_MouseClick);
            this.panelDesenho.Resize += new System.EventHandler(this.panelDesenho_Resize);
            this.btnFinalizarConexoes.Click += new System.EventHandler(this.btnFinalizarConexoes_Click);
            this.btnFloodFill.Click += new System.EventHandler(this.btnFloodFill_Click);
            this.btnScanline.Click += new System.EventHandler(this.btnScanline_Click); // Ligado ao handler correto
            this.btnVisualizarMatrizes.Click += new System.EventHandler(this.btnVisualizarMatrizes_Click);
            this.btnReflexaoVertical.Click += new System.EventHandler(this.TransformationUI_Changed);
            this.btnReflexaoHorizontal.Click += new System.EventHandler(this.TransformationUI_Changed);
            this.btnReflexaoConjunto.Click += new System.EventHandler(this.TransformationUI_Changed);
            this.numTranslacaoX.ValueChanged += new System.EventHandler(this.TransformationUI_Changed);
            this.numTranslacaoY.ValueChanged += new System.EventHandler(this.TransformationUI_Changed);
            this.numEscalaX.ValueChanged += new System.EventHandler(this.TransformationUI_Changed);
            this.numEscalaY.ValueChanged += new System.EventHandler(this.TransformationUI_Changed);
            this.numRotacaoEixo.ValueChanged += new System.EventHandler(this.TransformationUI_Changed);
            this.numRotacaoCentro.ValueChanged += new System.EventHandler(this.TransformationUI_Changed);
            this.numCisalhamentoX.ValueChanged += new System.EventHandler(this.TransformationUI_Changed);
            this.numCisalhamentoY.ValueChanged += new System.EventHandler(this.TransformationUI_Changed);
        }

        // --- Desenho ---
        private void panelDesenho_Paint(object sender, PaintEventArgs e)
        {
            if (drawingBitmap == null) return;
            if (needsRedraw)
            {
                // Não limpar aqui se o preenchimento acabou de acontecer
                // A flag needsRedraw controla isso
                bitmapGraphics.Clear(Color.White); // Limpa antes de redesenhar TUDO
                DrawPolygons(bitmapGraphics); DrawCurrentPolygon(bitmapGraphics);
                bitmapGraphics.FillEllipse(Brushes.Red, centroDoPainel.X - 3, centroDoPainel.Y - 3, 6, 6);
                needsRedraw = false; // Marcar como redesenhado
            }
            e.Graphics.DrawImageUnscaled(drawingBitmap, Point.Empty);
        }

        private void DrawPolygons(Graphics g)
        {
            foreach (CheckBox chk in flowLayoutPanelPoligonos.Controls.OfType<CheckBox>())
            {
                if (chk.Tag is int index && index >= 0 && index < listaPoligonos.Count)
                {
                    Poligono poly = listaPoligonos[index];
                    if (poly.ListaVerticesAtuais != null && poly.ListaVerticesAtuais.Count >= 2)
                    {
                        Color color = polygonDrawColor; float width = 1f;
                        if (chk.Checked) { color = selectionHighlightColor; width = 2f; }
                        using (Pen pen = new Pen(color, width))
                        {
                            try { g.DrawPolygon(pen, poly.ListaVerticesAtuais.ToArray()); }
                            catch (Exception ex) { Debug.WriteLine($"Erro ao desenhar polígono {index}: {ex.Message}"); }
                        }
                    }
                    else if (poly.ListaVerticesAtuais == null || poly.ListaVerticesAtuais.Count < 2) { Debug.WriteLine($"Polígono {index} tem poucos vértices atuais ({poly.ListaVerticesAtuais?.Count ?? 0})."); }
                }
            }
        }

        private void DrawCurrentPolygon(Graphics g)
        {
            if (currentPolygonPoints.Count > 0)
            {
                using (Pen currentPen = new Pen(currentPolygonDrawColor, 1))
                using (Brush currentBrush = new SolidBrush(currentPolygonDrawColor))
                {
                    foreach (Point p in currentPolygonPoints) { g.FillRectangle(currentBrush, p.X - 2, p.Y - 2, 5, 5); }
                    if (currentPolygonPoints.Count >= 2) { g.DrawLines(currentPen, currentPolygonPoints.ToArray()); }
                }
            }
        }

        // --- Criação de Polígonos e Reset da UI ---
        private void panelDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!isDrawingPolygon) { isDrawingPolygon = true; currentPolygonPoints.Clear(); }
                currentPolygonPoints.Add(e.Location); needsRedraw = true; panelDesenho.Invalidate();
            }
        }

        private void btnFinalizarConexoes_Click(object sender, EventArgs e)
        {
            if (currentPolygonPoints.Count >= 3)
            {
                try
                {
                    Poligono novoPoligono = new Poligono(currentPolygonPoints); int newIndex = listaPoligonos.Count; listaPoligonos.Add(novoPoligono);
                    CheckBox newCheckBox = new CheckBox { Text = $"P{newIndex + 1}", Tag = newIndex, AutoSize = true, Enabled = true, Checked = false, Margin = new Padding(5) };
                    newCheckBox.CheckedChanged += (s, args) => { needsRedraw = true; panelDesenho.Invalidate(); };
                    flowLayoutPanelPoligonos.Controls.Add(newCheckBox);
                    currentPolygonPoints.Clear(); isDrawingPolygon = false;
                    ResetTransformationControls();
                    needsRedraw = true; panelDesenho.Invalidate();
                }
                catch (ArgumentException ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Um polígono precisa de pelo menos 3 vértices.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ResetTransformationControls()
        {
            numTranslacaoX.ValueChanged -= TransformationUI_Changed; numTranslacaoY.ValueChanged -= TransformationUI_Changed; numEscalaX.ValueChanged -= TransformationUI_Changed; numEscalaY.ValueChanged -= TransformationUI_Changed; numRotacaoEixo.ValueChanged -= TransformationUI_Changed; numRotacaoCentro.ValueChanged -= TransformationUI_Changed; numCisalhamentoX.ValueChanged -= TransformationUI_Changed; numCisalhamentoY.ValueChanged -= TransformationUI_Changed;
            numTranslacaoX.Value = 0; numTranslacaoY.Value = 0; numEscalaX.Value = 1; numEscalaY.Value = 1; numRotacaoEixo.Value = 0; numRotacaoCentro.Value = 0; numCisalhamentoX.Value = 0; numCisalhamentoY.Value = 0;
            numTranslacaoX.ValueChanged += TransformationUI_Changed; numTranslacaoY.ValueChanged += TransformationUI_Changed; numEscalaX.ValueChanged += TransformationUI_Changed; numEscalaY.ValueChanged += TransformationUI_Changed; numRotacaoEixo.ValueChanged += TransformationUI_Changed; numRotacaoCentro.ValueChanged += TransformationUI_Changed; numCisalhamentoX.ValueChanged += TransformationUI_Changed; numCisalhamentoY.ValueChanged += TransformationUI_Changed;
        }

        // --- Visualizar Matrizes ---
        private void btnVisualizarMatrizes_Click(object sender, EventArgs e)
        {
            if (listaPoligonos.Count == 0) { MessageBox.Show("Nenhum polígono foi criado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            frmVisualizarMatrizes formMatrizes = new frmVisualizarMatrizes(listaPoligonos);
            formMatrizes.ShowDialog(this);
        }

        // --- Lógica de Transformação UNIFICADA ---
        private void TransformationUI_Changed(object sender, EventArgs e)
        {
            bool isReflectionClick = (sender == btnReflexaoVertical || sender == btnReflexaoHorizontal || sender == btnReflexaoConjunto);
            if (isReflectionClick && sender is Button btnReflect)
            {
                foreach (CheckBox chk in flowLayoutPanelPoligonos.Controls.OfType<CheckBox>())
                {
                    if (chk.Checked && chk.Tag is int index && index >= 0 && index < listaPoligonos.Count)
                    {
                        Poligono poly = listaPoligonos[index];
                        if (btnReflect == btnReflexaoVertical) poly.ToggleReflectionY();
                        else if (btnReflect == btnReflexaoHorizontal) poly.ToggleReflectionX();
                        else if (btnReflect == btnReflexaoConjunto) poly.ToggleReflectionOrigin();
                    }
                }
            }
            RebuildAndUpdateSelectedPolygons(); // Sempre reconstrói após mudar estado
        }

        private void RebuildAndUpdateSelectedPolygons()
        {
            float tx = (float)numTranslacaoX.Value; float ty = (float)numTranslacaoY.Value; float sx = (float)numEscalaX.Value; float sy = (float)numEscalaY.Value; float rEixo = (float)numRotacaoEixo.Value; float rCentro = (float)numRotacaoCentro.Value; float shx = (float)numCisalhamentoX.Value; float shy = (float)numCisalhamentoY.Value;

            foreach (CheckBox chk in flowLayoutPanelPoligonos.Controls.OfType<CheckBox>())
            {
                if (chk.Checked && chk.Tag is int index && index >= 0 && index < listaPoligonos.Count)
                {
                    Poligono poly = listaPoligonos[index];
                    poly.ResetMatrix(); // RESET
                    PointF cOrig = CalculateCentroidFromList(poly.ListaVerticesOriginais); PointF cPanel = this.centroDoPainel;

                    // Aplica na ordem: Scale -> Shear -> Reflect -> Rotate Eixo -> Rotate Centro -> Translate
                    if (sx != 1 || sy != 1) poly.Scale(sx, sy, cOrig, MatrixOrder.Append);
                    if (shx != 0 || shy != 0) poly.Shear(shx, shy, cOrig, MatrixOrder.Append);
                    if (poly.CurrentReflectX != 1f || poly.CurrentReflectY != 1f) poly.ApplyReflectionMatrix(poly.CurrentReflectX, poly.CurrentReflectY, cOrig, MatrixOrder.Append);
                    if (rEixo != 0) poly.Rotate(rEixo, cOrig, MatrixOrder.Append);
                    if (rCentro != 0) poly.Rotate(rCentro, cPanel, MatrixOrder.Append);
                    if (tx != 0 || ty != 0) poly.Translate(tx, ty, MatrixOrder.Append);

                    poly.UpdateVerticesAtuais(); // ATUALIZA
                }
            }
            needsRedraw = true; panelDesenho.Invalidate();
        }

        private PointF CalculateCentroidFromList(List<Point> pointList)
        {
            if (pointList == null || pointList.Count == 0) return PointF.Empty; double area = 0.0; double cx = 0.0; double cy = 0.0; for (int i = 0, j = pointList.Count - 1; i < pointList.Count; j = i++) { double crossProduct = (double)pointList[i].X * pointList[j].Y - (double)pointList[j].X * pointList[i].Y; area += crossProduct; cx += (pointList[i].X + pointList[j].X) * crossProduct; cy += (pointList[i].Y + pointList[j].Y) * crossProduct; }
            if (Math.Abs(area) < 1E-7) return new PointF((float)pointList.Average(p => p.X), (float)pointList.Average(p => p.Y)); area *= 3.0; return new PointF((float)(cx / area), (float)(cy / area));
        }

        // --- Lógica de Preenchimento ---
        private void btnFloodFill_Click(object sender, EventArgs e)
        {
            bool filledAny = false; foreach (CheckBox chk in flowLayoutPanelPoligonos.Controls.OfType<CheckBox>()) { if (chk.Checked && chk.Tag is int index && index >= 0 && index < listaPoligonos.Count) { Poligono poly = listaPoligonos[index]; if (poly.ListaVerticesAtuais.Count >= 3) { PointF centroidF = poly.CalculateCurrentCentroid(); if (!centroidF.IsEmpty) { Point startPoint = Point.Round(centroidF); if (startPoint.X >= 0 && startPoint.X < drawingBitmap.Width && startPoint.Y >= 0 && startPoint.Y < drawingBitmap.Height) { PerformFloodFill(startPoint); filledAny = true; } else Debug.WriteLine($"Centroide fora dos limites P{index + 1}"); } else Debug.WriteLine($"Centroide inválido P{index + 1}"); } } }
            if (filledAny)
            {
                // NÃO marcar needsRedraw = true aqui, pois o bitmap já foi alterado
                panelDesenho.Invalidate(); // Apenas invalida para exibir o bitmap modificado
            }
            else MessageBox.Show("Nenhum polígono válido selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PerformFloodFill(Point startPoint)
        {
            // ... (Código FloodFill com LockBits mantido) ...
            if (drawingBitmap == null) return; Color targetColor; try { targetColor = drawingBitmap.GetPixel(startPoint.X, startPoint.Y); } catch { return; }
            if (targetColor.ToArgb() == fillColor.ToArgb()) return; int width = drawingBitmap.Width; int height = drawingBitmap.Height; BitmapData bmpData = null; try { bmpData = drawingBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, drawingBitmap.PixelFormat); int bytesPerPixel = Image.GetPixelFormatSize(drawingBitmap.PixelFormat) / 8; int stride = bmpData.Stride; IntPtr ptr = bmpData.Scan0; int byteCount = Math.Abs(stride) * height; byte[] pixels = new byte[byteCount]; Marshal.Copy(ptr, pixels, 0, byteCount); int targetArgb = targetColor.ToArgb(); int fillArgb = fillColor.ToArgb(); Queue<Point> checkQueue = new Queue<Point>(); checkQueue.Enqueue(startPoint); while (checkQueue.Count > 0) { Point current = checkQueue.Dequeue(); int x = current.X; int y = current.Y; if (x < 0 || x >= width || y < 0 || y >= height) continue; int byteIndex = y * stride + x * bytesPerPixel; if (byteIndex < 0 || byteIndex + bytesPerPixel > byteCount) continue; int currentArgb = BitConverter.ToInt32(pixels, byteIndex); if (currentArgb == targetArgb) { byte[] fillBytes = BitConverter.GetBytes(fillArgb); Buffer.BlockCopy(fillBytes, 0, pixels, byteIndex, bytesPerPixel); checkQueue.Enqueue(new Point(x + 1, y)); checkQueue.Enqueue(new Point(x - 1, y)); checkQueue.Enqueue(new Point(x, y + 1)); checkQueue.Enqueue(new Point(x, y - 1)); } } Marshal.Copy(pixels, 0, ptr, byteCount); } catch (Exception ex) { Debug.WriteLine($"Erro Flood Fill: {ex.Message}"); } finally { if (bmpData != null) drawingBitmap.UnlockBits(bmpData); }
        }

        // --- SCANLINE IMPLEMENTADO ---
        private void btnScanline_Click(object sender, EventArgs e)
        {
            bool filledAny = false;
            foreach (CheckBox chk in flowLayoutPanelPoligonos.Controls.OfType<CheckBox>())
            {
                if (chk.Checked && chk.Tag is int index && index >= 0 && index < listaPoligonos.Count)
                {
                    Poligono poly = listaPoligonos[index];
                    if (poly.ListaVerticesAtuais.Count >= 3)
                    {
                        PerformScanlineFill(poly.ListaVerticesAtuais); // Passa vértices atuais
                        filledAny = true;
                    }
                }
            }
            if (filledAny)
            {
                // NÃO marcar needsRedraw = true aqui
                panelDesenho.Invalidate(); // Apenas invalida para exibir bitmap modificado
            }
            else
            {
                MessageBox.Show("Nenhum polígono selecionado para Scanline.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PerformScanlineFill(List<Point> polygonVertices)
        {
            if (drawingBitmap == null || polygonVertices.Count < 3) return;

            int width = drawingBitmap.Width;
            int height = drawingBitmap.Height;
            BitmapData bmpData = null;

            try
            {
                // 1. Encontrar Ymin e Ymax do polígono
                int yMin = polygonVertices.Min(p => p.Y);
                int yMax = polygonVertices.Max(p => p.Y);

                // Garante que Ymin/Ymax estão dentro dos limites do bitmap
                yMin = Math.Max(0, yMin);
                yMax = Math.Min(height - 1, yMax);

                // 2. Construir Edge Table (ET)
                // Usaremos um dicionário onde a chave é Y e o valor é uma lista de EdgeInfoScanline
                var edgeTable = new Dictionary<int, List<EdgeInfoScanline>>();
                for (int i = 0; i < polygonVertices.Count; i++)
                {
                    Point p1 = polygonVertices[i];
                    Point p2 = polygonVertices[(i + 1) % polygonVertices.Count]; // Próximo vértice (circular)

                    // Ignora arestas horizontais
                    if (p1.Y == p2.Y) continue;

                    // Garante que p1 é o vértice com menor Y
                    if (p1.Y > p2.Y) { var temp = p1; p1 = p2; p2 = temp; }

                    // Calcula informações da aresta
                    int edgeYMin = p1.Y;
                    int edgeYMax = p2.Y;
                    float xAtYMin = p1.X;
                    float inverseSlope = (p2.Y - p1.Y == 0) ? 0 : (float)(p2.X - p1.X) / (p2.Y - p1.Y); // dx/dy

                    EdgeInfoScanline edgeInfo = new EdgeInfoScanline(edgeYMax, xAtYMin, inverseSlope);

                    // Adiciona à ET na linha Ymin correspondente
                    if (!edgeTable.ContainsKey(edgeYMin))
                    {
                        edgeTable[edgeYMin] = new List<EdgeInfoScanline>();
                    }
                    edgeTable[edgeYMin].Add(edgeInfo);
                }

                // 3. LockBits para acesso rápido
                bmpData = drawingBitmap.LockBits(new Rectangle(0, 0, width, height),
                                                  ImageLockMode.WriteOnly, // WriteOnly pode ser mais rápido
                                                  drawingBitmap.PixelFormat); // Usa o formato do bitmap

                int bytesPerPixel = Image.GetPixelFormatSize(drawingBitmap.PixelFormat) / 8;
                int stride = bmpData.Stride;
                IntPtr ptr = bmpData.Scan0;
                int byteCount = Math.Abs(stride) * height;
                // Aloca array de bytes - não precisamos ler se for WriteOnly, mas escreveremos nele
                // Se precisar ler (ex: para checar cor existente), use ReadWrite e copie inicial
                byte[] pixels = new byte[byteCount];
                // Opcional: Limpar array ou copiar do bitmap se for ReadWrite
                // Marshal.Copy(ptr, pixels, 0, byteCount); // Se ReadWrite

                byte[] colorBytes = BitConverter.GetBytes(fillColor.ToArgb()); // Converte cor de preenchimento

                // 4. Processar Scanlines
                List<EdgeInfoScanline> activeEdgeTable = new List<EdgeInfoScanline>();
                for (int y = yMin; y <= yMax; y++)
                {
                    // a. Remove arestas da AET onde y == Ymax
                    activeEdgeTable.RemoveAll(edge => edge.YMax == y);

                    // b. Adiciona arestas da ET[y] para a AET
                    if (edgeTable.ContainsKey(y))
                    {
                        activeEdgeTable.AddRange(edgeTable[y]);
                    }

                    // c. Ordena AET por XCurrent
                    activeEdgeTable.Sort((e1, e2) => e1.XCurrent.CompareTo(e2.XCurrent));

                    // d. Preenche pixels entre pares de interseções X
                    for (int i = 0; i < activeEdgeTable.Count; i += 2)
                    {
                        if (i + 1 < activeEdgeTable.Count) // Garante que temos um par
                        {
                            // Arredonda x inicial para cima, x final para baixo para evitar buracos/overlaps
                            int xStart = (int)Math.Ceiling(activeEdgeTable[i].XCurrent);
                            int xEnd = (int)Math.Floor(activeEdgeTable[i + 1].XCurrent);

                            // Garante que xStart/xEnd estão dentro dos limites
                            xStart = Math.Max(0, xStart);
                            xEnd = Math.Min(width - 1, xEnd);

                            // Preenche a linha horizontal
                            for (int x = xStart; x < xEnd; x++) // Usa '< xEnd' para preencher até xEnd-1
                            {
                                int byteIndex = y * stride + x * bytesPerPixel;
                                // Verificação de limites para segurança
                                if (byteIndex >= 0 && byteIndex + bytesPerPixel <= byteCount)
                                {
                                    // Copia os bytes da cor para o array de pixels
                                    Buffer.BlockCopy(colorBytes, 0, pixels, byteIndex, bytesPerPixel);
                                }
                            }
                        }
                    }

                    // e. Atualiza XCurrent para a próxima scanline (y+1)
                    foreach (var edge in activeEdgeTable)
                    {
                        edge.XCurrent += edge.InverseSlope;
                    }
                }

                // 5. Copia os dados de volta para o bitmap
                Marshal.Copy(pixels, 0, ptr, byteCount);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro durante Scanline Fill: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Erro no Scanline: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 6. UnlockBits SEMPRE!
                if (bmpData != null)
                {
                    drawingBitmap.UnlockBits(bmpData);
                }
            }
        }

    } // Fim da classe frmPoligonosTransformacoes
}