using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ExpresionGenetica
{
    class Vertex
    {
        List<Edge> eL;
        Circle data;
        int id;

        public Vertex(Circle c, int id)
        {
            this.id = id;
            data = c;
            eL = new List<Edge>();
        }

        public int GetID()
        {
            return id;
        }

        public void AddEdge(Edge e)
        {
            eL.Add(e);
        }

        public Edge GetEdge(int i)
        {
            return eL[i];
        }

        public int Degree()
        {
            return eL.Count;
        }

        public Circle GetData()
        {
            return data;
        }

        public List<Edge> GetEdgesList()
        {
            return eL;
        }
    }
}
