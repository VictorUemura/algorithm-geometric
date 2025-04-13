// frmPrincipal.cs
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ProcessamentoImagens.Graficos;

namespace ProcessamentoImagens 
{
    public partial class frmPrincipal : Form
    {
        // --- Enums ---
        private enum ShapeType { None, Line, Circle, Ellipse }

        // --- Variáveis de Estado ---
        private ShapeType currentShape = ShapeType.None;
        private Point? firstPoint = null;
        private Bitmap drawingBitmap;
        private Graphics bitmapGraphics;
        private bool isDrawing = false;

        // --- Construtor ---
        public frmPrincipal()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        // --- Eventos de Ciclo de Vida do Formulário ---
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            SetupDrawingArea();
            UpdateAlgorithmGroupBoxes();
            UpdateStatusLabel();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            bitmapGraphics?.Dispose();
            drawingBitmap?.Dispose();
        }

        // --- Configuração da Área de Desenho ---
        private void SetupDrawingArea()
        {
            Control drawingSurface = this.drawingPanel; // Ou this.pictBoxImg1
            if (drawingSurface == null) { /* Tratamento de erro */ return; }

            int width = Math.Max(1, drawingSurface.ClientSize.Width);
            int height = Math.Max(1, drawingSurface.ClientSize.Height);
            drawingBitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bitmapGraphics = Graphics.FromImage(drawingBitmap);
            bitmapGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            bitmapGraphics.Clear(Color.White);
            drawingSurface.BackgroundImage = drawingBitmap;
            drawingSurface.BackgroundImageLayout = ImageLayout.None;

            drawingSurface.Resize += DrawingSurface_Resize; // Associa o evento Resize
        }

