# IDED_Parcial_Scripting
Alejandro Angarita Parra 000425695

Esteban Gallón Uribe 000425705


### Inconvenientes utilizando el patrón state:

Complejidad: El patrón State puede ser complejo de implementar, especialmente para flujos simples como el del prototipo actual.

Redundancia: El patrón State puede generar código redundante, ya que cada estado debe implementar la misma lógica para cada evento.

### Estrategia de implementación:

Una estrategia de implementación para el prototipo actual sería utilizar una máquina de estados con los siguientes estados:

- Espera
- Disparo
- Mostrar punto de impacto
- Calcular puntaje
- Determinar GameOver

Las transiciones entre estados serían las siguientes:

Espera → Disparo: cuando el jugador dispara una flecha.

Disparo → Mostrar punto de impacto: cuando la flecha alcanza su objetivo.

Mostrar punto de impacto → Calcular puntaje: cuando el punto de impacto de la flecha se ha mostrado al jugador.

Calcular puntaje → Determinar GameOver: cuando el puntaje del jugador ha sido calculado.

Determinar GameOver → Espera: cuando el juego termina y el jugador vuelve al estado inicial.

Cada estado implementaría la lógica necesaria para manejar los eventos que recibe y para realizar las transiciones a otros estados.
