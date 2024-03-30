class Data
{
    private int dia, mes, ano;

    public Data(int dia, int mes, int ano)
    {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }

    public int getDia(){return dia;}
    public void setDia(int d){ dia = (d>0) && (d<=31) ? d : 1; }
    public int getMes(){return mes;}
    public void setMes(int m){ mes = (m>0) && (d<=12) ? d : 1; }
    public int getAno(){return ano;}
    public void setAno(int a) { ano = a>0 ? a : 2010;}
}

class Agencia
{
    private int codigo;
    private string descricao;
    private Data dataAbertura;
    private List<Conta> contas;

    public Agencia(int codigo, string descricao, int dia, int mes,int ano)
    {
        codigo = codigo;
        descricao = descricao;
        dataAbertura = new Data(dia, mes, ano);
        contas = new List<Conta>;
    }

    public void adicionar(Conta conta)
    {
        conta.add(contas);
    }

    public void excluir(Conta conta)
    {
        contas.remove(conta);
    }

    public List<Conta> listarContar()
    {
        foreach(var conta in contas)
        {
            Console.WriteLine(conta);
        }
    } 
}

class Conta
{
    private int numero;
    private string titular;
    private double saldo;
    private Data dataAbertura;

    public Conta(int numero, string titular, double saldo, int dia, int mes, int ano)
    {
        this.numero = numero;
        this.titular = titular;
        this.saldo = saldo;
        dataAbertura = new Data(dia,mes,ano);
    }

    public int getNumero(){ return numero; }
    public void setNumero(int num) { numero = num; }
    public string getTitular() {r eturn titular; }
    public void setTitular(string titu) { titular = titu; }
    public double getSaldo() { return saldo; }
    public void setSaldo(int sald) { saldo = sald; }
    public Data GetDataAbertura() { return dataAbertura; }

    public double debitar(double valorDebitar)
    {
        if(valorDebitar<saldo)
        {
            saldo -= valorDebitar;
            Console.WriteLine($"Debitado {valorDebitar:C} na conta do titular {titular}.\n Saldo atual: {saldo:C}.");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente.");
        }
    }

    public double creditar(double valorCreditar)
    {
        saldo += valorCreditar;
        Console.WriteLine($"Creditado valor {valorCreditar:C} na conta do titular {titular}.\nSaldo atual: {saldo:C}.");
    }

     public override string ToString()
    {
        return $"Número: {numero}, Titular: {titular}, Saldo: {saldo:C}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Conta outraConta = (Conta)obj;
        return this.numero == outraConta.numero;
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

    public ContaPoupança (int numero, string titular, double saldo, double rendimento)
    :base (int numero, string titular, double saldo)
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

    public ContaCorrente (int numero, string titular, double saldo, double limiteCheque, bool contaEspecial)
    :base (int numero, string titular, double saldo)
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