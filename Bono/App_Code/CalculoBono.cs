using Microsoft.VisualBasic;
using System;

namespace Bono.App_Code
{
    public class CalculoBono
    {
        public CalculoBono()
        {

        }

        public double TasaDelPeriodo(double tasaAnual, double diasPeriodo, double diasAnio)
        {
            double tp = 0;
            tp = (Math.Pow((1 + tasaAnual), (diasPeriodo / diasAnio))) - 1;
            return tp;
        }

        public double TasaEfectivaAnual(double tasa, string tipoTasa, string periodoTasa, string periodoCapitalizacion, int diasXAnio)
        {
            double tea;
            double n;
            int dpt;
            int dpc;
            dpt = DiasXPeriodo(periodoTasa);
            dpc = DiasXPeriodo(periodoCapitalizacion);
            switch (tipoTasa)
            {
                case "nominal":
                    n = dpt / dpc;
                    tea = (Math.Pow((1 + (tasa / diasXAnio)), n)) - 1;
                    break;
                case "efectiva":
                    tea = (Math.Pow((1 + tasa), (diasXAnio / dpt))) - 1;
                    break;
                default:
                    tea = -1;
                    break;
            }
            return tea;
        }

        public int DiasXPeriodo(string periodo)
        {
            int d = 0;
            switch (periodo)
            {
                case "diaria":
                    d = 1;
                    break;
                case "quincenal":
                    d = 15;
                    break;
                case "mensual":
                    d = 30;
                    break;
                case "bimestral":
                    d = 60;
                    break;
                case "trimestral":
                    d = 90;
                    break;
                case "semestral":
                    d = 180;
                    break;
                case "anual":
                    d = 360;
                    break;
                default:
                    d = -1;
                    break;
            }
            return d;
        }

        public double Bono(int n, double valorNominal, int numeroPeriodos, char periodoGracia, double bonoIndexado, double cupon, double amortizacion)
        {
            double bono;
            if (n == 1)
            {
                bono = valorNominal;
            }
            else
            {
                if (n <= numeroPeriodos)
                {
                    if (periodoGracia == 'T')
                    {
                        bono = bonoIndexado - cupon;
                    }
                    else
                    {
                        bono = bonoIndexado + amortizacion;
                    }
                }
                else
                {
                    bono = 0;
                }
            }
            return bono;
        }

        public double InflacionXPeriodo(double inflacionAnual, double diasPeriodo, double diasXAnio)
        {
            double iPeriodo = (Math.Pow(1 + inflacionAnual, diasPeriodo / diasXAnio)) - 1;
            return iPeriodo;
        }

        public double BonoIndexado(double bono, double inflacionPeriodo)
        {
            double bonoIndexado = bono * (1 + inflacionPeriodo);
            return bonoIndexado;
        }

        public double Cupon(double tasaEfectivaPeriodo, double bonoIndexado)
        {
            double cupon = tasaEfectivaPeriodo * bonoIndexado * -1;
            return cupon;
        }

        public double Cuota(int n, int numeroPeriodos, char periodoGracia, double cupon, double amortizacion, string metodo, double valorNominal, double tep)
        {
            double cuota;
            if (n <= numeroPeriodos)
            {
                switch (metodo)
                {
                    case "aleman":
                        switch (periodoGracia)
                        {
                            case 'T':
                                cuota = 0;
                                break;
                            case 'P':
                                cuota = cupon;
                                break;
                            case 'S':
                                cuota = cupon + amortizacion;
                                break;
                            default:
                                cuota = -1;
                                break;
                        }
                        break;
                    case "frances":
                        switch (periodoGracia)
                        {
                            case 'T':
                                cuota = 0;
                                break;
                            case 'P':
                                cuota = cupon;
                                break;
                            case 'S':
                                /*vn*((((1+tep)^ntp)*tep)/(((1+tep)^ntp)-1))*(-1)*/
                                cuota = (valorNominal * (((Math.Pow(1 + tep, numeroPeriodos) * tep) / (Math.Pow(1 + tep, numeroPeriodos) - 1)))) * -1;
                                break;
                            default:
                                cuota = -1;
                                break;
                        }
                        break;
                    default:
                        switch (periodoGracia)
                        {
                            case 'T':
                                cuota = 0;
                                break;
                            case 'P':
                                cuota = cupon;
                                break;
                            case 'S':
                                cuota = cupon + amortizacion;
                                break;
                            default:
                                cuota = -1;
                                break;
                        }
                        break;
                }
            }
            else
            {
                cuota = -1;
            }
            return cuota;
        }

