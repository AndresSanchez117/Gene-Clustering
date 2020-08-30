using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProyectoFinal_ExpresionGenetica
{
    class Graph
    {
        List<Vertex> vL;

        public Graph()
        {
            vL = new List<Vertex>();
        }
        public Graph(List<Circle> cL, Bitmap bmp)
        {
            vL = new List<Vertex>();

            foreach (Circle c in cL)
                vL.Add(new Vertex(c, vL.Count));

            for (int i = 0; i < vL.Count; i++)
            {
                for (int j = i + 1; j < vL.Count; j++)
                {
                    if (AreAdjacent(vL[j], vL[i], bmp))
                    {
                        float x0 = vL[i].GetData().X;
                        float y0 = vL[i].GetData().Y;
                        float xf = vL[j].GetData().X;
                        float yf = vL[j].GetData().Y;

                        // Distancia Euclidiana
                        float fWeight = (float)Math.Sqrt((x0 - xf) * (x0 - xf) + (y0 - yf) * (y0 - yf));

                        Edge e1 = new Edge(vL[j], vL[i], fWeight);
                        Edge e2 = new Edge(vL[i], vL[j], fWeight);
                        vL[i].AddEdge(e1);
                        vL[j].AddEdge(e2);
                    }
                }
            }
        }

        public Graph(List<Edge> edgesList)
        {
            // ITERAR POR CADA ARISTA Y AGREGAR A vL SU
            // ORIGEN Y DESTINO ANTES PREGUNTADOSE SI 
            // LOS VERTICES ORIGEN Y DESTINO YA EXISTEN EN vL
            vL = new List<Vertex>();

            List<Vertex> verticesAgregados = new List<Vertex>();

            foreach (Edge arista in edgesList)
            {
                Vertex origen = arista.GetOrigin();
                Vertex destino = arista.GetDestination();

                if (!verticesAgregados.Contains(origen))
                {
                    verticesAgregados.Add(origen);
                    vL.Add(new Vertex(origen.GetData(), origen.GetID()));
                }
                if (!verticesAgregados.Contains(destino))
                {
                    verticesAgregados.Add(destino);
                    vL.Add(new Vertex(destino.GetData(), destino.GetID()));
                }

                // Se agrega adyacencia
                float fWeight = arista.GetWeight();

                // Para agregar la adyacencia hay que obtener un vertice origen
                // y un vertice destino
                // El vertice origen sera el vertice de vL que coincida su id
                // con el vertice origen declarado al principio
                Vertex nuevoOrigen = null;
                Vertex nuevoDestino = null;
                foreach (Vertex vertice in vL)
                {
                    if (origen.GetID() == vertice.GetID())
                        nuevoOrigen = vertice;
                    else if (destino.GetID() == vertice.GetID())
                        nuevoDestino = vertice;
                }

                Edge e1 = new Edge(nuevoDestino, nuevoOrigen, fWeight);
                Edge e2 = new Edge(nuevoOrigen, nuevoDestino, fWeight);
                nuevoOrigen.AddEdge(e1);
                nuevoDestino.AddEdge(e2);
            }

            //vL.Sort();
        }

        public int GetVertexCount()
        {
            return vL.Count;
        }

        public Vertex GetVertex(int i)
        {
            return vL[i];
        }

        public int GetVertexPos(Vertex v)
        {
            for (int i = 0; i < vL.Count; i++)
            {
                if (vL[i] == v)
                    return i;
            }
            return -1;
        }

        public void AddVertex(Vertex v)
        {
            vL.Add(v);
        }

        public bool ContainsVertex(Vertex v)
        {
            return vL.Contains(v);
        }

        bool AreAdjacent(Vertex v1, Vertex v2, Bitmap bmp)
        {
            // Determina si dos vértices son adyacentes en una imágen (No hay obstáculos entre ellos)
            float x1 = v1.GetData().X;
            float y1 = v1.GetData().Y;
            float x2 = v2.GetData().X;
            float y2 = v2.GetData().Y;

            bool bFlagFirst = false;
            bool bFlagSecond = false;

            float dx = x2 - x1;
            float dy = y2 - y1;
            float step;

            if (Math.Abs(dx) >= Math.Abs(dy))
                step = Math.Abs(dx);
            else
                step = Math.Abs(dy);

            dx /= step;
            dy /= step;

            float x;
            float y;

            x = x1;
            y = y1;

            for (int i = 0; i < step; i++)
            {
                Color color = bmp.GetPixel((int)Math.Round(x), (int)Math.Round(y));

                if (bFlagSecond && color.R == 255 && color.G == 255 && color.B == 255)
                {
                    return false;
                }
                else if (bFlagFirst && color.G != 255) // No funciona con obstaculos 255 en G (Verdes)
                {
                    bFlagSecond = true;
                }
                else if (!bFlagFirst && color.R == 255 && color.G == 255 && color.B == 255)
                {
                    bFlagFirst = true;
                }

                x += dx;
                y += dy;
            }

            return true;
        }
    }
}
