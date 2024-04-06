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

        //Construtor Conta
        public Conta(int numero, string titular, double saldo)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = saldo;
            dataAbertura = DateTime.Now;
        }

        //Get e set
        public int getNumero() { return numero; }
        public void setNumero(int num) { numero = num; }
        public string getTitular() { return titular; }
        public void setTitular(string titu) { titular = titu; }
        public double getSaldo() { return saldo; }
        public void setSaldo(double sald) { saldo = sald; }
        public DateTime GetDataAbertura() { return dataAbertura; }

        //Debitar da conta
        public double debitar(double valorDebitar)
        {
            saldo -= valorDebitar;
            return saldo;
        }

        //Creditar na conta
        public double creditar(double valorCreditar)
        {
            saldo += valorCreditar;
            return saldo;
        }

        //Imprime os dados da conta
        public virtual void imprimeDadosConta()
        {
            Console.WriteLine("-=- Informações de Conta -=-");
            Console.WriteLine($"Numero: {numero}");
            Console.WriteLine($"Titular: {titular}");
            Console.WriteLine($"Saldo: {saldo:C} ");
        }

        //Verifica se existem duas contas iguais
        public override bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }
            Conta outraConta = (Conta)obj;
            return numero == outraConta.numero;
        }

        public override int GetHashCode()
        {
            return numero.GetHashCode();
        }

        //Misturar informações string e int/double
        public override string ToString()
        {
            return $"Conta: {numero}, Titular: {titular}, Saldo: {saldo:C}, Data de Abertura: {dataAbertura}";
        }
    }

    //CONTA CORRENTE
    class ContaCorrente : Conta
    {
        private bool contaEspecial;
        private double limiteCheque;

        //Construtor Conta corrente herdando da Class Conta
        public ContaCorrente(int numero, string titular, double saldo, bool contaEspecial, double limiteCheque)
        : base(numero, titular, saldo)
        {
            this.contaEspecial = contaEspecial;
            this.limiteCheque = limiteCheque;
        }

        //Get e Set
        public bool getContaEspecial() { return contaEspecial; }
        public void setContaEspecial(bool contaSpecial) { contaEspecial = contaSpecial; }
        public double getLimiteCheque() { return limiteCheque; }
        public void setLimiteCheque(double limitCheque) { limiteCheque = limitCheque; }

        //Pegar saldo disponivel da Conta corrente
        public double getSaldoDisponivel()
        {
            double pegaSaldo = getSaldo();
            return pegaSaldo + limiteCheque;
        }

        //Imprime todos dados da conta
        public override void imprimeDadosConta()
        {
            base.imprimeDadosConta();
            if (contaEspecial == true)
            {
            Console.WriteLine($"Conta especial: sim");
            }
            else
            {
            Console.WriteLine($"Conta especial: não");
            }
            Console.WriteLine($"Limite do cheque: {limiteCheque}");
        }

        //Imprime o limite do cheque especial
        public void imprimeLimite()
        {
            Console.WriteLine($"Limite do cheque: {limiteCheque}");
        }

        public void imprimeSaldoTotal()
        {
            double pegaSaldo = getSaldo();
            Console.WriteLine($"Limite total disponivel: {pegaSaldo + limiteCheque}");
        }
    }

    class ContaPoupanca : Conta
    {
        private double rendimento;

        //Construtor Conta Poupança que herda classe Conta 
        public ContaPoupanca(int numero, string titular, double saldo, double rendimento)
        : base(numero, titular, saldo)
        {
            this.rendimento = rendimento;
        }

        //Get e set
        public double getRendimento() { return rendimento; }
        public void setRendimento(double rendiment) { rendimento = rendiment; }


        //Imprime os rendimentos da conta poupança
        public void imprimeRendimento()
        {
            Console.WriteLine($"Rendimento da poupança: {rendimento}");
        }
    }


    class TestarConta
    {
        public static void ExecutarTeste()
        {
            ContaCorrente conta1 = new ContaCorrente(1, "FHC", 2000000, true, 1.50000);
            conta1.imprimeDadosConta();
            Console.WriteLine();

            ContaCorrente conta2 = new ContaCorrente(2, "Carlos", 2540, false, 0);
            conta2.imprimeDadosConta();
            Console.WriteLine();
            
            ContaCorrente conta3 = new ContaCorrente(3, "Maria", 540, false, 0);
            conta3.imprimeDadosConta();
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        TestarConta.ExecutarTeste();
    }
}