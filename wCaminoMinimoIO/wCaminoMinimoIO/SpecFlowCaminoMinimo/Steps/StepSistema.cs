using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using wCaminoMinimoIO.Class;

namespace SpecFlowCaminoMinimo.Steps
{
    [Binding]
    public sealed class StepSistema
    {
        private readonly ScenarioContext _scenarioContext;
        private int _varResult = 0;

        public StepSistema(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private readonly clNodo objNodo = new clNodo();
        private readonly clArista objArista = new clArista();

        [Given("el punto de partida para calcular el esfuerzo total es (.*)")]
        public void GivenGetEsfuerzoTotal(string parStrPuntoPartidaGiven)
        {
            objNodo.NodoInicial = parStrPuntoPartidaGiven;
        }

        [Given("el punto de llegada para calcular el esfuerzo total es (.*)")]
        public void GivenAndGetEsfuerzoTotal(string parStrPuntoLlegadaGiven)
        {
            objNodo.NodoFinal = parStrPuntoLlegadaGiven;
        }

        [When("el usuario seleccione el botón Camino Mínimo")]
        public void WhenSeleccionaCaminoMinimoXEsfuerzo()
        {
            
            List<clNodo> Nodos = new List<clNodo>
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

            _varResult = objArista.CalcularCaminoMinimo(objNodo.NodoInicial, objNodo.NodoFinal, Nodos, AristasMapa); ;
        }

        [Then("el sistema muestra como resultado del esfuerzo total del camino mínimo (.*)")]
        public void ThenElEsfuerzoTotalDebeSer(int parResultado)
        {
            _varResult.Should().Be(parResultado);
        }
    }
}
