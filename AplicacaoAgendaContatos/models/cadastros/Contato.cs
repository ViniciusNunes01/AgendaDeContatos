namespace Models.Cadastros.Contatos;

public class Contato {

    private int _idContato;
    private string? _nome;
    private string? _sobrenome;
    private string? _empresa;
    private List<TelefoneContato> _telefones;
    private List<EmailContato> _emails;
    private List<DataImportanteContato> _datasImportantes;

    public int IdContato {

        get { return _idContato; }
        set { _idContato = value; }
    }

    public string? Nome {
        
        get { return _nome; }
        set {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.");
            _nome = value;
        }
    }

    public string? Sobrenome {

        get { return _sobrenome; }
        set { _sobrenome = value; }
    }

    public string? Empresa {

        get { return _empresa; }
        set { _empresa = value; }
    }

    public List<TelefoneContato> Telefones {

        get { return _telefones; }
        set { _telefones = value; }
    }

    public List<EmailContato> Emails {

        get { return _emails; }
        set { _emails = value; }
    }

    public List<DataImportanteContato> DatasImportantes {

        get { return _datasImportantes; }
        set { _datasImportantes = value; }
    }

    public Contato() {

        Telefones = new List<TelefoneContato>();
        Emails = new List<EmailContato>();
        DatasImportantes = new List<DataImportanteContato>();
    }

    public void AdicionarTelefone(TelefoneContato telefone) {

        Telefones.Add(telefone);
    }

    public void AdicionarEmail(EmailContato email) {

        Emails.Add(email);
    }

    public void AdicionarDataImportante(DataImportanteContato dataImportante) {

        DatasImportantes.Add(dataImportante);
    }

    public void RemoverTelefone(TelefoneContato telefone) {

        Telefones.Remove(telefone);
    }

    public void RemoverEmail(EmailContato email) {

        Emails.Remove(email);
    }

    public void RemoverDataImportante(DataImportanteContato dataImportante) {

        DatasImportantes.Remove(dataImportante);
    }

    public void EditarTelefone(TelefoneContato telefone) {

        var item = Telefones.Find(t => t.IdTelefoneContato == telefone.IdTelefoneContato);
    
        if (item != null) {

            item.Numero = telefone.Numero;
            item.Marcador = telefone.Marcador;
        }
    }

    public void EditarEmail(EmailContato email) {

        var item = Emails.Find(e => e.IdEmailContato == email.IdEmailContato);

        if (item != null) {

            item.EnderecoEmail = email.EnderecoEmail;
            item.Marcador = email.Marcador;
        }
    }

    public void EditarDataImportante(DataImportanteContato dataImportante) {

        var item = DatasImportantes.Find(d => d.IdDataImportanteContato == dataImportante.IdDataImportanteContato);

        if (item != null) {
            item.Data = dataImportante.Data;
            item.Marcador = dataImportante.Marcador;
        }
    }
}