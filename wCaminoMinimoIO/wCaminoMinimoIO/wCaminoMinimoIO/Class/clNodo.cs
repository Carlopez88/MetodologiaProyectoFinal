using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wCaminoMinimoIO.Class
{
    public class clNodo
    {
        #region VARIABLES
        public string Nombre { get; set; }
        public bool Evaluado { get; set; }
        public string Antecesor { get; set; }
        public string Predecesor { get; set; }
        public int ValorTemporal { get; set; }
        public int ValorFinal { get; set; }

        public string NodoInicial { get; set; }
        public string NodoFinal { get; set; }
        #endregion

        public string AsignarPuntoPartida()
        {
            return "Punto de Partida: " + NodoInicial;
        }
        public string AsignarPuntoLlegada()
        {
            return "Punto de Llegada: " + NodoFinal;
        }
    }
}
