using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Diagnostics; // Para Debug

namespace ProcessamentoImagens
{
    public class Poligono
    {
        // Propriedades existentes
        public List<Point> ListaVerticesOriginais { get; private set; }
        public Matrix MatrizAcumulada { get; private set; }
        public List<Point> ListaVerticesAtuais { get; private set; }

        // Estado da reflexão em torno do EIXO/CENTROIDE ORIGINAL (existente)
        public float CurrentReflectX { get; private set; } = 1f;
        public float CurrentReflectY { get; private set; } = 1f;

        // Estado da reflexão em torno do CENTRO DO PAINEL
        public float CenterReflectX { get; private set; } = 1f;
        public float CenterReflectY { get; private set; } = 1f;

        public Poligono(List<Point> verticesOriginais)
        {
            if (verticesOriginais == null || verticesOriginais.Count < 3) { throw new ArgumentException("Um polígono deve ter pelo menos 3 vértices."); }
            ListaVerticesOriginais = new List<Point>(verticesOriginais);
            MatrizAcumulada = new Matrix();
            ListaVerticesAtuais = new List<Point>(verticesOriginais);
            CurrentReflectX = 1f; CurrentReflectY = 1f;
            CenterReflectX = 1f; CenterReflectY = 1f;
            UpdateVerticesAtuais();
        }

