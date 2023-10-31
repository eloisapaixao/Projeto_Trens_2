using System.IO;

public interface IRegistro<Dado>
{
    void LerRegistro(BinaryReader arquivo, long qualRegistro);
    void GravarRegistro(BinaryWriter arquivo);
    int TamanhoRegistro { get; }
}