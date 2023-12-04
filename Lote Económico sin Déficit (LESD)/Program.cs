using System;

class LoteEconomicoSinDeficit
{
    static void Main()
    {
        // Datos del problema
        double demandaAnual = 900; // Demanda anual
        double costoOrdenar = 400; // Costo de realizar un pedido
        double costoMantenimiento = 600; // Costo de mantener una unidad en inventario por año
        double costoUnitario = 30; // Costo unitario de cada teléfono

        // Calcular la cantidad económica de pedido (EOQ)
        double eoq = CalcularEOQ(demandaAnual, costoOrdenar, costoMantenimiento);

        // Calcular el número de pedidos por año y el tiempo de ciclo
        double frecuenciaPedidos = CalcularFrecuenciaPedidos(demandaAnual, eoq);
        double tiempoCiclo = 1 / frecuenciaPedidos;

        // Calcular el costo total anual usando la fórmula específica
        double costoTotalAnual = CalcularCostoTotalAnualEspecifico(demandaAnual, eoq, costoOrdenar, costoMantenimiento, costoUnitario);

        // Mostrar resultados
        Console.WriteLine($"a) Cantidad económica de pedido (EOQ): {eoq}");
        Console.WriteLine($"b) Número de pedidos por año: {frecuenciaPedidos}");
        Console.WriteLine($"c) Costo total anual por pedido: {costoTotalAnual}");
    }

    // Función para calcular la cantidad económica de pedido (EOQ)
    static double CalcularEOQ(double demandaAnual, double costoOrdenar, double costoMantenimiento)
    {
        return Math.Sqrt((2 * demandaAnual * costoOrdenar) / costoMantenimiento);
    }

    // Función para calcular la frecuencia de pedidos
    static double CalcularFrecuenciaPedidos(double demandaAnual, double eoq)
    {
        return demandaAnual / eoq;
    }

    // Función para calcular el costo total anual usando la fórmula específica
    static double CalcularCostoTotalAnualEspecifico(double demandaAnual, double eoq, double costoOrdenar, double costoMantenimiento, double costoUnitario)
    {
        double costoTotalOrdenar = (demandaAnual / eoq) * costoOrdenar;
        double costoTotalMantenimiento = (eoq / 2) * costoMantenimiento;
        double costoTotalInventario = demandaAnual * costoUnitario;

        return costoTotalInventario + costoTotalOrdenar + costoTotalMantenimiento;
    }
}
