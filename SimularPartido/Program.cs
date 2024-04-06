using System;

public class SimuladorPartidoTenis
{
    private int puntajeJugador1;
    private int puntajeJugador2;
    private int juegosJugador1;
    private int juegosJugador2;

    // Constructor
    public SimuladorPartidoTenis()
    {
        puntajeJugador1 = 0;
        puntajeJugador2 = 0;
        juegosJugador1 = 0;
        juegosJugador2 = 0;
    }

    // Método para simular el resultado de un punto
    public void SimularPunto(char ganadorPunto)
    {
        if (ganadorPunto == '1')
        {
            puntajeJugador1++;
        }
        else if (ganadorPunto == '2')
        {
            puntajeJugador2++;
        }

        // Verificar si se ganó el juego
        if (puntajeJugador1 >= 4 && puntajeJugador1 - puntajeJugador2 >= 2)
        {
            juegosJugador1++;
            ReiniciarPuntajes();
        }
        else if (puntajeJugador2 >= 4 && puntajeJugador2 - puntajeJugador1 >= 2)
        {
            juegosJugador2++;
            ReiniciarPuntajes();
        }
    }

    // Método para reiniciar los puntajes después de ganar un juego
    private void ReiniciarPuntajes()
    {
        puntajeJugador1 = 0;
        puntajeJugador2 = 0;
    }

    // Método para obtener el marcador actual del partido
    public string ObtenerMarcador()
    {
        string marcador = "";

        // Convertir puntaje de tenis
        string[] puntajes = { "nada", "quince", "treinta", "cuarenta" };
        string puntajeJugador1Str = puntajes[puntajeJugador1];
        string puntajeJugador2Str = puntajes[puntajeJugador2];

        // Asignar marcador según puntajes
        if (juegosJugador1 < 6 && juegosJugador2 < 6)
        {
            marcador = $"{puntajeJugador1Str}-{puntajeJugador2Str}";
        }
        else if (juegosJugador1 == juegosJugador2 && juegosJugador1 == 6)
        {
            marcador = "Seis iguales";
        }
        else if (juegosJugador1 == 6 && juegosJugador2 < 5)
        {
            marcador = $"Juego para el jugador 1 {puntajeJugador1Str}-{puntajeJugador2Str}";
        }
        else if (juegosJugador2 == 6 && juegosJugador1 < 5)
        {
            marcador = $"Juego para el jugador 2 {puntajeJugador1Str}-{puntajeJugador2Str}";
        }
        else if (juegosJugador1 > 6 && juegosJugador1 - juegosJugador2 >= 2)
        {
            marcador = $"Juego para el jugador 1 {puntajeJugador1Str}-{puntajeJugador2Str}";
        }
        else if (juegosJugador2 > 6 && juegosJugador2 - juegosJugador1 >= 2)
        {
            marcador = $"Juego para el jugador 2 {puntajeJugador1Str}-{puntajeJugador2Str}";
        }

        return marcador;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SimularPartidoTenis simulador = new SimularPartidoTenis();
        string secuenciaPuntos = "112211221";

        Console.WriteLine("Marcador del partido después de cada punto:");

        foreach (char punto in secuenciaPuntos)
        {
            simulador.SimularPunto(punto);
            Console.WriteLine(simulador.ObtenerMarcador());
        }
    }
}
