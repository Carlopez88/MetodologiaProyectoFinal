Feature: UsuarioFinal
	Acciones que realiza el usuario final por medio de la aplicación:
	1. Diligenciar el esfuerzo entre cada punto o valor de cada arista del mapa
	2. Seleccionar el punto de partida
	3. Seleccionar el punto de llegada

#PUNTO ORIGEN
Scenario: Elegir Estación_Policía como origen
	Given el punto de partida es Estación_Policía
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Estación_Policía

Scenario: Elegir Café_Rocher como origen
	Given el punto de partida es Café_Rocher
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Café_Rocher

Scenario: Elegir Supermercado_Lina como origen
	Given el punto de partida es Supermercado_Lina
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Supermercado_Lina

Scenario: Elegir Casa_Paul como origen
	Given el punto de partida es Casa_Paul
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Casa_Paul

Scenario: Elegir Casa_Blanca como origen
	Given el punto de partida es Casa_Blanca
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Casa_Blanca

Scenario: Elegir Casa_Linda como origen
	Given el punto de partida es Casa_Linda
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Casa_Linda

Scenario: Elegir Banco_Ayuda como origen
	Given el punto de partida es Banco_Ayuda
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Banco_Ayuda

Scenario: Elegir Hacienda_Frank como origen
	Given el punto de partida es Hacienda_Frank
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Hacienda_Frank

Scenario: Elegir CComercial_Shean como origen
	Given el punto de partida es CComercial_Shean
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: CComercial_Shean

Scenario: Elegir Casa_Del_Sol como origen
	Given el punto de partida es Casa_Del_Sol
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Casa_Del_Sol

Scenario: Elegir Tronchatoro como origen
	Given el punto de partida es Tronchatoro
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Tronchatoro

Scenario: Elegir Casa_Port como origen
	Given el punto de partida es Casa_Port
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Casa_Port

Scenario: Elegir Casa_Embrujada como origen
	Given el punto de partida es Casa_Embrujada
	When el usuario selecciona el punto de partida
	Then el sistema muestra el enunciado de origen Punto de Partida: Casa_Embrujada

#PUNTO DESTINO
Scenario: Elegir Estación_Policía como destino
	Given el punto de llegada es Estación_Policía
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Estación_Policía

Scenario: Elegir Café_Rocher como destino
	Given el punto de llegada es Café_Rocher
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Café_Rocher

Scenario: Elegir Supermercado_Lina como destino
	Given el punto de llegada es Supermercado_Lina
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Supermercado_Lina

Scenario: Elegir Casa_Paul como destino
	Given el punto de llegada es Casa_Paul
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Casa_Paul

Scenario: Elegir Casa_Blanca como destino
	Given el punto de llegada es Casa_Blanca
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Casa_Blanca

Scenario: Elegir Casa_Linda como destino
	Given el punto de llegada es Casa_Linda
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Casa_Linda

Scenario: Elegir Banco_Ayuda como destino
	Given el punto de llegada es Banco_Ayuda
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Banco_Ayuda

Scenario: Elegir Hacienda_Frank como destino
	Given el punto de llegada es Hacienda_Frank
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Hacienda_Frank

Scenario: Elegir CComercial_Shean como destino
	Given el punto de llegada es CComercial_Shean
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: CComercial_Shean

Scenario: Elegir Casa_Del_Sol como destino
	Given el punto de llegada es Casa_Del_Sol
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Casa_Del_Sol

Scenario: Elegir Tronchatoro como destino
	Given el punto de llegada es Tronchatoro
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Tronchatoro

Scenario: Elegir Casa_Port como destino
	Given el punto de llegada es Casa_Port
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Casa_Port

Scenario: Elegir Casa_Embrujada como destino
	Given el punto de llegada es Casa_Embrujada
	When el usuario selecciona el punto de llegada
	Then el sistema muestra el enunciado de destino Punto de Llegada: Casa_Embrujada