using System.Text;
using static System.Console;
using ConsumerAdviceslip;
using System.Net.Http.Json;
using System.Text.Json;

WriteLine("Digite 'Sim' para receber um conselho: ");
string resposta = ReadLine();

string url = $"http://api.adviceslip.com/advice";

WriteLine("Carregando conselho...");


try
{
    using var client = new HttpClient();
    var response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();

    var content = await response.Content.ReadAsByteArrayAsync();

    var conselhos = System
                    .Text
                    .Json
                    .JsonSerializer
                    .Deserialize<AdviceResponse>(content);;


    if (resposta == "Sim") 
    {

    WriteLine($"Número do conselho: {conselhos.Slip.Id}");
    WriteLine($"Conselho: {conselhos.Slip.Advice}");

    }
    else
    {
        WriteLine("Sem conselhos por hoje");
    }

}
catch (Exception ex)
{
    WriteLine($"Erro ao gerar conselho: {ex.Message}");
}