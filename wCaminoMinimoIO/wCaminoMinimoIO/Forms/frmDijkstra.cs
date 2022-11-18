using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wCaminoMinimoIO.Class;

namespace wCaminoMinimoIO
{
    public partial class frmDijkstra : Form
    {
        public frmDijkstra()
        {
            InitializeComponent();

            this.Cafe.Enabled = true;
            this.Casita.Enabled = true;
            this.Mansion.Enabled = true;
            this.Tienda.Enabled = true;
            this.CasaPurpura.Enabled = true;
            this.CasaComercial.Enabled = true;
            this.CasaSol.Enabled = true;
            this.CasaSeria.Enabled = true;
            this.Policia.Enabled = true;
            this.CasaGris.Enabled = true;
            this.Encantada.Enabled = true;
            this.lblValida.Visible = false;
            this.lblPtoPartida.Visible = false;
            this.lblPtoLlegada.Visible = false;
            this.lblResultado.Visible = false;
            this.lblRuta.Visible = false;
        }

        #region ENUMERACIONES
        enum EnmVertices
        {
            Café_Rocher = 1,
            Casa_Paul = 2,
            Casa_Blanca = 3,
            Supermercado_Lina = 4,
            Casa_Linda = 5,
            Banco_Ayuda = 6,
            Hacienda_Frank = 7,
            CComercial_Shean = 8,
            Casa_Del_Sol = 9,
            Tronchatoro = 10,
            Estación_Policía = 11,
            Casa_Port = 12,
            Casa_Embrujada = 13
        }
        #endregion
        #region PROPIEDADES
        public static List<clArista> AristasMapa = new List<clArista>();
        public static List<clNodo> Nodos = new List<clNodo>
        {
            new clNodo { Nombre = "Café_Rocher", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Casa_Paul", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Casa_Blanca", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Supermercado_Lina", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Casa_Linda", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Banco_Ayuda", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Hacienda_Frank", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "CComercial_Shean", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Casa_Del_Sol", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Tronchatoro", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Estación_Policía", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Casa_Port", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
            new clNodo { Nombre = "Casa_Embrujada", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 }
        };
        public static List<clNodo> listNodoOrden = new List<clNodo>();
        public string nodoInicial = "";
        public string nodoFinal = "";
        #endregion  
        #region PRIVADOS
        private Boolean esValidoParaCalcular()
        {
            if (nodoInicial == "")
            {
                this.lblValida.Text = "Por Favor seleccione el punto de partida";
                this.lblValida.Visible = true;
                this.lblResultado.Visible = false;
                this.lblRuta.Visible = false;
                return false;
            }
            if (nodoFinal == "")
            {
                this.lblValida.Text = "Por Favor seleccione el punto de llegada";
                this.lblValida.Visible = true;
                this.lblResultado.Visible = false;
                this.lblRuta.Visible = false;
                return false;
            }
            else if (this.De1a12.Text.Trim().Length == 0 || this.De1a2.Text.Trim().Length == 0 || this.De2a11.Text.Trim().Length == 0 ||
                this.De2a3.Text.Trim().Length == 0 || this.De3a5.Text.Trim().Length == 0 || this.De3a6.Text.Trim().Length == 0 ||
                this.De4a8.Text.Trim().Length == 0 || this.De6a9.Text.Trim().Length == 0 || this.De6a4.Text.Trim().Length == 0 ||
                this.De6a8.Text.Trim().Length == 0 || this.De7a8.Text.Trim().Length == 0 || this.De10a9.Text.Trim().Length == 0 ||
                this.De11a10.Text.Trim().Length == 0 || this.De11a6.Text.Trim().Length == 0 || this.De11a9.Text.Trim().Length == 0 ||
                this.De12a11.Text.Trim().Length == 0 || this.De12a13.Text.Trim().Length == 0)
            {
                this.lblValida.Text = "Por Favor diligencie las distancias o esfuerzos";
                this.lblValida.Visible = true;
                this.lblResultado.Visible = false;
                this.lblRuta.Visible = false;
                return false;
            }

            this.lblValida.Visible = false;
            this.lblResultado.Visible = false;
            this.lblRuta.Visible = false;
            return true;
        }
        private void AsignarDistancia()
        {
            AristasMapa.Add(new clArista { NdInicial = "Café_Rocher", NdDestino = "Casa_Paul", Valor = Convert.ToInt32(this.De1a2.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Café_Rocher", NdDestino = "Casa_Port", Valor = Convert.ToInt32(this.De1a12.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Paul", NdDestino = "Café_Rocher", Valor = Convert.ToInt32(this.De1a2.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Paul", NdDestino = "Casa_Blanca", Valor = Convert.ToInt32(this.De2a3.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Paul", NdDestino = "Estación_Policía", Valor = Convert.ToInt32(this.De2a11.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Blanca", NdDestino = "Casa_Paul", Valor = Convert.ToInt32(this.De2a3.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Blanca", NdDestino = "Casa_Linda", Valor = Convert.ToInt32(this.De3a5.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Blanca", NdDestino = "Banco_Ayuda", Valor = Convert.ToInt32(this.De3a6.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Supermercado_Lina", NdDestino = "Banco_Ayuda", Valor = Convert.ToInt32(this.De6a4.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Supermercado_Lina", NdDestino = "CComercial_Shean", Valor = Convert.ToInt32(this.De4a8.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Linda", NdDestino = "Casa_Blanca", Valor = Convert.ToInt32(this.De3a5.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Banco_Ayuda", NdDestino = "Casa_Blanca", Valor = Convert.ToInt32(this.De3a6.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Banco_Ayuda", NdDestino = "Supermercado_Lina", Valor = Convert.ToInt32(this.De6a4.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Banco_Ayuda", NdDestino = "CComercial_Shean", Valor = Convert.ToInt32(this.De6a8.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Banco_Ayuda", NdDestino = "Casa_Del_Sol", Valor = Convert.ToInt32(this.De6a9.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Banco_Ayuda", NdDestino = "Estación_Policía", Valor = Convert.ToInt32(this.De11a6.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Hacienda_Frank", NdDestino = "CComercial_Shean", Valor = Convert.ToInt32(this.De7a8.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "CComercial_Shean", NdDestino = "Supermercado_Lina", Valor = Convert.ToInt32(this.De4a8.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "CComercial_Shean", NdDestino = "Banco_Ayuda", Valor = Convert.ToInt32(this.De6a8.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "CComercial_Shean", NdDestino = "Hacienda_Frank", Valor = Convert.ToInt32(this.De7a8.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Del_Sol", NdDestino = "Banco_Ayuda", Valor = Convert.ToInt32(this.De6a9.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Del_Sol", NdDestino = "Tronchatoro", Valor = Convert.ToInt32(this.De10a9.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Del_Sol", NdDestino = "Estación_Policía", Valor = Convert.ToInt32(this.De11a9.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Tronchatoro", NdDestino = "Casa_Del_Sol", Valor = Convert.ToInt32(this.De10a9.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Tronchatoro", NdDestino = "Estación_Policía", Valor = Convert.ToInt32(this.De11a10.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Estación_Policía", NdDestino = "Casa_Paul", Valor = Convert.ToInt32(this.De2a11.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Estación_Policía", NdDestino = "Banco_Ayuda", Valor = Convert.ToInt32(this.De11a6.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Estación_Policía", NdDestino = "Casa_Del_Sol", Valor = Convert.ToInt32(this.De11a9.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Estación_Policía", NdDestino = "Tronchatoro", Valor = Convert.ToInt32(this.De11a10.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Estación_Policía", NdDestino = "Casa_Port", Valor = Convert.ToInt32(this.De12a11.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Port", NdDestino = "Café_Rocher", Valor = Convert.ToInt32(this.De1a12.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Port", NdDestino = "Estación_Policía", Valor = Convert.ToInt32(this.De12a11.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Port", NdDestino = "Casa_Embrujada", Valor = Convert.ToInt32(this.De12a13.Text.Trim()) });
            AristasMapa.Add(new clArista { NdInicial = "Casa_Embrujada", NdDestino = "Casa_Port", Valor = Convert.ToInt32(this.De12a13.Text.Trim()) });
        }        
        #endregion
        #region PROTEGIDOS
        private void Cafe_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Café_Rocher";
                objNodo.NodoInicial = "Café_Rocher";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.Cafe.Enabled = false;
            }
            else
            {
                nodoFinal = "Café_Rocher";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Café_Rocher";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void Casita_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Casa_Paul";
                objNodo.NodoInicial = "Casa_Paul";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.Casita.Enabled = false;
            }
            else
            {
                nodoFinal = "Casa_Paul";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Casa_Paul";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void Mansion_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Casa_Blanca";
                objNodo.NodoInicial = "Casa_Blanca";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.Mansion.Enabled = false;
            }
            else
            {
                nodoFinal = "Casa_Blanca";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Casa_Blanca";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void Tienda_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Supermercado_Lina";
                objNodo.NodoInicial = "Supermercado_Lina";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.Tienda.Enabled = false;
            }
            else
            {
                nodoFinal = "Supermercado_Lina";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Supermercado_Lina";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void CasaPurpura_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Casa_Linda";
                objNodo.NodoInicial = "Casa_Linda";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.CasaPurpura.Enabled = false;
            }
            else
            {
                nodoFinal = "Casa_Linda";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Casa_Linda";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void Banco_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Banco_Ayuda";
                objNodo.NodoInicial = "Banco_Ayuda";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.Banco.Enabled = false;
            }
            else
            {
                nodoFinal = "Banco_Ayuda";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Banco_Ayuda";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void CasaPlus_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Hacienda_Frank";
                objNodo.NodoInicial = "Hacienda_Frank";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.CasaPlus.Enabled = false;
            }
            else
            {
                nodoFinal = "Hacienda_Frank";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Hacienda_Frank";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void CasaComercial_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "CComercial_Shean";
                objNodo.NodoInicial = "CComercial_Shean";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.CasaComercial.Enabled = false;
            }
            else
            {
                nodoFinal = "CComercial_Shean";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "CComercial_Shean";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void CasaSol_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Casa_Del_Sol";
                objNodo.NodoInicial = "Casa_Del_Sol";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.CasaSol.Enabled = false;
            }
            else
            {
                nodoFinal = "Casa_Del_Sol";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Casa_Del_Sol";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void CasaSeria_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Tronchatoro";
                objNodo.NodoInicial = "Tronchatoro";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.CasaSeria.Enabled = false;
            }
            else
            {
                nodoFinal = "Tronchatoro";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Tronchatoro";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void Policia_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Estación_Policía";
                objNodo.NodoInicial = "Estación_Policía";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.Policia.Enabled = false;
            }
            else
            {
                nodoFinal = "Estación_Policía";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Estación_Policía";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void CasaGris_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Casa_Port";
                objNodo.NodoInicial = "Casa_Port";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.CasaGris.Enabled = false;
            }
            else
            {
                nodoFinal = "Casa_Port";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Casa_Port";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void Encantada_Click(object sender, EventArgs e)
        {
            clNodo objNodo = new clNodo();

            if (nodoInicial == "")
            {
                nodoInicial = "Casa_Embrujada";
                objNodo.NodoInicial = "Casa_Embrujada";
                this.lblPtoPartida.Text = objNodo.AsignarPuntoPartida();
                this.lblPtoPartida.Visible = true;
                this.Encantada.Enabled = false;
            }
            else
            {
                nodoFinal = "Casa_Embrujada";
                this.Cafe.Enabled = false;
                this.Casita.Enabled = false;
                this.Mansion.Enabled = false;
                this.Tienda.Enabled = false;
                this.CasaPurpura.Enabled = false;
                this.CasaComercial.Enabled = false;
                this.CasaSol.Enabled = false;
                this.CasaSeria.Enabled = false;
                this.Policia.Enabled = false;
                this.CasaGris.Enabled = false;
                this.Encantada.Enabled = false;
                this.Banco.Enabled = false;
                this.CasaPlus.Enabled = false;

                objNodo.NodoFinal = "Casa_Embrujada";
                this.lblPtoLlegada.Text = objNodo.AsignarPuntoLlegada();
                this.lblPtoLlegada.Visible = true;
            }
        }
        private void btnCaminoMin_Click(object sender, EventArgs e)
        {
            if (esValidoParaCalcular())
            {
                AsignarDistancia();

                clArista objArista = new clArista();
                objArista.CalcularCaminoMinimo(nodoInicial, nodoFinal, Nodos, AristasMapa);

                this.lblResultado.Text = "El valor final de la ruta es: " + objArista.EsfuerzoResultante;
                this.lblRuta.Text = "Ruta: " + objArista.RutaResultante.Substring(2);
                this.lblResultado.Visible = true;
                this.lblRuta.Visible = true;
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblValida.Text = "";
            this.lblPtoPartida.Text = "";
            this.lblPtoLlegada.Text = "";
            this.lblResultado.Text = "";
            this.lblRuta.Text = "";

            nodoInicial = "";
            nodoFinal = "";

            AristasMapa = new List<clArista>();
            Nodos = new List<clNodo>
            {
                new clNodo { Nombre = "Café_Rocher", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Casa_Paul", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Casa_Blanca", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Supermercado_Lina", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Casa_Linda", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Banco_Ayuda", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Hacienda_Frank", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "CComercial_Shean", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Casa_Del_Sol", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Tronchatoro", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Estación_Policía", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Casa_Port", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 },
                new clNodo { Nombre = "Casa_Embrujada", Evaluado = false, Antecesor = "", Predecesor = "", ValorTemporal = 2147483646, ValorFinal = -1 }
            };
            listNodoOrden = new List<clNodo>();

            this.De1a2.Text = "";
            this.De1a12.Text = "";
            this.De2a3.Text = "";
            this.De2a11.Text = "";
            this.De3a5.Text = "";
            this.De3a6.Text = "";
            this.De6a4.Text = "";
            this.De4a8.Text = "";
            this.De6a8.Text = "";
            this.De6a9.Text = "";
            this.De11a6.Text = "";
            this.De7a8.Text = "";
            this.De10a9.Text = "";
            this.De11a9.Text = "";
            this.De11a10.Text = "";
            this.De12a11.Text = "";
            this.De12a13.Text = "";

            //MODIFICA VISUALIZACION
            this.Cafe.Enabled = true;
            this.Casita.Enabled = true;
            this.Mansion.Enabled = true;
            this.Tienda.Enabled = true;
            this.CasaPurpura.Enabled = true;
            this.CasaComercial.Enabled = true;
            this.CasaSol.Enabled = true;
            this.CasaSeria.Enabled = true;
            this.Policia.Enabled = true;
            this.CasaGris.Enabled = true;
            this.Encantada.Enabled = true;
            this.lblValida.Visible = false;
            this.lblPtoPartida.Visible = false;
            this.lblPtoLlegada.Visible = false;
            this.lblResultado.Visible = false;
            this.lblRuta.Visible = false;
        }
        #endregion
    }
}
