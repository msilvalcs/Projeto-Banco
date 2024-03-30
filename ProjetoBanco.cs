using System;
using System.Collections.Generic;
class Program
{

    class Conta
    {
        private int numero;
        private string titular;
        private double saldo;
        private DateTime dataAbertura;

        public Conta(int numero, string titular, double saldo)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = saldo;
            dataAbertura = DateTime.Now;
        }

        public int getNumero() { return numero; }
        public void setNumero(int num) { numero = num; }
        public string getTitular() { return titular; }
        public void setTitular(string titu) { titular = titu; }
        public double getSaldo() { return saldo; }
        public void setSaldo(double sald) { saldo = sald; }
        public DateTime GetDataAbertura() { return dataAbertura; }

        public double debitar(double valorDebitar)
        {
            if (valorDebitar < saldo)
            {
                saldo -= valorDebitar;
            }
            else
            {
                Console.WriteLine("Saldo inválido!");
            }
            return saldo;
        }

        public double creditar(double valorCreditar)
        {
            saldo += valorCreditar;
            return saldo;
        }
        public override bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }
            Conta outraConta = (Conta)obj;
            return this.numero == outraConta.numero;
        }

        public override int GetHashCode()
        {
            return numero.GetHashCode();
        }

        public override string ToString()
        {
            return $"Conta: {numero}, Titular: {titular}, Saldo: {saldo:C}, Data de Abertura: {dataAbertura}";
        }

        public void imprimeDadosConta()
        {
            Console.WriteLine("-=- Informações de Conta -=-");
            Console.WriteLine($"Numero: {numero}");
            Console.WriteLine($"Titular: {titular}");
            Console.Write($"Saldo: {saldo:C} ");
            if (saldo > 0)
            {
                Console.WriteLine("Saldo OK");
            }
            else
            {
                Console.WriteLine("Atenção cliente seu saldo está negativo.");
            }
        }
    }

    static void Main(string[] args)
    {
        Conta c1 = new Conta(1, "José", 500);
        c1.imprimeDadosConta();

        c1.debitar(12222);
        c1.imprimeDadosConta();

        Conta c2 = new Conta(2, "Marcos", 1500);
        c2.imprimeDadosConta();

        c2.debitar(12222);
        c2.imprimeDadosConta();

        Conta c3 = new Conta(3, "Maria", 1500);
        c3.imprimeDadosConta();

        c3.debitar(12222);
        c3.imprimeDadosConta();
    }

}