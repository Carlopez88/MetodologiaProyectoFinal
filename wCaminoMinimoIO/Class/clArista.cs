using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wCaminoMinimoIO.Class
{
  public class clArista
  {
    #region VARIABLES
    public string NdInicial { get; set; }
    public string NdDestino { get; set; }
    public int Valor { get; set; }

    public string EsfuerzoResultante { get; set; }
    public string RutaResultante { get; set; }
    #endregion

    public string HallarAntecesor(string NomNodo, List<clNodo> parLstNodos, List<clArista> parLstAristasMapa)
    {
      string antecesor = "";
      var aristasEvaluar = (from aristas in parLstAristasMapa
                            join nodos in parLstNodos
                            on aristas.NdInicial.ToUpper() equals nodos.Nombre.ToUpper()
                            where nodos.Nombre.ToUpper() == NomNodo.ToUpper()
                            select aristas).ToList();

      foreach (var arista in aristasEvaluar)
      {
        var NodoFin = (from nodo in parLstNodos where nodo.Nombre.ToUpper() == NomNodo.ToUpper() select nodo).ToList();
        var NodoInicio = (from nodo in parLstNodos where nodo.Nombre.ToUpper() == arista.NdDestino.ToUpper() select nodo).ToList();
        if ((NodoFin.ElementAt(0).ValorFinal - arista.Valor) == NodoInicio.ElementAt(0).ValorFinal)
        {
          antecesor = NodoInicio.ElementAt(0).Nombre;
          NodoInicio.ElementAt(0).Predecesor = NomNodo.ToUpper();
        }
      }

      return antecesor;
    }
    public bool FinAlgoritmo(List<clNodo> ListNodos)
    {
      bool vNodosVAlidados = true;

      foreach (var nodo in ListNodos)
      {
        if (!nodo.Evaluado)
        {
          vNodosVAlidados = nodo.Evaluado;
        }
      }

      return vNodosVAlidados;
    }
    public void CalcularCaminoMinimo(string parNodoInicial, string parNodoFinal, List<clNodo> parLstNodos, List<clArista> parLstAristasMapa)
    {
      string nodoActual = parNodoInicial;

      foreach (var item in parLstNodos)
      {
        if (parNodoInicial.ToUpper() == item.Nombre.ToUpper())
        {
          item.Evaluado = true;
          item.ValorTemporal = 0;
          item.ValorFinal = 0;
          item.Antecesor = "INICIO";
          break;
        }
      }

      while (!FinAlgoritmo(parLstNodos))
      {

        var nodoValidado = (from nodos in parLstNodos where nodos.Nombre.ToUpper() == nodoActual.ToUpper() select nodos).ToList();

        var aristasEvaluar = (from aristas in parLstAristasMapa
                              join nodos in parLstNodos
                              on aristas.NdInicial.ToUpper() equals nodos.Nombre.ToUpper()
                              where nodos.Nombre.ToUpper() == nodoActual.ToUpper()
                              select aristas).ToList();

        //Console.WriteLine("Aristas del nodo: {0}", aristasEvaluar.ElementAt(0).NdInicial.ToUpper());
        //foreach (var item in aristasEvaluar)
        //{
        //    Console.WriteLine("NdInicial: {0} | NdFinal: {1} |  Valor: {2} |\n", item.NdInicial, item.NdDestino, item.Valor);
        //}

        foreach (var aristaEvaluar in aristasEvaluar)
        {
          foreach (var nodoActualizar in parLstNodos)
          {
            if (aristaEvaluar.NdDestino == nodoActualizar.Nombre)
            {
              if (!nodoActualizar.Evaluado)
              {
                int acumulado = nodoValidado.ElementAt(0).ValorFinal + aristaEvaluar.Valor;
                var nodoValidDestino = (from nodos in parLstNodos where nodos.Nombre.ToUpper() == aristaEvaluar.NdDestino.ToUpper() select nodos).ToList();
                if (acumulado < nodoValidDestino.ElementAt(0).ValorTemporal)
                {
                  nodoActualizar.ValorTemporal = nodoValidado.ElementAt(0).ValorFinal + aristaEvaluar.Valor;
                }

              }
            }
          }
        }

        //Console.WriteLine("************************************* NODOS MODIFICADOS ******************************************* \n");

        //foreach (var listnodos in Nodos)
        //{
        //    dataNodo = String.Format(" | Nodo: {0} | Evaluado: {1} | Antecesor: {2} | Predecesor: {3} | ValorTemporal: {4} | ValorFinal: {5}\n", listnodos.Nombre, listnodos.Evaluado, listnodos.Antecesor, listnodos.Predecesor, listnodos.ValorTemporal, listnodos.ValorFinal);
        //    Console.WriteLine(dataNodo);
        //}

        var nodosEvaluarMin = (from nodos in parLstNodos
                               where nodos.ValorFinal == -1
                               select nodos).ToList();

        int nodoMin = nodosEvaluarMin.Min(x => x.ValorTemporal);

        var nodosEvaluar = (from nodos in parLstNodos
                            where nodos.ValorTemporal == nodoMin
                            select nodos).ToList();

        //Console.WriteLine("************************************* NODOS A EVALUAR ******************************************* \n");

        int iteracion = 0;

        foreach (var itemNd in nodosEvaluar)
        {
          if (iteracion < 1)
          {
            if (itemNd.ValorFinal == -1)
            {
              iteracion++;
              itemNd.ValorFinal = itemNd.ValorTemporal;
              itemNd.Evaluado = true;
              nodoActual = itemNd.Nombre;
              //dataNodo = String.Format(" | Nodo: {0} | Evaluado: {1} | Antecesor: {2} | Predecesor: {3} | ValorTemporal: {4} | ValorFinal: {5}\n", itemNd.Nombre, itemNd.Evaluado, itemNd.Antecesor, itemNd.Predecesor, itemNd.ValorTemporal, itemNd.ValorFinal);
              //Console.WriteLine(dataNodo);
            }
          }

        }

        nodoValidado.ElementAt(0).Evaluado = true;

      }

      //Console.WriteLine("\n\n************************************* TABLA FINAL ******************************************* \n");
      //foreach (var listnodos in Nodos)
      //{
      //    dataNodo = String.Format(" | Nodo: {0} | Evaluado: {1} | Antecesor: {2} | Predecesor: {3} | ValorTemporal: {4} | ValorFinal: {5}\n", listnodos.Nombre, listnodos.Evaluado, listnodos.Antecesor, listnodos.Predecesor, listnodos.ValorTemporal, listnodos.ValorFinal);
      //    Console.WriteLine(dataNodo);
      //}

      //Console.WriteLine("\n\n*********************************************************************************************** \n\n\n");
      //Console.WriteLine("\n\n************************************* ANALIZANDO RUTA ******************************************* \n");

      var rutaFinal = (from nodos in parLstNodos where nodos.Nombre.ToUpper() == parNodoFinal.ToUpper() select nodos).ToList();
      rutaFinal.ElementAt(0).Predecesor = "FINAL";

      //Console.WriteLine("El valor de la ruta es: {0}\n", rutaFinal.ElementAt(0).ValorFinal);
      //Console.WriteLine("La ruta es *******************\n");

      do
      {
        rutaFinal.ElementAt(0).Antecesor = HallarAntecesor(rutaFinal.ElementAt(0).Nombre.ToUpper(), parLstNodos, parLstAristasMapa);
        rutaFinal = (from nodos in parLstNodos where nodos.Nombre.ToUpper() == rutaFinal.ElementAt(0).Antecesor.ToUpper() select nodos).ToList();
      } while (rutaFinal.ElementAt(0).Nombre.ToUpper() != parNodoInicial.ToUpper());

      var ImprimirRuta = (from nodos in parLstNodos
                          where nodos.Predecesor != "" && nodos.Antecesor != ""
                          orderby nodos.ValorFinal
                          select nodos).ToList();

      string dataNodo = "";
      string valFinal = "";

      foreach (var rutaImpresa in ImprimirRuta)
      {
        //dataNodo = String.Format("\n | Nodo: {0} | ValorFinal: {1} |\n", rutaImpresa.Nombre, rutaImpresa.ValorFinal);                    
        //Console.WriteLine(dataNodo);

        dataNodo = dataNodo + " / " + rutaImpresa.Nombre;
        valFinal = rutaImpresa.ValorFinal.ToString();
      }

      //ASIGNA INFO A LAS PROPIEDADES
      EsfuerzoResultante = valFinal;
      RutaResultante = dataNodo;
    }   
  }
}
