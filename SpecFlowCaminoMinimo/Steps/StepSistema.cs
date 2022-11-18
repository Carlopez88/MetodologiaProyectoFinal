using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using wCaminoMinimoIO.Class;

namespace SpecFlowCaminoMinimo.Steps
{
  [Binding]
  public sealed class StepSistema
  {
    private readonly ScenarioContext _scenarioContext;
    private int _varResult = 0;
    private List<clArista> _AristasMapa = new List<clArista>();

    public StepSistema(ScenarioContext scenarioContext)
    {
      _scenarioContext = scenarioContext;
    }

    private readonly clNodo objNodo = new clNodo();
    private readonly clArista objArista = new clArista();
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

    [Given("el usuario seleccione como punto de partida (.*)")]
    public void GetPuntoPartida(string parStrPuntoPartidaGiven)
    {
      objNodo.NodoInicial = parStrPuntoPartidaGiven;
    }

    [Given("el usuario seleccione como punto de llegada (.*)")]
    public void GetPuntoLlegada(string parStrPuntoLlegadaGiven)
    {
      objNodo.NodoFinal = parStrPuntoLlegadaGiven;
    }

    [Given("el usuario ingresa el esfuerzo para cada arista")]
    public void GetValorAristas(Table table)
    {
      
      var data = table.CreateSet<clArista>();

      foreach (var item in data)
      {
        _AristasMapa.Add(new clArista { NdInicial = item.NdInicial, NdDestino = item.NdDestino, Valor = Convert.ToInt32(item.Valor) });
      }
    }

    [When("El usuario seleccione el botón Camino Mínimo")]
    public void WhenSeleccionaCaminoMinimoXEsfuerzo()
    {
      objArista.CalcularCaminoMinimo(objNodo.NodoInicial, objNodo.NodoFinal, Nodos, _AristasMapa);
      _varResult = Convert.ToInt32(objArista.EsfuerzoResultante.TrimEnd());
    }

    [Then("el sistema muestra como resultado del esfuerzo total del camino mínimo (.*)")]
    public void ThenElEsfuerzoTotalDebeSer(int parResultado)
    {
      _varResult.Should().Be(parResultado);
    }
  }
}
