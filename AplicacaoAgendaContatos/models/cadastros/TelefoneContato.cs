using Utils.Generator;
using Utils.Marcadores;

namespace Models.Cadastros.Contatos;

public class TelefoneContato {

    private int _idTelefoneContato;
    public int IdTelefoneContato {
        get { return _idTelefoneContato; }
        set { _idTelefoneContato = value; }
    }

    private string? _numero;
    public string? Numero {
        get { return _numero; }
        set { _numero = value; }
    }

    private MarcadorTelefone _marcador;
    public MarcadorTelefone Marcador {
        get { return _marcador; }
        set { _marcador = value; }
    }

    public TelefoneContato() {
        IdTelefoneContato = IdGenerator.GetNextIdTelefone();
    }
}