        public double Amortizacion(int n, int numeroPeriodos, char periodoGracia, double bonoIndexado, string metodo, double cuota, double cupon)
        {
            double amortizacion;
            if (n <= numeroPeriodos)
            {
                switch (metodo)
                {
                    case "aleman":
                        if (periodoGracia == 'T' || periodoGracia == 'P')
                        {
                            amortizacion = 0;
                        }
                        else
                        {
                            amortizacion = (bonoIndexado * -1) / (numeroPeriodos - n + 1);
                        }
                        break;
                    case "frances":
                        if (periodoGracia == 'T' || periodoGracia == 'P')
                        {
                            amortizacion = 0;
                        }
                        else
                        {
                            amortizacion = cuota-cupon;
                        }
                        break;
                    case "americano":
                        if (n == numeroPeriodos) {
                            amortizacion = bonoIndexado * -1;
                        }
                        else {
                            amortizacion = 0;
                        }
                        break;
                    default:
                        amortizacion = -1;
                        break;
                }
            }
            else
            {
                amortizacion = -1;
            }
            return amortizacion;
        }

        public double Prima(int n, int numeroPeriodos, double pPrima, double bonoIndexado) {
            double prima;
            if (n == numeroPeriodos) {
                prima = pPrima * bonoIndexado * -1;
            }
            else {
                prima = 0;
            }
            return prima;
        }

        public double Escudo(double cupon, double ir) {
            double escudo;

            escudo = (cupon * -1) * ir;

            return escudo;
        }

        public double FlujoEmisor(int n, int numeroPeriodos, double valorComercial, double costoInicialEmisor, double cuota, double prima) {
            double flujoEmisor;
            if (n == 0) {
                flujoEmisor = valorComercial - costoInicialEmisor;
            }
            else {
                if (n <= numeroPeriodos) {
                    flujoEmisor = cuota + prima;
                }
                else {
                    flujoEmisor = 0;
                }
            }
            return flujoEmisor;
        }

        public double FlujoEmisorEscudo(int n, double flujoEmisor, double escudo ) {
            double flujoEmisorEscudo;
            if (n == 0) {
                flujoEmisorEscudo = flujoEmisor;
            }
            else {
                flujoEmisorEscudo = flujoEmisor + escudo;
            }
            return flujoEmisorEscudo;
        }

        public double FlujoBonista(int n, double valorComercial, double costoInicialBonista, double flujoEmisor) {
            double flujoBonista;
            if (n == 0) {
                flujoBonista = (valorComercial * -1) - costoInicialBonista;
            }
            else {
                flujoBonista = flujoEmisor * -1;
            }
            return flujoBonista;
        }

        public double ValorActual(double[] flujoBonista, double tasaDescuentoAnual, int numeroPeriodos) {
            double valorActual = 0;
            for (int i = 1; i<= numeroPeriodos; i++) {
                valorActual = valorActual + ((flujoBonista[i]) / Math.Pow(i + tasaDescuentoAnual, i));
            }
            return valorActual;
        }

        public double VANeto(double[] flujoBonista, double valorActual) {
            double valorActualNeto;
            valorActualNeto = flujoBonista[0] + valorActual;
            return valorActualNeto;
        }

        public double Tir(double[] flujoBonista) {
            double tir = Financial.IRR(flujoBonista,0.1);
            return 0;
        }

        public double Tcea(double tir, double diasAnio, double diasPeriodo) {
            double tcea = Math.Pow(1+tir,diasAnio/diasPeriodo)-1;
            return tcea;
        }

    }
}