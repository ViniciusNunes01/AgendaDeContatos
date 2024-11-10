using Utils.Generator;
using Utils.Marcadores;

namespace Models.Cadastros.Contatos;

public class DataImportanteContato {

    private int _idDataImportanteContato;
    public int IdDataImportanteContato {
        get { return _idDataImportanteContato; }
        set { _idDataImportanteContato = value; }
    }

    private DateTime _data;
    public DateTime Data {
        get { return _data; }
        set { _data = value; }
    }

    private MarcadorDataImportante _marcador;
    public MarcadorDataImportante Marcador {
        get { return _marcador; }
        set { _marcador = value; }
    }

    public DataImportanteContato() {
        IdDataImportanteContato = IdGenerator.GetNextIdDataImportante();
    }
}