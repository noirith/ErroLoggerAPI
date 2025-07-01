namespace ErroLoggerAPI.Models;

public class ErroDTO
{
    public string Erro {get;set;}
    public string Trace {get;set;}
    public int Quantidade {get;set;}
    public int ClientesAfetados {get;set;}
    public string Data {get;set;}
}