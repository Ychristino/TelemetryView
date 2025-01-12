using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelemetryViewer;
using TelemetryViewer.Server;

if (args.Contains("--how")){
    help();
}
else{
    var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {   
            if ( args.Contains("--tcp"))
            {
                services.AddSingleton<IServer, TCPServer>();
            }
            else
            {
                services.AddSingleton<IServer, UDPServer>();
            }

            services.AddHostedService<Worker>();
        })
        .Build();

    await host.RunAsync();
}


void help(){

    Console.WriteLine(""" 
    SERVIDOR SERÁ INICIALIZAOD A PARTIR DO IP 127.0.0.1:13000
    POR PADRÃO, O SERVIDOR SERÁ INICIALIZADO COM PROTOCOLO UDP.

    UTILIZE O ARGUMENTO --TCP PARA UTILIZAR O PROTOCOLO TCP.
    
    EXEMPLO DE USO:
        dotnet run --tcp
    
    Irá inicializar a execução pelo protocolo TCP.
    Após a conexão com o client, será possível enviar mensagens, sendo estas apresentadas no console de execução da aplicação.

    Para execução padrão, pelo protocolo UDP, basta utilizar o seguinte formato.

    EXEMPLO DE USO:
        dotnet run

    A execução será incializada e a troca de mensagens pode acontecer normalmente, sendo a mensagem recebida logada no console de execução.

    Para ambos os casos a mensagem deve ser demonstrada e um retorno será enviado ao usuário com a mensagem: 'ack', com fim de atestar o recebimento.

    Todas as mensagens enviadas ao servidor devem conter o encerrametno '\n'.
    A utilização da notação '\n' indica o final da mensagem.
    """);
}
