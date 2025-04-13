using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Diagnostics; // Para Debug

namespace ProcessamentoImagens // Certifique-se que o namespace está correto
{
    public class Poligono
    {
        public List<Point> ListaVerticesOriginais { get; private set; }
        public Matrix MatrizAcumulada { get; private set; }
        public List<Point> ListaVerticesAtuais { get; private set; }
        public float CurrentReflectX { get; private set; } = 1f;
        public float CurrentReflectY { get; private set; } = 1f;

        public Poligono(List<Point> verticesOriginais)
        {
            if (verticesOriginais == null || verticesOriginais.Count < 3) { throw new ArgumentException("Um polígono deve ter pelo menos 3 vértices."); }
            ListaVerticesOriginais = new List<Point>(verticesOriginais);
            MatrizAcumulada = new Matrix();
            ListaVerticesAtuais = new List<Point>(verticesOriginais);
            CurrentReflectX = 1f; CurrentReflectY = 1f;
            UpdateVerticesAtuais();
        }

        public void UpdateVerticesAtuais()
        {
            if (ListaVerticesOriginais.Count == 0) { ListaVerticesAtuais = new List<Point>(); return; }
            PointF[] temp = ListaVerticesOriginais.Select(p => new PointF(p.X, p.Y)).ToArray();
            MatrizAcumulada.TransformPoints(temp);
            ListaVerticesAtuais = temp.Select(pf => Point.Round(pf)).ToList();
        }

        public PointF CalculateCurrentCentroid()
        {
            if (ListaVerticesAtuais == null || ListaVerticesAtuais.Count == 0) return PointF.Empty;
            double accumulatedArea = 0.0; double centerX = 0.0; double centerY = 0.0;
            for (int i = 0, j = ListaVerticesAtuais.Count - 1; i < ListaVerticesAtuais.Count; j = i++) { double temp = (double)ListaVerticesAtuais[i].X * ListaVerticesAtuais[j].Y - (double)ListaVerticesAtuais[j].X * ListaVerticesAtuais[i].Y; accumulatedArea += temp; centerX += (ListaVerticesAtuais[i].X + ListaVerticesAtuais[j].X) * temp; centerY += (ListaVerticesAtuais[i].Y + ListaVerticesAtuais[j].Y) * temp; }
            if (Math.Abs(accumulatedArea) < 1E-7) return new PointF((float)ListaVerticesAtuais.Average(p => p.X), (float)ListaVerticesAtuais.Average(p => p.Y));
            accumulatedArea *= 3.0; return new PointF((float)(centerX / accumulatedArea), (float)(centerY / accumulatedArea));
        }

        // --- MÉTODO RENOMEADO AQUI ---
        // Reseta a matriz para identidade
        public void ResetMatrix()
        {
            MatrizAcumulada.Reset();
            // O estado de reflexão (CurrentReflectX/Y) NÃO é resetado aqui,
            // pois a reconstrução da matriz usará esses valores.
        }

        // --- Métodos para MODIFICAR O ESTADO da reflexão ---
        public void ToggleReflectionX() { CurrentReflectX *= -1; }
        public void ToggleReflectionY() { CurrentReflectY *= -1; }
        public void ToggleReflectionOrigin() { CurrentReflectX *= -1; CurrentReflectY *= -1; }

        // --- Métodos para APLICAR Transformações à Matriz Acumulada ---
        private void ApplyTransform(Matrix transform, MatrixOrder order = MatrixOrder.Append) { MatrizAcumulada.Multiply(transform, order); }
        public void Translate(float dx, float dy, MatrixOrder order = MatrixOrder.Append) { MatrizAcumulada.Translate(dx, dy, order); }
        public void Scale(float sx, float sy, PointF center, MatrixOrder order = MatrixOrder.Append) { Matrix m = new Matrix(); m.Translate(center.X, center.Y); m.Scale(sx, sy); m.Translate(-center.X, -center.Y); ApplyTransform(m, order); }
        public void Rotate(float angle, PointF center, MatrixOrder order = MatrixOrder.Append) { Matrix m = new Matrix(); m.Translate(center.X, center.Y); m.Rotate(angle); m.Translate(-center.X, -center.Y); ApplyTransform(m, order); }
        public void Shear(float shx, float shy, PointF center, MatrixOrder order = MatrixOrder.Append) { Matrix m = new Matrix(); m.Translate(center.X, center.Y); m.Shear(shx, shy); m.Translate(-center.X, -center.Y); ApplyTransform(m, order); }
        // Método para aplicar a matriz de reflexão durante a reconstrução
        public void ApplyReflectionMatrix(float reflectScaleX, float reflectScaleY, PointF center, MatrixOrder order = MatrixOrder.Append) { Matrix m = new Matrix(); m.Translate(center.X, center.Y); m.Scale(reflectScaleX, reflectScaleY); m.Translate(-center.X, -center.Y); ApplyTransform(m, order); }
    }
}