        public void UpdateVerticesAtuais()
        {
            if (ListaVerticesOriginais.Count == 0) { ListaVerticesAtuais = new List<Point>(); return; }
            PointF[] temp = ListaVerticesOriginais.Select(p => new PointF(p.X, p.Y)).ToArray();
            try
            {
                if (MatrizAcumulada.IsInvertible)
                {
                    MatrizAcumulada.TransformPoints(temp);
                }
                else
                {
                    Debug.WriteLine("Aviso: Matriz de transformação não é invertível. Vértices atuais podem não ser calculados corretamente.");
                    // Mantem os pontos como estavam antes da transformação falha.
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao transformar pontos: {ex.Message}");
            }
            ListaVerticesAtuais = temp.Select(pf => Point.Round(pf)).ToList();
        }

        // Calcula o centroide dos vértices ATUAIS
        public PointF CalculateCurrentCentroid()
        {
            if (ListaVerticesAtuais == null || ListaVerticesAtuais.Count == 0) return PointF.Empty;

            // >>>>>>>> VERIFIQUE AQUI: Declaração de centerY <<<<<<<<<<
            double accumulatedArea = 0.0; double centerX = 0.0; double centerY = 0.0;

            for (int i = 0, j = ListaVerticesAtuais.Count - 1; i < ListaVerticesAtuais.Count; j = i++)
            {
                if (float.IsNaN(ListaVerticesAtuais[i].X) || float.IsInfinity(ListaVerticesAtuais[i].X) ||
                    float.IsNaN(ListaVerticesAtuais[i].Y) || float.IsInfinity(ListaVerticesAtuais[i].Y) ||
                    float.IsNaN(ListaVerticesAtuais[j].X) || float.IsInfinity(ListaVerticesAtuais[j].X) ||
                    float.IsNaN(ListaVerticesAtuais[j].Y) || float.IsInfinity(ListaVerticesAtuais[j].Y))
                {
                    Debug.WriteLine("Aviso: Vértices inválidos encontrados ao calcular centroide atual.");
                    return PointF.Empty;
                }
                double temp = (double)ListaVerticesAtuais[i].X * ListaVerticesAtuais[j].Y - (double)ListaVerticesAtuais[j].X * ListaVerticesAtuais[i].Y;
                accumulatedArea += temp;
                centerX += (ListaVerticesAtuais[i].X + ListaVerticesAtuais[j].X) * temp;
                // >>>>>>>> VERIFIQUE AQUI: Uso de centerY <<<<<<<<<<
                centerY += (ListaVerticesAtuais[i].Y + ListaVerticesAtuais[j].Y) * temp;
            }
            if (Math.Abs(accumulatedArea) < 1E-7)
            {
                // Evita NaN se todos os pontos forem iguais ou colineares e a média for calculada
                if (!ListaVerticesAtuais.Any()) return PointF.Empty;
                return new PointF((float)ListaVerticesAtuais.Average(p => p.X), (float)ListaVerticesAtuais.Average(p => p.Y));
            }

            accumulatedArea *= 3.0;

            // >>>>>>>> VERIFIQUE AQUI: Uso de centerY <<<<<<<<<<
            if (Math.Abs(accumulatedArea) < 1E-7 || double.IsNaN(centerX / accumulatedArea) || double.IsNaN(centerY / accumulatedArea) || double.IsInfinity(centerX / accumulatedArea) || double.IsInfinity(centerY / accumulatedArea))
            {
                Debug.WriteLine("Aviso: Divisão por zero ou resultado inválido/infinito ao calcular centroide atual.");
                // Fallback mais seguro
                if (!ListaVerticesAtuais.Any()) return PointF.Empty;
                return new PointF((float)ListaVerticesAtuais.Average(p => p.X), (float)ListaVerticesAtuais.Average(p => p.Y));
            }
            // >>>>>>>> VERIFIQUE AQUI: Uso de centerY <<<<<<<<<<
            return new PointF((float)(centerX / accumulatedArea), (float)(centerY / accumulatedArea));
        }


        public void ResetMatrix() { MatrizAcumulada.Reset(); }
        public void ToggleReflectionX() { CurrentReflectX *= -1; }
        public void ToggleReflectionY() { CurrentReflectY *= -1; }
        public void ToggleReflectionOrigin() { CurrentReflectX *= -1; CurrentReflectY *= -1; }
        public void ToggleCenterReflectionX() { CenterReflectX *= -1; }
        public void ToggleCenterReflectionY() { CenterReflectY *= -1; }
        public void ToggleCenterReflectionOrigin() { CenterReflectX *= -1; CenterReflectY *= -1; }
        public void ResetCenterReflectionState() { CenterReflectX = 1f; CenterReflectY = 1f; }
        public void ResetAxisReflectionState() { CurrentReflectX = 1f; CurrentReflectY = 1f; }

        private void ApplyTransform(Matrix transform, MatrixOrder order = MatrixOrder.Append)
        { if (transform != null && transform.IsInvertible) { MatrizAcumulada.Multiply(transform, order); } else { Debug.WriteLine("Aviso: Tentativa de aplicar matriz de transformação nula ou não invertível."); } }
        public void Translate(float dx, float dy, MatrixOrder order = MatrixOrder.Append)
        { if (float.IsNaN(dx) || float.IsInfinity(dx) || float.IsNaN(dy) || float.IsInfinity(dy)) return; MatrizAcumulada.Translate(dx, dy, order); }
        public void Scale(float sx, float sy, PointF center, MatrixOrder order = MatrixOrder.Append)
        { if (Math.Abs(sx) < 1E-7 || Math.Abs(sy) < 1E-7) return; if (float.IsNaN(sx) || float.IsInfinity(sx) || float.IsNaN(sy) || float.IsInfinity(sy)) return; Matrix m = new Matrix(); m.Translate(center.X, center.Y); m.Scale(sx, sy); m.Translate(-center.X, -center.Y); ApplyTransform(m, order); }
        public void Rotate(float angle, PointF center, MatrixOrder order = MatrixOrder.Append)
        { if (float.IsNaN(angle) || float.IsInfinity(angle)) return; Matrix m = new Matrix(); m.Translate(center.X, center.Y); m.Rotate(angle); m.Translate(-center.X, -center.Y); ApplyTransform(m, order); }
        public void Shear(float shx, float shy, PointF center, MatrixOrder order = MatrixOrder.Append)
        { if (float.IsNaN(shx) || float.IsInfinity(shx) || float.IsNaN(shy) || float.IsInfinity(shy)) return; if (Math.Abs(1.0f - shx * shy) < 1E-7) { Debug.WriteLine("Aviso: Cisalhamento não invertível."); return; } Matrix m = new Matrix(); m.Translate(center.X, center.Y); m.Shear(shx, shy); m.Translate(-center.X, -center.Y); ApplyTransform(m, order); }
        public void ApplyReflectionMatrix(float reflectScaleX, float reflectScaleY, PointF center, MatrixOrder order = MatrixOrder.Append)
        { if (float.IsNaN(reflectScaleX) || float.IsInfinity(reflectScaleX) || float.IsNaN(reflectScaleY) || float.IsInfinity(reflectScaleY)) return; Matrix m = new Matrix(); m.Translate(center.X, center.Y); m.Scale(reflectScaleX, reflectScaleY); m.Translate(-center.X, -center.Y); ApplyTransform(m, order); }
    }
}