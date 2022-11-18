Feature: Sistema
	Calcular la ruta más rápida o el camino más óptimo que tarda trasladarse de un punto A a un punto B en el mapa

#Scenario: Limpiar formulario
#	When el usuario seleccione el botón Limpiar
#	Then el sistema limpia la información diligenciada del esfuerzo de cada arista
#	And el sistema oculta el enunciado del Punto de Partida
#	And el sistema oculta el enunciado del Punto de Llegada

Background:
  Given el usuario seleccione como punto de partida Estación_Policía
  And el usuario seleccione como punto de llegada Supermercado_Lina
  And el usuario ingresa el esfuerzo para cada arista
    | NdInicial         | NdDestino         | Valor |
    | Café_Rocher       | Casa_Paul         | 5     |
    | Café_Rocher       | Casa_Port         | 6     |
    | Casa_Paul         | Café_Rocher       | 5     |
    | Casa_Paul         | Casa_Blanca       | 3     |
    | Casa_Paul         | Estación_Policía  | 6     |
    | Casa_Blanca       | Casa_Paul         | 3     |
    | Casa_Blanca       | Casa_Linda        | 3     |
    | Casa_Blanca       | Banco_Ayuda       | 4     |
    | Supermercado_Lina | Banco_Ayuda       | 8     |
    | Supermercado_Lina | CComercial_Shean  | 7     |
    | Casa_Linda        | Casa_Blanca       | 3     |
    | Banco_Ayuda       | Casa_Blanca       | 4     |
    | Banco_Ayuda       | Supermercado_Lina | 8     |
    | Banco_Ayuda       | CComercial_Shean  | 10    |
    | Banco_Ayuda       | Casa_Del_Sol      | 6     |
    | Banco_Ayuda       | Estación_Policía  | 6     |
    | Hacienda_Frank    | CComercial_Shean  | 5     |
    | CComercial_Shean  | Supermercado_Lina | 7     |
    | CComercial_Shean  | Banco_Ayuda       | 10    |
    | CComercial_Shean  | Hacienda_Frank    | 5     |
    | Casa_Del_Sol      | Banco_Ayuda       | 6     |
    | Casa_Del_Sol      | Tronchatoro       | 3     |
    | Casa_Del_Sol      | Estación_Policía  | 8     |
    | Tronchatoro       | Casa_Del_Sol      | 3     |
    | Tronchatoro       | Estación_Policía  | 4     |
    | Estación_Policía  | Casa_Paul         | 6     |
    | Estación_Policía  | Banco_Ayuda       | 6     |
    | Estación_Policía  | Casa_Del_Sol      | 8     |
    | Estación_Policía  | Tronchatoro       | 4     |
    | Estación_Policía  | Casa_Port         | 5     |
    | Casa_Port         | Café_Rocher       | 6     |
    | Casa_Port         | Estación_Policía  | 5     |
    | Casa_Port         | Casa_Embrujada    | 1     |
    | Casa_Embrujada    | Casa_Port         | 1     |

Scenario: Calcular esfuerzo total resultante del camino mínimo
  When El usuario seleccione el botón Camino Mínimo
  Then el sistema muestra como resultado del esfuerzo total del camino mínimo 14



