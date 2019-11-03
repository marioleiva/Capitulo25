using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyWin_Lab24
{
    public class Profesor
    {
        private int  mintId;
        private String mvarNombre;
        private String mvarApellidos;

        public int Id
        {
            get { return mintId; }
            set { mintId = value; }
        }
        public String Nombre
        {
            get { return mvarNombre; }
            set { mvarNombre = value; }
        }

        public String Apellidos
        {
            get { return mvarApellidos; }
            set { mvarApellidos = value; }
        }


    }
}
