namespace ReadingFeedRSS.Services.Interfaces
{
    public interface IRegrasService
    {
        string RemoverElementosHTML(string texto);
        string RemoverPontuacoes(string texto);
    }
}
