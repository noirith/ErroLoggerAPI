using ErroLoggerAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ErroLoggerAPI.Services;

public class ErroService
{
    private readonly IMongoCollection<ErroReportado> _erros;

    public ErroService(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _erros = database.GetCollection<ErroReportado>(settings.Value.CollectionName);
    }

    public async Task<List<ErroDTO>> ObterErrosPaginadosAsync(int pagina, int tamanhoPagina)
    {
        var erros = await _erros.Find(_ => true)
            .SortByDescending(e => e.Data)
            .Skip((pagina - 1) * tamanhoPagina)
            .Limit(tamanhoPagina)
            .ToListAsync();

        return erros.Select(e => new ErroDTO
        {
            Erro = e.Erro,
            Trace = e.Trace,
            Quantidade = e.Quantidade,
            ClientesAfetados = e.ClientesAfetados,
            Data = e.Data.ToString("dd/MM/yyyy HH:mm:ss")
        }).ToList();
    }



    public async Task SalvarErroAsync(ErroReportado erro)
{
    var filtro = Builders<ErroReportado>.Filter.And(
        Builders<ErroReportado>.Filter.Eq(e => e.Erro, erro.Erro),
        Builders<ErroReportado>.Filter.Eq(e => e.Trace, erro.Trace)
    );

    var atualizacao = Builders<ErroReportado>.Update
        .Inc(e => e.Quantidade, 1)
        .Inc(e => e.ClientesAfetados, erro.ClientesAfetados)
        .Set(e => e.Data, DateTime.Now);

    var resultado = await _erros.UpdateOneAsync(filtro, atualizacao);

    if (resultado.MatchedCount == 0)
    {
        erro.Quantidade = 1;
        erro.Data = DateTime.Now;
        await _erros.InsertOneAsync(erro);
    }
}

}