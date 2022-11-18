using FluentAssertions;
using TechTalk.SpecFlow;
using wCaminoMinimoIO.Class;

namespace SpecFlowCaminoMinimo.Steps
{
    [Binding]
    public sealed class StepUsuarioFinal
    {
        private readonly ScenarioContext _scenarioContext;
        private string _varResult = "";

        public StepUsuarioFinal(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private readonly clNodo objNodo = new clNodo();

        [Given("el punto de partida es (.*)")]
        public void GivenPuntoPartida(string parStrPuntoPartidaGiven)
        {
            objNodo.NodoInicial = parStrPuntoPartidaGiven;
        }

        [When("el usuario selecciona el punto de partida")]
        public void WhenPuntoPartidaEsSeleccionado()
        {
            _varResult = objNodo.AsignarPuntoPartida();
        }

        [Then("el sistema muestra el enunciado de origen (.*)")]
        public void ThenElResultadoOrigenDebeSer(string parStrResultado)
        {
            _varResult.Should().Be(parStrResultado);
        }

        [Given("el punto de llegada es (.*)")]
        public void GivenPuntoLlegada(string parStrPuntoLlegadaGiven)
        {
            objNodo.NodoFinal = parStrPuntoLlegadaGiven;
        }

        [When("el usuario selecciona el punto de llegada")]
        public void WhenPuntoLlegadaEsSeleccionado()
        {
            _varResult = objNodo.AsignarPuntoLlegada();
        }

        [Then("el sistema muestra el enunciado de destino (.*)")]
        public void ThenElResultadoFinalDebeSer(string parStrResultado)
        {
            _varResult.Should().Be(parStrResultado);
        }
    }
}
