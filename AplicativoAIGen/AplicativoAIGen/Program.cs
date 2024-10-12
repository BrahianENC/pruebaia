// See https://aka.ms/new-console-template for more information

//Se implementar las librerias
using Azure.AI.OpenAI;
using Azure;
using OpenAI.Chat;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Abstractions;

string key = "5cd4fa33c357440397c1cb6ca9f28b0a";
string endpoint = "https://brdemoazopia.openai.azure.com/";
string model = "gptpostman";

AzureOpenAIClient azureClient = new(  //OBJETO
    new Uri(endpoint),
    new AzureKeyCredential(key) //Instancias
);

ChatClient chatClient = azureClient.GetChatClient(model); //METODO

//configuraciones de la solicitud de chat

ChatCompletionOptions options = new ChatCompletionOptions()
{
    Temperature = 0,
    MaxTokens = 800
};

List<ChatMessage> messages = [
    new SystemChatMessage("Eres un experto en matemáticas, tu tarea es explicar de manera detallada sobre teoria de conjuntos"),
    new UserChatMessage("Que es un conjunto y cuantos tipos hay?"),

    ];

ChatCompletion completion = chatClient.CompleteChat(messages, options);

Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");

string respuesta = completion.Content[0].Text;

