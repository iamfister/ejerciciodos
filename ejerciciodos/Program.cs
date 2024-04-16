/*
* Crea un programa que calcule quien gana más partidas al piedra,
* papel, tijera, lagarto, spock.
* - El resultado puede ser: "Player 1", "Player 2", "Tie" (empate)
* - La función recibe un listado que contiene pares, representando cada jugada.
* - El par puede contener combinaciones de "🗿" (piedra), "📄" (papel),
*   "✂️" (tijera), "🦎" (lagarto) o "🖖" (spock).
* - Ejemplo. Entrada: [("🗿","✂️"), ("✂️","🗿"), ("📄","✂️")]. Resultado: "Player 2".
*/

int numPartidas = 3; // Número de partidas a jugar
int victoriasJugador1 = 0;
int victoriasJugador2 = 0;

Console.WriteLine("¡Bienvenidos al juego de piedra, papel, tijera, lagarto, spock!");

for (int i = 1; i <= numPartidas; i++)
{
    Console.WriteLine("\nPartida #" + i);

    Console.Write("Jugador 1, elige: ");
    string jugadaJugador1 = Console.ReadLine().ToLower();

    Console.Write("Jugador 2, elige: ");
    string jugadaJugador2 = Console.ReadLine().ToLower();

    if (jugadaJugador1 == jugadaJugador2)
    {
        Console.WriteLine("Empate en esta partida.");
    }
    else if ((jugadaJugador1 == "piedra" && jugadaJugador2 is "tijera" or "lagarto") ||
             (jugadaJugador1 == "papel" && jugadaJugador2 is "piedra" or "spock") ||
             (jugadaJugador1 == "tijera" && jugadaJugador2 is "papel" or "lagarto") ||
             (jugadaJugador1 == "lagarto" && jugadaJugador2 is "papel" or "spock") ||
             (jugadaJugador1 == "spock" && jugadaJugador2 is "piedra" or "tijera"))
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

Console.WriteLine("\n--- Resultado final ---");
Console.WriteLine("Jugador 1: " + victoriasJugador1 + " victorias");
Console.WriteLine("Jugador 2: " + victoriasJugador2 + " victorias");

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