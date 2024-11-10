//Classe criada no intuito de realizar um auto incremento nos Ids das classes auxiliares

namespace Utils.Generator;

public static class IdGenerator {

    private static int _idTelefone = 0;
    private static int _idEmail = 0;
    private static int _idDataImportante = 0;

    public static int GetNextIdTelefone() {
        return ++_idTelefone;
    }

    public static int GetNextIdEmail() {
        return ++_idEmail;
    }

    public static int GetNextIdDataImportante() {
        return ++_idDataImportante;
    }
}
