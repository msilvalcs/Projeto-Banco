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
            saldo -= valorDebitar;
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

    class ContaPoupança : Conta
    {
        private double rendimento;

        public ContaPoupança(int numero, string titular, double saldo, double rendimento)
        : base(numero, titular, saldo)
        {
            this.rendimento = rendimento;
        }

        public double getRendimento() { return rendimento; }
        public void setRendimento(double rendiment) { rendimento = rendiment; }

        public void imprimeRendimento()
        {
            Console.WriteLine($"Rendimento da poupança: {rendimento}");
        }
    }

    class ContaCorrente : Conta
    {
        private bool contaEspecial;
        private double limiteCheque;

        public ContaCorrente(int numero, string titular, double saldo, double limiteCheque, bool contaEspecial)
        : base(numero, titular, saldo)
        {
            this.contaEspecial = contaEspecial;
            this.limiteCheque = limiteCheque;
        }

        public bool getContaEspecial() { return contaEspecial; }
        public void setContaEspecial(bool contaSpecial) { contaEspecial = contaSpecial; }
        public double getLimiteCheque() { return limiteCheque; }
        public void setLimiteCheque(double limitCheque) { limiteCheque = limitCheque; }

        public void imprimeRendimento()
        {
            double rendimento = getRendimento();
            Console.WriteLine($"Rendimento da poupança: {rendimento}.");
        }

        public double getSaldoDisponivel() { return (saldo + limiteCheque) }
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
            Console.WriteLine($"Conta especial: {contaEspecial}");
            Console.WriteLine($"Limite do cheque: {limiteCheque}");
        }
        public void imprimeLimite()
        {
            Console.WriteLine($"Limite do cheque: {limiteCheque}");
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
        c3.imprimeDadosConta()
    }
}