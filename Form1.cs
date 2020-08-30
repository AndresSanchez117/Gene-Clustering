using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ExpresionGenetica
{
    public partial class Form1 : Form
    {
        Bitmap bmpGraph;
        Bitmap bmpTree;
        Graph graph;
        List<Circle> circleList;
        // Para Kruskal
        float fKruskalCost;
        List<Edge> kruskalEdges;
        Graph kruskalTree;
        bool[] visited;
        PriorityQueue<Edge> pq;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Se carga una imagen
            openFileDialogImage.ShowDialog();
            Image imagen = Image.FromFile(openFileDialogImage.FileName);
            pictureBoxImage.Image = imagen;
            buttonGenerateGraph.Enabled = true;
        }

        private void buttonGenerateGraph_Click(object sender, EventArgs e)
        {
            circleList = new List<Circle>();

            Bitmap bmpAnalize = new Bitmap(openFileDialogImage.FileName);
            bmpGraph = new Bitmap(bmpAnalize);

            // Encontrando los circulos de la imagen
            for (int i = 0; i < bmpAnalize.Height; i++)
            {
                for (int j = 0; j < bmpAnalize.Width; j++)
                {
                    Color col = bmpAnalize.GetPixel(j, i);
                    if (col.R == 0 && col.G == 0 && col.B == 0)
                    {
                        if (IsInCircle(j, i, circleList))
                            circleList.Add(FindCenter(j, i, bmpAnalize));
                    }
                }
            }

            // Creación de grafo
            graph = new Graph(circleList, bmpAnalize);

            // Se dibuja el grafo
            DrawGraph();
            DrawIdentifiers(circleList, bmpGraph);

            // Se muestra la información del grafo
            treeViewGraph.BeginUpdate();
            treeViewGraph.Nodes.Clear();
            for (int i = 0; i < graph.GetVertexCount(); i++)
            {
                Vertex origin = graph.GetVertex(i);
                treeViewGraph.Nodes.Add("Vertice " + origin.GetID().ToString());
                for (int j = 0; j < origin.Degree(); j++)
                {
                    Vertex d = origin.GetEdge(j).GetDestination();
                    float fWeigth = origin.GetEdge(j).GetWeight();
                    treeViewGraph.Nodes[i].Nodes.Add("Distancia a vertice " + d.GetID().ToString() + ": " + fWeigth.ToString());
                }
            }
            treeViewGraph.EndUpdate();

            buttonCluster.Enabled = true;
        }

        private void buttonCluster_Click(object sender, EventArgs e)
        {
            FormClusterInfo formClusterInfo = new FormClusterInfo();

            while (!formClusterInfo.GetClosed() || formClusterInfo.GetK() > graph.GetVertexCount() || formClusterInfo.GetK() < 1)
                formClusterInfo.ShowDialog();

            int K = formClusterInfo.GetK();
            labelClusters.Text = "Grupos: " + K;

            // Se encuentran los aristas del ARM con el algoritmo de Prim
            Kruskal(K);

            // Se dibujan los ARM
            DrawTree();
            FindComponents();
            DrawIdentifiers(circleList, bmpTree);

            // Orden de seleccion de aristas Kruskal
            listBoxKruskalEdges.BeginUpdate();
            listBoxKruskalEdges.Items.Clear();
            int iEdgeId = 1;
            foreach (Edge edge in kruskalEdges)
            {
                listBoxKruskalEdges.Items.Add(iEdgeId + ". " + edge.ToString());
                iEdgeId++;
            }
            listBoxKruskalEdges.EndUpdate();
        }

        void Kruskal(int K)
        {
            kruskalEdges = new List<Edge>();
            pq = new PriorityQueue<Edge>();

            fKruskalCost = 0;

            // Entran todos los aristas del grafo a la cola de prioridad
            visited = new bool[graph.GetVertexCount()];
            for (int i = 0; i < graph.GetVertexCount() - 1; i++)
                AddEdges(graph.GetVertex(i));

            // Inicializa componentes conexos
            List<List<Vertex>> componentesConexos = new List<List<Vertex>>();
            for (int i = 0; i < graph.GetVertexCount(); i++)
            {
                List<Vertex> componente = new List<Vertex>
                {
                    graph.GetVertex(i)
                };
                componentesConexos.Add(componente);
            }

            while (!pq.IsEmpty() && kruskalEdges.Count != graph.GetVertexCount() - K)
            {
                // Seleccion de arista con la cola de prioridad
                Edge edge = pq.Dequeue();

                List<Vertex> componente1 = null;
                List<Vertex> componente2 = null;

                // Busqueda de componentes conexos
                foreach (var componente in componentesConexos)
                {
                    if (componente.Contains(edge.GetOrigin()))
                        componente1 = componente;
                    if (componente.Contains(edge.GetDestination()))
                        componente2 = componente;
                }

                if (componente1 != componente2)
                {
                    // No pertenecen al mismo componente
                    kruskalEdges.Add(edge);
                    fKruskalCost += edge.GetWeight();

                    // Fusionar componentes
                    componente1.AddRange(componente2);
                    componentesConexos.Remove(componente2);
                }
            }

            kruskalTree = new Graph(kruskalEdges);
        }

        void FindComponents()
        {
            int n = kruskalTree.GetVertexCount();
            visited = new bool[n];

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    Brush brush = new SolidBrush(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                    DFS(i, brush);
                }
            }

            pictureBoxImage.Image = bmpTree;
        }

        void DFS(int at, Brush brush)
        {
            Graphics gra = Graphics.FromImage(bmpTree);
            visited[at] = true;

            // Colorear vertice
            Circle vertexCircle = kruskalTree.GetVertex(at).GetData();
            int r = (int)Math.Round(vertexCircle.Radius);
            int x = (int)Math.Round(vertexCircle.X);
            int y = (int)Math.Round(vertexCircle.Y);
            gra.FillEllipse(brush, x - r - 5, y - r - 5, 2 * (r + 5), 2 * (r + 5));

            List<Edge> vecinos = kruskalTree.GetVertex(at).GetEdgesList();
            foreach (Edge e in vecinos)
            {
                if (!visited[kruskalTree.GetVertexPos(e.GetDestination())])
                    DFS(kruskalTree.GetVertexPos(e.GetDestination()), brush);
            }
        }

        void AddEdges(Vertex v)
        {
            // Agrega aristas del vertice v a la cola de prioridad
            visited[v.GetID()] = true;

            List<Edge> aristas = v.GetEdgesList();
            foreach (Edge arista in aristas)
            {
                if (!visited[arista.GetDestination().GetID()])
                    pq.Enqueue(arista);
            }
        }

        bool IsInCircle(int x, int y, List<Circle> list)
        {
            // Determina si un punto (x, y) pertenece a un círculo (Vértice)
            if (list.Count == 0)
                return true;

            // Coordenadas centrales de cada circulo
            float x0;
            float y0;

            float xk = x;
            float yk = y;

            float radio;
            foreach (Circle c in list)
            {
                x0 = c.X;
                y0 = c.Y;
                radio = c.Radius + 5;
                float sol = (xk - x0) * (xk - x0) + (yk - y0) * (yk - y0) - radio * radio;
                if (sol < 0)
                    return false;
            }
            return true;
        }

        Circle FindCenter(int x, int y, Bitmap bmp)
        {
            /* Se obtienen coordenadas del centro a partir del punto
              superior izquierdo del círculo, No considera el ruido del círculo */
            int j = y;
            while (true)
            {
                Color col = bmp.GetPixel(x, j);
                if (col.R != 0 || col.G != 0 || col.B != 0)
                {
                    break;
                }
                j++;
            }
            j--; //Pixel no en circulo

            int i = x;
            while (true)
            {
                Color col = bmp.GetPixel(i, y);
                if (col.R != 0 || col.G != 0 || col.B != 0)
                {
                    break;
                }
                i++;
            }
            i--; //Pixel no en circulo

            float xCenter = ((i - x) / 2) + x;
            float yCenter = ((j - y) / 2) + y;
            float radius = (j - y) / 2;

            Circle circle = new Circle(xCenter, yCenter, radius);

            return circle;
        }

        void DrawGraph()
        {
            // Dibuja el grafo en pantalla

            Graphics gra = Graphics.FromImage(bmpGraph);
            Pen linePen = new Pen(Color.Black);

            for (int i = 0; i < graph.GetVertexCount(); i++)
            {
                Vertex origin = graph.GetVertex(i);
                for (int j = 0; j < origin.Degree(); j++)
                {
                    Vertex destination = origin.GetEdge(j).GetDestination();
                    // No funciona para lazos
                    if (destination.GetID() > i)
                    {
                        float x0 = origin.GetData().X;
                        float y0 = origin.GetData().Y;

                        float xf = destination.GetData().X;
                        float yf = destination.GetData().Y;

                        gra.DrawLine(linePen, x0, y0, xf, yf);
                    }
                }
            }

            pictureBoxImage.Image = bmpGraph;
        }

        void DrawIdentifiers(List<Circle> list, Bitmap bitmap)
        {
            // Dibuja identificadores de vértices en el grafo
            Graphics gra = Graphics.FromImage(bitmap);
            Font stringFont = new Font("Arial", 22);
            SolidBrush brush = new SolidBrush(Color.Red);
            StringFormat stringFormat = new StringFormat();

            int id = 0;

            foreach (Circle c in list)
            {
                gra.DrawString(id.ToString(), stringFont, brush, c.X, c.Y, stringFormat);
                id++;
            }
        }

        void DrawTree()
        {
            bmpTree = new Bitmap(openFileDialogImage.FileName);
            Graphics gra = Graphics.FromImage(bmpTree);
            Pen linePen = new Pen(Color.Black);

            foreach (Edge edge in kruskalEdges)
            {
                Vertex origin = edge.GetOrigin();
                Vertex destination = edge.GetDestination();

                float x0 = origin.GetData().X;
                float y0 = origin.GetData().Y;

                float xf = destination.GetData().X;
                float yf = destination.GetData().Y;

                gra.DrawLine(linePen, x0, y0, xf, yf);
            }

            pictureBoxImage.Image = bmpTree;
        }
    }
}
