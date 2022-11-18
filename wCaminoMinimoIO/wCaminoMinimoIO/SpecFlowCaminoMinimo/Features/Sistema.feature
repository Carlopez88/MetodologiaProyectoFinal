Feature: Sistema
	Calcular la ruta más rápida o el camino más óptimo que tarda trasladarse de un punto A a un punto B en el mapa

#Scenario: Limpiar formulario
#	When el usuario seleccione el botón Limpiar
#	Then el sistema limpia la información diligenciada del esfuerzo de cada arista
#	And el sistema oculta el enunciado del Punto de Partida
#	And el sistema oculta el enunciado del Punto de Llegada


Scenario: Calcular esfuerzo total resultante del camino mínimo
	Given el punto de partida para calcular el esfuerzo total es Estación_Policía
	And el punto de llegada para calcular el esfuerzo total es Supermercado_Lina
	When el usuario seleccione el botón Camino Mínimo
	Then el sistema muestra como resultado del esfuerzo total del camino mínimo 14

	Examples: Ruta
		| Arista                               | Esfuerzo |
		| Café_Rocher_-_Casa_Paul              | 5        |
		| Café_Rocher_-_Casa_Port              | 6        |
		| Casa_Paul_-_Café_Rocher              | 5        |
		| Casa_Paul_-_Casa_Blanca              | 3        |
		| Casa_Paul_-_Estación_Policía         | 6        |
		| Casa_Blanca_-_Casa_Paul              | 3        |
		| Casa_Blanca_-_Casa_Linda             | 3        |
		| Casa_Blanca_-_Banco_Ayuda            | 4        |
		| Supermercado_Lina_-_Banco_Ayuda      | 8        |
		| Supermercado_Lina_-_CComercial_Shean | 7        |
		| Casa_Linda_-_Casa_Blanca             | 3        |
		| Banco_Ayuda_-_Casa_Blanca            | 4        |
		| Banco_Ayuda_-_Supermercado_Lina      | 8        |
		| Banco_Ayuda_-_CComercial_Shean       | 10       |
		| Banco_Ayuda_-_Casa_Del_Sol           | 6        |
		| Banco_Ayuda_-_Estación_Policía       | 6        |
		| Hacienda_Frank_-_CComercial_Shean    | 5        |
		| CComercial_Shean_-_Supermercado_Lina | 7        |
		| CComercial_Shean_-_Banco_Ayuda       | 10       |
		| CComercial_Shean_-_Hacienda_Frank    | 5        |
		| Casa_Del_Sol_-_Banco_Ayuda           | 6        |
		| Casa_Del_Sol_-_Tronchatoro           | 3        |
		| Casa_Del_Sol_-_Estación_Policía      | 8        |
		| Tronchatoro_-_Casa_Del_Sol           | 3        |
		| Tronchatoro_-_Estación_Policía       | 4        |
		| Estación_Policía_-_Casa_Paul         | 6        |
		| Estación_Policía_-_Banco_Ayuda       | 6        |
		| Estación_Policía_-_Casa_Del_Sol      | 8        |
		| Estación_Policía_-_Tronchatoro       | 4        |
		| Estación_Policía_-_Casa_Port         | 5        |
		| Casa_Port_-_Café_Rocher              | 6        |
		| Casa_Port_-_Estación_Policía         | 5        |
		| Casa_Port_-_Casa_Embrujada           | 1        |
		| Casa_Embrujada_-_Casa_Port           | 1        |