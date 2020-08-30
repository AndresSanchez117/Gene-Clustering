using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ExpresionGenetica
{
    class Edge : IComparable<Edge>
    {
        Vertex destination;
        Vertex origin;
        float fWeight;

        public Edge(Vertex dest, Vertex ori, float w)
        {
            origin = ori;
            destination = dest;
            fWeight = w;
        }

        public Vertex GetOrigin()
        {
            return origin;
        }

        public Vertex GetDestination()
        {
            return destination;
        }

        public float GetWeight()
        {
            return fWeight;
        }

        public int CompareTo(Edge other)
        {
            if (this.fWeight < other.fWeight)
                return -1;
            else if (this.fWeight > other.fWeight)
                return 1;
            else
                return 0;
        }

        public override string ToString()
        {
            return "Origen: " + origin.GetID() + ", Destino: " + destination.GetID();
        }
    }
}
