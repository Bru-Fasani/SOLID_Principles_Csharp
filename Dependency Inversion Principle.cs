// Abstração (interface)
public interface IProcessadorDePagamento {
    void ProcessarPagamento(decimal valor);
}

// Implementação concreta 1
public class PayPalProcessor : IProcessadorDePagamento {
    public void ProcessarPagamento(decimal valor) {
        Console.WriteLine($"Processando R${valor} via PayPal...");
    }
}

// Implementação concreta 2
public class StripeProcessor : IProcessadorDePagamento {
    public void ProcessarPagamento(decimal valor) {
        Console.WriteLine($"Processando R${valor} via Stripe...");
    }
}

// Classe de alto nível (agora depende da abstração)
public class ServicoDePagamento {
    private readonly IProcessadorDePagamento _processador;

    // Injeção de dependência via construtor
    public ServicoDePagamento(IProcessadorDePagamento processador) {
        _processador = processador;
    }

    public void RealizarPagamento(decimal valor) {
        _processador.ProcessarPagamento(valor);
    }
}

// Uso:
IProcessadorDePagamento processador = new PayPalProcessor(); // ou new StripeProcessor()
var servico = new ServicoDePagamento(processador);
servico.RealizarPagamento(150.00m);