        // --- Tratador de Evento de Redimensionamento ---
        private void DrawingSurface_Resize(object sender, EventArgs e)
        {
            Control surface = sender as Control;
            if (surface != null && surface.ClientSize.Width > 0 && surface.ClientSize.Height > 0)
            {
                if (drawingBitmap == null || drawingBitmap.Width != surface.ClientSize.Width || drawingBitmap.Height != surface.ClientSize.Height)
                {
                    Bitmap oldBitmap = drawingBitmap;
                    Graphics oldGraphics = bitmapGraphics;

                    drawingBitmap = new Bitmap(surface.ClientSize.Width, surface.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    bitmapGraphics = Graphics.FromImage(drawingBitmap);
                    bitmapGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    bitmapGraphics.Clear(Color.White);
                    surface.BackgroundImage = drawingBitmap;

                    oldGraphics?.Dispose();
                    oldBitmap?.Dispose();
                    surface.Invalidate();
                    firstPoint = null;
                    UpdateStatusLabel();
                }
            }
        }

        // --- Tratadores de Evento da UI ---
        private void chkLinha_CheckedChanged(object sender, EventArgs e) => HandleShapeSelection(chkLinha, ShapeType.Line);
        private void chkCircunferencia_CheckedChanged(object sender, EventArgs e) => HandleShapeSelection(chkCircunferencia, ShapeType.Circle);
        private void chkElipse_CheckedChanged(object sender, EventArgs e) => HandleShapeSelection(chkElipse, ShapeType.Ellipse);

        private void drawingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDrawing) return;
            if (currentShape == ShapeType.None)
            {
                MessageBox.Show("Selecione uma forma.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (firstPoint == null)
            {
                firstPoint = e.Location;
                UpdateStatusLabel($"Primeiro ponto: {firstPoint.Value}. Clique no segundo ponto.");
            }
            else
            {
                Point secondPoint = e.Location;
                isDrawing = true;
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                try
                {
                    // *** A MÁGICA ACONTECE AQUI ***
                    DrawSelectedShape(firstPoint.Value, secondPoint);
                    (sender as Control)?.Invalidate(); // Atualiza a área de desenho
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao desenhar: {ex.Message}\n{ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    firstPoint = null;
                    isDrawing = false;
                    Cursor = Cursors.Default;
                    UpdateStatusLabel();
                }
            }
        }

        private void btnAbrirPoligonos_Click(object sender, EventArgs e)
        {
            // Cria uma instância do novo formulário
            frmPoligonosTransformacoes formPoligonos = new frmPoligonosTransformacoes();
            // Mostra o formulário de forma não modal (ou modal se preferir com ShowDialog())
            formPoligonos.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (bitmapGraphics != null)
            {
                bitmapGraphics.Clear(Color.White);
                firstPoint = null;
                Control drawingSurface = this.drawingPanel; // Ou this.pictBoxImg1
                drawingSurface?.Invalidate();
                UpdateStatusLabel();
            }
        }

        // --- Métodos Auxiliares da UI ---
        private void HandleShapeSelection(CheckBox selectedCheckbox, ShapeType shape)
        {
            if (selectedCheckbox.Checked)
            {
                if (currentShape != shape)
                {
                    currentShape = shape;
                    firstPoint = null;

                    foreach (CheckBox c in groupBoxShape.Controls.OfType<CheckBox>().Where(chk => chk != selectedCheckbox))
                    {
                        c.Checked = false; // Agora 'c' é do tipo CheckBox e tem a propriedade 'Checked'
                    }
                    UpdateStatusLabel();
                }
            }
            else if (currentShape == shape)
            {
                currentShape = ShapeType.None;
                firstPoint = null;
                UpdateStatusLabel();
            }
            UpdateAlgorithmGroupBoxes();
        }

        private void UpdateAlgorithmGroupBoxes()
        {
            groupBoxLinhaAlg.Enabled = (currentShape == ShapeType.Line);
            groupBoxCirculoAlg.Enabled = (currentShape == ShapeType.Circle);
            groupBoxElipseAlg.Enabled = (currentShape == ShapeType.Ellipse);
        }

        private void UpdateStatusLabel(string message = null)
        {
            if (lblStatus == null) return; // Se não houver label de status
            lblStatus.Text = message ?? (currentShape == ShapeType.None ? "Selecione uma forma para desenhar." : $"Forma: {currentShape}. Clique no primeiro ponto.");
        }

        // --- Método Principal de Desenho (Dispatcher) ---
        private void DrawSelectedShape(Point p1, Point p2)
        {
            // Usa o Graphics e Bitmap que são membros da classe
            if (bitmapGraphics == null || drawingBitmap == null) return;
            Color drawColor = Color.DodgerBlue; // Escolha uma cor

            // Instancia a classe de algoritmo necessária
            switch (currentShape)
            {
                case ShapeType.Line:
                    var retaDrawer = new Reta(bitmapGraphics, drawingBitmap, drawColor);
                    if (rbLinhaEqReal.Checked) retaDrawer.DesenharRetaReal(p1, p2);
                    else if (rbLinhaDDA.Checked) retaDrawer.DesenharRetaDDA(p1, p2);
                    else if (rbLinhaPontoMedio.Checked) retaDrawer.DesenharRetaPontoMedio(p1, p2);
                    break;

                case ShapeType.Circle:
                    int radius = (int)Math.Round(Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)));
                    if (radius <= 0) return;
                    var circuloDrawer = new Circulo(bitmapGraphics, drawingBitmap, drawColor);
                    if (rbCirculoEqReal.Checked) circuloDrawer.DesenharCirculoReal(p1, radius);
                    else if (rbCirculoTrigonometria.Checked) circuloDrawer.DesenharCirculoTrigonometria(p1, radius);
                    else if (rbCirculoPontoMedio.Checked) circuloDrawer.DesenharCirculoPontoMedio(p1, radius);
                    break;

                case ShapeType.Ellipse:
                    int rx = Math.Abs(p2.X - p1.X);
                    int ry = Math.Abs(p2.Y - p1.Y);
                    if (rx <= 0 || ry <= 0) return;
                    var elipseDrawer = new Elipse(bitmapGraphics, drawingBitmap, drawColor);
                    if (rbElipsePontoMedio.Checked) elipseDrawer.DesenharElipsePontoMedio(p1, rx, ry);
                    break;
            }
        }

    }
}