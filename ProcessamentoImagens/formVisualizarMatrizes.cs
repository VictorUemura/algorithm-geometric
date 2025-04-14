using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessamentoImagens
{
    public partial class frmVisualizarMatrizes : Form
    {
        private readonly List<Poligono> _listaPoligonos;

        public frmVisualizarMatrizes(List<Poligono> poligonos)
        {
            InitializeComponent();
            _listaPoligonos = poligonos ?? new List<Poligono>();
        }

        private void frmVisualizarMatrizes_Load(object sender, EventArgs e)
        {
            ExibirMatrizes();
        }

        private void ExibirMatrizes()
        {
            StringBuilder sb = new StringBuilder();

            if (_listaPoligonos.Count == 0)
            {
                sb.AppendLine("Nenhum polígono foi criado ainda.");
            }
            else
            {
                for (int i = 0; i < _listaPoligonos.Count; i++)
                {
                    Poligono poly = _listaPoligonos[i];
                    Matrix m = poly.MatrizAcumulada;
                    float[] elements = m.Elements;

                    sb.AppendLine($"--- Polígono P{i + 1} ---");
                    sb.AppendLine("Matriz Acumulada (Formato 3x3):");
                    sb.AppendLine($"[ {elements[0]:F3}".PadRight(10) + $"{elements[2]:F3}".PadRight(10) + $"{elements[4]:F3}".PadRight(10) + " ]");
                    sb.AppendLine($"[ {elements[1]:F3}".PadRight(10) + $"{elements[3]:F3}".PadRight(10) + $"{elements[5]:F3}".PadRight(10) + " ]");
                    sb.AppendLine($"[ {"0.000"}".PadRight(10) + $"{"0.000"}".PadRight(10) + $"{"1.000"}".PadRight(10) + " ]");
                    sb.AppendLine(); 
                    sb.AppendLine($"Elementos Brutos: [{string.Join(", ", elements.Select(el => el.ToString("F3")))}]");
                    sb.AppendLine("--------------------");
                    sb.AppendLine();
                }
            }

            richTextBoxMatrizes.Text = sb.ToString();
        }
    }
}   