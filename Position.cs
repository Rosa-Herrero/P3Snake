using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Snake
{
    struct Position
    {
        //PENDENT IMPLEMENTAR



        public override bool Equals(object obj)
        {
            // comprovem que no sigui null
            if (obj == null)
                return false;
            // comprovem que sigui una variable d'aquesta estructura
            if (!(obj is Position))
                return false;
            // fem un CAST per guardar dins d'una variable d'aquesta estructura
            Position pos = (Position)obj;
            return this == pos;
        }

        public override int GetHashCode()
        {
            return this.row * 10000 + this.col;
        }
    }
}
