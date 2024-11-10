using Utils.Generator;
using Utils.Marcadores;

namespace Models.Cadastros.Contatos;

public class EmailContato {

    private int _idEmailContato;
    public int IdEmailContato {
        get { return _idEmailContato; }
        set { _idEmailContato = value; }
    }

    private string? _enderecoEmail;
    public string? EnderecoEmail {
        get { return _enderecoEmail; }
        set { _enderecoEmail = value; }
    }

    private MarcadorEmail _marcador;
    public MarcadorEmail Marcador {
        get { return _marcador; }
        set { _marcador = value; }
    }

    public EmailContato() {
        IdEmailContato = IdGenerator.GetNextIdEmail();
    }
}