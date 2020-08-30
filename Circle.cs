using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ExpresionGenetica
{
    class Circle
    {
        readonly float x;
        readonly float y;
        readonly float radius;

        public Circle(float x, float y, float radio)
        {
            this.radius = radio;
            this.x = x;
            this.y = y;
        }

        public float X => x;
        public float Y => y;
        public float Radius => radius;

        public override string ToString()
        {
            return "Centro: (" + x + "," + y + ") Radio: " + radius;
        }
    }
}
