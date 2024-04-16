/*
 * Crea un programa que calcule quien gana más partidas al piedra,
 * papel, tijera, lagarto, spock.
 * - El resultado puede ser: "Player 1", "Player 2", "Tie" (empate)
 * - La función recibe un listado que contiene pares, representando cada jugada.
 * - El par puede contener combinaciones de "🗿" (piedra), "📄" (papel),
 *   "✂️" (tijera), "🦎" (lagarto) o "🖖" (spock).
 * - Ejemplo. Entrada: [("🗿","✂️"), ("✂️","🗿"), ("📄","✂️")]. Resultado: "Player 2".
 */

using ejerciciodos;

Dictionary<Movimiento, List<Movimiento>> reglas = new Dictionary<Movimiento, List<Movimiento>>
{
    { Movimiento.Piedra, [Movimiento.Tijera, Movimiento.Lagarto] },
    { Movimiento.Papel, [Movimiento.Piedra, Movimiento.Spock] },
    { Movimiento.Tijera, [Movimiento.Papel, Movimiento.Lagarto] },
    { Movimiento.Lagarto, [Movimiento.Papel, Movimiento.Spock] },
    { Movimiento.Spock, [Movimiento.Piedra, Movimiento.Tijera] }
};

int numPartidas = 3;
int victoriasJugador1 = 0;
int victoriasJugador2 = 0;

Console.WriteLine("¡Bienvenidos al juego de piedra, papel, tijera, lagarto, spock!");

for (int i = 1; i <= numPartidas; i++)
{
    Console.WriteLine($"\nPartida #{i}");

    Movimiento jugadaJugador1 = LeerOpcion("Jugador 1");
    Movimiento jugadaJugador2 = LeerOpcion("Jugador 2");

    int resultado = DeterminarGanador(jugadaJugador1, jugadaJugador2);
    if (resultado == 0)
    {
        Console.WriteLine("Empate en esta partida.");
    }
    else if (resultado == 1)
    {
        Console.WriteLine("¡Jugador 1 gana esta partida!");
        victoriasJugador1++;
    }
    else
    {
        Console.WriteLine("¡Jugador 2 gana esta partida!");
        victoriasJugador2++;
    }
}

MostrarResultadoFinal(victoriasJugador1, victoriasJugador2);

return;

Movimiento LeerOpcion(string jugador)
{
    Console.WriteLine($"{jugador}, elige: piedra, papel, tijera, lagarto, o spock");
    string entrada = Console.ReadLine().ToLower();
    if (Enum.TryParse(entrada, true, out Movimiento opcion))
    {
        return opcion;
    }

    Console.WriteLine("Entrada no válida, intenta de nuevo.");
    return LeerOpcion(jugador);
}

int DeterminarGanador(Movimiento jugador1, Movimiento jugador2)
{
    if (jugador1 == jugador2) return 0;
    if (reglas[jugador1].Contains(jugador2)) return 1;
    return -1;
}

void MostrarResultadoFinal(int victoriasJugador1, int victoriasJugador2)
{
    Console.WriteLine("\n--- Resultado final ---");
    Console.WriteLine($"Jugador 1: {victoriasJugador1} victorias");
    Console.WriteLine($"Jugador 2: {victoriasJugador2} victorias");

    if (victoriasJugador1 > victoriasJugador2)
    {
        Console.WriteLine("¡Jugador 1 gana el juego!");
    }
    else if (victoriasJugador2 > victoriasJugador1)
    {
        Console.WriteLine("¡Jugador 2 gana el juego!");
    }
    else
    {
        Console.WriteLine("¡Empate! No hay un ganador claro.");
    }
}