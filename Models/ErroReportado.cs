using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ErroLoggerAPI.Models;

public class ErroReportado
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("erro")]
    public string Erro { get; set; }

    [BsonElement("trace")]
    public string Trace { get; set; }

    [BsonElement("quantidade")]
    public int Quantidade { get; set; }

    [BsonElement("clientesAfetados")]
    public int ClientesAfetados { get; set; }

    [BsonElement("data")]
    public DateTime Data { get; set; }
}
